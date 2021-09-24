using System;

namespace Sat.Recruitment.Api.Extensions
{
    public static class EmailModelExtensions
    {
        public static string ToGetEmail(this string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return email = string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
