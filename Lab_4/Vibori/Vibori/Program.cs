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
            ConstituencyPriorites c = new ConstituencyPriorites(3, 5);
            c.SetVoitersProirites();
            c.CalculateResaltByKondarse();
            Console.WriteLine("Kopland");
            c.CalculateResaltByKopland();
            Console.ReadKey();

        }
    }
}
