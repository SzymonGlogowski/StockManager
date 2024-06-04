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
        public IndicatorIntervalConfig()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int Interval
        {
            get
            {

                if (txtInterval.Text == "" || txtInterval.Text == null || Convert.ToInt32(txtInterval.Text) == 0)
                {
                    return 14;
                }
                return Convert.ToInt32(txtInterval.Text);
            }
        }
    }
}
