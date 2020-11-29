using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibori
{
    class Program
    {
        static void Main(string[] args)
        {
            int VoitersCount = 3;
            int AlternativesCount = 3;
            var VoitersResalts = new List<int[]>();
            Console.WriteLine("Введите прироитеты голосующих");
            int i = 0;
            while (i < VoitersCount)
            {
                int j = 0;
                Console.WriteLine($"Введите приоритеты {i} избирателя");
                int[] resalt = new int[AlternativesCount];
                while (j < AlternativesCount)
                {
                    resalt[j] = Convert.ToInt32(Console.ReadLine());
                    j++;
                }
                VoitersResalts.Add(resalt);
                i++;

            }
            ConstituencyPriorites cp = new ConstituencyPriorites(AlternativesCount, VoitersCount, VoitersResalts);
            Console.WriteLine();
            Console.WriteLine("Kondarse metod");
            cp.CalculateResaltByKondarse();
            Console.WriteLine();
            Console.WriteLine("Kopland metod");
            cp.CalculateResaltByKopland();
            Console.WriteLine();
            Console.WriteLine("BordModel");
            BordModel bordModel = new BordModel(VoitersResalts);
            Console.WriteLine("Выигрывает альтернатива "+bordModel.CalculateResalt());
            Console.WriteLine();
            Console.WriteLine("Simpson rule");
            SimpsonRule sr = new SimpsonRule(VoitersResalts);
            sr.CalculateResalt();
            Console.WriteLine();
            Console.WriteLine("Relative majority");
            RelativeMajority rm = new RelativeMajority(VoitersResalts);
            rm.CalculateResalt();
            Console.ReadLine();
        }
        public void SetVoitersProirites()
        {
            
        }
    }
}
