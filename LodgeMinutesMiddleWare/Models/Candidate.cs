using LodgeMinutesMiddleWare.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    public class Candidate : ModelBase
    {
        #region Fields

        private string _id;

        private string _name;

        private Degrees _degree;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the candidates name.
        /// </summary>
        public string Namne
        {
            get { return _name; }
            set
            {
                if( _name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the degree the candidate is receiving.
        /// </summary>
        public int Degree
        {
            get { return (int)_degree; }
            set
            {
                if( (int)_degree != value)
                {
                    _degree = (Degrees)value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        #endregion

        /// <summary>
        /// Creates a new instance of the <cref>Candidate</cref> class.
        /// </summary>
        public Candidate()
        {
            _id = Guid.NewGuid().ToString();
        }

    }
}