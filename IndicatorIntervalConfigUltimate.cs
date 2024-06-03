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
    public partial class IndicatorIntervalConfigUltimate : Form
    {
        public IndicatorIntervalConfigUltimate()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int Interval1
        {
            get
            {
                if (txtInterval1.Text == "" || txtInterval1.Text == null)
                {
                    return 7;
                }
                return Convert.ToInt32(txtInterval1.Text);
            }
        }
        public int Interval2
        {
            get
            {
                if (txtInterval2.Text == "" || txtInterval2.Text == null)
                {
                    return 14;
                }
                return Convert.ToInt32(txtInterval2.Text);
            }
        }
        public int Interval3
        {
            get
            {
                if (txtInterval3.Text == "" || txtInterval3.Text == null)
                {
                    return 28;
                }
                return Convert.ToInt32(txtInterval3.Text);
            }
        }
    }
}
