using System;
using System.Collections.Generic;
using System.Linq;
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

namespace test.Component
{
    /// <summary>
    /// SearchBox.xaml 的互動邏輯
    /// </summary>
    
    public partial class SearchBox : UserControl
    {
        #region Declarations
        public static readonly DependencyProperty BackgroundTextProperty =
            DependencyProperty.Register("BackgroundText", typeof(object), typeof(SearchBox), new PropertyMetadata("Default"));

        public static readonly DependencyProperty CanSearchProperty =
            DependencyProperty.Register("CanSearch", typeof(object), typeof(SearchBox), new PropertyMetadata(false));
        #endregion

        #region Property
        public object BackgroundText
        {
            get { return (object)GetValue(BackgroundTextProperty); }
            set { SetValue(BackgroundTextProperty, value); }
        }
        public bool CanSearch
        {
            get { return (bool)GetValue(CanSearchProperty); }
            set { SetValue(CanSearchProperty, value); }
        }
        #endregion

        #region MemberFunction
        public SearchBox()
        {
            InitializeComponent();
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
           if( CanSearch)
                MessageBox.Show(string.Format("Property CnaSearch is {0}", (bool)CanSearch));
        }
        #endregion

    }
}
