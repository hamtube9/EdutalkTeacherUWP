using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.Common.Base
{
    public class ViewModelBase : Prism.Windows.Mvvm.ViewModelBase
    {
        public void Toast(string str)
        {
            if (CrossToastPopUp.IsSupported == true)
            {
                CrossToastPopUp.Current.ShowToastMessage(str,Plugin.Toast.Abstractions.ToastLength.Short);
            }
        }


        public void ToastError(string str)
        {
            if (CrossToastPopUp.IsSupported == true)
            {
                CrossToastPopUp.Current.ShowToastMessage(str, Plugin.Toast.Abstractions.ToastLength.Short);
            }
        }

        public void ToastSuccess(string str)
        {
            if (CrossToastPopUp.IsSupported == true)
            {
                CrossToastPopUp.Current.ShowToastMessage(str, Plugin.Toast.Abstractions.ToastLength.Short);
            }
        }


    }

    public class DelegateCommand : ICommand
    {
        private SimpleEventHandler handler;
        private bool isEnable = true;
        public event EventHandler CanExecuteChanged;
        public delegate void SimpleEventHandler();

        public DelegateCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }

        public bool IsEnable
        {
            get
            {
                return this.isEnable;
            }
        }

        void ICommand.Execute(object obj)
        {
            this.handler();
        }

        bool ICommand.CanExecute(object obj)
        {
            return this.IsEnable;
        }
        private void OnCanExcuteChanged()
        {
            if(this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
