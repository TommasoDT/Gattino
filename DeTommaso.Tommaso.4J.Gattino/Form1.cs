using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace DeTommaso.Tommaso._4J.Gattino
{
    public partial class Gattino : Form
    {
        public Gattino()
        {
            InitializeComponent();
        }

        Figura gattino;

        Graphics graphics;
        Pen blackPen;
        Pen whitePen;
        Pen bluePen;

        private void Gattino_Load(object sender, EventArgs e)
        {
            graphics = areaDisegno.CreateGraphics();
            blackPen = new Pen(Color.Black, 2);
            whitePen = new Pen(Color.White, 2);
            bluePen = new Pen(Color.Blue, 2);

            gattino = new Figura();
            StreamReader streamReader = new StreamReader("./gattino.txt");
            while (!streamReader.EndOfStream)
            {
                string[] strCoordinate = streamReader.ReadLine().Split(',');
                string[] strCoordinateSuccessive = streamReader.ReadLine().Split(',');

                int x1, y1, x2, y2;
                int.TryParse(strCoordinate[0], out x1);
                int.TryParse(strCoordinate[1], out y1);
                int.TryParse(strCoordinateSuccessive[0], out x2);
                int.TryParse(strCoordinateSuccessive[1], out y2);

                gattino.AggiungiLinea(x1, y1, x2, y2);
            }
            streamReader.Close();

            //Ciclo per aggiustare le coordinate avendo come origine l'angolo in basso a sinistra
            for(int i = 0; i < gattino.Linee.Count; i++)
            {
                gattino.Linee[i].Start.CorreggiCoordinate(0, areaDisegno.Width, areaDisegno.Height);
                gattino.Linee[i].End.CorreggiCoordinate(0, areaDisegno.Width, areaDisegno.Height);
            }
        }

        private void areaDisegno_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);
            graphics.DrawRectangle(blackPen, 0, 0, areaDisegno.Width - 1, areaDisegno.Height - 1);

            for (int i = 1; i < gattino.Linee.Count; i++)
            {
                graphics.DrawLine(blackPen, gattino.Linee[i - 1].Start.X, gattino.Linee[i - 1].Start.Y, gattino.Linee[i - 1].End.X, gattino.Linee[i - 1].End.Y);
                //Rende nera la riga disegnata in precedenza
                graphics.DrawLine(bluePen, gattino.Linee[i].Start.X, gattino.Linee[i].Start.Y, gattino.Linee[i].End.X, gattino.Linee[i].End.Y);
                //Disegna la riga attuale di colore blu
                Thread.Sleep(100);
                //Disegna una riga ogni 100ms
            }

            Thread.Sleep(1000);

            Figura fotogramma = gattino;
            for (int numFoto = 0; numFoto < 60; numFoto++)
            {
                //Renderizza un fotogramma ogni 100ms
                Thread.Sleep(10);

                graphics.Clear(Color.Black);
                graphics.DrawRectangle(blackPen, 0, 0, areaDisegno.Width - 1, areaDisegno.Height - 1);

                for (int i = 0; i < gattino.Linee.Count; i++)
                {
                    graphics.DrawLine(whitePen, gattino.Linee[i].Start.X, gattino.Linee[i].Start.Y, gattino.Linee[i].End.X, gattino.Linee[i].End.Y);
                }

                fotogramma = fotogramma.FiguraTraslata(10, -10);
            }

            Thread.Sleep(2000);

            this.BackColor = Color.Black;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }
    }
}
