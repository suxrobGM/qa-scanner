using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xceed.Words.NET;

namespace QA_Scanner.Models
{
    public static class Subject
    {        
        private const string questionNotFound = "Question was not found";
        private const string answerNotFound = "The answer of this question was not found";


        public static string ResponseManualTableMethod(string question, string docFile = "Documents\\ManualTableMethod.docx")
        {
            question = question.ParseQA();

            using (var docx = DocX.Load(docFile))
            {
                foreach (var row in docx.Tables[0].Rows)
                {
                    string questionLine = row.Cells[1].Paragraphs[0].Text.ParseQA();

                    if (questionLine.Contains(question))
                    {
                        return row.Cells[2].Paragraphs[0].Text;
                    }
                }
            }

            return questionNotFound;
        }

        public static string ResponseEcology(string question, string firstDocFile = "Documents\\Ecology_1_2018.docx", string secondDocFile = "Documents\\Ecology_2_2018.docx")
        {
            bool MatchQuestion_in_FirstDocx = false;
            bool MatchQuestion_in_SecondDocx = false;
            question = question.ParseQA();       

            try
            {
                using (DocX document1 = DocX.Load(firstDocFile))
                {
                    foreach (var p in document1.Paragraphs)
                    {
                        string ParagraphText = p.Text;
                        ParagraphText = ParagraphText.ParseQA();                       

                        if (ParagraphText.Contains(question))
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
                        using (DocX document2 = DocX.Load(secondDocFile))
                        {
                            foreach (var p in document2.Paragraphs)
                            {
                                string ParagraphText = p.Text;
                                ParagraphText = ParagraphText.ParseQA();                              

                                if (ParagraphText.Contains(question))
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

            return questionNotFound;           
        }

        public static string ResponseEnglish(string question, string docFile = "Documents\\English_2018.docx")
        {           
            question = question.ParseQA();            

            try
            {
                using (DocX document = DocX.Load(docFile))
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

                        if (CellText.Contains(question))
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
            return questionNotFound;
        }

        public static string ResponsePhysics(string question, string docFile = "Documents\\PhysicsQA_2018.txt")
        {
            question = question.ParseQA();
            string[] buffer = File.ReadAllLines(docFile);

            try
            {
                foreach(var line in buffer)
                {
                    string question_line = line;
                    question_line = question_line.ParseQA();
                    if (question_line.Contains(question))
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
            return questionNotFound;
        }

        public static string ResponseStructure(string question, string docFile = "Documents\\DataStructure_2018.docx")
        {
            question = question.ParseQA();

            try
            {
                using (DocX document = DocX.Load(docFile))
                {
                    foreach (var row in document.Tables[0].Rows)
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

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return questionNotFound;
        }

        public static string ResponseComputerNetwork(string question, string docFile = "Documents\\ComputerNetwork_2019.docx")
        {
            question = question.ParseQA();

            using (var docx = DocX.Load(docFile))
            {             
                foreach (var row in docx.Tables[0].Rows)
                {                   
                    string questionLine = row.Cells[1].Paragraphs[0].Text.ParseQA();
                    
                    if (questionLine.Contains(question))
                    {
                        
                        return row.Cells[2].Paragraphs[0].Text;
                    }
                }
            }

            return questionNotFound;
        }

        public static string ResponseDigital(string question, string docFile = "Documents\\Digital_2019.docx")
        {
            question = question.ParseQA();
            question = question.RemoveStartingDigits();

            using (var docx = DocX.Load(docFile))
            {
                int i = 0;
                foreach (var p in docx.Paragraphs)
                {
                    string questionLine = p.Text.ParseQA();
                    questionLine = questionLine.RemoveStartingDigits();

                    if (questionLine.Contains(question) && (i+5) < docx.Paragraphs.Count)
                    {
                        for (int j = 1; j < 5; j++)
                        {
                            var answers = docx.Paragraphs[i + j].MagicText.Where(x => x.formatting.UnderlineStyle == UnderlineStyle.singleLine).Select(x => x.text);
                            if (answers.Any())
                            {
                                return answers.First();
                            }
                        }

                        return answerNotFound;
                    }

                    i++;
                }
            }

            return questionNotFound;
        }       
    }
}
