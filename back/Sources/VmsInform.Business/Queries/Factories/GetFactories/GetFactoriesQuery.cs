using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VmsInform.Web.Dto.Factories;

namespace VmsInform.Business.Queries.Factories.GetFactories
{
    public class GetFactoriesQuery : IRequest<IEnumerable<FactoryDto>>
    {
    }
}
