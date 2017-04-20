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
    public class Bill : ModelBase
    {
        #region Fields

        private string _id;

        private double _amount;

        private string _purpose;

        private string _organization;

        private bool _approved;

        #endregion

        #region Properties

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

        #endregion

        /// <summary>
        /// Creates a new instance of the <cref>Bill</cref>  class.
        /// </summary>
        public Bill()
            : base()
        {
            _id = Guid.NewGuid().ToString();
        }

        

    }
}