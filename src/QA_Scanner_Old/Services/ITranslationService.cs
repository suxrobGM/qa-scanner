using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Scanner.Services
{
    public enum Language
    {
        en,
        ru
    };

    public interface ITranslationService
    {
        Task<string> TransalteTextAsync(string text, Language sourceLanguage = Language.en, Language translatingLanguage = Language.ru);
    }
}
