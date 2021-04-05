using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //
        //Api içerisndeki appsetting.json içerisinde oluşturduğumuz securityKey değeri ver, bize securityKey karşılığını verir. MICROSOFT.IDENTITYMODEL.TOKENS manage nuget. 
        // ÖZET:
        // Bizim appsettings.json içerisinde verdiğimiz securityKey'i byte array dönüştürüyorve simetrik anahtar haline getiriyor. Zorunlu
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
