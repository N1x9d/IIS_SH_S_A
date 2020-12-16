using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace NeiroNetTest
{
    public class Layer
    {
        List<Connection> _cons = new List<Connection>();
        List<Neiron> _neirons = new List<Neiron>();


        public Layer()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    _cons.Add(new Connection(i, j));
                }
            }

            for (int i = 0; i < 10; i++)
            {
                _neirons.Add(new Neiron(i, _cons));
            }
        }

        public int RunNet(int[,] matrix)
        {
            List<decimal> outputs = new List<decimal>();
            foreach (var neiro in _neirons)
            {
                outputs.Add(neiro.Output(matrix));
            }

            decimal max = -1;
            int maxInd = -1;
            int k = 0;
            foreach (var i in outputs)
            {
                if (i > max)
                {
                    max = i;
                    maxInd = k;
                }

                k++;
            }

            return maxInd;
        }

        /// <summary>
        /// алгоритм обучения(за раз принимает одну матрицу)
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="expectedResalt">ожидаемый результат</param>
        /// <param name="evaluateCount">число эпох</param>
        public void autoLearning(List<int[,]> matrix, int evaluateCount)
        {
            for (int i = 0; i <= evaluateCount; i++)
            {
                int k = 0;
                foreach (var matr in matrix)
                {
                    var res = RunNet(matr);
                    if (res != k)
                    {
                        _neirons[res].learning(matr, res); //караем сработавший не правильно нейрон
                        _neirons[k].learning(matr, res); //караем не сработавший нейрон
                    }

                    k++;
                }
            }
        }

        public void manualLearning(int[,] matrix, int expResalt)
        {
            var res = RunNet(matrix);
            if (res != expResalt)
            {
                _neirons[res].learning(matrix, res); //караем сработавший не правильно нейрон
                _neirons[expResalt].learning(matrix, res); //караем не сработавший нейрон
            }
        }
    }
}