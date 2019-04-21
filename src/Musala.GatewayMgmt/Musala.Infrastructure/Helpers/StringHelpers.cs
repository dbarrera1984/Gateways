using System.Text.RegularExpressions;

namespace Musala.Infrastructure.Helpers
{
    public static class StringHelpers
    {
        public static string CamelCaseToFriendlyName(string camelCase)
        {
            return Regex.Replace(camelCase, "(\\B[A-Z])", " $1");
        }
    }
}
