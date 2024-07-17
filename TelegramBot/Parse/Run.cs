using HtmlAgilityPack;
using System;
using TelegramParse.Interfaces;

namespace TelegramParse.Parse
{
    public class Run
    {
        private readonly HttpClient _client;
        private readonly HtmlWeb _htmlWeb;
        private readonly IConfiguration _config;
        private readonly IMessage _message;

        public Run(HttpClient httpClient, HtmlWeb htmlWeb,IConfiguration configuration, IMessage message) 
        {
            _client = httpClient;
            _htmlWeb = htmlWeb;
            _config = configuration;
            _message = message;

        }

        public async Task RunParse()
        {
            string url = _config["UrlWork"] + Uri.EscapeDataString("jobs-c#+developer");
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string html = await response.Content.ReadAsStringAsync();
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                var jobTitles = document.DocumentNode.SelectSingleNode("//div[@id='pjax-jobs-list']");
                var jobList = jobTitles.SelectNodes("./div[@tabindex]");
                foreach (var job in jobList)
                {
                    var jobName = job.SelectSingleNode(".//h2[@class='my-0']").InnerText;
                    var location = job.SelectSingleNode(".//span[@class='']").InnerText;
                    var company = job.SelectSingleNode(".//span[@class='strong-600']").InnerText;
                    var text = job.SelectSingleNode(".//p[@class='ellipsis ellipsis-line ellipsis-line-3 text-default-7 mb-0']").InnerText.Trim();
                    await _message.Send($"{jobName}\n {location} {company}\n {text}",236322076L);
                }

            }
        }
    }
}
