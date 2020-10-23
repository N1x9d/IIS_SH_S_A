﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KnowledgeBaseFolder.Base
{	
	public  class Rule:IXmlSerializable
	{
		string _nameRule;
		string _nameQuestion;

		List<CombinationFact> _factsRuele;
		List<Fact> _mutableFact;

		public bool IsUsed;
		/// <summary>
		///  Имя правила.
		/// </summary>
		public string NameRule => _nameRule;

		/// <summary>
		///  Имя вопроса.
		/// </summary>
		public string NameQuestion => _nameQuestion;

		/// <summary>
		///  Получить коллекцию комбинаций фактов 
		/// </summary>
		public IReadOnlyList<CombinationFact> GetCombinationFacts => _factsRuele;

		/// <summary>
		///  Вернуть List фактов рабочей памяти
		/// </summary>
		public IReadOnlyList<Fact> GetMutableFacts => _mutableFact;

		public Rule(string nameRule,string nameQuestion)
		{
			_nameRule = nameRule;
			_nameQuestion = nameQuestion;
			_factsRuele = new List<CombinationFact>();
			_mutableFact = new List<Fact>();
			IsUsed = false;
		}
		public Rule()
		{
			_factsRuele = new List<CombinationFact>();
			_mutableFact = new List<Fact>();
			IsUsed = false;
		}
		
		public void Used()
        {
			IsUsed = true;
        }

		/// <summary>
		///  Добавить новый факт
		/// </summary>	
		public void AddMutableFact(string nameFact,bool? stateOfFact)
        {
			_mutableFact.Add(new Fact(nameFact, stateOfFact));
        }

		/// <summary>
		///  Добавить комбинацию фактов (тригеров) 
		/// </summary>
		public void AddCombinationFact(List<CombinationFact> facts)
		{	
			for(int i=0;i<facts.Count;i++)
			_factsRuele.Add(facts[i]);			
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
					case "nameRule":
						_nameRule = reader.ReadElementString();
						break;
					case "CombinationFact":
						var combinationFact = new CombinationFact();
						combinationFact.ReadXml(reader);
						_factsRuele.Add(combinationFact);
						break;
					case "nameQuestion":
						_nameQuestion = reader.ReadElementString();
						break;
					case "MutableFact":
						var fact = new Fact();
						fact.ReadXml(reader);
						_mutableFact.Add(fact);
						break;
					default: reader.Read(); break;
				}
			}
			reader.Read();
			if (reader.LocalName == "Rule") { reader.Read(); }
			if (reader.LocalName == "Rules") { reader.Read(); }
		}

        public void WriteXml(XmlWriter writer)
        {
			writer.WriteStartElement("Rule");
			writer.WriteStartElement("nameRule");
			writer.WriteString(NameRule);
			writer.WriteEndElement();
			writer.WriteStartElement("nameQuestion");
			writer.WriteString(NameQuestion);
			writer.WriteEndElement();
			writer.WriteStartElement("CombinationsFact");
			for (int index = 0; index < _factsRuele.Count; index++)
            {
				_factsRuele[index].WriteXml(writer);
            }
			writer.WriteEndElement();
			writer.WriteStartElement("MutablesFact");
			for (int index = 0; index < _mutableFact.Count; index++)
			{
				writer.WriteStartElement("MutableFact");
				_mutableFact[index].WriteXml(writer);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
    }
}
