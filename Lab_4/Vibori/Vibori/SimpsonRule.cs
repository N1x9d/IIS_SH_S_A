using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibori
{
    class SimpsonRule
    {
        List<int[]> voitersResalts;
        //колличество экспертов
        int expert;
        //Колличество оценок
        int mark;

        public SimpsonRule(List<int[]> VoitersResalts)
        {
            voitersResalts = VoitersResalts;
            expert = voitersResalts.Count;
            mark = voitersResalts[0].Length;
        }

        public void CalculateResalt()
        {
            List<int> kon = new List<int>();
            for (int indexpert = 0; indexpert < mark; indexpert++)
            {
                List<int> pr = new List<int>();
                for (int indmark = 0; indmark < mark; indmark++)
                {
                    int iWins = 0;
                    int kWins = 0;
                    
                    if (indexpert + 1!= indmark + 1)
                    {
                        foreach (var r in voitersResalts)//перебор списков приоритетов избирателей
                        {
                            if (Array.IndexOf(r, indexpert + 1) < Array.IndexOf(r, indmark+1 ))// если альтернатива i лучше k
                                iWins++;
                            else if (Array.IndexOf(r, indexpert + 1) != Array.IndexOf(r, indmark+1 ))// если альтернатива k лучше i
                                kWins++;
                        }
                        pr.Add(iWins); //создаем оценочный лист для сравнения i-ой альтернативы с остальными
                    }                    
                }
                if (pr.Count != 0)
                {
                    int m = pr.Min(); //ищем минимумы
                    kon.Add(m);
                }
            }
            int itog = kon.IndexOf(kon.Max()) + 1; // находим максимум в списке минимумов
            Console.WriteLine("Выигрывает альтернатива " + itog + " с результатом "+ kon.Max());
        }
    }
}
