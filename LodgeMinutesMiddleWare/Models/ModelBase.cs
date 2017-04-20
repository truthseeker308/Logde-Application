using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    public class ModelBase: INotifyPropertyChanged, IEditableObject
    {
        #region Fields
        
        public event PropertyChangedEventHandler PropertyChanged;

        private ModelBase _current;
        private ModelBase _backup;

        private bool _inTxn = false;

        private string _id;

        #endregion

        protected string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public ModelBase() { _id = Guid.NewGuid().ToString(); }

        protected void NotifyPropertyChanged( [CallerMemberName] String propertyName = "" )
        {
            var myEvent = PropertyChanged;

            if (myEvent != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Begins the edit.
        /// </summary>
        void IEditableObject.BeginEdit()
        {
            if( !_inTxn )
            {
                _backup = _current;
                _inTxn = true;
            }
        }

        /// <summary>
        /// Ends the edit.
        /// </summary>
        void IEditableObject.EndEdit()
        {
            if( _inTxn )
            {
                _backup = new ModelBase();
                _inTxn = false;
            }
        }

        /// <summary>
        /// Cancels the edit.
        /// </summary>
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
