using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blijdorp
{
    class Program
    {
        static void Main(string[] args)
        {
            Kassa kassa = new Kassa();
            kassa.OnlineKassa();

            while (kassa.IsBusy)
            {
              kassa.addKlant();
              kassa.IsBusy = kassa.getBool("Nog een persoon?");
            }

            kassa.berekenPrijs();
            
        }
    }
}
