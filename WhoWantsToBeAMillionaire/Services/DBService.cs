using Microsoft.VisualBasic.FileIO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Services
{
    class DBService
    {
        private static string baseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        private static string xmlResultsPath = Path.Combine(baseDirectory, @"DB\Results.xml");
        private static string xmlQuestionsPath = Path.Combine(baseDirectory, @"DB\Questions.xml");

        // Metodele ce definesc operatiile CRUD: Create, Read, Update, Delete
        public static bool AddQuestion(Question question)
        {
            Question q = new Question
            {
                QuestionId = "skrskr",
                CorrectOptionIndex = 1,
                DifficultyLevel = DifficultyLevel.Einstein,
                Explanations = "iaca",
                Options = new List<string>
                {
                    "1", "2", "3", "4"
                },
                QuestionText = "aica"
            };

            return XmlHelper.AppendToXmlFile(q, xmlQuestionsPath);
        }

        public static void SaveResults(Results results)
        {
            XmlHelper.AppendToXmlFile(results, xmlResultsPath);
        }

        public static List<Question> GetQuestions()
        {
            List<Question> questionFromXaml = XmlHelper.FromXmlFile<Question>(xmlQuestionsPath);
            return questionFromXaml;
        }

        public static List<Question> GetTestQuestions()
        {
            MessageBox.Show(xmlResultsPath);
            List<Question> TestQuestions = new List<Question>();
            for (int i = 0; i < 15; i++)
            {
                Question tq = new Question()
                {
                    QuestionId = "TestQuestionId" + i,
                    CorrectOptionIndex = 1,
                    DifficultyLevel = DifficultyLevel.Easy,
                    Explanations = "The quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphs grab quick-jived waltz. Brick quiz whangs jumpy veldt fox. Bright vixens jump; dozy fowl quack. Quick wafting zephyrs vex bold",
                    Options = new List<string>() { "op1", "op2", "op3", "op4" },
                    QuestionText = "Text intrebare " + i
                };
                TestQuestions.Add(tq);
            }

            return TestQuestions;
        }

        public static bool RemoveQuestion(string questionId)
        {
            try
            {
                List<Question> questions = GetQuestions();
                Question toBeDeleted = questions.First(q => q.QuestionId == questionId);
                questions.Remove(toBeDeleted);
                XmlHelper.ToXmlFile(questions, xmlQuestionsPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WriteQuestionsToXmlFile(List<Question> QuestionsList)
        {
            try
            {
                XmlHelper.ToXmlFile(QuestionsList, xmlQuestionsPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateQuestion(Question question)
        {
            try
            {
                List<Question> questions = GetQuestions();
                Question toBeUpdated = questions.First(q => q.QuestionId == question.QuestionId);
                toBeUpdated = question;
                XmlHelper.ToXmlFile(questions, xmlQuestionsPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class XmlHelper
    {
        public static bool NewLineOnAttributes { get; set; }

        public static string ToXml(object obj)
        {
            Type T = obj.GetType();

            var xs = new XmlSerializer(T);
            var ws = new XmlWriterSettings { Indent = true, NewLineOnAttributes = NewLineOnAttributes, OmitXmlDeclaration = true };

            var sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, ws))
            {
                xs.Serialize(writer, obj);
            }

            return sb.ToString();
        }

        public static T FromXml<T>(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xml))
            {
                return (T)xs.Deserialize(sr);
            }
        }

        public static void ToXmlFile(Object obj, string filePath)
        {
            var xs = new XmlSerializer(obj.GetType());
            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                xs.Serialize(writer, obj);
            }
        }

        public static bool AppendToXmlFile<T>(T obj, string filePath)
        {
            try
            {
                // Daca fisierul nu a fost inca folosit, il aducem in starea in care vom putea sa lucram cu el.
                if (File.ReadAllText(filePath).Length < 80)
                {
                    ToXmlFile(new List<T> { }, filePath);
                }

                List<T> objects = FromXmlFile<T>(filePath);
                objects.Add(obj);
                ToXmlFile(objects, filePath);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static List<T> FromXmlFile<T>(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            try
            {
                var result = FromXml<List<T>>(sr.ReadToEnd());
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show("Datele nu au putu fi citite din fisierul XML");
                Debug.WriteLine(e.Message);
                return new List<T>();
            }
            finally
            {
                sr.Close();
            }
        }
    }
}
