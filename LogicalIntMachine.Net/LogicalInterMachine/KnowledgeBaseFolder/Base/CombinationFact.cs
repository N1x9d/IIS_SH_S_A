using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KnowledgeBaseFolder.Base
{

	public class CombinationFact : IXmlSerializable
	{
		List<Fact> _factsRuele;

		public CombinationFact()
		{
			_factsRuele = new List<Fact>();
		}
		public CombinationFact(List<Fact> facts)
		{
			_factsRuele = new List<Fact>();
			for (int i = 0; i < facts.Count; i++)
				AddFact(facts[i].NameFact, facts[i].StateOfFact);
		}

		/// <summary>
		///  Найти нужные факт по имени и вернуть true (нашел) false(не соответсвие) null (не нашел).
		/// </summary>
		public IReadOnlyList<Fact> GetFacts => _factsRuele;




		/// <summary>
		///  Добавить новый факт (триггер) 
		/// </summary>
		public void AddFact(string nameFact, bool? stateOfFact)
		{
			Fact fact = new Fact(nameFact, stateOfFact);
			_factsRuele.Add(fact);

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

					case "Fact":
						var factsRuele = new Fact();
						factsRuele.ReadXml(reader);
						_factsRuele.Add(factsRuele);
						break;
					default: reader.Read(); break;
				}
			}
			reader.Read();
			if (reader.LocalName == "CombinationsFact") { reader.Read(); }
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("CombinationFact");
			for (int indexer = 0; indexer < _factsRuele.Count; indexer++)
			{
				_factsRuele[indexer].WriteXml(writer);
			}
			writer.WriteEndElement();
		}
	}
}

