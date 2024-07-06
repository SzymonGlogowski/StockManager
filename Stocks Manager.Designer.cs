namespace StockManager
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.stocksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDatabaseDataSet = new StockManager.StocksDatabaseDataSet();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbxIndicators = new System.Windows.Forms.ComboBox();
            this.chxEnableAutoscalling = new System.Windows.Forms.CheckBox();
            this.chxEnableScallingByMarkingArea = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnRemoveMovingAverages = new System.Windows.Forms.Button();
            this.chxMovingAverages = new System.Windows.Forms.CheckBox();
            this.lblIntervals = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.txtMonths = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.stocksTableAdapter = new StockManager.StocksDatabaseDataSetTableAdapters.StocksTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chtChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtIndicators = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.candleNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxChartType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stocksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIndicators)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // stocksBindingSource
            // 
            this.stocksBindingSource.DataMember = "Stocks";
            this.stocksBindingSource.DataSource = this.stocksDatabaseDataSet;
            // 
            // stocksDatabaseDataSet
            // 
            this.stocksDatabaseDataSet.DataSetName = "StocksDatabaseDataSet";
            this.stocksDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(113, 30);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 25);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbxIndicators
            // 
            this.cbxIndicators.FormattingEnabled = true;
            this.cbxIndicators.Items.AddRange(new object[] {
            "RSI",
            "CCI",
            "%R Willams",
            "Ultimate",
            "MFI",
            "SMA",
            "EMA",
            "WMA",
            "TEMA"});
            this.cbxIndicators.Location = new System.Drawing.Point(113, 3);
            this.cbxIndicators.Name = "cbxIndicators";
            this.cbxIndicators.Size = new System.Drawing.Size(100, 21);
            this.cbxIndicators.TabIndex = 0;
            this.cbxIndicators.Text = "RSI";
            this.cbxIndicators.SelectedIndexChanged += new System.EventHandler(this.cbxIndicators_SelectedIndexChanged);
            // 
            // chxEnableAutoscalling
            // 
            this.chxEnableAutoscalling.AutoSize = true;
            this.chxEnableAutoscalling.Location = new System.Drawing.Point(12, 113);
            this.chxEnableAutoscalling.Name = "chxEnableAutoscalling";
            this.chxEnableAutoscalling.Size = new System.Drawing.Size(119, 17);
            this.chxEnableAutoscalling.TabIndex = 7;
            this.chxEnableAutoscalling.Text = "Enable Autoscalling";
            this.chxEnableAutoscalling.UseVisualStyleBackColor = true;
            this.chxEnableAutoscalling.CheckedChanged += new System.EventHandler(this.chxEnableAutoscalling_CheckedChanged);
            // 
            // chxEnableScallingByMarkingArea
            // 
            this.chxEnableScallingByMarkingArea.AutoSize = true;
            this.chxEnableScallingByMarkingArea.Location = new System.Drawing.Point(12, 136);
            this.chxEnableScallingByMarkingArea.Name = "chxEnableScallingByMarkingArea";
            this.chxEnableScallingByMarkingArea.Size = new System.Drawing.Size(180, 17);
            this.chxEnableScallingByMarkingArea.TabIndex = 8;
            this.chxEnableScallingByMarkingArea.Text = "Enable Scalling By Marking Area";
            this.chxEnableScallingByMarkingArea.UseVisualStyleBackColor = true;
            this.chxEnableScallingByMarkingArea.CheckedChanged += new System.EventHandler(this.chxEnableScallingByMarkingArea_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(219, 30);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(109, 25);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(641, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Panel1Collapsed = true;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnFetchData);
            this.splitContainer3.Panel2.Controls.Add(this.btnRemoveMovingAverages);
            this.splitContainer3.Panel2.Controls.Add(this.cbxChartType);
            this.splitContainer3.Panel2.Controls.Add(this.chxMovingAverages);
            this.splitContainer3.Panel2.Controls.Add(this.lblIntervals);
            this.splitContainer3.Panel2.Controls.Add(this.lblSymbol);
            this.splitContainer3.Panel2.Controls.Add(this.txtMonths);
            this.splitContainer3.Panel2.Controls.Add(this.txtSymbol);
            this.splitContainer3.Panel2.Controls.Add(this.btnExport);
            this.splitContainer3.Panel2.Controls.Add(this.chxEnableAutoscalling);
            this.splitContainer3.Panel2.Controls.Add(this.chxEnableScallingByMarkingArea);
            this.splitContainer3.Panel2.Controls.Add(this.cbxIndicators);
            this.splitContainer3.Panel2.Controls.Add(this.btnSave);
            this.splitContainer3.Panel2.Controls.Add(this.btnLoad);
            this.splitContainer3.Size = new System.Drawing.Size(334, 165);
            this.splitContainer3.SplitterDistance = 332;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnRemoveMovingAverages
            // 
            this.btnRemoveMovingAverages.Location = new System.Drawing.Point(219, 3);
            this.btnRemoveMovingAverages.Name = "btnRemoveMovingAverages";
            this.btnRemoveMovingAverages.Size = new System.Drawing.Size(109, 23);
            this.btnRemoveMovingAverages.TabIndex = 17;
            this.btnRemoveMovingAverages.Text = "Remove MAs";
            this.btnRemoveMovingAverages.UseVisualStyleBackColor = true;
            this.btnRemoveMovingAverages.Click += new System.EventHandler(this.btnRemoveMovingAverages_Click);
            // 
            // chxMovingAverages
            // 
            this.chxMovingAverages.AutoSize = true;
            this.chxMovingAverages.Location = new System.Drawing.Point(133, 113);
            this.chxMovingAverages.Name = "chxMovingAverages";
            this.chxMovingAverages.Size = new System.Drawing.Size(167, 17);
            this.chxMovingAverages.TabIndex = 16;
            this.chxMovingAverages.Text = "Show Only 1 Moving Average";
            this.chxMovingAverages.UseVisualStyleBackColor = true;
            this.chxMovingAverages.CheckedChanged += new System.EventHandler(this.chxMovingAverages_CheckedChanged);
            // 
            // lblIntervals
            // 
            this.lblIntervals.AutoSize = true;
            this.lblIntervals.Location = new System.Drawing.Point(9, 90);
            this.lblIntervals.Name = "lblIntervals";
            this.lblIntervals.Size = new System.Drawing.Size(34, 13);
            this.lblIntervals.TabIndex = 15;
            this.lblIntervals.Text = "Days:";
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(9, 64);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(44, 13);
            this.lblSymbol.TabIndex = 14;
            this.lblSymbol.Text = "Symbol:";
            // 
            // txtMonths
            // 
            this.txtMonths.Location = new System.Drawing.Point(65, 87);
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.Size = new System.Drawing.Size(134, 20);
            this.txtMonths.TabIndex = 13;
            this.txtMonths.Text = "30";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(65, 61);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(134, 20);
            this.txtSymbol.TabIndex = 12;
            this.txtSymbol.Text = "AAPL";
            // 
            // btnFetchData
            // 
            this.btnFetchData.Location = new System.Drawing.Point(219, 58);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(109, 25);
            this.btnFetchData.TabIndex = 11;
            this.btnFetchData.Text = "Fetch Data";
            this.btnFetchData.UseVisualStyleBackColor = true;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // stocksTableAdapter
            // 
            this.stocksTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 428F));
            this.tableLayoutPanel1.Controls.Add(this.chtIndicators, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chtChart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 961);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // chtChart
            // 
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 80F;
            chartArea2.InnerPlotPosition.Width = 80F;
            chartArea2.InnerPlotPosition.X = 10F;
            chartArea2.InnerPlotPosition.Y = 3F;
            chartArea2.Name = "StockChartArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 87F;
            chartArea2.Position.Width = 90F;
            chartArea2.Position.Y = 1F;
            this.chtChart.ChartAreas.Add(chartArea2);
            this.chtChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chtChart.Legends.Add(legend2);
            this.chtChart.Location = new System.Drawing.Point(3, 3);
            this.chtChart.Name = "chtChart";
            series2.ChartArea = "StockChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series2.IsVisibleInLegend = false;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Stock Value";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValuesPerPoint = 4;
            series3.ChartArea = "StockChartArea";
            series3.IsVisibleInLegend = false;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Volume";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.ChartArea = "StockChartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "SMA";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series5.ChartArea = "StockChartArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsXValueIndexed = true;
            series5.Legend = "Legend1";
            series5.Name = "EMA";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.ChartArea = "StockChartArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsXValueIndexed = true;
            series6.Legend = "Legend1";
            series6.Name = "WMA";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series7.ChartArea = "StockChartArea";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.IsXValueIndexed = true;
            series7.Legend = "Legend1";
            series7.Name = "TEMA";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chtChart.Series.Add(series2);
            this.chtChart.Series.Add(series3);
            this.chtChart.Series.Add(series4);
            this.chtChart.Series.Add(series5);
            this.chtChart.Series.Add(series6);
            this.chtChart.Series.Add(series7);
            this.chtChart.Size = new System.Drawing.Size(978, 517);
            this.chtChart.TabIndex = 5;
            // 
            // chtIndicators
            // 
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 80F;
            chartArea1.InnerPlotPosition.Width = 80F;
            chartArea1.InnerPlotPosition.X = 10F;
            chartArea1.InnerPlotPosition.Y = 3F;
            chartArea1.Name = "IndicatorsArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 87F;
            chartArea1.Position.Width = 90F;
            chartArea1.Position.Y = 1F;
            this.chtIndicators.ChartAreas.Add(chartArea1);
            this.chtIndicators.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtIndicators.Legends.Add(legend1);
            this.chtIndicators.Location = new System.Drawing.Point(3, 526);
            this.chtIndicators.Name = "chtIndicators";
            series1.ChartArea = "IndicatorsArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chtIndicators.Series.Add(series1);
            this.chtIndicators.Size = new System.Drawing.Size(978, 255);
            this.chtIndicators.TabIndex = 7;
            this.chtIndicators.Text = "Indicators";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel2.Controls.Add(this.splitContainer3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvData, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 787);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(978, 171);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.candleNumberDataGridViewTextBoxColumn,
            this.openDataGridViewTextBoxColumn,
            this.closeDataGridViewTextBoxColumn,
            this.highDataGridViewTextBoxColumn,
            this.lowDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn});
            this.dgvData.DataSource = this.stocksBindingSource;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 3);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(632, 165);
            this.dgvData.TabIndex = 1;
            // 
            // candleNumberDataGridViewTextBoxColumn
            // 
            this.candleNumberDataGridViewTextBoxColumn.DataPropertyName = "Candle Number";
            this.candleNumberDataGridViewTextBoxColumn.HeaderText = "Candle Number";
            this.candleNumberDataGridViewTextBoxColumn.Name = "candleNumberDataGridViewTextBoxColumn";
            // 
            // openDataGridViewTextBoxColumn
            // 
            this.openDataGridViewTextBoxColumn.DataPropertyName = "Open";
            this.openDataGridViewTextBoxColumn.HeaderText = "Open";
            this.openDataGridViewTextBoxColumn.Name = "openDataGridViewTextBoxColumn";
            // 
            // closeDataGridViewTextBoxColumn
            // 
            this.closeDataGridViewTextBoxColumn.DataPropertyName = "Close";
            this.closeDataGridViewTextBoxColumn.HeaderText = "Close";
            this.closeDataGridViewTextBoxColumn.Name = "closeDataGridViewTextBoxColumn";
            // 
            // highDataGridViewTextBoxColumn
            // 
            this.highDataGridViewTextBoxColumn.DataPropertyName = "High";
            this.highDataGridViewTextBoxColumn.HeaderText = "High";
            this.highDataGridViewTextBoxColumn.Name = "highDataGridViewTextBoxColumn";
            // 
            // lowDataGridViewTextBoxColumn
            // 
            this.lowDataGridViewTextBoxColumn.DataPropertyName = "Low";
            this.lowDataGridViewTextBoxColumn.HeaderText = "Low";
            this.lowDataGridViewTextBoxColumn.Name = "lowDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            // 
            // cbxChartType
            // 
            this.cbxChartType.FormattingEnabled = true;
            this.cbxChartType.Items.AddRange(new object[] {
            "Line",
            "Bar",
            "Candlestick"});
            this.cbxChartType.Location = new System.Drawing.Point(7, 3);
            this.cbxChartType.Name = "cbxChartType";
            this.cbxChartType.Size = new System.Drawing.Size(100, 21);
            this.cbxChartType.TabIndex = 2;
            this.cbxChartType.Text = "Candlestick";
            this.cbxChartType.SelectedIndexChanged += new System.EventHandler(this.cbxChartType_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Stock Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stocksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDatabaseDataSet)).EndInit();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIndicators)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLoad;
        private StocksDatabaseDataSet stocksDatabaseDataSet;
        private System.Windows.Forms.BindingSource stocksBindingSource;
        private StocksDatabaseDataSetTableAdapters.StocksTableAdapter stocksTableAdapter;
        private System.Windows.Forms.CheckBox chxEnableAutoscalling;
        private System.Windows.Forms.CheckBox chxEnableScallingByMarkingArea;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.TextBox txtMonths;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.ComboBox cbxIndicators;
        private System.Windows.Forms.Label lblIntervals;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.CheckBox chxMovingAverages;
        private System.Windows.Forms.Button btnRemoveMovingAverages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtIndicators;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn candleNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cbxChartType;
        private System.Windows.Forms.Button btnSave;
    }
}

