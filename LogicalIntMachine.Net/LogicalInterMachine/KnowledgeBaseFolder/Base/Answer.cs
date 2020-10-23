using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KnowledgeBaseFolder.Base
{
	public class Answer:IXmlSerializable
	{
		string _nameAnswer;
		List<CombinationFact> _factsAnswer;

		/// <summary>
		/// Имя факта
		/// </summary>
		public string NameAnswer { get => _nameAnswer; }

		/// <summary>
		///  Получить коллекцию комбинаций фактов 
		/// </summary>
		public IReadOnlyList<CombinationFact> GetCombinationFacts => _factsAnswer;

		public Answer(string nameAnswer)
		{
			_nameAnswer = nameAnswer;
			_factsAnswer = new List<CombinationFact>();


		}
		public Answer()
        {
			_factsAnswer = new List<CombinationFact>();
		}

		/// <summary>
		/// Добавить новый факт (триггер)
		/// </summary>
		public void AddCombinationFact(List<CombinationFact> facts)
		{
			for (int i = 0; i < facts.Count; i++)
				_factsAnswer.Add(facts[i]);
			
		}

        public XmlSchema GetSchema()
        {
			return null;
        }

        public void ReadXml(XmlReader reader)
        {
			reader.Read();
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				switch (reader.LocalName)
				{
					case "nameAnswer":
						_nameAnswer = reader.ReadElementString();
						break;
					case "CombinationFact":
						var combinationFact = new CombinationFact();
						combinationFact.ReadXml(reader);
						_factsAnswer.Add(combinationFact);
						break;
					default: reader.Read(); break;
				}
			}
			reader.Read();
		}

        public void WriteXml(XmlWriter writer)
        {
			writer.WriteStartElement("Answer");
			writer.WriteStartElement("nameAnswer");
			writer.WriteString(NameAnswer);
			writer.WriteEndElement();
			writer.WriteStartElement("CombinationsFact");
			for (int indexer = 0; indexer < _factsAnswer.Count; indexer++)
            {
				_factsAnswer[indexer].WriteXml(writer);
            }
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
    }

}
