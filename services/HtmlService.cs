using System.Text.RegularExpressions;

namespace dotnet_crawler.services
{
    public class HtmlService
    {
        public static string GetToken(string html)
        {
            return Regex.Match(html, @"id=""token""\s*value=""(.*)""").Groups[1].ToString();
        }

        public static string GetAnswer(string html)
        {
            string resultado = Regex.Match(html, @"<span id=""answer"">(\d*)</span>").Groups[1].ToString();
            if(string.IsNullOrEmpty(resultado))
                resultado = html;
            return resultado;
        }
    }
}