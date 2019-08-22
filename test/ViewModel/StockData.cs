using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.ViewModel
{
    class StockData : INotifyPropertyChanged
    {
        #region Declarations
        public event PropertyChangedEventHandler PropertyChanged;
        protected string _StackName = string.Empty;
        protected int _StackID;
        #endregion

        #region Property
        public string StackName
        {
            get
            {
                return _StackName;
            }
            set
            {
                _StackName = string.Format("{0}({1})", value, _StackID);
                onPropertyChnaged("StackName");
            }
        }

        public int StackID
        {
            get
            {
                return _StackID;
            }
            set
            {
                _StackID = value;
                onPropertyChnaged("StackID");
                onPropertyChnaged("StackName");
            }
        }

        #endregion

        #region MemberFunction
        public void onPropertyChnaged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }
}
