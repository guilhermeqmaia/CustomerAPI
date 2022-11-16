using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utilities
{
    public class StringExtensions
    {
        public StringExtensions() {}
        public static string formatCpf(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }
        public static string formatPostalCode(string postalCode)
        {
            //Todo: format postal code
            throw new NotImplementedException();
        }

        public static string formatCellphone(string cellphone)
        {
            //Todo: format cellphone
            throw new NotImplementedException();
        }
    }
}
