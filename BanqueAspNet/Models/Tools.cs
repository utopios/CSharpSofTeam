using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BanqueWeb.Models
{
    public class Tools
    {
        public static bool IsName(string name)
        {
            string pattern = @"^[a-zA-Z\s-]+$";
            return Regex.IsMatch(name, pattern);
        }

        public static bool IsPhone(string phone)
        {
            string pattern = @"^0([1-9]{1})(\.|\s|-)?((\d){2}(\.|\s|-)?){3}(\d{2})$";
            return Regex.IsMatch(phone, pattern);
        }
    }
}
