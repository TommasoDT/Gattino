using System;
using System.Drawing;
using System.Collections.Generic;

namespace DeTommaso.Tommaso._4J.Gattino
{
    public class Figura
    {
        private List<Linea> linee;
        public List<Linea> Linee
        {
            get 
            { 
                return linee; 
            } 
            set
            {
                linee = value;
            }
        }
        public bool Disegnabile
        {
            get
            {
                if (linee.Count >= 3)
                    return true;
                else
                    return false;
            }
        }

        public Figura(List<Linea> _linee)
        {
            linee = _linee;
        }

        public Figura() : this(new List<Linea>()) { }

        public Figura(List<Punto> _punti) : this()
        {
            for(int i = 0; i < (_punti.Count - 1); i++)
                AggiungiLinea(_punti[i], _punti[i + 1]);
            AggiungiLinea(_punti[_punti.Count - 1], _punti[0]);
        }

        public void AggiungiLinea(Linea l)
        {
            linee.Add(l);
        }

        public void AggiungiLinea(Punto start, Punto end)
        {
            AggiungiLinea(new Linea(start, end));
        }

        public void AggiungiLinea(int x1, int y1, int x2, int y2)
        {
            AggiungiLinea(new Punto(x1, y1), new Punto(x2, y2));
        }

        public Figura FiguraTraslata(int xOffset, int yOffset)
        {
            Figura figuraTraslata = this;

            for (int i = 0; i < figuraTraslata.Linee.Count; i++)
            {
                figuraTraslata.Linee[i].Start.Trasla(xOffset, yOffset);
                figuraTraslata.Linee[i].End.Trasla(xOffset, yOffset);
            }

            return figuraTraslata;
        }
    }
}
