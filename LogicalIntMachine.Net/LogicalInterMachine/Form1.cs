using LogicalInterfaceMachine;
using LogicalInterMachine.InterfaceMachine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicalInterMachine
{
    public partial class Form1 : Form
    {
        LogicalMachine logicalMachine;

        public Form1()
        {
            InitializeComponent();
            logicalMachine = new LogicalMachine();
            logicalMachine.LoadKnowladgeBasw();
            logicalMachine.GetCurentRuler();
            textBox1.Text = logicalMachine.CurQuestion;
            if (logicalMachine.AnswersWays.Count>1)
            {
                for (int i=0; i< logicalMachine.AnswersWays.Count;i++)
                {
                    comboBox1.Items.Add(logicalMachine.AnswersWays[i]);
                }
            }
            else
            {
                comboBox1.Items.Add("yes");
                comboBox1.Items.Add("no");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (logicalMachine.ResaltAnswer != null)
            {
                textBox2.Text = logicalMachine.ResaltAnswer;
            }
            //else
            //{
                
                bool otvet = false;

                if (comboBox1.SelectedItem.ToString() == "yes" || comboBox1.SelectedItem.ToString() == "no")
                {
                    if (comboBox1.SelectedItem.ToString() == "yes") otvet = true;
                    if (comboBox1.SelectedItem.ToString() == "no") otvet = false;
                    UserAnswer userAnswer = new UserAnswer(otvet);
                    logicalMachine.AddDataFromUser(userAnswer);
                }
                else
                {
                    UserAnswer userAnswer = new UserAnswer(comboBox1.SelectedItem.ToString());
                    logicalMachine.AddDataFromUser(userAnswer);
                }

                logicalMachine.GetCurentRuler();
                textBox1.Text = logicalMachine.CurQuestion;
                comboBox1.Items.Clear();

                if (logicalMachine.AnswersWays.Count > 1)
                {
                    for (int i = 0; i < logicalMachine.AnswersWays.Count; i++)
                    {
                        comboBox1.Items.Add(logicalMachine.AnswersWays[i]);
                    }
                }
                else
                {
                    comboBox1.Items.Add("yes");
                    comboBox1.Items.Add("no");
                }
            //}

        }
    }
}
