using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Runner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 0;
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = true;

            //Load the drop down box with the available projects
            var type = typeof(IRunnable);
            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.Name != "IRunnable");

            foreach (var item in types)
            {
                comboBox1.Items.Add(item);
	        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 1;
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = true;

            var t = comboBox1.SelectedItem as Type;
            IRunnable instance = Activator.CreateInstance(t) as IRunnable;
            output.Text = instance.Run(input.Text);

            progressBar1.MarqueeAnimationSpeed = 0;
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
        }
    }
}
