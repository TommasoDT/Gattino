using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DeTommaso.Tommaso._4J.Gattino
{
    public class Linea
    {
        private Punto start;
        private Punto end;

        public Punto Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        public Punto End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }

        public Linea(Punto _start, Punto _end)
        {
            start = _start;
            end = _end;
        }
    }
}
