using System;

namespace DMP.Enrichers
{
    public static class DomainParser
    {
        public static string DomainParseFromURL(string Url)
        {
            if (Url.Contains(@"://"))
                Url = Url.Split(new string[] { "://" }, 2, StringSplitOptions.None)[1];

            return Url.Split('/')[0];
        }
    }
}