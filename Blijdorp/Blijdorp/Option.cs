using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blijdorp
{
    interface OptionVisitor<U>
    {
        U onVolwassene(Volwassene volwassene);
        U onKind(Kind kind);
        U onAbonnee(Abonnee abonnee);
        U onBaby(Baby baby);
        U onBergeleider(Bergeleider bergeleider);
       
    }
    interface Option
    {
        U Visit<U>(OptionVisitor<U> visitor);
    }

    class IsGehandicapt : OptionVisitor<bool>
    {
        public bool onAbonnee(Abonnee abonnee)
        {
            return abonnee.gehandicapt;
        }

        public bool onBaby(Baby baby)
        {
            return false;
        }

        public bool onBergeleider(Bergeleider bergeleider)
        {
            return false;
        }

        public bool onKind(Kind kind)
        {
            return kind.gehandicapt;
        }

        public bool onVolwassene(Volwassene volwassene)
        {
            return volwassene.gehandicapt;
        }
    }
    class PrijsBerekenaar : OptionVisitor<double>
    {
        public double onAbonnee(Abonnee abonnee)
        {
            return 0.00;
        }

        public double onBaby(Baby baby)
        {
            return 0.00;
        }

        public double onBergeleider(Bergeleider bergeleider)
        {
            return 13.00;
        }

        public double onKind(Kind kind)
        {
            if (kind.Online())
            {
                return 16.50;
            }

            else { return 18.50; }

        }

        public double onVolwassene(Volwassene volwassene)
        {
            if (volwassene.Online())
            {
                return 21.00;
            }

            else { return 23.00; }
        }
    }
}
