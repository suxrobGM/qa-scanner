using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace QA_Scanner.Services
{
    public class TranslationService : ITranslationService
    {
        private HttpClient _client;
        private HtmlDocument _doc;

        public TranslationService()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://translate.google.com")
            };
            _doc = new HtmlDocument();
        }

        public async Task<string> TransalteTextAsync(string text, Language sourceLanguage = Language.en, Language translatingLanguage = Language.ru)
        {
            var response = await _client.GetAsync($"#view=home&op=translate&sl={sourceLanguage}&tl={translatingLanguage}&text={text}");

            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();
                _doc.LoadHtml(htmlContent);
                //_doc.DocumentNode.Element.
            }

            return text;
        }
    }
}
