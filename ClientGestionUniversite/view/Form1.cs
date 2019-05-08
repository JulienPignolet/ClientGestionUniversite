using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClientGestionUniversite.view
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateCharts();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            updateCharts();
        }

        private void updateCharts()
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            //chart1.Series["Series1"].Points[0].SetValueXY(1, 12);
            chart1.Series["Series1"].Points.AddXY("L3", 25);
            chart1.Series["Series1"].Points[0].Color = Color.Red;
            chart1.Series["Series1"].Points.AddXY("M1", 35);
            chart1.Series["Series1"].Points.AddXY("M2 SID", 65);
            chart1.Series["Series1"].Points.AddXY("M2 GI", 75);

            /*
            Random rdn = new Random();
            for (int i = 116; i > 0; i--)
            {
                chart1.Series["Series1"].Points.AddXY
                    (rdn.Next(0, 10), rdn.Next(0, 10));
            }
             * */

            //chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
            //chart1.Series["Series1"].Color = Color.Red;
        }
    }
}
