using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xceed.Words.NET;

namespace QA_Scanner.Models
{   
    public class Subject
    {               
        private readonly string _docFile;
        private readonly DocX _docx;

        public const string questionNotFound = "Question was not found";
        public const string answerNotFound = "The answer of this question was not found";

        public Subject(string docFile)
        {
            _docFile = "Documents\\" + docFile;
            _docx = DocX.Load(_docFile);
        }

        public string ResponseManualTableMethod(string question)
        {
            question = question.ParseQA();

            foreach (var row in _docx.Tables[0].Rows)
            {
                string questionLine = row.Cells[1].Paragraphs[0].Text.ParseQA();

                if (questionLine.Contains(question))
                {
                    return row.Cells[2].Paragraphs[0].Text;
                }
            }

            return questionNotFound;
        }        

        public string ResponseEnglish(string question)
        {
            question = question.ParseQA();
            question = question.RemoveStartingDigits();

            int i = 0;
            foreach (var p in _docx.Paragraphs)
            {
                string questionLine = p.Text.ParseQA();
                questionLine = questionLine.RemoveStartingDigits();               

                if (questionLine.Contains(question) && i < _docx.Paragraphs.Count)
                {
                    i++;
                    while (!_docx.Paragraphs[i].Text.IsStartingWithDigits())
                    {
                        var answers = _docx.Paragraphs[i].MagicText
                            .Where(x =>
                            {
                                if (x.formatting != null && x.formatting.Bold.HasValue)
                                    return x.formatting.Bold.Value;
                                else
                                    return false;
                            })
                            .Select(x => x.text);

                        if (answers.Any())                       
                            return answers.Aggregate((item1, item2) => item1 + item2);                      

                        i++;
                    }                    

                    return answerNotFound;
                }

                i++;
            }

            return questionNotFound;
        }        

        public string ResponseDataStructure(string question)
        {
            question = question.ParseQA();

            foreach (var row in _docx.Tables[0].Rows)
            {
                string CellText = row.Cells[1].Paragraphs[0].Text;

                if (row.Cells[1].Paragraphs.Count > 1)
                {
                    string Temp = String.Empty;
                    for (int i = 0; i < row.Cells[1].Paragraphs.Count; i++)
                    {
                        Temp += row.Cells[1].Paragraphs[i].Text;
                    }
                    CellText = Temp;
                }

                CellText = CellText.ParseQA();

                if (CellText.Contains(question))
                {
                    return row.Cells[2].Paragraphs[0].Text; //founded answer!
                }
            }

            return questionNotFound;
        }

        public string ResponseComputerNetwork(string question)
        {
            question = question.ParseQA();
            question = question.RemoveStartingDigits();

            foreach (var row in _docx.Tables[0].Rows)
            {
                string questionLine = row.Cells[1].Paragraphs[0].Text.ParseQA();
                questionLine = questionLine.RemoveStartingDigits();

                if (questionLine.Contains(question))
                {

                    return row.Cells[2].Paragraphs[0].Text;
                }
            }

            return questionNotFound;
        }

        public string ResponseDigital(string question)
        {
            question = question.ParseQA();
            question = question.RemoveStartingDigits();

            int i = 0;
            foreach (var p in _docx.Paragraphs)
            {
                string questionLine = p.Text.ParseQA();
                questionLine = questionLine.RemoveStartingDigits();

                if (questionLine.Contains(question) && (i + 5) < _docx.Paragraphs.Count)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        var answers = _docx.Paragraphs[i + j].MagicText.Where(x => x.formatting.UnderlineStyle == UnderlineStyle.singleLine).Select(x => x.text);
                        if (answers.Any())
                        {
                            return answers.First();
                        }
                    }

                    return answerNotFound;
                }

                i++;
            }

            return questionNotFound;
        }       

        public string ResponsePhilosophy(string question)
        {
            question = question.ParseQA();
            question = question.RemoveStartingDigits();

            int i = 0;
            foreach (var p in _docx.Paragraphs)
            {
                string questionLine = p.Text.ParseQA();
                questionLine = questionLine.RemoveStartingDigits();
                
                if (questionLine.Contains(question) && (i + 5) < _docx.Paragraphs.Count)
                {
                    for (int j = 1; j < 5; j++)
                    {                       
                        var answers = _docx.Paragraphs[i + j].MagicText
                            .Where(x => 
                            {
                                if (x.formatting != null && x.formatting.Bold.HasValue)
                                    return x.formatting.Bold.Value;
                                else
                                    return false;
                            })
                            .Select(x => x.text);

                        if (answers.Any())
                        {
                            return answers.First().Substring(2).Trim();
                        }
                    }

                    return answerNotFound;
                }

                i++;
            }

            return questionNotFound;
        }

        public string ResponseCppProgramming(string question)
        {
            question = question.ParseQA();
            question = question.RemoveStartingDigits();

            int i = 0;
            foreach (var p in _docx.Paragraphs)
            {
                string questionLine = p.Text.ParseQA();
                questionLine = questionLine.RemoveStartingDigits();

                if (questionLine.Contains(question) && i < _docx.Paragraphs.Count)
                {
                    i++;
                    while (!_docx.Paragraphs[i].Text.IsStartingWithDigits() || !_docx.Paragraphs[i].Text.StartsWith("::"))
                    {
                        var answers = _docx.Paragraphs[i].MagicText
                            .Where(x =>
                            {
                                if (x.text.StartsWith("{=") || x.text.StartsWith("="))
                                    return true;
                                else if (x.formatting != null && x.formatting.Bold.HasValue)
                                    return x.formatting.Bold.Value;
                                else
                                    return false;
                            })
                            .Select(x => x.text);

                        if (answers.Any())
                            return answers.Aggregate((item1, item2) => item1 + item2);

                        i++;
                    }

                    return answerNotFound;
                }

                i++;
            }

            return questionNotFound;
        }
    }
}
