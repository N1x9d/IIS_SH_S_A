using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibori
{
    public class ConstituencyPriorites
    {
        public int AlternativesCount { get; private set; }
        public int VoitersCount { get; private set; }

        public List<int[]> VoitersResalts;
        /// <summary>
        /// Коструктор
        /// </summary>
        /// <param name="alternativesCount"> колличество альтернатив</param>
        /// <param name="voitersCount"> количество кандидатов</param>
        public ConstituencyPriorites(int alternativesCount, int voitersCount)
        {
            AlternativesCount = alternativesCount;
            VoitersCount = voitersCount;
            VoitersResalts = new List<int[]>();
        }
        /// <summary>
        /// Ввести приоритеты избирателей
        /// </summary>
        public void SetVoitersProirites()
        {
            Console.WriteLine("Введите прироитеты голосующих");
            int i = 0;
            while(i < VoitersCount)
            {
                int j = 0;
                Console.WriteLine($"Введите приоритеты {i+1} избирателя");
                int[] resalt = new int[AlternativesCount];
                while(j< AlternativesCount)
                {
                    resalt[j] = Convert.ToInt32(Console.ReadLine());
                    j++;
                }
                VoitersResalts.Add(resalt);
                i++;
            }
        }
        /// <summary>
        /// посчитать методом Кондерсе по правилу явного победителя
        /// </summary>
        public void CalculateResaltByKondarse()
        {
            int[] resalt = new int[AlternativesCount];
            int i = 0;
            while (i < AlternativesCount-1)
            {
                int k = i+1;
                while (k < AlternativesCount) 
                {
                    int iWins = 0;
                    int kWins = 0;
                    foreach (var r in VoitersResalts)//перебор списков приоритетов избирателей
                    {
                        if (Array.IndexOf(r, i+1) < Array.IndexOf(r, k+1))// если альтернатива i лучше k
                            iWins++;
                        else if (Array.IndexOf(r, i+1) != Array.IndexOf(r, k+1))// если альтернатива k лучше i
                            kWins++;
                    }
                    if (iWins > kWins)//если за альтернативу i проголосовало больше человека
                    {
                        resalt[i]++;
                        Console.WriteLine($"Альтернатива {i+1}={iWins}> альтернатива {k+1}={kWins}") ;
                    }
                    else if (iWins != kWins)//если за альтернативу k проголосовало больше человека
                    {
                        resalt[k]++;
                        Console.WriteLine($"Альтернатива {k+1}={kWins}> альтернатива {i+1}={iWins}");
                    }
                    k++;
                }
                i++;   
            }
            //подсчет результата
            var a = resalt.Max();
            var res = Array.IndexOf(resalt, a);
            var res2 = Array.LastIndexOf(resalt, a);
            if (res == res2)
                Console.WriteLine($"Альтернатива {res+1} выиграла");
            else
                Console.WriteLine($"Возник парадокс Кандерсе и {res+1} {res2+1} выиграли");

        }
        /// <summary>
        /// посчитать методом Кондерсе по правилу Копланда
        /// </summary>
        public void CalculateResaltByKopland()
        {
            int[] resalt = new int[AlternativesCount];
            int i = 0;

            while (i < AlternativesCount - 1)
            {
                int k = i + 1;
                while (k < AlternativesCount)
                {
                    int iWins = 0;
                    int kWins = 0;
                    foreach (var r in VoitersResalts)//перебор списков приоритетов избирателей
                    {
                        if (Array.IndexOf(r, i + 1) < Array.IndexOf(r, k + 1))// если альтернатива i лучше k
                            iWins++;
                        else if (Array.IndexOf(r, i + 1) != Array.IndexOf(r, k + 1))// если альтернатива k лучше i
                            kWins++;
                    }
                    if (iWins > kWins)//если за альтернативу i проголосовало больше человека
                    {
                        resalt[i] += 1;
                        resalt[k] -= 1;
                        Console.WriteLine($"Альтернатива {i + 1}={iWins} итого {resalt[i]}> альтернатива {k + 1}={kWins} итого {resalt[k]}");
                    }
                    else if (iWins != kWins)//если за альтернативу k проголосовало больше человека
                    {
                        resalt[k] += 1;
                        resalt[i] -= 1;
                        Console.WriteLine($"Альтернатива {k + 1}={kWins} итого {resalt[k]}> альтернатива {i + 1}={iWins} итого {resalt[i]}");
                    }
                    else //если за альтернативу k равносильна i
                        Console.WriteLine($"Альтернатива {k + 1}={kWins} итого {resalt[k]}= альтернатива {i + 1}={iWins} итого {resalt[i]}");
                    k++;
                }
                i++;
            }
            //подсчет результата
            var a = resalt.Max();
            var res = Array.IndexOf(resalt, a);
            var res2 = Array.LastIndexOf(resalt, a);
            if (res == res2)
                Console.WriteLine($"Альтернатива {res + 1} выиграла");
            else
                Console.WriteLine($"Возник парадокс Кандерсе и {res + 1} {res2 + 1} выиграли");

        }
    }
}
