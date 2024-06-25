using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Business.Commands.Prices.UpdateBasePriceFromOffer;
using VmsInform.Business.Commands.Prices.UpdateBasePriceFromOfferById;
using VmsInform.Business.Commands.Prices.UpdateBasePriceManual;
using VmsInform.Business.Commands.Prices.UpdatePriceOrder;
using VmsInform.Business.Commands.Prices.UpdateSurcharge;
using VmsInform.Business.Queries.Prices.CalcPrice;
using VmsInform.Business.Queries.Prices.GetCurrencyCource;
using VmsInform.Business.Queries.Prices.GetPriceList;
using VmsInform.Business.Queries.Prices.GetPriceOffers;
using VmsInform.Business.Queries.Prices.GetPrices;
using VmsInform.Business.Queries.Prices.GetPriceType;
using VmsInform.Web.Dto.Partners.Prices;
using VmsInform.Web.Dto.Prices;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : BaseApiController
    {
        private readonly IMediator _mediator;
        
        public PricesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public Task<GetPricesResultDto> Get() => _mediator.Send(new GetPricesQuery());

        [HttpGet("calcPrice")]
        public Task<PriceDto> CalcPrice([FromQuery] CalcPriceQuery query) => _mediator.Send(query);

        [HttpPut("update")]
        public Task<PriceItemData> Update([FromBody] UpdateSurchargeCommand command) => _mediator.Send(command);

        [HttpGet("priceOffers/{GoodId}")]
        public Task<GoodPriceOffersResultDto> GetPriceOffers([FromRoute] GetPriceOffersQuery query) => _mediator.Send(query);

        [HttpPut("{goodId}/updateBasePriceFromOffer")]
        public async Task<PricesEditGoodDto> UpdateBasePrice([FromRoute] long goodId, [FromBody] PartnerPriceOfferDto offer)
        {
            return await _mediator.Send(new UpdateBasePriceFromOfferCommand { GoodId = goodId, Offer = offer });
        }

        [HttpPut("updateBasePriceFromOfferById")]
        public async Task UpdateBasePriceFromOfferById([FromBody] UpdateBasePriceFromOfferByIdCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
        }

        [HttpPut("updateBasePriceManual")]
        public async Task<PricesEditGoodDto> UpdateBasePriceManual([FromBody] UpdateBasePriceManualCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("updateGoodOrder")]
        public async Task UpdateGoodOrder([FromBody] UpdatePriceOrderCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet("currencyCource")]
        public async Task<decimal> GetCurrencyCource([FromQuery] GetCurrencyCourceQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> BuildPrice([FromQuery] GetPriceListQuery query, CancellationToken cancellationToken)
        {
            var report = await BuildPriceReport(await _mediator.Send(query), query.PriceId, cancellationToken);

            var webReport = new WebReport();
            webReport.Width = "100%";
            webReport.Report = report;
            ViewBag.ReportId = "fr" + webReport.ID;
            ViewBag.priceId = query.PriceId;
            return View(webReport);
        }

        //http://localhost:5080/api/Prices/BuildPrice?PriceId=1

        [HttpGet("[action]")]
        public async Task<IActionResult> BuildPricePdf([FromQuery] GetPriceListQuery query, CancellationToken cancellationToken)
        {
  

            var report = await BuildPriceReport(await _mediator.Send(query,  cancellationToken), query.PriceId, cancellationToken);
            
            var export = new PDFSimpleExport();
            using (var ms = new MemoryStream())
            {
                export.Export(report, ms);
                ms.Flush();
                return File(ms.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("Прайс") + ".pdf");
            }

        }

        private async Task<Report> BuildPriceReport(IEnumerable<PriceListItemDto> data, long priceId, CancellationToken cancellationToken)
        {
            var priceType = await _mediator.Send(new GetPriceTypeQuery { PriceTypeId = priceId }, cancellationToken);

            var resourceStream = GetType().Assembly.GetManifestResourceStream("VmsInformWeb.Reports.Price.frx");

            var report = new Report();
            report.Load(resourceStream);
            report.RegisterData(data, "Price");
            report.SetParameterValue("PriceType", priceType.Name);
            report.Prepare();

            return report;
        }
    }
}
