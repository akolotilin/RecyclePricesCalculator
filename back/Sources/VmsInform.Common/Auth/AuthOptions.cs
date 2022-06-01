using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace VmsInform.Common.Auth
{
    public class AuthOptions
    {
        public const string TokenIssuer = "VmsInform.API";
        public const string Audience = "VmsInform.WebClient";

        const string KEY = "Rs401SчO_c?t^щgП$rrBв9TGф!0в266f~Nn3";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
