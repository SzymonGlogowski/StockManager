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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.candleNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stocksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDatabaseDataSet = new StockManager.StocksDatabaseDataSet();
            this.chtChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbxChartType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbxIndicators = new System.Windows.Forms.ComboBox();
            this.chtIndicators = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.stocksTableAdapter = new StockManager.StocksDatabaseDataSetTableAdapters.StocksTableAdapter();
            this.chxEnableAutoscalling = new System.Windows.Forms.CheckBox();
            this.chxEnableScallingByMarkingArea = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIndicators)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.candleNumberDataGridViewTextBoxColumn,
            this.openDataGridViewTextBoxColumn,
            this.closeDataGridViewTextBoxColumn,
            this.highDataGridViewTextBoxColumn,
            this.lowDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.dgvData.DataSource = this.stocksBindingSource;
            this.dgvData.Location = new System.Drawing.Point(12, 624);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(650, 225);
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
            // chtChart
            // 
            chartArea1.Name = "ChartArea1";
            this.chtChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtChart.Legends.Add(legend1);
            this.chtChart.Location = new System.Drawing.Point(13, 13);
            this.chtChart.Name = "chtChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "Stock Value";
            series1.YValuesPerPoint = 4;
            this.chtChart.Series.Add(series1);
            this.chtChart.Size = new System.Drawing.Size(860, 350);
            this.chtChart.TabIndex = 1;
            this.chtChart.Text = "Chart";
            // 
            // cbxChartType
            // 
            this.cbxChartType.FormattingEnabled = true;
            this.cbxChartType.Items.AddRange(new object[] {
            "Line",
            "Bar",
            "Candlestick"});
            this.cbxChartType.Location = new System.Drawing.Point(666, 624);
            this.cbxChartType.Name = "cbxChartType";
            this.cbxChartType.Size = new System.Drawing.Size(100, 21);
            this.cbxChartType.TabIndex = 2;
            this.cbxChartType.Text = "Candlestick";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(666, 651);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(772, 651);
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
            "RSI"});
            this.cbxIndicators.Location = new System.Drawing.Point(773, 624);
            this.cbxIndicators.Name = "cbxIndicators";
            this.cbxIndicators.Size = new System.Drawing.Size(100, 21);
            this.cbxIndicators.TabIndex = 0;
            this.cbxIndicators.SelectedIndexChanged += new System.EventHandler(this.cbxIndicators_SelectedIndexChanged);
            // 
            // chtIndicators
            // 
            chartArea2.Name = "ChartArea1";
            this.chtIndicators.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtIndicators.Legends.Add(legend2);
            this.chtIndicators.Location = new System.Drawing.Point(13, 370);
            this.chtIndicators.Name = "chtIndicators";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtIndicators.Series.Add(series2);
            this.chtIndicators.Size = new System.Drawing.Size(860, 248);
            this.chtIndicators.TabIndex = 6;
            this.chtIndicators.Text = "Indicators";
            // 
            // stocksTableAdapter
            // 
            this.stocksTableAdapter.ClearBeforeFill = true;
            // 
            // chxEnableAutoscalling
            // 
            this.chxEnableAutoscalling.AutoSize = true;
            this.chxEnableAutoscalling.Location = new System.Drawing.Point(666, 682);
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
            this.chxEnableScallingByMarkingArea.Location = new System.Drawing.Point(666, 705);
            this.chxEnableScallingByMarkingArea.Name = "chxEnableScallingByMarkingArea";
            this.chxEnableScallingByMarkingArea.Size = new System.Drawing.Size(180, 17);
            this.chxEnableScallingByMarkingArea.TabIndex = 8;
            this.chxEnableScallingByMarkingArea.Text = "Enable Scalling By Marking Area";
            this.chxEnableScallingByMarkingArea.UseVisualStyleBackColor = true;
            this.chxEnableScallingByMarkingArea.CheckedChanged += new System.EventHandler(this.chxEnableScallingByMarkingArea_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(666, 728);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 25);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.chxEnableScallingByMarkingArea);
            this.Controls.Add(this.chxEnableAutoscalling);
            this.Controls.Add(this.chtIndicators);
            this.Controls.Add(this.cbxIndicators);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxChartType);
            this.Controls.Add(this.chtChart);
            this.Controls.Add(this.dgvData);
            this.Name = "Form1";
            this.Text = "Stock Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtIndicators)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtChart;
        private System.Windows.Forms.ComboBox cbxChartType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cbxIndicators;
        private StocksDatabaseDataSet stocksDatabaseDataSet;
        private System.Windows.Forms.BindingSource stocksBindingSource;
        private StocksDatabaseDataSetTableAdapters.StocksTableAdapter stocksTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn candleNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtIndicators;
        private System.Windows.Forms.CheckBox chxEnableAutoscalling;
        private System.Windows.Forms.CheckBox chxEnableScallingByMarkingArea;
        private System.Windows.Forms.Button btnExport;
    }
}

