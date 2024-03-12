using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'stocksDatabaseDataSet.Stocks' . Możesz go przenieść lub usunąć.
            this.stocksTableAdapter.Fill(this.stocksDatabaseDataSet.Stocks);

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

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            chtChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chtChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            chtChart.Series["Stock Value"].XValueMember = "Date";
            chtChart.Series["Stock Value"].YValueMembers = "High,Low,Open,Close";
            chtChart.Series["Stock Value"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chtChart.Series["Stock Value"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
            //chtChart.Series["Stock Value"]["OpenCloseStyle"] = "Triangle";
            chtChart.Series["Stock Value"]["ShowOpenClose"] = "Both";
            chtChart.DataManipulator.IsStartFromFirst = true;
            chtChart.DataSource = stocksDatabaseDataSet.Stocks;
            chtChart.DataBind();
        }
    }
}
