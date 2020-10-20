using KnowledgeBaseFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicalInterfaceMachine
{
    class LogicalMachine
    {
        public LogicalMachine()
        {
            knowledgeBase = KnowledgeBase.GetKnowledge;
        }

        KnowledgeBase knowledgeBase;
        public void SaveKnowladgeBasw(string nameFile)
        {
            knowledgeBase.Save(nameFile);
        }
        public void LoadKnowladgeBasw(string nameFile)
        {
            knowledgeBase.Load(nameFile);
        }

    }
    
   
}
