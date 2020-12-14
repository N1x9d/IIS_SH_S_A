using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeiroNetTest
{
    public partial class Form1 : Form
    {
        static int CountElementN = 12;
        static int SizeElementN = 30;
        static int CountElementM = 12;
        static int SizeElementM = 30;
        static bool stateЬMouseDown = false;

        Bitmap flag;
        Graphics flagGraphics;
        int[,] flagelement = new int[CountElementN, CountElementM];

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(CountElementN * SizeElementN, CountElementM * SizeElementM);
            this.Controls.Add(pictureBox1);
            flag = new Bitmap(CountElementN * SizeElementN, CountElementM * SizeElementM);
            flagGraphics = Graphics.FromImage(flag);
            textBox1.Text = "12";
            textBox2.Text = "12";
            textBox3.Text = "30";
            textBox4.Text = "30";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CountElementN =Convert.ToInt32(textBox1.Text);
            SizeElementN = Convert.ToInt32(textBox3.Text);
            CountElementM = Convert.ToInt32(textBox2.Text);
            SizeElementM = Convert.ToInt32(textBox4.Text);
            pictureBox1.Image = null;
            pictureBox1.Size = new Size(CountElementN * SizeElementN, CountElementM * SizeElementM);
            this.Controls.Add(pictureBox1);
            flag = new Bitmap(CountElementN * SizeElementN, CountElementM * SizeElementM);
            flagGraphics = Graphics.FromImage(flag);
            flagelement = new int[CountElementN, SizeElementM];
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            stateЬMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            stateЬMouseDown = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (stateЬMouseDown == true)
            {
                try
                {
                    double px = e.X;
                    double py = e.Y;
                    int x = Convert.ToInt32(Math.Floor(px / SizeElementN));
                    int y = Convert.ToInt32(Math.Floor(py / SizeElementM));
                    flagelement[x, y] = 1;
                    flagGraphics.FillRectangle(Brushes.Black, x * SizeElementN, y * SizeElementM, SizeElementN, SizeElementM);
                    pictureBox1.Image = flag;
                }
                catch(System.IndexOutOfRangeException) { MessageBox.Show("Куды повел"); stateЬMouseDown = false; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Size = new Size(CountElementN * SizeElementN, CountElementM * SizeElementM);
            this.Controls.Add(pictureBox1);
            flag = new Bitmap(CountElementN * SizeElementN, CountElementM * SizeElementM);
            flagGraphics = Graphics.FromImage(flag);
            flagelement = new int[CountElementN, SizeElementM];
        }
    }
}
