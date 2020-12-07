using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lm = new LogicalMashine();
            KBGenerator KBGenerator;
            IReadOnlyList<Entity> eneties;
            IReadOnlyList<Connection> connections;
            KBGenerator = new KBGenerator();
            connections = KBGenerator.connection;
            eneties = KBGenerator.entity;
            for (int i = 0; i<eneties.Count;i++)
            {
                comboBox1.Items.Add(eneties[i].Name);
            }
            for (int i = 0; i < eneties.Count; i++)
            {
                comboBox2.Items.Add(eneties[i].Name);
            }
            for (int i = 19; i < 28; i++)
            {
                comboBox3.Items.Add(eneties[i].Name);
            }
            for (int i = 15; i < 19; i++)
            {
                comboBox4.Items.Add(eneties[i].Name);
            }
            for (int i = 19; i < 28; i++)
            {
                comboBox5.Items.Add(eneties[i].Name);
            }
            for (int i = 4; i < 8; i++)
            {
                comboBox6.Items.Add(eneties[i].Name);
            }
            for (int i = 19; i < 28; i++)
            {
                comboBox7.Items.Add(eneties[i].Name);
            }
        }

        LogicalMashine lm;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                label5.Text = lm.HierarchicalQuestion(comboBox1.Text.ToString(), comboBox2.Text.ToString()).ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                label5.Text = lm.HierarchicalQuestion(comboBox1.Text.ToString(), comboBox2.Text.ToString()).ToString();
            }
        }
       
        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                label5.Text = lm.HierarchicalQuestion(comboBox3.Text.ToString(), comboBox4.Text.ToString()).ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                label5.Text = lm.HierarchicalQuestion(comboBox3.Text.ToString(), comboBox4.Text.ToString()).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {}

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = lm.СommunicationQuestion(comboBox5.Text.ToString()).ToString();

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text != "")
            {
                label5.Text = lm.EntityQuestion(comboBox7.Text.ToString(), comboBox6.Text.ToString()).ToString();
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text != "")
            {
                label5.Text = lm.EntityQuestion(comboBox7.Text.ToString(), comboBox6.Text.ToString()).ToString();
            }
        }
    }
}
