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
using Skender.Stock.Indicators;
using YahooFinanceApi;

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
            decimal max, min;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (null != row && null != row.Cells[3].Value)
                {
                    high.Add(Convert.ToDecimal(row.Cells[3].Value.ToString()));
                }
            }

            if(dgvData.Rows.Count >= 2)
            { 
                max = high.Max();
            }

            else
            {
                max = 100;
            }

            List<decimal> low = new List<decimal>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (null != row && null != row.Cells[4].Value)
                {
                    low.Add(Convert.ToDecimal(row.Cells[4].Value.ToString()));
                }
            }

            if (dgvData.Rows.Count >= 2)
            {
                min = low.Min();
            }

            else
            {
                min = 0;
            }

            chtChart.ChartAreas["ChartArea1"].AxisY.Maximum = (double)max;
            chtChart.ChartAreas["ChartArea1"].AxisY.Minimum = (double)min;

            chtChart.ChartAreas["ChartArea1"].AxisY.Interval = ((double)max - (double)min) / 5.0;
            chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = chtChart.ChartAreas["ChartArea1"].AxisY.Interval / 2.0;
        }
        private void GenericChartScaling()
        {
            List<decimal> high = new List<decimal>();
            decimal max;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (null != row && null != row.Cells[3].Value)
                {
                    high.Add(Convert.ToDecimal(row.Cells[3].Value.ToString()));
                }
            }

            if (dgvData.Rows.Count >= 2)
            {
                max = high.Max();
            }

            else
            {
                max = 100;
            }

            chtChart.ChartAreas["ChartArea1"].AxisY.Maximum = (double)max;
            chtChart.ChartAreas["ChartArea1"].AxisY.Minimum = 0;

            chtChart.ChartAreas["ChartArea1"].AxisY.Interval = ((double)max) / 5.0;
            chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = chtChart.ChartAreas["ChartArea1"].AxisY.Interval / 2.0;
        }
        private void ScalingByMarkingArea()
        {
            chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
            chtChart.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;
            chtChart.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;

            chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = true;
            chtChart.ChartAreas["ChartArea1"].CursorY.AutoScroll = true;
            chtChart.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;
        }
        private void DisableScallingByMarkingArea()
        {
            chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = false;
            chtChart.ChartAreas["ChartArea1"].CursorX.AutoScroll = false;
            chtChart.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = false;

            chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = false;
            chtChart.ChartAreas["ChartArea1"].CursorY.AutoScroll = false;
            chtChart.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = false;
        }
        private void ZoomReset()
        {
            chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
            chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
        }
        private async Task getStockData(string symbol, DateTime startDate, DateTime endDate)
        {
            try
            {
                var historicdata = await Yahoo.GetHistoricalAsync(symbol, startDate, endDate);
                var security = await Yahoo.Symbols(symbol).Fields(Field.LongName).QueryAsync();
                var ticker = security[symbol];
                var companyName = ticker[Field.LongName];
                for (int i = 0; i < historicdata.Count; i += 1)
                {
                    stocksTableAdapter.Insert(i + 1, historicdata.ElementAt(i).Open, historicdata.ElementAt(i).Close, historicdata.ElementAt(i).High, historicdata.ElementAt(i).Low, historicdata.ElementAt(i).DateTime);
                    this.stocksTableAdapter.Fill(this.stocksDatabaseDataSet.Stocks);
                }
                chxEnableAutoscalling.Checked = false; //temporary solution
                chxEnableAutoscalling.Checked = true;
            }

            catch
            {
                MessageBox.Show($"Failed to get symbol: {symbol}", "Error");
            }
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

                chtChart.DataManipulator.IsStartFromFirst = true;
                chtChart.DataSource = stocksDatabaseDataSet.Stocks;
                chtChart.DataBind();
            }
            if (cbxChartType.SelectedIndex == 1)
            {
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

        private void cbxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChartType.SelectedIndex == 0)
            {
                chtChart.Series["Stock Value"].ChartType = SeriesChartType.Line;
                btnLoad.PerformClick();
            }
            if (cbxChartType.SelectedIndex == 1)
            {
                chtChart.Series["Stock Value"].ChartType = SeriesChartType.Stock;
                btnLoad.PerformClick();
            }
            if (cbxChartType.SelectedIndex == 2)
            {
                chtChart.Series["Stock Value"].ChartType = SeriesChartType.Candlestick;
                btnLoad.PerformClick();
            }
        }

        private void cbxIndicators_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxIndicators.SelectedIndex == 0)
            {
                Series RSI = chtIndicators.Series.Add("RSI");
                chtIndicators.Series["RSI"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["ChartArea1"].AxisY.Maximum = 100.0;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.Minimum = 0.0;

                chtIndicators.ChartAreas["ChartArea1"].AxisY.Interval = 100.0 / 10.0;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = chtIndicators.ChartAreas["ChartArea1"].AxisY.Interval / 2.0;

                //chtIndicators.ChartAreas["ChartArea1"].AxisX.Minimum = xAxisMin;
                //chtIndicators.ChartAreas["ChartArea1"].AxisX.Maximum = xAxisMax;

                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                List<DateTime> dates = new List<DateTime>();

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (null != row && null != row.Cells[5].Value)
                    {
                        dates.Add(Convert.ToDateTime(row.Cells[5].Value.ToString()));
                    }
                }

                List<double> RSIvalue = new List<double>();

                for(int i = 0; i < dates.Count(); i += 1)
                {
                    RSIvalue.Add(50.0);
                }
                
                RSI.Color = Color.Purple;
                RSI.Points.DataBindXY(dates, RSIvalue);

                //IEnumerable<RsiResult> results = quotes.GetRsi(lookbackPeriods);

                //chtIndicators.DataManipulator.IsStartFromFirst = true;
                //chtIndicators.DataSource = stocksDatabaseDataSet.Stocks;
                //chtIndicators.DataBind();*/
            }
        }

        private void chxEnableAutoscalling_CheckedChanged(object sender, EventArgs e)
        {
            if (chxEnableAutoscalling.Checked)
            {
                chxEnableScallingByMarkingArea.Enabled = false;
                ChartScaling();
                btnLoad.PerformClick();
            }

            if (!chxEnableAutoscalling.Checked)
            {
                chxEnableScallingByMarkingArea.Enabled = true;
                GenericChartScaling();
                btnLoad.PerformClick();
            }
        }

        private void chxEnableScallingByMarkingArea_CheckedChanged(object sender, EventArgs e)
        {
            if (chxEnableScallingByMarkingArea.Checked)
            {
                chxEnableAutoscalling.Enabled = false;
                ScalingByMarkingArea();
                btnLoad.PerformClick();
            }

            if (!chxEnableScallingByMarkingArea.Checked)
            {
                chxEnableAutoscalling.Enabled = true;
                DisableScallingByMarkingArea();
                ZoomReset();
                btnLoad.PerformClick();
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = ".jpeg|*.jpeg|.png|*.png|.bmp|*.bmp";
            saveFileDialog1.Title = "Save the chart as an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        chtChart.SaveImage(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Chart successfully saved as JPEG image!", "Saved");
                        break;

                    case 2:
                        chtChart.SaveImage(fs, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show("Chart successfully saved as PNG image!", "Saved");
                        break;
                    case 3:
                        chtChart.SaveImage(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        MessageBox.Show("Chart successfully saved as BMP image!", "Saved");
                        break;
                }
                fs.Close();
            }
        }

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            var symbol = txtSymbol.Text;
            int months = Convert.ToInt32(txtMonths.Text);
            DateTime enddate = DateTime.Today;
            DateTime startdate = DateTime.Today.AddMonths(-months);
            var awaiter = getStockData(symbol, startdate, enddate);
        }
    }
}
