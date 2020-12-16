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
            button3.Visible = true;
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
                    flagGraphics.FillRectangle(Brushes.Black, x * SizeElementN, y * SizeElementM, SizeElementN,
                        SizeElementM);
                    pictureBox1.Image = flag;
                }
                catch (System.IndexOutOfRangeException)
                {
                    MessageBox.Show("Куды повел");
                    stateЬMouseDown = false;
                }
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
                    /*else*/
                    lol[k] = flagelement[k, i].ToString();
                }

                /*if (lol[0]!=null) */
                dataForSave.Add(lol);
            }

            var headers = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"};
            CsvWriter.Write(tw, headers, /*one,*/ dataForSave, ';');
            tw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = folderBrowserDialog1.SelectedPath;
            List<int[,]> numbers=new List<int[,]>();
            for (int j = 0; j < 10; j++)
            {numbers.Clear();
                for (int i = 0; i < 10; i++)
                {
                    numbers.Add(OpenData(filename + $@"\{i}_{j + 1}.csv"));
                }
                ll.autoLearning(numbers, 10000);
            }

            button3.Enabled = true;
        }

        public int[,] OpenData(string path)
        {
            int[,] res = new int[12, 12];
            int i = 0;
            dataForOpen.Clear();
            var csv = File.ReadAllText(path); //*"F:\\4 курс\\1 семестр\\ИСИТ\\Цифры\\" + schet.ToString() + ".csv");
            foreach (var line in CsvReader.ReadFromText(csv))
            {
                res[i, 0] = Convert.ToInt32(line["1"]);
                res[i, 1] = Convert.ToInt32(line["2"]);
                res[i, 2] = Convert.ToInt32(line["3"]);
                res[i, 3] = Convert.ToInt32(line["4"]);
                res[i, 4] = Convert.ToInt32(line["5"]);
                res[i, 5] = Convert.ToInt32(line["6"]);
                res[i, 6] = Convert.ToInt32(line["7"]);
                res[i, 7] = Convert.ToInt32(line["8"]);
                res[i, 8] = Convert.ToInt32(line["9"]);
                res[i, 9] = Convert.ToInt32(line["10"]);
                res[i, 10] = Convert.ToInt32(line["11"]);
                res[i, 11] = Convert.ToInt32(line["12"]);
                i++;
            }

            return res;
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
            //Layer ll = new Layer();

            textBox5.Visible = true;
            textBox5.Text = ll.RunNet(flagelement).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ll.manualLearning(flagelement,Convert.ToInt32(textBox5.Text));
        }
    }
}