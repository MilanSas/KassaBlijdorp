using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blijdorp
{
    class Kassa
    {
        double totaleprijs;
        List<Klant> klanten = new List<Klant>();
        OptionVisitor<double> prijsbereknaar = new PrijsBerekenaar();
        OptionVisitor<bool> IsGehandicapt = new IsGehandicapt();
        public bool IsBusy = true;
        public bool bergeleider = false;
        public bool online;
        private int leeftijd;

        public bool isGehandicapte()
        { 
            foreach (Klant klant in klanten)
            {
                if (klant.Visit(IsGehandicapt))
                {
                    return true;
                }   
            }
            return false;
        }

        public bool getBool(string question)
        {
            while (true)
            {
                Console.Write(question);
                string Answer = Console.ReadLine().ToLower();

                if (Answer == "y" || Answer == "n")
                {
                    if (Answer == "y") { return true; }

                    else{return false;}
                    
                }
                Console.WriteLine("Antwoord met Y of N");
            }
        }

        public int getLeeftijd()
        {
            bool heeftleeftijd = false;
            while (!heeftleeftijd)
            {
                Console.WriteLine("Leeftijd?");
                try
                {
                    leeftijd = int.Parse(Console.ReadLine());
                    if (leeftijd < 0)
                    {
                        Console.WriteLine("Leeftijd moet over 0 zijn");
                    }

                    else
                    {
                        heeftleeftijd = true;
                    }

                }

                catch { Console.WriteLine("U moet een leeftijd invullen"); }
            }
            return leeftijd;
        }

        public void OnlineKassa()
        {
            online = getBool("Online Kassa?");
            
        }

        public void berekenPrijs()
        {
            totaleprijs = 0;
            foreach (Klant klant in klanten)
            {
                totaleprijs += klant.Visit(prijsbereknaar);
            }

            Console.WriteLine(totaleprijs);
        }

        public void addKlant()
        {
            bool abonnement = getBool("Abonnement?");

            if (abonnement)
            {
                bool gehandicapt = getBool("Gehandicapt?");

                if (gehandicapt)
                {
                    Console.WriteLine("added abonnee gehandicapt");
                    klanten.Add(new Abonnee(gehandicapt));
                }

                else
                {
                    Console.WriteLine("added abbonee niet gehandicapt");
                    klanten.Add(new Abonnee(gehandicapt));
                }
                
                return;
            }

            leeftijd = getLeeftijd();

            if (0 <= leeftijd && leeftijd < 3)
            {
                Console.WriteLine("added baby");
                klanten.Add(new Baby());
            }

            if ((3 <= leeftijd && leeftijd < 13) || (leeftijd >= 13))
            {
                bool gehandicapt = getBool("Gehandicapt?");


                if (!gehandicapt && (leeftijd >= 13))
                {
                    bool bergeleider = getBool("Bergeleider?");


                    if (bergeleider)
                    {
                        if (isGehandicapte())
                        {
                            Console.WriteLine("added bergeleider");
                            klanten.Add(new Bergeleider());
                            return;
                        }

                        else { Console.WriteLine("Er is geen gehandicapte niks toegevoegd"); return;}
                    }
                }

                if (3 <= leeftijd && leeftijd < 13)
                {
                    Console.WriteLine("added kind");
                    klanten.Add(new Kind(online, gehandicapt));
                }

                else if (leeftijd >= 13)
                {
                    Console.WriteLine("added volwassene");
                    klanten.Add(new Volwassene(online, gehandicapt));
                }
            }
        }
    }
}


