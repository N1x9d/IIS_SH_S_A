﻿using System;
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
            BordModel bordModel = new BordModel(VoitersResalts);
            bordModel.CalculateResalt();
        }
        public void SetVoitersProirites()
        {
            
        }
    }
}