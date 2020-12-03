using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
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
        public static void SaveResults(Results results)
        {
            XmlHelper.AppendToXmlFile(results, xmlResultsPath);
        }

        public static List<Question> GetQuestions()
        {
            List<Question> questionFromXaml = XmlHelper.FromXmlFile<Question>(xmlQuestionsPath);
            return questionFromXaml;
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
                // Validare intrebari
                // Este setata doar o conditie de validare: Campul CorrectOptionId sa contina valori din intervalul [0, 3].
                Question invalidCorrectOptionId = QuestionsList.Where(q => q.CorrectOptionIndex < 0 || q.CorrectOptionIndex > 3).FirstOrDefault();
                if(invalidCorrectOptionId != null)
                {
                    MessageBox.Show(string.Format($"Intrebarea cu ID-ul {invalidCorrectOptionId.QuestionId} contine campuri invalide: {nameof(invalidCorrectOptionId.CorrectOptionIndex)}"));
                    return false;
                }

                XmlHelper.ToXmlFile(QuestionsList, xmlQuestionsPath);
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
            try
            {
                var xs = new XmlSerializer(obj.GetType());
                using (XmlWriter writer = XmlWriter.Create(filePath))
                {
                    xs.Serialize(writer, obj);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
                MessageBox.Show("Datele nu au putu fi citite din fisierul XML, " + e.Message);
                return new List<T>();
            }
            finally
            {
                sr.Close();
            }
        }
    }
}
