using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using System.IO;

namespace QA_Scanner
{
    public static class Subjects
    {
        private const string FirstDocx = "ecology_1_2018.docx";
        private const string SecondDocx = "ecology_2_2018.docx";
        public const string NotFoundedQuestion = "Question was not found";      

        public static string FindResponseEcology(string Question, string FirstDocxName = FirstDocx, string SecondDocxName = SecondDocx)
        {
            bool MatchQuestion_in_FirstDocx = false;
            bool MatchQuestion_in_SecondDocx = false;
            Question = Question.ParseQA();       

            try
            {
                using (DocX document1 = DocX.Load(FirstDocx))
                {
                    foreach (var p in document1.Paragraphs)
                    {
                        string ParagraphText = p.Text;
                        ParagraphText = ParagraphText.ParseQA();                       

                        if (ParagraphText.Contains(Question))
                        {
                            MatchQuestion_in_FirstDocx = true;
                            continue;
                        }

                        if (MatchQuestion_in_FirstDocx)
                        {
                            return p.Text;
                        }
                    }

                    if (!MatchQuestion_in_FirstDocx)
                    {
                        using (DocX document2 = DocX.Load(SecondDocx))
                        {
                            foreach (var p in document2.Paragraphs)
                            {
                                string ParagraphText = p.Text;
                                ParagraphText = ParagraphText.ParseQA();                              

                                if (ParagraphText.Contains(Question))
                                {
                                    MatchQuestion_in_SecondDocx = true;
                                    continue;
                                }

                                if (MatchQuestion_in_SecondDocx)
                                {
                                    return p.Text;
                                }
                            }
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NotFoundedQuestion;           
        }

        public static string FindResponseEnglish(string Question, string DocxName = "english_2018.docx")
        {           
            Question = Question.ParseQA();            

            try
            {
                using (DocX document = DocX.Load(DocxName))
                {                 
                    foreach(var row in document.Tables[0].Rows)
                    {
                        string CellText = row.Cells[1].Paragraphs[0].Text;

                        if(row.Cells[1].Paragraphs.Count > 1)
                        {
                            string Temp = String.Empty;
                            for (int i=0; i< row.Cells[1].Paragraphs.Count; i++)
                            {
                                Temp += row.Cells[1].Paragraphs[i].Text;
                            }
                            CellText = Temp;
                        }

                        CellText = CellText.ParseQA();

                        if (CellText.Contains(Question))
                        {                           
                            return row.Cells[2].Paragraphs[0].Text; //founded answer!
                        }                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NotFoundedQuestion;
        }

        public static string FindResponsePhysics(string Question, string DocxName = "PhysicsQA_2018.txt")
        {
            Question = Question.ParseQA();
            string[] buffer = File.ReadAllLines(DocxName);

            try
            {
                foreach(var line in buffer)
                {
                    string question_line = line;
                    question_line = question_line.ParseQA();
                    if (question_line.Contains(Question))
                    {
                        string asnwer_line = line.Remove(0, line.IndexOf("Правильный ответ:"));
                        return asnwer_line;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NotFoundedQuestion;
        }
    }

    public static class StringHelper
    {
        private static string[] ExtraChars = { " ", ",", ".", "!", "?", Environment.NewLine, "_", "-" };

        public static string RemoverStrs(this string str, string[] removeStrs)
        {
            foreach (var removeStr in removeStrs)
            {
                str = str.Replace(removeStr, "");
            }            
            return str;
        }

        public static string ParseQA(this string QuestionOrAnswerString)
        {
            QuestionOrAnswerString = QuestionOrAnswerString.RemoverStrs(ExtraChars);
            QuestionOrAnswerString = QuestionOrAnswerString.ToLower();
            QuestionOrAnswerString = QuestionOrAnswerString.Trim();

            return QuestionOrAnswerString;
        }
    }
}
