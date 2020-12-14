using System.Collections.Generic;

namespace NeiroNetTest
{
    public class Neiron
    {
        private int NeironResalt; //то число за которое нейрон отвечает
        private List<NeironInputs> _inputCons = new List<NeironInputs>(); //входы
        private double _errorLim = 0.01; //порог ошибки
        private decimal _lastError = 0m;

        public Neiron(int neironResalt, List<Connection> cons)
        {
            NeironResalt = neironResalt;
            foreach (var con in cons)
            {
                _inputCons.Add(new NeironInputs(con));
            }
        }

        public decimal Output(int[,] matrix)
        {
            decimal res=0;
            foreach (var inp in _inputCons)
            {
                res += matrix[inp.Connection.MatrixX, inp.Connection.MatrixY] * inp.Weight;
            }

            return res;
        }

        public void learning(int[,] matrix, int resalt)
        {
            if(resalt==NeironResalt)
                foreach (var inp in _inputCons)
                {
                    if (matrix[inp.Connection.MatrixX, inp.Connection.MatrixY] == 1)
                        inp.Weight -=0.01m;
                }
            else
            {
                foreach (var inp in _inputCons)
                {
                    if (matrix[inp.Connection.MatrixX, inp.Connection.MatrixY] == 1)
                        inp.Weight +=0.01m;
                }
            }
        }
    }
}