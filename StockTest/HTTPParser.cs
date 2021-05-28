using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using HtmlAgilityPack;
using System.Xml;


namespace StockTest
{
    public class HTTPParser
    {
        public static List<Dictionary<string, string>> GetHTML(string url)
        {
            List<Dictionary<string, string>> stockData = new List<Dictionary<string, string>>();
            HtmlWeb web = new HtmlWeb();

            HtmlDocument document = web.Load(url);

            foreach (HtmlNode row in document.DocumentNode.SelectNodes("//html/body/section/div[2]/div/div[2]/div/div[1]/table//tr"))
            {
                Dictionary<string, string> rowDict = new Dictionary<string, string>();
                foreach (HtmlNode cell in row.SelectNodes("td"))
                {
                    string[] cellCls = cell.Attributes["class"].Value.Split(' ');
                    if (cellCls.Length >= 2)
                    {
                        rowDict.Add(cellCls[1], cell.InnerText.Trim() );
                    }
                }
                stockData.Add(rowDict);
            }
            return stockData;
        }
    }
}
