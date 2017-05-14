using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blijdorp
{
    interface Klant : Option
    {
        
    }

    class Volwassene : Klant
    {
        private bool online;
        public bool gehandicapt;

        public Volwassene(bool online, bool gehandicapt)
        {
            this.online = online;
            this.gehandicapt = gehandicapt;
        }

        public bool Online()
        {
            return online;
        }

        public U Visit<U>(OptionVisitor<U> visitor)
        {
            return visitor.onVolwassene(this);
        }
    }

    class Kind : Klant
    {
        private bool online;
        public bool gehandicapt;

        public Kind(bool online, bool gehandicapt)
        {
            this.online = online;
            this.gehandicapt = gehandicapt;
        }
        public bool Online()
        {
            return online;
        }
        public U Visit<U>(OptionVisitor<U> visitor)
        {
           return visitor.onKind(this);
        }
    }

    class Baby : Klant
    {
        public U Visit<U>(OptionVisitor<U> visitor)
        {
           return visitor.onBaby(this);
        }
    }
    class Abonnee : Klant
    {
        public bool gehandicapt;
       
        public Abonnee(bool gehandicapt)
        {
            this.gehandicapt = gehandicapt;
        }
        public U Visit<U>(OptionVisitor<U> visitor)
        {
            return visitor.onAbonnee(this);
        }
    }
 
    class Bergeleider : Klant
    {
        public U Visit<U>(OptionVisitor<U> visitor)
        {
            return visitor.onBergeleider(this);
        }
    }
}
