using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.Helpers.InputCheck;

public class ContactCheck
{
    public static bool CheckName(string name)
    {
        var result = new Regex(@"^\b([A-ZÀ-ÿ][-,a-z. ']+[ ]*)+$");
        Match match = result.Match(name);
        return match.Success;
    }
    public static bool CheckNumber(string phoneNumber)
    {
        var result = new Regex(@"^(\+?994|0)(77|51|50|55|70|40|60|12)(\-|)(\d){3}(\-|)(\d){2}(\-|)(\d){2}$");
        Match match = result.Match(phoneNumber);
        return match.Success;
    }
    public static bool CheckEmail(string email)
    {
        var result = new Regex(@"^([a-zA-Z]+[a-zA-z.!#$%&'*+-=?^`{|}~]{0,64})+[@]+[a-zA-z-]+[.]+[a-zA-z]+$");
        Match m = result.Match(email);
        return m.Success;
    }
   
}

