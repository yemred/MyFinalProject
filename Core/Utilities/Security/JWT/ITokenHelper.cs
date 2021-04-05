using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        // Kullanıcı Adı ve Parolası girdi. Eğer doğru ise bu method( CreateToken Methodu) çalışacak. Veritabanına gidip claimleri bulup JWT oluşturacak
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
