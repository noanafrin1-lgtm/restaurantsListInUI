using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurantsListInUI.ViewModels
{
    internal class ExampleViewModel : ViewModelBase
    {
        public ExampleViewModel(){
        }
        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }
    }
}
