using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Views
{
    [Serializable]
    public abstract class ViewModeBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged( [CallerMemberName] String propertyName = "" )
        {
            var myEvent = PropertyChanged;

            if( myEvent != null )
            {
                PropertyChanged(this,new PropertyChangedEventArgs( propertyName ));
            }
        }

    }
}