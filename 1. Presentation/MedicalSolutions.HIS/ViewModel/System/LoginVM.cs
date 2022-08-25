using MedicalSolutions.HIS.Base.ViewModels;
using MedicalSolutions.Models.HIS.Systems;
using MedicalSolutions.Util.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalSolutions.HIS.ViewModel.System
{
    public class LoginVM : BaseVM
    {
        public LoginVM()
        {
            LoginClickCommad = new RelayCommand<RoutedEventArgs>(e => e != null, e => LoginClick(e));
            ExitClickCommad = new RelayCommand<RoutedEventArgs>(e => e != null, e => ExitClick(e));
        }

        #region Property

        public ICommand LoginClickCommad { get; set; }
        public ICommand ExitClickCommad { get; set; }

        private LoginModel _loginInfo;
        public LoginModel LoginInfo
        {
            get => _loginInfo;
            set
            {
                if (_loginInfo != value)
                {
                    _loginInfo = value;

                    OnPropertyChanged();
                }    
            }
        }

        #endregion

        #region Method

        private void LoginClick(RoutedEventArgs e)
        {

        }

        private void ExitClick(RoutedEventArgs e)
        {

        }

        #endregion
    }
}
