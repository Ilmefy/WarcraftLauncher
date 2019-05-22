using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.src.Core
{
    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

    }
    public static class StringExtension
    {
        public static bool ContainsWithComparer(this String value, string phrase)
        {
            string valueLowerCase = value.ToLower();
            string phraseLowerCase = phrase.ToLower();
            if (valueLowerCase.Contains(phraseLowerCase))
                return true;
            return false;
        }
    }
}
