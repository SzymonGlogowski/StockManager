using Newtonsoft.Json.Linq;
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
    public partial class IndicatorIntervalConfig : Form
    {
        public int Interval { get; set; }
        public int Index { get; set; }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Index == 0 || Index == 4)
            {
                if (txtInterval.Text == "" || txtInterval.Text == null || Convert.ToInt32(txtInterval.Text) < 2)
                {
                    Interval = 14;
                    MessageBox.Show("Generic value 14 were applied for Interval because input value is incorrect!", "Warning Interval");
                }
                else
                {
                    Interval = Convert.ToInt32(txtInterval.Text);
                }
            }

            if (Index == 1 || Index == 5 || Index == 6 || Index == 7 || Index == 8)
            {
                if (txtInterval.Text == "" || txtInterval.Text == null || Convert.ToInt32(txtInterval.Text) < 2)
                {
                    Interval = 20;
                    MessageBox.Show("Generic value 20 were applied for Interval because input value is incorrect!", "Warning Interval");

                }
                else
                {
                    Interval = Convert.ToInt32(txtInterval.Text);
                }
            }

            if (Index == 2)
            {
                if (txtInterval.Text == "" || txtInterval.Text == null || Convert.ToInt32(txtInterval.Text) < 2)
                {
                    Interval = 10;
                    MessageBox.Show("Generic value 10 were applied for Interval because input value is incorrect!", "Warning Interval");

                }
                else
                {
                    Interval = Convert.ToInt32(txtInterval.Text);
                }
            }
            this.Close();
        }
        public IndicatorIntervalConfig(int cbxIndicators)
        {
            InitializeComponent();
            Index = cbxIndicators;
            if (Index == 0 || Index == 4)
            {
                txtInterval.Text = "14";
            }
            if (Index == 1 || Index == 5 || Index == 6 || Index == 7 || Index == 8)
            {
                txtInterval.Text = "20";
            }
            if (Index == 2)
            {
                txtInterval.Text = "10";
            }
        }
    }
}
