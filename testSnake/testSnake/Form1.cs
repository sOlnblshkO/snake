using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testSnake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initializeSnake();
            qe.Add("r");
            timer1.Start();
        }

        Graphics formGraphics;

        void drawMap()
        {
            formGraphics = this.CreateGraphics();
            formGraphics.Clear(Color.White);
            Pen myPen;
            myPen = new Pen(Color.Red);
            for (int x1 = 0, x2 = 0, y1 = 0, y2 = 500; x1 <= 500; x1 += 50, x2 += 50)
            {
                formGraphics.DrawLine(myPen, x1, y1, x2, y2);
            }
            for (int x1 = 0, x2 = 500, y1 = 0, y2 = 0; y1 <= 500; y1 += 50, y2 += 50)
            {
                formGraphics.DrawLine(myPen, x1, y1, x2, y2);
            }
            myPen.Dispose();
            formGraphics.Dispose();
        }

        List<int> x1 = new List<int>();
        List<int> y1 = new List<int>();
        List<string> qe = new List<string>();

        void initializeSnake()
        {
            x1.Add(100);
            x1.Add(50);
            x1.Add(0);
            y1.Add(0);
            y1.Add(0);
            y1.Add(0);
        }

        public void drawSnake()
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            SolidBrush snakeHead = new SolidBrush(Color.Black);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(snakeHead, new Rectangle(x1[0], y1[0], 50, 50));
            for (int i = 1; i < x1.Count; i++)
            {
                formGraphics.FillRectangle(myBrush, new Rectangle(x1[i], y1[i], 50, 50));
            }
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        void moveSnake()
        {
            int x = 0, y = 0;
            for (int i = 1; i < x1.Count; i++)
            {
                if (x1[i] == x1[0] && y1[i] == y1[0])
                {
                    timer1.Stop();
                    MessageBox.Show("You loose!!! ");
                }
            }
            if (qe.Last() == "r")
            {
                if (x1[0] == xs * 50 && y1[0] == ys * 50)
                {
                    ready = false;
                }
                if (x1[0] + 50 != 500)
                {
                    x = x1[0];
                    y = y1[0];
                    x1[0] += 50;
                }
                else
                {
                    x = x1[0];
                    y = y1[0];
                    x1[0] = 0;
                }
            }
            else if (qe.Last() == "l")
            {
                if (x1[0] == xs * 50 && y1[0] == ys * 50)
                {
                    ready = false;
                }
                if (x1[0] - 50 != -50)
                {
                    x = x1[0];
                    y = y1[0];
                    x1[0] -= 50;
                }
                else
                {
                    x = x1[0];
                    y = y1[0];
                    x1[0] = 450;
                }
            }
            else if (qe.Last() == "d")
            {
                if (x1[0] == xs * 50 && y1[0] == ys * 50)
                {
                    ready = false;
                }
                if (y1[0] + 50 != 500)
                {
                    x = x1[0];
                    y = y1[0];
                    y1[0] += 50;
                }
                else
                {
                    x = x1[0];
                    y = y1[0];
                    y1[0] = 0;
                }
            }
            else if (qe.Last() == "u")
            {
                if (x1[0] == xs * 50 && y1[0] == ys * 50)
                {
                    ready = false;
                }
                if (y1[0] - 50 != -50)
                {
                    x = x1[0];
                    y = y1[0];
                    y1[0] -= 50;
                }
                else
                {
                    x = x1[0];
                    y = y1[0];
                    y1[0] = 450;
                }
            }
            if (ready == false)
            {
                increase();
                for (int i = x1.Count - 2; i > 1; i--)
                {
                    x1[i] = x1[i - 1];
                    y1[i] = y1[i - 1];
                }
                x1[1] = x;
                y1[1] = y;
                while (createSweet() != 1) ;
            }
            else
            {
                for (int i = x1.Count - 1; i > 1; i--)
                {
                    x1[i] = x1[i - 1];
                    y1[i] = y1[i - 1];
                }
                x1[1] = x;
                y1[1] = y;
            }
        }

        int xs, ys;

        Boolean ready = false;

        void randomSweet()
        {
            Random rnd = new Random();
            xs = rnd.Next(0, 9);
            ys = rnd.Next(0, 9);
        }

        int createSweet()
        {
            if (ready == false)
            {
                randomSweet();
                for (int i = 0; i < x1.Count; i++)
                {
                    if (x1[i] == xs * 50 && y1[i] == ys * 50)
                        return 0;
                }
                SolidBrush sweetBrush = new SolidBrush(Color.Yellow);
                formGraphics = this.CreateGraphics();
                formGraphics.FillRectangle(sweetBrush, new Rectangle(xs * 50, ys * 50, 50, 50));
                ready = true;
                return 1;
            }
            else
            {
                SolidBrush sweetBrush = new SolidBrush(Color.Yellow);
                formGraphics = this.CreateGraphics();
                formGraphics.FillRectangle(sweetBrush, new Rectangle(xs * 50, ys * 50, 50, 50));
                return 1;
            }
        }

        void increase()
        {
            x1.Add(x1[x1.Count - 1]);
            y1.Add(y1[y1.Count - 1]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawMap();
            while (createSweet() != 1);
            drawSnake();
            moveSnake();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd' || e.KeyChar == 'D' || e.KeyChar == 'в' || e.KeyChar == 'В')
            {
                if (!qe.Last().Equals("l"))
                qe.Add("r");
            }
            if (e.KeyChar == 'a' || e.KeyChar == 'A' || e.KeyChar == 'Ф' || e.KeyChar == 'ф')
            {
                if (!qe.Last().Equals("r"))
                    qe.Add("l");
            }
            if (e.KeyChar == 's' || e.KeyChar == 'S' || e.KeyChar == 'Ы' || e.KeyChar == 'ы')
            {
                if (!qe.Last().Equals("u"))
                    qe.Add("d");
            }
            if (e.KeyChar == 'w' || e.KeyChar == 'W' || e.KeyChar == 'Ц' || e.KeyChar == 'ц')
            {
                if (!qe.Last().Equals("d"))
                    qe.Add("u");
            }
        }
    }
    public partial class MyButton : Button
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Right)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }
    }
}
