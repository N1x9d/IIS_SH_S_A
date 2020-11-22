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
        public ConstituencyPriorites(int alternativesCount, int voitersCount)
        {
            AlternativesCount = alternativesCount;
            VoitersCount = voitersCount;
            VoitersResalts = new List<int[]>();
        }
        public void SetVoitersProirites()
        {
            Console.WriteLine("Введите прироитеты голосующих");
            int i = 0;
            while(i < VoitersCount)
            {
                int j = 0;
                Console.WriteLine($"Введите приоритеты {i} избирателя");
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
        public void CalculateResalt()
        {
            int[] resalt = new int[AlternativesCount];
            int i = 0;
            int k = 0;
            int iWins = 0;
            int kWins = 0;
            while (i < AlternativesCount)
            {
                while (k < AlternativesCount)
                    if (k != i) 
                    {
                        foreach (var r in VoitersResalts)
                        {
                            if (Array.IndexOf(r, i) > Array.IndexOf(r, k))
                                iWins++;
                            else if (Array.IndexOf(r, i) != Array.IndexOf(r, k))
                                kWins++;
                        }

                    }
            }

        }
    }
}
