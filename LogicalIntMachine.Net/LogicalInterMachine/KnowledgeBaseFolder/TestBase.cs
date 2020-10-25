using KnowledgeBaseFolder.Base;
using System.Collections.Generic;


namespace KnowledgeBaseFolder
{
    class TestBase
    {
        public TestBase()
        {
            knowledgeBase = KnowledgeBase.GetKnowledge;
        }

        KnowledgeBase knowledgeBase;

        public void FillAnswerAndRule()
        {
            CreateAddAnswer();
            CreateAddRule();
        }
        void CreateAddRule()
        {

            knowledgeBase.AddRules("determine-budget", "What is your budget?",
                new List<CombinationFact>{},
                    new List<Fact> {new Fact("budget-low",null),
                                new Fact("budget-middle",null),
                                new Fact("budget-high",null)});
            knowledgeBase.AddRules("determine-children", "Are you planning to go on vacation with children?",
                new List<CombinationFact>{
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-low",true) }),
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-middle",true)}),
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-high",true)})},
                new List<Fact> { new Fact("children", null) });
            knowledgeBase.AddRules("determine-category-low", null,
                new List<CombinationFact>{
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-low",true),
                                new Fact("children",true) })},
                new List<Fact> { new Fact("category-low", true) });
            
            knowledgeBase.AddRules("determine-category-middle", null,
                new List<CombinationFact>{
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-middle",true),
                                new Fact("children",true) }),
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-low",true),
                                new Fact("children",false) })},
                new List<Fact> { new Fact("category-middle", true) });
            knowledgeBase.AddRules("determine-category-high", null,
                new List<CombinationFact>{
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-high",true),
                                new Fact("children",false) }),
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-middle",true),
                                new Fact("children",false) }),
                    new CombinationFact(new List<Fact>{
                                new Fact("budget-high",true),
                                new Fact("children",true) })},
                new List<Fact> { new Fact("category-high", true) });
            knowledgeBase.AddRules("determine-abroad", "Do you want to spend your holiday abroad?",
                new List<CombinationFact>{
                    new CombinationFact(new List<Fact>{
                                new Fact("category-middle",true)}),
                    new CombinationFact(new List<Fact>{
                                new Fact("category-high",true)})},
                new List<Fact> { new Fact("abroad", null) });
            knowledgeBase.AddRules("determine-russia", null,
                new List<CombinationFact>{
                    new CombinationFact(new List<Fact>{
                                new Fact("category-low",true)})},
                new List<Fact> { new Fact("abroad", false) });
            knowledgeBase.AddRules("determine-visa", "Do you agree to get a visa if you don't have one?",
                new List<CombinationFact>{
                    new CombinationFact(new List<Fact>{
                                new Fact("abroad",true)})},
                new List<Fact> { new Fact("visa", null) });
            knowledgeBase.AddRules("determine-excursion", "what type of vacation do you prefer?",
               new List<CombinationFact> { },
               new List<Fact> { new Fact("excursion", null) ,
                                new Fact("beach", null) ,
                                new Fact("ski", null) });
            knowledgeBase.AddRules("determine-excursion", "When you want to rest?",
               new List<CombinationFact> { },
               new List<Fact> { new Fact("winter", null) ,
                                new Fact("spring", null) ,
                                new Fact("summer", null) ,
                                new Fact("autumn", null) });
            knowledgeBase.AddRules("EROR", "Sorry, we could not find you a vacation?",
               new List<CombinationFact> { },
               new List<Fact> { });

        }
        void CreateAddAnswer()
        {
            knowledgeBase.AddAnswer("No options. Check budget.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("budget-low",false),
                                                    new Fact("budget-middle",false),
                                                    new Fact("budget-high",false) }) });
            knowledgeBase.AddAnswer("No options. Check season.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("winter",false),
                                                    new Fact("spring",false),
                                                    new Fact("summer",false),
                                                    new Fact("autumn",false) })});
            knowledgeBase.AddAnswer("St. Petersburg.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",false),
                                                    new Fact("category-middle",true),
                                                    new Fact("excursion",true)})});
            knowledgeBase.AddAnswer("Perm.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",false),
                                                    new Fact("category-low",true),
                                                    new Fact("excursion",true)})});
            knowledgeBase.AddAnswer("Sochi ski resort.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",false),
                                                    new Fact("category-middle",true),
                                                    new Fact("ski",true),
                                                    new Fact("winter",true)}),
                new CombinationFact(new List<Fact>{ new Fact("abroad",false),
                                                    new Fact("category-middle",true),
                                                    new Fact("ski",true),
                                                    new Fact("autumn",true)}) ,
                new CombinationFact(new List<Fact>{ new Fact("abroad",false),
                                                    new Fact("category-middle",true),
                                                    new Fact("ski",true),
                                                    new Fact("spring",true)})});
            knowledgeBase.AddAnswer("Sochi beach resort.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",false),
                                                    new Fact("summer",true),
                                                    new Fact("beach",true),
                                                    new Fact("category-low",true)}),
                new CombinationFact(new List<Fact>{ new Fact("abroad",false),
                                                    new Fact("summer",true),
                                                    new Fact("beach",true),
                                                    new Fact("category-middle",true)})});
            knowledgeBase.AddAnswer("United Arab Emirates.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("winter",true),
                                                    new Fact("beach",true),
                                                    new Fact("category-high",true)}),
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("summer",true),
                                                    new Fact("beach",true),
                                                    new Fact("category-middle",true)})});
            knowledgeBase.AddAnswer("Turkey.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-middle",true),
                                                    new Fact("beach",true),
                                                    new Fact("spring",true)}),
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-middle",true),
                                                    new Fact("beach",true),
                                                    new Fact("summer",true)})});
            knowledgeBase.AddAnswer("Egypt.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-middle",true),
                                                    new Fact("beach",true),
                                                    new Fact("spring",true)}),
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-middle",true),
                                                    new Fact("beach",true),
                                                    new Fact("autumn",true)})});
            knowledgeBase.AddAnswer("Germany ski resort.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-high",true),
                                                    new Fact("visa",true),
                                                    new Fact("children",false),
                                                    new Fact("ski",true)})});
            knowledgeBase.AddAnswer("Germany excursion.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-high",true),
                                                    new Fact("visa",true),
                                                    new Fact("children",false),
                                                    new Fact("excursion",true)})});
            knowledgeBase.AddAnswer("Spain ski resort.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-high",true),
                                                    new Fact("visa",true),
                                                    new Fact("ski",true),
                                                    new Fact("children",true),
                                                    new Fact("winter",true)})});
            knowledgeBase.AddAnswer("Spain beach resort.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-high",true),
                                                    new Fact("visa",true),
                                                    new Fact("beach",true),
                                                    new Fact("children",true),
                                                    new Fact("summer",true)})});
            knowledgeBase.AddAnswer("China.", new List<CombinationFact>{
                new CombinationFact(new List<Fact>{ new Fact("abroad",true),
                                                    new Fact("category-high",true),
                                                    new Fact("visa",true),
                                                    new Fact("excursion",true),
                                                    new Fact("children",true)})});
        }
    }
}
