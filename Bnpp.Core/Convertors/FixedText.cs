using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Convertors
{
    public class FixedText
    {
        public static string FixedEmail(string Email)
        {
            return Email.Trim().ToLower();
        }
        public static string SkipLetter(string Name)
        {
            return Name.Trim().ToLower();
        }
    }
}
