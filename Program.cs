using System;
using System.Net.Http;
using dotnet_crawler.services;

namespace dotnet_crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "";
            string url = "http://applicant-test.us-east-1.elasticbeanstalk.com/";
            HttpClient httpClient = new HttpClient() {  BaseAddress = new Uri(url) };

            RequestService requestService = new RequestService(httpClient, url);
            token = requestService.GetTokenFromSite();
            string decodeToken = Function.getDecodedToken(token);

            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Decoded-Token: {decodeToken}");

            string answer = requestService.SubmitAndGetAnswerFromSite(decodeToken);
            
            Console.WriteLine($"Resultado: {answer}");
            Console.WriteLine("");
            Console.WriteLine($"Digite qualquer tecla para sair...");
            Console.ReadLine();
        }
    }
}
