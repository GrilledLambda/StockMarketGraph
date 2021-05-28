using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Http;



namespace StockTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Dictionary<string, string>> stockData = HTTPParser.GetHTML("https://www.marketwatch.com/investing/stock/live");
            chart1.Titles.Add("Live Stock Report");

            foreach (Dictionary<string, string> stockInfo in stockData)
            {
                //add new series to chart and change its chart-type to line
                chart1.Series.Add(stockInfo["symbol"]);
                chart1.Series[stockInfo["symbol"]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                foreach (KeyValuePair<string, string> stock in stockInfo)
                {
                    string currentStock = stock.Key + " | " + stock.Value;
                    GeneralOutput.Items.Add(currentStock);
                    chart1.Series[stockInfo["symbol"]].Points.AddXY(0, 0);
                    chart1.Series[stockInfo["symbol"]].Points.AddXY(1, stockInfo["price"]);

                }
            }
            //chart1.Series["Stock 1"].Points.AddXY("1", "10");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
