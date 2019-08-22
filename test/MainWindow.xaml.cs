using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Declarations
        string OriginalData = string.Empty;
        #endregion

        #region Property
        #endregion

        #region MemberFunction
        public MainWindow()
        {
            InitializeComponent();
            //client - service(取得資料轉換成符合Model格式)
            var dt = useHttpWebRequest_Get();
            dg.ItemsSource = dt;

            List<ViewModel.StockData> StkData = new List<ViewModel.StockData>();
            foreach (var item in dt)
            {
                ViewModel.StockData stk = new ViewModel.StockData();
                stk.StackID = item.StockID;
                stk.StackName = item.StockName;
                StkData.Add(stk);
            }
            dgInfo.ItemsSource = StkData;
        }

        
        private List<Model.Stock> useHttpWebRequest_Get()
        {
            List<Model.Stock> tempList = new List<Model.Stock>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50332/api/S05301?limit=1000&page=1");
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json";

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var temp = reader.ReadToEnd();
                        if (temp.Contains("ok"))
                        {
                            OriginalData = temp.Substring(temp.IndexOf("["), temp.IndexOf("]") - temp.IndexOf("[")+1).Replace(@"\","").Replace("/","").Replace("\"","");
                            var dt = OriginalData.Split(',');
                            for(int i=0;i<dt.Length;i=i+5)
                            {
                                Model.Stock stk = new Model.Stock();
                                stk.StockID = int.Parse(dt[i].Substring(dt[i].IndexOf(":")+1, dt[i].Length - dt[i].IndexOf(":") - 1));
                                stk.StockName = dt[i+1].Substring(dt[i + 1].IndexOf(":") + 1, dt[i + 1].Length - dt[i + 1].IndexOf(":") - 1);
                                stk.Exchange = dt[i + 2].Substring(dt[i + 2].IndexOf(":") + 1, dt[i + 2].Length - dt[i + 2].IndexOf(":") - 1);
                                stk.Issued = dt[i + 3].Substring(dt[i + 3].IndexOf(":") + 1, dt[i + 3].Length - dt[i + 3].IndexOf(":") - 1);
                                stk.Currency = dt[i + 4].Substring(dt[i + 4].IndexOf(":") + 1, dt[i + 4].Length - dt[i + 4].IndexOf(":") - 1);
                                tempList.Add(stk);
                            }
                        }


                    }
                    
                }
                else
                {
                  
                }
            }
            return tempList;
        }

        #endregion

        private void SearchBox_OnEyesWatch(string para)
        {

        }
    }
}
