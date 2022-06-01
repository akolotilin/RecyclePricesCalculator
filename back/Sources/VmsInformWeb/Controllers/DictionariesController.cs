using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VmsInform.Business.Queries.Partners.GetBuyers;
using VmsInform.Common.Queries.Common.GetDictionary;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Common;
using VmsInform.Web.Dto.Partners;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public DictionariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("currencies")]
        public async Task<IEnumerable<NamedObjectDto>> GetCurrencies()
        {
            return await GetDictionary<Currency>();
        }

        [HttpGet("buyers")]
        public async Task<IEnumerable<NamedObjectDto>> GetBuyers()
        {
            return await _mediator.Send(new GetBuyersQuery());
        }

        [HttpGet("contactTypes")]
        public IEnumerable<ContactTypeDto> GetContactTypes()
        {
            return Enum.GetNames(typeof(ContactType))
                .Select(a => new ContactTypeDto { Key = a, DisplayName = GetContactTypeName(a) })
                .ToList();
        }

        private string GetContactTypeName(string contactType)
        {
            switch(contactType)
            {
                case nameof(ContactType.CellPhone):
                    return "Моб. телефон";
                case nameof(ContactType.WorkPhone):
                    return "Рабочий телефон";
                case nameof(ContactType.Email):
                    return "E-Mail";
                default:
                    return contactType;
            }
        }


        private async Task<IEnumerable<NamedObjectDto>> GetDictionary<TDictionary>()
            where TDictionary: NamedObject
        {
            return await _mediator.Send(new GetDictionaryQuery<TDictionary>());
        }       

    }
}