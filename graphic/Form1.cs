using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.1;
        double DollarC, EuroC;
        int day = 1;

        Random random = new Random();

        private void predictBtn_Click(object sender, EventArgs e)
        {
                DollarC = (double)edCourse.Value;
                EuroC = (double)edEuro.Value;
                
                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(0, DollarC);
                chart1.Series[1].Points.AddXY(0, EuroC);

                timer1.Start();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DollarC = DollarC * (1 + k * (random.NextDouble() - 0.5));
            EuroC = EuroC * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(day, DollarC);
            chart1.Series[1].Points.AddXY(day, EuroC);
            day++;
        }
    }
}
