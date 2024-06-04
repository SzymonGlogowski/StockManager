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
        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public IndicatorIntervalConfig(int cbxIndicators)
        {
            InitializeComponent();
            if (cbxIndicators == 0)
            {
                if (txtInterval.Text == "" || txtInterval.Text == null || Convert.ToInt32(txtInterval.Text) == 0)
                {
                    Interval = 14;
                }
                else
                {
                    Interval = Convert.ToInt32(txtInterval.Text);
                }
            }

            if (cbxIndicators == 1)
            {
                if (txtInterval.Text == "" || txtInterval.Text == null || Convert.ToInt32(txtInterval.Text) == 0)
                {
                    Interval = 20;
                }
                else
                {
                    Interval = Convert.ToInt32(txtInterval.Text);
                }
            }

            if (cbxIndicators == 2)
            {
                if (txtInterval.Text == "" || txtInterval.Text == null || Convert.ToInt32(txtInterval.Text) == 0)
                {
                    Interval = 10;
                }
                else
                {
                    Interval = Convert.ToInt32(txtInterval.Text);
                }
            }

            if (cbxIndicators == 4)
            {
                if (txtInterval.Text == "" || txtInterval.Text == null || Convert.ToInt32(txtInterval.Text) == 0)
                {
                    Interval = 14;
                }
                else
                {
                    Interval = Convert.ToInt32(txtInterval.Text);
                }
            }
        }
    }
}
