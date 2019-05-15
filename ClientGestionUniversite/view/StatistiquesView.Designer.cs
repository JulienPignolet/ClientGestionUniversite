using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGestionUniversite.view
{
    public partial class StatistiquesView
    {


        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.column = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.column)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartT)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // column
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.column.ChartAreas.Add(chartArea1);
            this.column.Dock = System.Windows.Forms.DockStyle.Fill;
            this.column.Location = new System.Drawing.Point(3, 3);
            this.column.Name = "column";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Name = "Series1";
            series1.ToolTip = "#VALY1{#.##}%";
            this.column.Series.Add(series1);
            this.column.Size = new System.Drawing.Size(482, 397);
            this.column.TabIndex = 0;
            this.column.Text = "Column";
            title1.Name = "Title1";
            title1.Text = "Taux d\'affectation des heures de cours par UE";
            this.column.Titles.Add(title1);
            // 
            // chartT
            // 
            chartArea2.Name = "ChartArea1";
            this.chartT.ChartAreas.Add(chartArea2);
            this.chartT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartT.Location = new System.Drawing.Point(491, 3);
            this.chartT.Name = "chartT";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Series2";
            this.chartT.Series.Add(series2);
            this.chartT.Series.Add(series3);
            this.chartT.Size = new System.Drawing.Size(482, 397);
            this.chartT.TabIndex = 2;
            this.chartT.Text = "Pie";
            title2.Name = "Title1";
            title2.Text = "Affectation des cours par personnes";
            this.chartT.Titles.Add(title2);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Année",
            "Période",
            "UE",
            "EC"});
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.chartT, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.column, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(976, 416);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // StatistiquesView
            // 
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Form1";
            this.Size = new System.Drawing.Size(976, 416);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.column)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartT)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart column;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartT;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
