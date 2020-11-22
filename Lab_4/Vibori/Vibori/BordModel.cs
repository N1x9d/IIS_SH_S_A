using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibori
{
    class BordModel
    {
        List<int[]> voitersResalts;
        //колличество экспертов
        int expert;
        //Колличество оценок
        int mark;
        public BordModel(List<int[]> VoitersResalts)
        {
            voitersResalts = VoitersResalts;
            expert = voitersResalts.Count;
            mark = voitersResalts[0].Length;
        }

        public int CalculateResalt()
        {
            var markExpert = new int[mark];
            for(int indexpert = 0; indexpert < expert; indexpert++)
            {
                for(int indmark=0; indmark <mark; indmark++)
                {
                    //Определяет index и отнимает от него колличесвто элементов -1 для выставления оценки и загоняет
                    // в массив оценок
                    markExpert[voitersResalts[indexpert][indmark] - 1] += Math.Abs(indmark - (mark - 1));
                }
            }
            int maxmark=markExpert.Max<int>();
            int resualt = Array.IndexOf(markExpert, maxmark);
            return resualt + 1;
        }
    }
}
