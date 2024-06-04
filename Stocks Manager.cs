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
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

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
            if (dgvData.Rows.Count > 30)
            {
                chtChart.ChartAreas["ChartArea1"].AxisX.Interval = 30;
            }

            if (dgvData.Rows.Count <= 30)
            {
                chtChart.ChartAreas["ChartArea1"].AxisX.Interval = dgvData.Rows.Count;
            }

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
            if (dgvData.Rows.Count > 30)
            {
                chtChart.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                chtChart.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 30;
            }

            if (dgvData.Rows.Count <= 30)
            {
                chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = dgvData.Rows.Count;
            }

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
        private void FullZoomReset()
        {
            while (chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.IsZoomed || chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.IsZoomed)
            {
                if (chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.IsZoomed)
                {
                    chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
                }

                if (chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.IsZoomed)
                {
                    chtChart.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
                }
            }

            if (dgvData.Rows.Count > 30)
            {
                chtChart.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                chtChart.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 30;
            }

            if (dgvData.Rows.Count <= 30)
            {
                chtChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = dgvData.Rows.Count;
            }
        }
        private void PrepareJson()
        {
            List<object> stockObjects = new List<object>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var Stock = new
                    {
                        Date = row.Cells[5].Value,
                        Open = row.Cells[1].Value,
                        High = row.Cells[3].Value,
                        Low = row.Cells[4].Value,
                        Close = row.Cells[2].Value,
                        Volume = row.Cells[6].Value,
                    };
                    stockObjects.Add(Stock);
                }
            }
            var jsonwr = JsonConvert.SerializeObject(stockObjects, Formatting.Indented);
            File.WriteAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json", jsonwr);
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
                    stocksTableAdapter.Insert(i + 1, historicdata.ElementAt(i).Open, historicdata.ElementAt(i).Close, historicdata.ElementAt(i).High, historicdata.ElementAt(i).Low, historicdata.ElementAt(i).DateTime, Convert.ToInt32(historicdata.ElementAt(i).Volume));
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

                chtChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtChart.Legends.Clear();

                chtChart.Series["Stock Value"].YAxisType = AxisType.Primary;
                chtChart.Series["Stock Value"].XValueMember = "Date";
                chtChart.Series["Stock Value"].YValueMembers = "Close";
                chtChart.Series["Stock Value"].XValueType = ChartValueType.DateTime;

                chtChart.Series["Volume"].YAxisType = AxisType.Secondary;
                chtChart.Series["Volume"].XValueMember = "Date";
                chtChart.Series["Volume"].YValueMembers = "Volume";
                chtChart.Series["Volume"].XValueType = ChartValueType.DateTime;
                chtChart.Series["Volume"].Color = Color.FromArgb(70, 150, 150, 150);

                chtChart.DataManipulator.IsStartFromFirst = true;
                chtChart.DataSource = stocksDatabaseDataSet.Stocks;
                chtChart.DataBind();
            }
            if (cbxChartType.SelectedIndex == 1)
            {
                chtChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtChart.Legends.Clear();

                chtChart.Series["Stock Value"].YAxisType = AxisType.Primary;
                chtChart.Series["Stock Value"].XValueMember = "Date";
                chtChart.Series["Stock Value"].YValueMembers = "High,Low,Open,Close";
                chtChart.Series["Stock Value"].XValueType = ChartValueType.DateTime;
                chtChart.Series["Stock Value"]["ShowOpenClose"] = "Both";

                chtChart.Series["Volume"].YAxisType = AxisType.Secondary;
                chtChart.Series["Volume"].XValueMember = "Date";
                chtChart.Series["Volume"].YValueMembers = "Volume";
                chtChart.Series["Volume"].XValueType = ChartValueType.DateTime;
                chtChart.Series["Volume"].Color = Color.FromArgb(70, 150, 150, 150);

                chtChart.DataManipulator.IsStartFromFirst = true;
                chtChart.DataSource = stocksDatabaseDataSet.Stocks;
                chtChart.DataBind();
            }
            if (cbxChartType.SelectedIndex == 2)
            {
                chtChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtChart.Legends.Clear();

                chtChart.Series["Stock Value"].YAxisType = AxisType.Primary;
                chtChart.Series["Stock Value"].XValueMember = "Date";
                chtChart.Series["Stock Value"].YValueMembers = "High,Low,Open,Close";
                chtChart.Series["Stock Value"].XValueType = ChartValueType.DateTime;
                chtChart.Series["Stock Value"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
                chtChart.Series["Stock Value"]["ShowOpenClose"] = "Both";

                chtChart.Series["Volume"].YAxisType = AxisType.Secondary;
                chtChart.Series["Volume"].XValueMember = "Date";
                chtChart.Series["Volume"].YValueMembers = "Volume";
                chtChart.Series["Volume"].XValueType = ChartValueType.DateTime;
                chtChart.Series["Volume"].Color = Color.FromArgb(70,150,150,150);

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
                var IntervalWindow = new IndicatorIntervalConfig();
                IntervalWindow.ShowDialog();
                chtIndicators.Series.Clear();
                Series RSI = chtIndicators.Series.Add("RSI");
                chtIndicators.Series["RSI"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                if (dgvData.Rows.Count > 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 30;
                }

                if (dgvData.Rows.Count <= 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = dgvData.Rows.Count;
                }

                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<RsiResult> results = quotes.GetRsi(IntervalWindow.Interval);
                List<double> rsivalues = new List<double>();
                List<string> dates = new List<string>();

                foreach (RsiResult r in results)
                {
                    if (r.Rsi == null)
                    {
                        r.Rsi = double.NaN;
                    }
                    rsivalues.Add((double)r.Rsi);
                    dates.Add(Convert.ToString(r.Date));
                }

                RSI.Color = Color.Purple;
                RSI.Points.DataBindXY(dates, rsivalues);
            }
            if (cbxIndicators.SelectedIndex == 1)
            {
                var IntervalWindow = new IndicatorIntervalConfig();
                IntervalWindow.ShowDialog();
                chtIndicators.Series.Clear();
                Series CCI = chtIndicators.Series.Add("CCI");
                chtIndicators.Series["CCI"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                if (dgvData.Rows.Count > 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 30;
                }

                if (dgvData.Rows.Count <= 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = dgvData.Rows.Count;
                }

                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<CciResult> results = quotes.GetCci(IntervalWindow.Interval);
                List<double> ccivalues = new List<double>();
                List<string> dates = new List<string>();

                foreach (CciResult c in results)
                {
                    if (c.Cci == null)
                    {
                        c.Cci = double.NaN;
                    }
                    ccivalues.Add((double)c.Cci);
                    dates.Add(Convert.ToString(c.Date));
                }

                CCI.Color = Color.DarkKhaki;
                CCI.Points.DataBindXY(dates, ccivalues);
            }
            if (cbxIndicators.SelectedIndex == 2)
            {
                var IntervalWindow = new IndicatorIntervalConfig();
                IntervalWindow.ShowDialog();
                chtIndicators.Series.Clear();
                Series WilliamsR = chtIndicators.Series.Add("WillamsR");
                chtIndicators.Series["WillamsR"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                if (dgvData.Rows.Count > 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 30;
                }

                if (dgvData.Rows.Count <= 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = dgvData.Rows.Count;
                }

                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<WilliamsResult> results = quotes.GetWilliamsR(IntervalWindow.Interval);
                List<double> willamsRvalues = new List<double>();
                List<string> dates = new List<string>();

                foreach (WilliamsResult w in results)
                {
                    if (w.WilliamsR == null)
                    {
                        w.WilliamsR = double.NaN;
                    }
                    willamsRvalues.Add((double)w.WilliamsR);
                    dates.Add(Convert.ToString(w.Date));
                }

                WilliamsR.Color = Color.DarkBlue;
                WilliamsR.Points.DataBindXY(dates, willamsRvalues);
            }
            if (cbxIndicators.SelectedIndex == 3)
            {
                var IntervalWindowUltimate = new IndicatorIntervalConfigUltimate();
                IntervalWindowUltimate.ShowDialog();
                chtIndicators.Series.Clear();
                Series Ultimate = chtIndicators.Series.Add("Ultimate");
                chtIndicators.Series["Ultimate"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                if (dgvData.Rows.Count > 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 30;
                }

                if (dgvData.Rows.Count <= 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = dgvData.Rows.Count;
                }

                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<UltimateResult> results = quotes.GetUltimate(IntervalWindowUltimate.Interval1, IntervalWindowUltimate.Interval2, IntervalWindowUltimate.Interval3);
                List<double> ultimatevalues = new List<double>();
                List<string> dates = new List<string>();

                foreach (UltimateResult u in results)
                {
                    if (u.Ultimate == null)
                    {
                        u.Ultimate = double.NaN;
                    }
                    ultimatevalues.Add((double)u.Ultimate);
                    dates.Add(Convert.ToString(u.Date));
                }

                Ultimate.Color = Color.OrangeRed;
                Ultimate.Points.DataBindXY(dates, ultimatevalues);
            }
            if (cbxIndicators.SelectedIndex == 4)
            {
                var IntervalWindow = new IndicatorIntervalConfig();
                IntervalWindow.ShowDialog();
                chtIndicators.Series.Clear();
                Series mfi = chtIndicators.Series.Add("MFI");
                chtIndicators.Series["MFI"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                if (dgvData.Rows.Count > 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 30;
                }

                if (dgvData.Rows.Count <= 30)
                {
                    chtIndicators.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = dgvData.Rows.Count;
                }

                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<MfiResult> results = quotes.GetMfi(IntervalWindow.Interval);
                List<double> mfivalues = new List<double>();
                List<string> dates = new List<string>();

                foreach (MfiResult m in results)
                {
                    if (m.Mfi == null)
                    {
                        m.Mfi = double.NaN;
                    }
                    mfivalues.Add((double)m.Mfi);
                    dates.Add(Convert.ToString(m.Date));
                }

                mfi.Color = Color.DarkSeaGreen;
                mfi.Points.DataBindXY(dates, mfivalues);
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
                FullZoomReset();
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
            int days = Convert.ToInt32(txtMonths.Text);
            DateTime enddate = DateTime.Today;
            DateTime startdate = DateTime.Today.AddDays(-days);
            var awaiter = getStockData(symbol, startdate, enddate);
        }
    }
}
