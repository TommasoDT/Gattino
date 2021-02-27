using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTommaso.Tommaso._4J.Gattino
{
    public class Punto
    {
        private int x;
        private int y;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public Punto(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void CorreggiCoordinate(int posizioneOrigine, int pianoWidth, int pianoHeight)
        {
            if (posizioneOrigine == 0)
                y = pianoHeight - y;
            else if (posizioneOrigine == 2)
            {
                x = pianoWidth - x;
                y = pianoHeight - y;
            }
            else if (posizioneOrigine == 3)
                x = pianoWidth - x;
        }

        public void Trasla(int offsetX, int offsetY)
        {
            x = x + offsetX;
            y = y + offsetY;
        }
    }
}
