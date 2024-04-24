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
using System.Data.SqlClient;

namespace StockManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChartScaling()
        {
            List<decimal> high = new List<decimal>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (null != row && null != row.Cells[3].Value)
                {
                    high.Add(Convert.ToDecimal(row.Cells[3].Value.ToString()));
                }
            }

            decimal max = high.Max();

            List<decimal> low = new List<decimal>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (null != row && null != row.Cells[4].Value)
                {
                    low.Add(Convert.ToDecimal(row.Cells[4].Value.ToString()));
                }
            }

            decimal min = low.Min();

            chtChart.ChartAreas["ChartArea1"].AxisY.Maximum = (double)max;
            chtChart.ChartAreas["ChartArea1"].AxisY.Minimum = (double)min;

            chtChart.ChartAreas["ChartArea1"].AxisY.Interval = ((double)max - (double)min) / 5.0;
            chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = chtChart.ChartAreas["ChartArea1"].AxisY.Interval / 2.0;

            btnScalingReset.Enabled = false;
        }

        private void GenericChartScaling()
        {
            List<decimal> high = new List<decimal>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (null != row && null != row.Cells[3].Value)
                {
                    high.Add(Convert.ToDecimal(row.Cells[3].Value.ToString()));
                }
            }

            decimal max = high.Max();

            chtChart.ChartAreas["ChartArea1"].AxisY.Maximum = (double)max;
            chtChart.ChartAreas["ChartArea1"].AxisY.Minimum = 0;

            chtChart.ChartAreas["ChartArea1"].AxisY.Interval = ((double)max) / 5.0;
            chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = chtChart.ChartAreas["ChartArea1"].AxisY.Interval / 2.0;

            btnScalingReset.Enabled = true;
        }

        private void ScalingByMarkingArea()
        {
            chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
            chtChart.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;
            chtChart.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;

            chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = true;
            chtChart.ChartAreas["ChartArea1"].CursorY.AutoScroll = true;
            chtChart.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;

            btnZoomReset.Enabled = false;
        }

        private void DisableScallingByMarkingArea()
        {
            chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = false;
            chtChart.ChartAreas["ChartArea1"].CursorX.AutoScroll = false;
            chtChart.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = false;

            chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = false;
            chtChart.ChartAreas["ChartArea1"].CursorY.AutoScroll = false;
            chtChart.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = false;

            btnZoomReset.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.stocksTableAdapter.Fill(this.stocksDatabaseDataSet.Stocks);
            chxEnableAutoscalling.Checked = true;
            btnLoad.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                stocksBindingSource.EndEdit();
                stocksTableAdapter.Update(stocksDatabaseDataSet.Stocks);
                dgvData.Refresh();
                MessageBox.Show("Your data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cbxChartType.SelectedIndex == 0)
            {
                if (chxEnableAutoscalling.Checked)
                {
                    ChartScaling();
                }

                if (!chxEnableAutoscalling.Checked)
                {
                    GenericChartScaling();
                }

                if (chxEnableScallingByMarkingArea.Checked)
                {
                    ScalingByMarkingArea();
                }

                if (!chxEnableScallingByMarkingArea.Checked)
                {
                    DisableScallingByMarkingArea();
                }

                chtChart.Series["Stock Value"].ChartType = SeriesChartType.Line;

                chtChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                //chtChart.ChartAreas["ChartArea1"].AxisX.Minimum = xAxisMin;
                //chtChart.ChartAreas["ChartArea1"].AxisX.Maximum = xAxisMax;

                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtChart.Legends.Clear();

                chtChart.Series["Stock Value"].XValueMember = "Date";
                chtChart.Series["Stock Value"].YValueMembers = "Close";
                chtChart.Series["Stock Value"].XValueType = ChartValueType.Date;
                chtChart.Series["Stock Value"]["ShowOpenClose"] = "Both";

                chtChart.DataManipulator.IsStartFromFirst = true;
                chtChart.DataSource = stocksDatabaseDataSet.Stocks;
                chtChart.DataBind();
            }

            if (cbxChartType.SelectedIndex == 1)
            {
                if (chxEnableAutoscalling.Checked)
                {
                    ChartScaling();
                }

                if (!chxEnableAutoscalling.Checked)
                {
                    GenericChartScaling();
                }

                if (chxEnableScallingByMarkingArea.Checked)
                {
                    ScalingByMarkingArea();
                }

                if (!chxEnableScallingByMarkingArea.Checked)
                {
                    DisableScallingByMarkingArea();
                }

                chtChart.Series["Stock Value"].ChartType = SeriesChartType.Stock;

                chtChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                //chtChart.ChartAreas["ChartArea1"].AxisX.Minimum = xAxisMin;
                //chtChart.ChartAreas["ChartArea1"].AxisX.Maximum = xAxisMax;

                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtChart.Legends.Clear();

                chtChart.Series["Stock Value"].XValueMember = "Date";
                chtChart.Series["Stock Value"].YValueMembers = "High,Low,Open,Close";
                chtChart.Series["Stock Value"].XValueType = ChartValueType.Date;
                chtChart.Series["Stock Value"]["ShowOpenClose"] = "Both";

                chtChart.DataManipulator.IsStartFromFirst = true;
                chtChart.DataSource = stocksDatabaseDataSet.Stocks;
                chtChart.DataBind();
            }

            if (cbxChartType.SelectedIndex == 2)
            {
                if (chxEnableAutoscalling.Checked)
                {
                    ChartScaling();
                }

                if (!chxEnableAutoscalling.Checked)
                {
                    GenericChartScaling();
                }

                if (chxEnableScallingByMarkingArea.Checked)
                {
                    ScalingByMarkingArea();
                }

                if (!chxEnableScallingByMarkingArea.Checked)
                {
                    DisableScallingByMarkingArea();
                }

                chtChart.Series["Stock Value"].ChartType = SeriesChartType.Candlestick;

                chtChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                //chtChart.ChartAreas["ChartArea1"].AxisX.Minimum = xAxisMin;
                //chtChart.ChartAreas["ChartArea1"].AxisX.Maximum = xAxisMax;

                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtChart.Legends.Clear();

                chtChart.Series["Stock Value"].XValueMember = "Date";
                chtChart.Series["Stock Value"].YValueMembers = "High,Low,Open,Close";
                chtChart.Series["Stock Value"].XValueType = ChartValueType.Date;
                chtChart.Series["Stock Value"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
                chtChart.Series["Stock Value"]["ShowOpenClose"] = "Both";

                chtChart.DataManipulator.IsStartFromFirst = true;
                chtChart.DataSource = stocksDatabaseDataSet.Stocks;
                chtChart.DataBind();
            }
        }

        private void btnZoomReset_Click(object sender, EventArgs e)
        {
            chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
            chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
        }

        private void btnScalingReset_Click(object sender, EventArgs e)
        {
            List<decimal> high = new List<decimal>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (null != row && null != row.Cells[3].Value)
                {
                    high.Add(Convert.ToDecimal(row.Cells[3].Value.ToString()));
                }
            }

            decimal max = high.Max();

            chtChart.ChartAreas["ChartArea1"].AxisY.Maximum = (double)max;
            chtChart.ChartAreas["ChartArea1"].AxisY.Minimum = 0;

            chtChart.ChartAreas["ChartArea1"].AxisY.Interval = ((double)max) / 5.0;
            chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = chtChart.ChartAreas["ChartArea1"].AxisY.Interval / 2.0;
        }
    }
}
