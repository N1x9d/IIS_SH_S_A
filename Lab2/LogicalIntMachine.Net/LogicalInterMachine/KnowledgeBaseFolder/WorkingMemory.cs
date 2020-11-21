using KnowledgeBaseFolder.Base;
using System;
using System.Collections.Generic;

namespace KnowledgeBaseFolder
{
    class WorkingMemory
    {
        public WorkingMemory()
        {
            _temporaryFacts = new List<Fact>();
        }

        private List<Fact> _temporaryFacts;

        public IReadOnlyList<Fact>  TemporaryFacts => _temporaryFacts;

        /// <summary>
        ///  Добавить новый факт.
        /// </summary>
        public void AddFact(string nameFact,bool stateOfFact)
        {
            var fact = new Fact(nameFact, stateOfFact);
            _temporaryFacts.Add(fact);
        }

        
        
    }
}
