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
using System.Drawing.Text;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography.X509Certificates;

namespace StockManager
{
    public partial class Form1 : Form
    {
        public bool FlagMA { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void ChartScaling()
        {
            AddScrollbarToChart();

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

            chtChart.ChartAreas["StockChartArea"].AxisY.Maximum = (double)max;
            chtChart.ChartAreas["StockChartArea"].AxisY.Minimum = (double)min;

            chtChart.ChartAreas["StockChartArea"].AxisY.Interval = ((double)max - (double)min) / 5.0;
            chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Interval = chtChart.ChartAreas["StockChartArea"].AxisY.Interval / 2.0;
        }
        private void GenericChartScaling()
        {
            AddScrollbarToChart();

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

            chtChart.ChartAreas["StockChartArea"].AxisY.Maximum = (double)max;
            chtChart.ChartAreas["StockChartArea"].AxisY.Minimum = 0;

            chtChart.ChartAreas["StockChartArea"].AxisY.Interval = ((double)max) / 5.0;
            chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Interval = chtChart.ChartAreas["StockChartArea"].AxisY.Interval / 2.0;
        }
        private void AddScrollbarToChart()
        {
            if (dgvData.Rows.Count > 90)
            {
                chtChart.ChartAreas["StockChartArea"].AxisX.ScrollBar.Enabled = true;
                chtChart.ChartAreas["StockChartArea"].AxisX.IsLabelAutoFit = true;
                chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Size = 90;
            }

            if (dgvData.Rows.Count <= 90)
            {
                chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Size = dgvData.Rows.Count;
            }
        }

        private void AddScrollbarToIndicators()
        {
            if (dgvData.Rows.Count > 90)
            {
                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScrollBar.Enabled = true;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.IsLabelAutoFit = true;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScaleView.Size = 90;
            }

            if (dgvData.Rows.Count <= 90)
            {
                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScaleView.Size = dgvData.Rows.Count;
            }
        }
        private void HideOtherMovingAverages()
        {
            FlagMA = true;
            for (int i = 2; i < chtChart.Series.Count; i += 1)
            {
                if (i != cbxIndicators.SelectedIndex - 3 && cbxIndicators.SelectedIndex >= 5)
                {
                    chtChart.Series[i].Enabled = false;
                }
                else if(i == cbxIndicators.SelectedIndex - 3 && cbxIndicators.SelectedIndex >= 5)
                {
                    chtChart.Series[i].Enabled = true;
                }

                if (cbxIndicators.SelectedIndex < 5)
                {
                    if (chtChart.Series[i].Points.Any() && FlagMA == true)
                    {
                        chtChart.Series[i].Enabled = true;
                        FlagMA = false;
                    }
                    else
                    {
                        chtChart.Series[i].Enabled = false;
                    }
                }
            }
        }
        private void ShowOtherMovingAverages()
        {
            for (int i = 2; i < chtChart.Series.Count; i += 1)
            {
                chtChart.Series[i].Enabled = true;
            }
        }
        private void RefreshMovingAverages()
        {
            if (chxMovingAverages.Checked)
            {
                chxMovingAverages.Checked = false;
                chxMovingAverages.Checked = true;
            }
        }
        private void DeleteMovingAverages()
        {
            for (int i = 2; i < chtChart.Series.Count; i += 1)
            {
                chtChart.Series[i].Points.Clear();
            }
        }
        private void ScalingByMarkingArea()
        {
            chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Zoomable = true;
            chtChart.ChartAreas["StockChartArea"].CursorX.AutoScroll = true;
            chtChart.ChartAreas["StockChartArea"].CursorX.IsUserSelectionEnabled = true;

            chtChart.ChartAreas["StockChartArea"].AxisY.ScaleView.Zoomable = true;
            chtChart.ChartAreas["StockChartArea"].CursorY.AutoScroll = true;
            chtChart.ChartAreas["StockChartArea"].CursorY.IsUserSelectionEnabled = true;
        }
        private void DisableScallingByMarkingArea()
        {
            chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Zoomable = false;
            chtChart.ChartAreas["StockChartArea"].CursorX.AutoScroll = false;
            chtChart.ChartAreas["StockChartArea"].CursorX.IsUserSelectionEnabled = false;

            chtChart.ChartAreas["StockChartArea"].AxisY.ScaleView.Zoomable = false;
            chtChart.ChartAreas["StockChartArea"].CursorY.AutoScroll = false;
            chtChart.ChartAreas["StockChartArea"].CursorY.IsUserSelectionEnabled = false;
        }
        private void FullZoomReset()
        {
            while (chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.IsZoomed || chtChart.ChartAreas["StockChartArea"].AxisY.ScaleView.IsZoomed)
            {
                if (chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.IsZoomed)
                {
                    chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.ZoomReset();
                }

                if (chtChart.ChartAreas["StockChartArea"].AxisY.ScaleView.IsZoomed)
                {
                    chtChart.ChartAreas["StockChartArea"].AxisY.ScaleView.ZoomReset();
                }
            }
            AddScrollbarToChart();
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
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    stocksTableAdapter.Delete((int)row.Cells[0].Value, (decimal)row.Cells[1].Value, (decimal)row.Cells[2].Value, (decimal)row.Cells[3].Value, (decimal)row.Cells[4].Value, (DateTime)row.Cells[5].Value, (int)row.Cells[6].Value);
                }
                DeleteMovingAverages();
                for (int i = 0; i < chtIndicators.Series.Count; i += 1)
                {
                    chtIndicators.Series[i].Points.Clear();
                }
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
                chtChart.ChartAreas["StockChartArea"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["StockChartArea"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["StockChartArea"].AxisX.Interval = 1;

                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

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
                chtChart.ChartAreas["StockChartArea"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["StockChartArea"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["StockChartArea"].AxisX.Interval = 1;

                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

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
                chtChart.ChartAreas["StockChartArea"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["StockChartArea"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["StockChartArea"].AxisX.Interval = 1;

                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

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
                var IntervalWindow = new IndicatorIntervalConfig(cbxIndicators.SelectedIndex);
                IntervalWindow.ShowDialog();
                chtIndicators.Series.Clear();
                Series RSI = chtIndicators.Series.Add("RSI");
                chtIndicators.Series["RSI"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.Interval = 1;

                AddScrollbarToIndicators();

                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

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
                    string date = Convert.ToString(r.Date);
                    string datewithouthours = Convert.ToDateTime(date).ToString("dd.MM.yyyy");
                    dates.Add(datewithouthours);
                }

                RSI.Color = Color.Purple;
                RSI.Points.DataBindXY(dates, rsivalues);
            }
            if (cbxIndicators.SelectedIndex == 1)
            {
                var IntervalWindow = new IndicatorIntervalConfig(cbxIndicators.SelectedIndex);
                IntervalWindow.ShowDialog();
                chtIndicators.Series.Clear();
                Series CCI = chtIndicators.Series.Add("CCI");
                chtIndicators.Series["CCI"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.Interval = 1;

                AddScrollbarToIndicators();

                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.LineColor = Color.LightGray;
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
                    string date = Convert.ToString(c.Date);
                    string datewithouthours = Convert.ToDateTime(date).ToString("dd.MM.yyyy");
                    dates.Add(datewithouthours);
                }

                CCI.Color = Color.DarkKhaki;
                CCI.Points.DataBindXY(dates, ccivalues);
            }
            if (cbxIndicators.SelectedIndex == 2)
            {
                var IntervalWindow = new IndicatorIntervalConfig(cbxIndicators.SelectedIndex);
                IntervalWindow.ShowDialog();
                chtIndicators.Series.Clear();
                Series WilliamsR = chtIndicators.Series.Add("WillamsR");
                chtIndicators.Series["WillamsR"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.Interval = 1;

                AddScrollbarToIndicators();

                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

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
                    string date = Convert.ToString(w.Date);
                    string datewithouthours = Convert.ToDateTime(date).ToString("dd.MM.yyyy");
                    dates.Add(datewithouthours);
                }

                WilliamsR.Color = Color.DarkBlue;
                WilliamsR.Points.DataBindXY(dates, willamsRvalues);
            }
            if (cbxIndicators.SelectedIndex == 3)
            {
                var IntervalWindowUltimate = new IndicatorIntervalConfigUltimate(cbxIndicators.SelectedIndex);
                IntervalWindowUltimate.ShowDialog();
                chtIndicators.Series.Clear();
                Series Ultimate = chtIndicators.Series.Add("Ultimate");
                chtIndicators.Series["Ultimate"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.Interval = 1;

                AddScrollbarToIndicators();

                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

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
                    string date = Convert.ToString(u.Date);
                    string datewithouthours = Convert.ToDateTime(date).ToString("dd.MM.yyyy");
                    dates.Add(datewithouthours);
                }

                Ultimate.Color = Color.OrangeRed;
                Ultimate.Points.DataBindXY(dates, ultimatevalues);
            }
            if (cbxIndicators.SelectedIndex == 4)
            {
                var IntervalWindow = new IndicatorIntervalConfig(cbxIndicators.SelectedIndex);
                IntervalWindow.ShowDialog();
                chtIndicators.Series.Clear();
                Series mfi = chtIndicators.Series.Add("MFI");
                chtIndicators.Series["MFI"].ChartType = SeriesChartType.Line;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.MajorGrid.LineWidth = 0;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MajorGrid.LineWidth = 0;

                chtIndicators.ChartAreas["IndicatorsArea"].AxisX.Interval = 1;

                AddScrollbarToIndicators();

                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.Enabled = true;
                chtIndicators.ChartAreas["IndicatorsArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

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
                    string date = Convert.ToString(m.Date);
                    string datewithouthours = Convert.ToDateTime(date).ToString("dd.MM.yyyy");
                    dates.Add(datewithouthours);
                }

                mfi.Color = Color.DarkSeaGreen;
                mfi.Points.DataBindXY(dates, mfivalues);
            }
            if (cbxIndicators.SelectedIndex == 5)
            {
                var IntervalWindow = new IndicatorIntervalConfig(cbxIndicators.SelectedIndex);
                IntervalWindow.ShowDialog();
                chtChart.Series["SMA"].ChartType = SeriesChartType.Line;

                chtChart.ChartAreas["StockChartArea"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["StockChartArea"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["StockChartArea"].AxisX.Interval = 1;

                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<SmaResult> results = quotes.GetSma(IntervalWindow.Interval);
                List<double> smavalues = new List<double>();
                List<DateTime> dates = new List<DateTime>();

                foreach (SmaResult s in results)
                {
                    if (s.Sma == null)
                    {
                        s.Sma = double.NaN;
                    }
                    smavalues.Add((double)s.Sma);
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (null != row && null != row.Cells[5].Value)
                    {
                        dates.Add(Convert.ToDateTime(row.Cells[5].Value.ToString()));
                    }
                }

                chtChart.Series["SMA"].Color = Color.DodgerBlue;
                chtChart.Series["SMA"].Points.DataBindXY(dates, smavalues);
                RefreshMovingAverages();
            }

            if (cbxIndicators.SelectedIndex == 6)
            {
                var IntervalWindow = new IndicatorIntervalConfig(cbxIndicators.SelectedIndex);
                IntervalWindow.ShowDialog();
                chtChart.Series["EMA"].ChartType = SeriesChartType.Line;

                chtChart.ChartAreas["StockChartArea"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["StockChartArea"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["StockChartArea"].AxisX.Interval = 1;

                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<EmaResult> results = quotes.GetEma(IntervalWindow.Interval);
                List<double> emavalues = new List<double>();
                List<DateTime> dates = new List<DateTime>();

                foreach (EmaResult s in results)
                {
                    if (s.Ema == null)
                    {
                        s.Ema = double.NaN;
                    }
                    emavalues.Add((double)s.Ema);
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (null != row && null != row.Cells[5].Value)
                    {
                        dates.Add(Convert.ToDateTime(row.Cells[5].Value.ToString()));
                    }
                }

                chtChart.Series["EMA"].Color = Color.DarkBlue;
                chtChart.Series["EMA"].Points.DataBindXY(dates, emavalues);
                RefreshMovingAverages();
            }
            if (cbxIndicators.SelectedIndex == 7)
            {
                var IntervalWindow = new IndicatorIntervalConfig(cbxIndicators.SelectedIndex);
                IntervalWindow.ShowDialog();
                chtChart.Series["WMA"].ChartType = SeriesChartType.Line;

                chtChart.ChartAreas["StockChartArea"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["StockChartArea"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["StockChartArea"].AxisX.Interval = 1;

                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<WmaResult> results = quotes.GetWma(IntervalWindow.Interval);
                List<double> wmavalues = new List<double>();
                List<DateTime> dates = new List<DateTime>();

                foreach (WmaResult w in results)
                {
                    if (w.Wma == null)
                    {
                        w.Wma = double.NaN;
                    }
                    wmavalues.Add((double)w.Wma);
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (null != row && null != row.Cells[5].Value)
                    {
                        dates.Add(Convert.ToDateTime(row.Cells[5].Value.ToString()));
                    }
                }

                chtChart.Series["WMA"].Color = Color.DarkViolet;
                chtChart.Series["WMA"].Points.DataBindXY(dates, wmavalues);
                RefreshMovingAverages();
            }
            if (cbxIndicators.SelectedIndex == 8)
            {
                var IntervalWindow = new IndicatorIntervalConfig(cbxIndicators.SelectedIndex);
                IntervalWindow.ShowDialog();
                chtChart.Series["TEMA"].ChartType = SeriesChartType.Line;

                chtChart.ChartAreas["StockChartArea"].AxisX.MajorGrid.LineWidth = 0;
                chtChart.ChartAreas["StockChartArea"].AxisY.MajorGrid.LineWidth = 0;

                chtChart.ChartAreas["StockChartArea"].AxisX.Interval = 1;

                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.Enabled = true;
                chtChart.ChartAreas["StockChartArea"].AxisY.MinorGrid.LineColor = Color.LightGray;

                chtIndicators.Legends.Clear();

                PrepareJson();
                var jsonre = File.ReadAllText("C:\\Users\\Admin\\Documents\\GitHub\\StockManager\\jsons\\Stocks.json");
                IEnumerable<Quote> quotes = JsonConvert
                    .DeserializeObject<IReadOnlyCollection<Quote>>(jsonre)
                    .ToSortedCollection();
                IEnumerable<TemaResult> results = quotes.GetTema(IntervalWindow.Interval);
                List<double> temavalues = new List<double>();
                List<DateTime> dates = new List<DateTime>();

                foreach (TemaResult t in results)
                {
                    if (t.Tema == null)
                    {
                        t.Tema = double.NaN;
                    }
                    temavalues.Add((double)t.Tema);
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (null != row && null != row.Cells[5].Value)
                    {
                        dates.Add(Convert.ToDateTime(row.Cells[5].Value.ToString()));
                    }
                }

                chtChart.Series["TEMA"].Color = Color.DarkGreen;
                chtChart.Series["TEMA"].Points.DataBindXY(dates, temavalues);
                RefreshMovingAverages();
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
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
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
        private void chtChart_AxisScrollBarClicked(object sender, ScrollBarEventArgs e)
        {
            chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScaleView.Position = chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Position;
        }
        private void chtChart_AxisViewChanging(object sender, ViewEventArgs e)
        {
            chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScaleView.Position = chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Position;
        }
        private void chtChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScaleView.Position = chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Position;
        }
        private void chtIndicators_AxisScrollBarClicked(object sender, ScrollBarEventArgs e)
        {
            chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Position = chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScaleView.Position;
        }
        private void chtIndicators_AxisViewChanging(object sender, ViewEventArgs e)
        {
            chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Position = chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScaleView.Position;
        }
        private void chtIndicators_AxisViewChanged(object sender, ViewEventArgs e)
        {
            chtChart.ChartAreas["StockChartArea"].AxisX.ScaleView.Position = chtIndicators.ChartAreas["IndicatorsArea"].AxisX.ScaleView.Position;
        }
        private void chxMovingAverages_CheckedChanged(object sender, EventArgs e)
        {
            if (chxMovingAverages.Checked)
            {
                HideOtherMovingAverages();
            }

            if (!chxMovingAverages.Checked)
            {
                ShowOtherMovingAverages();
            }
        }
        private void btnRemoveMovingAverages_Click(object sender, EventArgs e)
        {
            DeleteMovingAverages();
        }
    }
}
