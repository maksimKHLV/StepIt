using GalaSoft.MvvmLight;
using kargo.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kargo.Services.Interface
{
    public interface INavigationService
    {
        public void NavigateTo<T>(ParameterMessage? message = null) where T : ViewModelBase;
   
    }
}
