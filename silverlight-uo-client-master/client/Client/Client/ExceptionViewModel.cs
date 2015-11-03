using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.ComponentModel.Design;
using System.Windows.Input;

namespace Client
{
    public class ExceptionViewModel : ViewModelBase
    {
        public string Exception
        {
            get { return Get(() => Exception); }
            set { Set(() => Exception, value); }
        }
    }
}
