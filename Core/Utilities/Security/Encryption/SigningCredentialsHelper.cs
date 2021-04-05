using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        // JWT oluşturulabilmesi için, Credential => sizin bir sisteme girebilmeniz için elinizde olanlardır.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //
            // Aynı password hash'leme gibi sistemde bunu yapıyor. JWT için olanı. 
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
