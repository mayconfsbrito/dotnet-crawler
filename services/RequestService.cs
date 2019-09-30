using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_crawler.services
{
    public class RequestService
    {
        private HttpClient _client;

        private string _url;

        public RequestService(HttpClient client, string url)
        {
            _client = client;
            _url = url;

            InitHttpRequestMessages(_client);
        }

        public string GetTokenFromSite()
        {
            var response = MakeGetRequest().Result;
            return HtmlService.GetToken(response);
        }

        public string SubmitAndGetAnswerFromSite(string decodeToken)
        {
            var postResponse = MakePostRequest(decodeToken).Result;
            return HtmlService.GetAnswer(postResponse);
        }

        private async Task<string> MakeGetRequest()
        {
            var response = await _client.GetAsync(_url);
            return await response.Content.ReadAsStringAsync();
        }

        private  async Task<string> MakePostRequest(string decodeToken)
        {
            Thread.Sleep(2360);
             var httpContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("token", decodeToken),
            });
            return await _client.PostAsync(_url, httpContent).Result.Content.ReadAsStringAsync();
        }

        private void InitHttpRequestMessages(HttpClient _client)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            // HttpClient client = new HttpClient(handler) { BaseAddress = new Uri(_url) };

            _client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            _client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9,pt-BR;q=0.8,pt;q=0.7");
            _client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            _client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _client.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded");
            _client.DefaultRequestHeaders.Add("Host", "applicant-test.us-east-1.elasticbeanstalk.com");
            _client.DefaultRequestHeaders.Add("Origin", "http://applicant-test.us-east-1.elasticbeanstalk.com");
            _client.DefaultRequestHeaders.Add("Pragma", "no-cache");
            _client.DefaultRequestHeaders.Add("Referer", "http://applicant-test.us-east-1.elasticbeanstalk.com/");
            _client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.75 Safari/537.36");
        }
    }
}