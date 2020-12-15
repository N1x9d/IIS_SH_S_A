using System;
using System.Drawing;
using System.Windows.Forms;
using Csv;
using System.IO;
using System.Collections.Generic;

namespace NeiroNetTest
{
    public partial class Form1 : Form
    {
        static int CountElementN = 12;
        static int SizeElementN = 30;
        static int CountElementM = 12;
        static int SizeElementM = 30;
        static bool stateЬMouseDown = false;
        int schet = 1;
        List<int[]> dataForOpen = new List<int[]>();

        Bitmap flag;
        Graphics flagGraphics;
        int[,] flagelement = new int[CountElementN, CountElementM];
        Layer ll = new Layer();

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
            textBox5.Text = schet.ToString();
            textBox5.Visible = false;
            button3.Visible = false;
            for (int i=0; i<10; i++)
            {
                for (int k=1; k<11; k++)
                {
                    string path = "F:\\4 курс\\1 семестр\\ИСИТ\\Цифры\\" + i + "_" + k + ".csv";
                    OpenData(path);
                    int[,] element = new int[CountElementN, CountElementM];
                    for (int p = 0; p < CountElementN; p++)
                    {

                        for (int n = 0; n < CountElementM; n++)
                        {
                            element[p, n] = dataForOpen[p][n];
                        }
                    }
                   
                    ll.autoLearning(element, i, 7);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CountElementN = Convert.ToInt32(textBox1.Text);
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
                catch (System.IndexOutOfRangeException) { MessageBox.Show("Куды повел"); stateЬMouseDown = false; }
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

        public void SaveData()
        {
            string path = "F:\\4 курс\\1 семестр\\ИСИТ\\Цифры\\распознать.csv";
            TextWriter tw = new StreamWriter(path);
            List<string[]> dataForSave = new List<string[]>();
            string[] one = new string[12];
            for (int i = 0; i < CountElementN; i++)
            {                
                string[] lol = new string[12];
                for (int k = 0; k < CountElementM; k++)
                {                    
                    //if (i==0) one[k] = flagelement[k, i].ToString();
                    /*else*/ lol[k] = flagelement[k, i].ToString();
                }
                /*if (lol[0]!=null) */dataForSave.Add(lol);
            }
            var headers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            CsvWriter.Write(tw, headers, /*one,*/ dataForSave, ';');
            tw.Close();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SaveData();
            //button2_Click(sender, e);
            //schet++;
            //textBox5.Text = schet.ToString();
        }

        public void OpenData(string path)
        {
            dataForOpen.Clear();
            var csv = File.ReadAllText(path); //*"F:\\4 курс\\1 семестр\\ИСИТ\\Цифры\\" + schet.ToString() + ".csv");
            foreach (var line in CsvReader.ReadFromText(csv))
            {               
                var o = line["1"];
                var dv = line["2"];
                var t = line["3"];
                var ch = line["4"];
                var p = line["5"];
                var sh = line["6"];
                var s = line["7"];
                var v = line["8"];
                var dev = line["9"];
                var des = line["10"];
                var odin = line["11"];
                var dven = line["12"];
                int[] mass = new int[] { Convert.ToInt32(o), Convert.ToInt32(dv), Convert.ToInt32(t), Convert.ToInt32(ch), Convert.ToInt32(p), Convert.ToInt32(sh), Convert.ToInt32(s), Convert.ToInt32(v), Convert.ToInt32(dev), Convert.ToInt32(des), Convert.ToInt32(odin), Convert.ToInt32(dven) };
                dataForOpen.Add(mass); 
            }

            //for (int i = 0; i < CountElementN; i++)
            //{
            //    string[] lol = new string[12];
            //    for (int k = 0; k < CountElementM; k++)
            //    {
            //        //if (i==0) one[k] = flagelement[k, i].ToString();
            //        /*else*/
            //        //lol[k] = flagelement[k, i].ToString();
            //        flagelement[i, k] = 1;
            //    }
            //    /*if (lol[0]!=null) */
            //    dataForSave.Add(lol);
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //OpenData();
            //int[,] element = new int[CountElementN, CountElementM];
            //for (int i = 0; i < CountElementN; i++)
            //{
                
            //    for (int k = 0; k < CountElementM; k++)
            //    {
            //        element[i, k] = dataForOpen[i][k];
            //    }                
            //}
            string path = "F:\\4 курс\\1 семестр\\ИСИТ\\Цифры\\распознать.csv";
            SaveData();
            OpenData(path);
            int[,] element = new int[CountElementN, CountElementM];
            for (int p = 0; p < CountElementN; p++)
            {

                for (int n = 0; n < CountElementM; n++)
                {
                    element[p, n] = dataForOpen[p][n];
                }
            }
            //Layer ll = new Layer();
            ll.RunNet(element);
        }
    }
}
