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
        public int Interval1 { get; set; }
        public int Interval2 { get; set; }
        public int Interval3 { get; set; }
        public int Index { get; set; }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Index == 3)
            {
                if (txtInterval1.Text == "" || txtInterval1.Text == null || Convert.ToInt32(txtInterval1.Text) == 0)
                {
                    Interval1 = 7;
                }
                else
                {
                    Interval1 = Convert.ToInt32(txtInterval1.Text);
                }

                if (txtInterval2.Text == "" || txtInterval2.Text == null || Convert.ToInt32(txtInterval2.Text) == 0)
                {
                    Interval2 = 14;
                }
                else
                {
                    Interval2 = Convert.ToInt32(txtInterval2.Text);
                }

                if (txtInterval3.Text == "" || txtInterval3.Text == null || Convert.ToInt32(txtInterval3.Text) == 0)
                {
                    Interval3 = 28;
                }
                else
                {
                    Interval3 = Convert.ToInt32(txtInterval3.Text);
                }
            }

            if (Interval1 >= Interval2 || Interval2 >= Interval3 || Interval1 >= Interval3)
            {
                Interval1 = 7;
                Interval2 = 14;
                Interval3 = 28;
            }
            this.Close();
        }
        public IndicatorIntervalConfigUltimate(int cbxIndicators)
        {
            InitializeComponent();
            Index = cbxIndicators;
        }
    }
}
