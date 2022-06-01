using Microsoft.AspNetCore.Mvc;
using VmsInform.Web.Dto.Clients;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    public class BuyersController : BaseApiController
    {
        [HttpGet("{clientId}/prices")]
        public ClientPricesDataDto GetPrices(long clientId)
        {
            return new ClientPricesDataDto
            {
                ClientName = "Иванов Иван Иваныч",
                Groups = new[] 
                {
                    new PricesGoodGroupDto
                    {
                        Name= "Алюминиевая группа",
                        Prices = new[] {
                            new ClientPriceDto
                            {
                                GoodId = 1,
                                GoodName = "Алюминий хлам",
                                Price = 123
                            },
                            new ClientPriceDto
                            {
                                GoodId = 2,
                                GoodName = "Алюминий пищевой",
                                Price = 123
                            },
                            new ClientPriceDto
                            {
                                GoodId = 3,
                                GoodName = "Алюминий баночка",
                                Price = 123
                            }
                        }
                    },
                    new PricesGoodGroupDto
                    {
                        Name = "Медно-латунная группа",
                         Prices = new[]
                         {
                             new ClientPriceDto
                             {
                                 GoodId = 4,
                                 GoodName = "Медь мих",
                                 Price = 234,
                             },
                             new ClientPriceDto
                             {
                                 GoodId = 5,
                                 GoodName = "Медь шина",
                                 Price = 236,
                             },
                             new ClientPriceDto
                             {
                                 GoodId = 5,
                                 GoodName = "Медь А",
                                 Price = 234,
                             }
                         }
                    }
                }
            };
        }
    }
}
