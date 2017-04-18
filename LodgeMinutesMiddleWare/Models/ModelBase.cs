using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    [Serializable]
    public class ModelBase: INotifyPropertyChanged, IEditableObject
    {
        #region Fields

        private ModelBase _parent;
        private ModelBase _current;
        private ModelBase _backup;

        private bool _inTxn = false;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public ModelBase() { }

        protected void NotifyPropertyChanged( [CallerMemberName] String propertyName = "" )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }

        void IEditableObject.BeginEdit()
        {
            if( !_inTxn )
            {
                _backup = _current;
                _inTxn = true;
            }
        }

        void IEditableObject.EndEdit()
        {
            if( _inTxn )
            {
                _backup = new ModelBase();
                _inTxn = false;
            }
        }

        void IEditableObject.CancelEdit()
        {
            if( _inTxn )
            {
                _current = _backup;
                _inTxn = false;
            }

        }

    }
}
