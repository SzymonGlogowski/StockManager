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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.candleNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stocksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDatabaseDataSet = new StockManager.StocksDatabaseDataSet();
            this.cbxChartType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbxIndicators = new System.Windows.Forms.ComboBox();
            this.chtIndicators = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chxEnableAutoscalling = new System.Windows.Forms.CheckBox();
            this.chxEnableScallingByMarkingArea = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chtChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txtMonths = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.stocksTableAdapter = new StockManager.StocksDatabaseDataSetTableAdapters.StocksTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIndicators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(650, 161);
            this.dgvData.TabIndex = 0;
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
            // cbxChartType
            // 
            this.cbxChartType.FormattingEnabled = true;
            this.cbxChartType.Items.AddRange(new object[] {
            "Line",
            "Bar",
            "Candlestick"});
            this.cbxChartType.Location = new System.Drawing.Point(3, 3);
            this.cbxChartType.Name = "cbxChartType";
            this.cbxChartType.Size = new System.Drawing.Size(95, 21);
            this.cbxChartType.TabIndex = 2;
            this.cbxChartType.Text = "Candlestick";
            this.cbxChartType.SelectedIndexChanged += new System.EventHandler(this.cbxChartType_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(104, 30);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(95, 25);
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
            "MFI"});
            this.cbxIndicators.Location = new System.Drawing.Point(104, 3);
            this.cbxIndicators.Name = "cbxIndicators";
            this.cbxIndicators.Size = new System.Drawing.Size(95, 21);
            this.cbxIndicators.TabIndex = 0;
            this.cbxIndicators.Text = "RSI";
            this.cbxIndicators.SelectedIndexChanged += new System.EventHandler(this.cbxIndicators_SelectedIndexChanged);
            // 
            // chtIndicators
            // 
            chartArea5.InnerPlotPosition.Auto = false;
            chartArea5.InnerPlotPosition.Height = 75F;
            chartArea5.InnerPlotPosition.Width = 80F;
            chartArea5.InnerPlotPosition.X = 10F;
            chartArea5.InnerPlotPosition.Y = 5F;
            chartArea5.Name = "ChartArea1";
            this.chtIndicators.ChartAreas.Add(chartArea5);
            this.chtIndicators.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chtIndicators.Legends.Add(legend5);
            this.chtIndicators.Location = new System.Drawing.Point(0, 0);
            this.chtIndicators.Name = "chtIndicators";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.IsXValueIndexed = true;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chtIndicators.Series.Add(series7);
            this.chtIndicators.Size = new System.Drawing.Size(959, 250);
            this.chtIndicators.TabIndex = 6;
            this.chtIndicators.Text = "Indicators";
            // 
            // chxEnableAutoscalling
            // 
            this.chxEnableAutoscalling.AutoSize = true;
            this.chxEnableAutoscalling.Location = new System.Drawing.Point(3, 61);
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
            this.chxEnableScallingByMarkingArea.Location = new System.Drawing.Point(3, 84);
            this.chxEnableScallingByMarkingArea.Name = "chxEnableScallingByMarkingArea";
            this.chxEnableScallingByMarkingArea.Size = new System.Drawing.Size(180, 17);
            this.chxEnableScallingByMarkingArea.TabIndex = 8;
            this.chxEnableScallingByMarkingArea.Text = "Enable Scalling By Marking Area";
            this.chxEnableScallingByMarkingArea.UseVisualStyleBackColor = true;
            this.chxEnableScallingByMarkingArea.CheckedChanged += new System.EventHandler(this.chxEnableScallingByMarkingArea_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(3, 107);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 25);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(13, 15);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chtChart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(959, 934);
            this.splitContainer1.SplitterDistance = 515;
            this.splitContainer1.TabIndex = 10;
            // 
            // chtChart
            // 
            chartArea6.InnerPlotPosition.Auto = false;
            chartArea6.InnerPlotPosition.Height = 85F;
            chartArea6.InnerPlotPosition.Width = 80F;
            chartArea6.InnerPlotPosition.X = 10F;
            chartArea6.InnerPlotPosition.Y = 5F;
            chartArea6.Name = "ChartArea1";
            this.chtChart.ChartAreas.Add(chartArea6);
            this.chtChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chtChart.Legends.Add(legend6);
            this.chtChart.Location = new System.Drawing.Point(0, 0);
            this.chtChart.Name = "chtChart";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series8.IsXValueIndexed = true;
            series8.Legend = "Legend1";
            series8.Name = "Stock Value";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series8.YValuesPerPoint = 4;
            series9.ChartArea = "ChartArea1";
            series9.IsXValueIndexed = true;
            series9.Legend = "Legend1";
            series9.Name = "Volume";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chtChart.Series.Add(series8);
            this.chtChart.Series.Add(series9);
            this.chtChart.Size = new System.Drawing.Size(959, 515);
            this.chtChart.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chtIndicators);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(959, 415);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvData);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txtMonths);
            this.splitContainer3.Panel2.Controls.Add(this.txtSymbol);
            this.splitContainer3.Panel2.Controls.Add(this.btnFetchData);
            this.splitContainer3.Panel2.Controls.Add(this.splitter1);
            this.splitContainer3.Panel2.Controls.Add(this.cbxChartType);
            this.splitContainer3.Panel2.Controls.Add(this.btnExport);
            this.splitContainer3.Panel2.Controls.Add(this.chxEnableAutoscalling);
            this.splitContainer3.Panel2.Controls.Add(this.chxEnableScallingByMarkingArea);
            this.splitContainer3.Panel2.Controls.Add(this.cbxIndicators);
            this.splitContainer3.Panel2.Controls.Add(this.btnSave);
            this.splitContainer3.Panel2.Controls.Add(this.btnLoad);
            this.splitContainer3.Size = new System.Drawing.Size(959, 161);
            this.splitContainer3.SplitterDistance = 650;
            this.splitContainer3.TabIndex = 0;
            // 
            // txtMonths
            // 
            this.txtMonths.Location = new System.Drawing.Point(104, 139);
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.Size = new System.Drawing.Size(100, 20);
            this.txtMonths.TabIndex = 13;
            this.txtMonths.Text = "30";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(104, 110);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtSymbol.TabIndex = 12;
            this.txtSymbol.Text = "AAPL";
            // 
            // btnFetchData
            // 
            this.btnFetchData.Location = new System.Drawing.Point(3, 136);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(95, 25);
            this.btnFetchData.TabIndex = 11;
            this.btnFetchData.Text = "Fetch Data";
            this.btnFetchData.UseVisualStyleBackColor = true;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 161);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // stocksTableAdapter
            // 
            this.stocksTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Stock Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIndicators)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtChart)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cbxChartType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private StocksDatabaseDataSet stocksDatabaseDataSet;
        private System.Windows.Forms.BindingSource stocksBindingSource;
        private StocksDatabaseDataSetTableAdapters.StocksTableAdapter stocksTableAdapter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtIndicators;
        private System.Windows.Forms.CheckBox chxEnableAutoscalling;
        private System.Windows.Forms.CheckBox chxEnableScallingByMarkingArea;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.TextBox txtMonths;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn candleNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtChart;
        private System.Windows.Forms.ComboBox cbxIndicators;
    }
}

