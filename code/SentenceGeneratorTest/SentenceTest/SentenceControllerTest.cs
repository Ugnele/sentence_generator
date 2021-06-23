using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RichardSzalay.MockHttp;
using Sentence.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SentenceGeneratorTest.SentenceTest
{
    public class SentenceControllerTest
    {
        private SentenceController controller;
        private readonly IConfiguration configuration;

        public SentenceControllerTest()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
        }

        [Fact]
        public async void IsSentenceBuiltAsync()
        {
            var httpMock = new MockHttpMessageHandler();
            httpMock.When($"{configuration["lengthServiceURL"]}")
                .Respond("text/plain", "5");
            string wordsResponse = "{ \"adjectives\": [ \"chyliferous\" ], \"adverbs\": [ \"here\" ], " +
                "\"nouns\": [ \"Arctictis\", \"tuff\" ], \"verbs\": [ \"slate\" ] }";
            httpMock.When($"{configuration["wordsServiceURL"]}")
                .Respond("text/plain", wordsResponse);

            var client = new HttpClient(httpMock);
            controller = new SentenceController(configuration, client);//

            var response = await controller.GetSentence();
            string sentence = ((OkObjectResult)response).Value.ToString();

            Assert.Equal("SLATE HERE CHYLIFEROUS ARCTICTIS  AND TUFF", sentence.ToUpper());
        }
    }
}
