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
    public class Money: ModelBase
    {
        #region Fields

        private string _id;

        private double _amount;

        private string _purpose;

        private bool _paid;

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
            : base()
        {
            this.Amount = 0;
            this.Purpose = String.Empty;
            this.Paid = false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            // TODO: return a string of this instance
            return String.Format( "Amount- {0}\tPurpose - {2}\tPaid -{2}", this.Amount, this.Purpose, this.Paid );
        }

    }
}
