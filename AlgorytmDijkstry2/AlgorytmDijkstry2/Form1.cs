using System.Collections;
using System.Drawing;

namespace AlgorytmDijkstry2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawLineInt(e);
        }
        void DrawLineInt(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen linePen = new Pen(Color.Black, 2);
            Point gdansk = new Point((Size)button1.Location);
            Point olsztyn = new Point((Size)button2.Location);
            Point elk = new Point((Size)button3.Location);
            Point bialystok = new Point((Size)button4.Location);
            Point szczecin = new Point((Size)button5.Location);
            Point poznan = new Point((Size)button6.Location);
            Point warszawa = new Point((Size)button7.Location);
            Point lublin = new Point((Size)button8.Location);
            Point wroclaw = new Point((Size)button9.Location);
            Point krakow = new Point((Size)button10.Location);
            e.Graphics.DrawLine(linePen, gdansk, olsztyn);
            e.Graphics.DrawLine(linePen, olsztyn, elk);
            e.Graphics.DrawLine(linePen, elk, bialystok);
            e.Graphics.DrawLine(linePen, gdansk, szczecin);
            e.Graphics.DrawLine(linePen, szczecin, poznan);
            e.Graphics.DrawLine(linePen, szczecin, wroclaw);
            e.Graphics.DrawLine(linePen, poznan, wroclaw);
            e.Graphics.DrawLine(linePen, wroclaw, krakow);
            e.Graphics.DrawLine(linePen, krakow, lublin);
            e.Graphics.DrawLine(linePen, lublin, bialystok);
            e.Graphics.DrawLine(linePen, warszawa, elk);
            e.Graphics.DrawLine(linePen, warszawa, poznan);
            e.Graphics.DrawLine(linePen, warszawa, olsztyn);
            e.Graphics.DrawLine(linePen, warszawa, gdansk);
            e.Graphics.DrawLine(linePen, warszawa, lublin);
            e.Graphics.DrawLine(linePen, warszawa, krakow);
            e.Graphics.DrawLine(linePen, krakow, poznan);
            e.Graphics.DrawLine(linePen, gdansk, poznan);
            e.Graphics.DrawLine(linePen, warszawa, bialystok);

        }


        NodeG n0 = new NodeG(0);
        NodeG n1 = new NodeG(1);
        NodeG n2 = new NodeG(2);
        NodeG n3 = new NodeG(3);
        NodeG n4 = new NodeG(4);
        NodeG n5 = new NodeG(5);
        NodeG n6 = new NodeG(6);
        NodeG n7 = new NodeG(7);
        NodeG n8 = new NodeG(8);
        NodeG n9 = new NodeG(9);

        Graf g = new Graf();

        List<Element> tabelka = new List<Element>();

        bool kierunek = false;
        public void Form1_Load(object sender, EventArgs e)
        {
            g.Add(new Edge(n0, n1, 2));
            g.Add(new Edge(n1, n0, 2));

            g.Add(new Edge(n0, n6, 4));
            g.Add(new Edge(n6, n0, 4));

            g.Add(new Edge(n0, n5, 4));
            g.Add(new Edge(n5, n0, 4));

            g.Add(new Edge(n0, n4, 3));
            g.Add(new Edge(n4, n0, 3));

            g.Add(new Edge(n1, n2, 2));
            g.Add(new Edge(n2, n1, 2));

            g.Add(new Edge(n1, n6, 3));
            g.Add(new Edge(n6, n1, 3));

            g.Add(new Edge(n2, n6, 3));
            g.Add(new Edge(n6, n2, 3));

            g.Add(new Edge(n2, n3, 1));
            g.Add(new Edge(n3, n2, 1));

            g.Add(new Edge(n3, n7, 3));
            g.Add(new Edge(n7, n3, 3));

            g.Add(new Edge(n3, n6, 2));
            g.Add(new Edge(n6, n3, 2));

            g.Add(new Edge(n4, n5, 2));
            g.Add(new Edge(n5, n4, 2));

            g.Add(new Edge(n4, n8, 2));
            g.Add(new Edge(n8, n4, 2));

            g.Add(new Edge(n5, n6, 2));
            g.Add(new Edge(n6, n5, 2));

            g.Add(new Edge(n5, n8, 2));
            g.Add(new Edge(n8, n5, 2));

            g.Add(new Edge(n5, n9, 3));
            g.Add(new Edge(n9, n5, 3));

            g.Add(new Edge(n6, n7, 2));
            g.Add(new Edge(n7, n6, 2));

            g.Add(new Edge(n6, n9, 3));
            g.Add(new Edge(n9, n6, 3));

            g.Add(new Edge(n7, n9, 3));
            g.Add(new Edge(n9, n7, 3));

            g.Add(new Edge(n8, n9, 3));
            g.Add(new Edge(n9, n8, 3));


            label2.Text = "Czas drogi";
            label3.Text = "Wybierz skad";
            label4.Text = "Obliczanie najlepszego czasu drogi miedzy miastami";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {

                tabelka = g.AlgorytmDijkstry(n0);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 0)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;

            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {
                tabelka = g.AlgorytmDijkstry(n1);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 1)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {
                tabelka = g.AlgorytmDijkstry(n2);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 2)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {
                tabelka = g.AlgorytmDijkstry(n3);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 3)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {
                tabelka = g.AlgorytmDijkstry(n4);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 4)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {
                tabelka = g.AlgorytmDijkstry(n5);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 5)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {
                tabelka = g.AlgorytmDijkstry(n6);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 6)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {
                tabelka = g.AlgorytmDijkstry(n7);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 7)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            {
                tabelka = g.AlgorytmDijkstry(n8);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 8)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (kierunek == false)
            { 
                tabelka = g.AlgorytmDijkstry(n9);

                kierunek = true;
            }
            else if (kierunek == true)
            {
                String s = "Najszybsza trasa zajmie ";
                foreach (Element element in tabelka)
                {
                    if (element.wezel.data == 9)
                    {
                        s += element.dystans;
                    }
                }
                label2.Text = s + "h";
                kierunek = false;
            }
            if (kierunek == false) label3.Text = "Wybierz skad";
            if (kierunek == true) label3.Text = "Wybierz dokad";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
