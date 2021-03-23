using Core.Utilities.Abstract.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        // Run içerisine istediğimiz kadar IResult verebiliyoruz parametre olarak
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;   // Hatalı logic geri döndürüyor. Oda logiğin içindeki error çalıştırır
                }
            }
            return null;
        }
    }
}
