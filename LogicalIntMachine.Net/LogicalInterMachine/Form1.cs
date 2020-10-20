using LogicalInterfaceMachine;
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
        public Form1()
        {
            InitializeComponent();
            logicalMachine = new LogicalMachine();
            logicalMachine.LoadKnowladgeBasw("KnowledgeBase.xml");
            
        }
        LogicalMachine logicalMachine;
    }
}
