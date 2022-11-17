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
            postalCode = postalCode.Trim().Replace("-", "");
            return postalCode;
        }

        public static string formatCellphone(string cellphone)
        {
            cellphone = cellphone.Trim().Replace("-", "").Replace("(", "").Replace(")", "");
            return cellphone;
        }
    }
}
