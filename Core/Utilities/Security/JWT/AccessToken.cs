using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //
    // Erişbeilmemiz için paketin içerisinde token gider. Bu AccessToken'dır
    public class AccessToken
    {
        //
        // Kullanıcı kullanıcı adı ve parolası ile giriş yaptıkran sonra, token verilir bo o token'dır
        public string Token { get; set; }

        //
        // Token Geçerlilik süresi
        public DateTime Expiration { get; set; }
    }
}
