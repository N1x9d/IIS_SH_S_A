using KnowledgeBaseFolder;
using KnowledgeBaseFolder.Base;
using LogicalInterMachine.InterfaceMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicalInterfaceMachine
{
    class LogicalMachine
    {
        
        private Rule CurentRule;

        public string ResaltAnswer { get; private set; }
        /// <summary>
        /// Текущий вопрос пользователю(если пуст то требуй следующее правило, если null то все сломалось)
        /// </summary>
        public string CurQuestion { get; private set; }
        /// <summary>
        /// Список вариантов ответа если НЕ да/нет
        /// </summary>
        public List<string> AnswersWays;
        public LogicalMachine( )
        {
            knowledgeBase = KnowledgeBase.GetKnowledge;
            AnswersWays = new List<string>();
        }
        KnowledgeBase knowledgeBase;
        public void SaveKnowladgeBasw(string nameFile)
        {
            knowledgeBase.Save(nameFile);
        }
        public void LoadKnowladgeBasw()
        {
            knowledgeBase.Load();
        }

        /// <summary>
        /// Заполнить факты, требующие ответа пользователя
        /// </summary>
        /// <param name="answer">ответ пользователя</param>
        public void AddDataFromUser(UserAnswer answer)
        {
            if(answer.Answer!=null)
            {
                var NewFact = CurentRule.GetMutableFacts[0];
                knowledgeBase.AddNewFactWorkMembory(NewFact.NameFact, (bool)answer.Answer);
            }
            else 
            {
                foreach( var fact in CurentRule.GetMutableFacts)
                {
                    if( fact.NameFact==answer.SelectedAnswer)
                        knowledgeBase.AddNewFactWorkMembory(fact.NameFact, true);
                    else
                        knowledgeBase.AddNewFactWorkMembory(fact.NameFact, false);
                }
            }
            CheckAnswers();
            GetCurentRuler();
        }

        private void AddDataAboutSelectedRule()
        {
            CurQuestion = CurentRule.NameQuestion;
            if (CurQuestion != "")
            {
                foreach (var a in CurentRule.GetMutableFacts)
                    AnswersWays.Add(a.NameFact);
            }
            else
            {
                var NewFact = CurentRule.GetMutableFacts[0];
                knowledgeBase.AddNewFactWorkMembory(NewFact.NameFact, (bool)NewFact.StateOfFact);
                CheckAnswers();
                GetCurentRuler();
            }
        }
        /// <summary>
        /// Проверить наличие выходного ответа
        /// </summary>
        private void CheckAnswers()
        {
            var answers = knowledgeBase.GetAnswers;
            var instanteMemoryCopy = knowledgeBase.GetFactWorkingMemory;
            foreach (var answ in answers) 
            { 
                bool isContainsNeededFacts = true;
                foreach (var Combfact in answ.GetCombinationFacts)
                {
                    isContainsNeededFacts = true;
                    foreach (var fact in Combfact.GetFacts)
                    {
                        if (isContainsNeededFacts)
                        {
                            var factInMemory = instanteMemoryCopy.Where(f => f.NameFact == fact.NameFact).ToList();
                            if (factInMemory.Count == 1)
                            {
                                if (factInMemory[0].StateOfFact != fact.StateOfFact)
                                isContainsNeededFacts = false;
                            }
                        }
                        else
                            break;
                    }
                }
                if (isContainsNeededFacts)
                {
                    ResaltAnswer = answ.NameAnswer;
                    break;
                }
            
            }
        }
        /// <summary>
        /// Найти подходящее правило
        /// </summary>
        public void GetCurentRuler()
        {
            CurentRule = null;
            CurQuestion = null;
            AnswersWays.Clear();
            var RulersList = knowledgeBase.GetRules;
            var instanteMemoryCopy = knowledgeBase.GetFactWorkingMemory;
           
            foreach(var rul in RulersList)
            {
                if (!rul.IsUsed)
                {
                    if (instanteMemoryCopy.Count == 0 && rul.GetCombinationFacts.Count == 0 || rul.GetCombinationFacts.Count == 0) 
                    {
                        CurentRule = rul;
                        rul.Used();
                        AddDataAboutSelectedRule();
                        break;
                    }
                    else if(instanteMemoryCopy.Count!=0)
                    {
                        bool isContainsNeededFacts = true;
                        
                        foreach(var Combfact in rul.GetCombinationFacts)
                        {
                            isContainsNeededFacts = true;
                            foreach (var fact in Combfact.GetFacts)
                            {
                                if (isContainsNeededFacts)
                                {
                                    var factInMemory = instanteMemoryCopy.Where(f => f.NameFact == fact.NameFact).ToList();
                                    if (factInMemory.Count == 1)
                                    {
                                        if (factInMemory[0].StateOfFact != fact.StateOfFact)
                                            isContainsNeededFacts = false;
                                    }
                                }
                                else 
                                    break;
                            }
                        }
                        if (isContainsNeededFacts)
                        {
                            CurentRule = rul;
                            rul.Used();
                            AddDataAboutSelectedRule();
                            break;
                        }
                    }
                }
            }
        }

    }
    
   
}
