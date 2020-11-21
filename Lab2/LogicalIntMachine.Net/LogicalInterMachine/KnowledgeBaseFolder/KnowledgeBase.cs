using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using KnowledgeBaseFolder.Base;

namespace KnowledgeBaseFolder
{
    /// <summary>
    ///  Класс контейнер Базы Знаний.
    /// </summary>
    class KnowledgeBase
    {
        WorkingMemory workingMemory;
        Container container;

        /// <summary>
        ///  Вернуть List правил.
        /// </summary> 
        public IReadOnlyList<Rule> GetRules => container.GetRules;

        /// <summary>
        ///  Вернуть List ответов.
        /// </summary>
        public IReadOnlyList<Answer> GetAnswers => container.GetAnswers;

        /// <summary>
        ///  Вернуть фаткы рабочей памяти.
        /// </summary>
        public IReadOnlyList<Fact> GetFactWorkingMemory => workingMemory.TemporaryFacts;

        private static KnowledgeBase knowledge = null;

        private KnowledgeBase()
        {
            workingMemory = new WorkingMemory();
            container = new Container();
        }

        public static KnowledgeBase GetKnowledge
        {
            get
            {
                if (knowledge == null)
                    knowledge = new KnowledgeBase();
                return knowledge;
            }
        }

        /// <summary>
        ///  Обнулить рабочую память.
        /// </summary>
        public void DropWorkMemory()
        {
            workingMemory = new WorkingMemory();
        }




        /// <summary>
        ///  Добавить новый факт в рабочую память.
        /// </summary>
        public void AddNewFactWorkMembory(string nameFact, bool stateOfFact)
        {
            workingMemory.AddFact(nameFact, stateOfFact);
        }
        public void Load(string filename = "KnowledgeBase.xml")
        {
            var binFormatter = new XmlSerializer(typeof(Container));
            if (filename != null)
            {
                using (var file = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    container = (Container)binFormatter.Deserialize(file);
                    file.Close();
                }

            }
        }

        public void Save(string fileName)
        {
            try
            {
                if (fileName != null)
                {
                    var binFormatter = new XmlSerializer(typeof(Container));
                    using (var file = new FileStream(fileName, FileMode.CreateNew))
                    {
                        binFormatter.Serialize(file, container);
                        file.Close();
                    }
                }
            }
            catch (System.IO.IOException) { MessageBox.Show("Данный файл уже существует"); }

        }

        /// <summary>
        ///  Доьавить новое правило.
        /// </summary>
        public void AddRules(string nameRule, string nameAnswer, List<CombinationFact> factRule, List<Fact> mutableFacts) //временные
        {
            container.AddRules(nameRule, nameAnswer, factRule, mutableFacts);
        }

        /// <summary>
        ///  Добавить новый ответ.
        /// </summary>
        public void AddAnswer(string nameAnswer, List<CombinationFact> factsAnswer)
        {
            container.AddAnswer(nameAnswer, factsAnswer);
        }
    }
}
