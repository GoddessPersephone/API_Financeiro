using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Controllers.Token
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Ctreate(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));   
            
        }
    }
}