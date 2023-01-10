using AutoMapper;
using System.Collections.Generic;

namespace VmsInform.Business.TypeMapping.Profiles.Converters
{
    internal sealed class StringToStringListConverter : IValueConverter<string, IEnumerable<string>>
    {
        public IEnumerable<string> Convert(string sourceMember, ResolutionContext context)
        {
            return sourceMember.Split(',');
        }
    }
}
