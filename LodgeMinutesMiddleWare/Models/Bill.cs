using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    public class Bill : INotifyPropertyChanged, IEditableObject
    {
        #region Fields

        private string _id;

        private double _amount;

        private string _service;

        private string _organization;

        private bool _approved;

        private Bill _parent;
        private Bill _current;
        private Bill _backup;

        private bool _inTxn = false;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        public string ID { get { return _id; } }

        [Required( ErrorMessage = "Amount is required." )]
        [DataType( DataType.Currency )]
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

        [Required( ErrorMessage = "Service is required.", AllowEmptyStrings =false )]
        public string Service
        {
            get { return _service; }
            set
            {
                if( _service != value )
                {
                    _service = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required( ErrorMessage = "Organization is required.", AllowEmptyStrings = false )]
        public string Organization
        {
            get { return _organization; }
            set
            {
                if( _organization != value )
                {
                    _organization = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required( ErrorMessage = "Approved is required." )]
        public bool Approved
        {
            get { return _approved; }
            set
            {
                if( _approved != value )
                {
                    _approved = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Bill()
        {

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
                _backup = new Bill();
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
