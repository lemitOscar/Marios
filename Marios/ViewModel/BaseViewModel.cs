using System;
using System.Collections.Generic;

using System.Text;

namespace Marios.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BaseViewModel : INotifyPropertyChanged
    {
        //ctrl + k +s para la region
        #region InterrfaceINotify
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Properties
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
