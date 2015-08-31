using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 性能计数器
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += (e, a) =>
            {
                this.label1.Text = performanceCounter1.NextValue().ToString();
            };
            timer.Start();
        }
    }
}
