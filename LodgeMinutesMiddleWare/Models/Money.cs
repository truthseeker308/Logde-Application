using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    public class Money: INotifyPropertyChanged, IEditableObject
    {
        #region Fields

        private string _id;

        private double _amount;

        private string _purpose;

        private bool _paid;

        private Money _parent;
        private Money _current;
        private Money _backup;

        private bool _inTxn = false;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public string ID {  get { return _id; } }

        [Required( ErrorMessage = "Amount is required." )]
        [DataType(DataType.Currency)]
        public double Amount
        {
            get { return _amount; }
            set
            {
                if( _amount != value )
                {
                    _amount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required( ErrorMessage = "Purpose is required.", AllowEmptyStrings = false )]
        public string Purpose
        {
            get { return _purpose; }
            set
            {
                if( _purpose != value )
                {
                    _purpose = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required( ErrorMessage = "Paid is required.")]
        public bool Paid
        {
            get { return _paid; }
            set
            {
                if( _paid != value )
                {
                    _paid = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        public Money()
        {
            _id = Guid.NewGuid().ToString();
            _amount = 0.0;

        }

        private void NotifyPropertyChanged( [CallerMemberName] String propertyName = "" )
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
                _backup = new Money();
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
