using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibori
{
    class RelativeMajority
    {
        List<int[]> voitersResalts;
        //количество экспертов
        int expert;
        //количество оценок
        int mark;

        List<int> one = new List<int>();

        public RelativeMajority(List<int[]> VoitersResalts)
        {
            voitersResalts = VoitersResalts;
            expert = voitersResalts.Count;
            mark = voitersResalts[0].Length;
        }

        public void CalculateResalt()
        {
            int[] oo = new int[voitersResalts.Count];
            foreach (var r in voitersResalts)//перебор списков приоритетов избирателей
            {
                one.Add(r[0]);
            }
            for (int i=0; i<one.Count;i++)
            {
                oo[i] = one[i];
            }
            var most = oo.GroupBy(x => x).OrderByDescending(x => x.Count()).First(); //находим самое частовстречаемое число
            Console.WriteLine("Выигрывает альтернатива {0} в количестве {1}", most.Key, most.Count());
                
            for (int indmark = 0; indmark < mark; indmark++)
            {
                int iWins = 0;
                int kWins = 0;

                if (most.Key != indmark + 1)
                {
                    foreach (var r in voitersResalts)//перебор списков приоритетов избирателей
                    {
                        if (Array.IndexOf(r, most.Key) < Array.IndexOf(r, indmark + 1))// если альтернатива i лучше k
                            iWins++;
                        else if (Array.IndexOf(r, most.Key) != Array.IndexOf(r, indmark + 1))// если альтернатива k лучше i
                            kWins++;
                    }
                    Console.WriteLine("Проигрывая альтернативе {0} в количестве {1}", indmark + 1, kWins);
                }
            }
        }
    }
}
