using LodgeMinutesMiddleWare.Commands;
using LodgeMinutesMiddleWare.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LodgeMinutesMiddleWare.Models
{
    public abstract class MotionBase: ModelBase
    {
        #region Fields

        private string _madeBy;

        private string _secondedBy;

        private string _specifics;

        private string _status;

        private MotionResults? _results;

        private ICommand _radioButtonCommand;

        private bool _canExecute;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the made by.
        /// </summary>
        /// <value>
        /// The made by.
        /// </value>
        public string MadeBy
        {
            get { return _madeBy; }
            set
            {
                if( _madeBy != value )
                {
                    _madeBy = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the seconded by.
        /// </summary>
        /// <value>
        /// The seconded by.
        /// </value>
        public string SecondedBy
        {
            get { return _secondedBy; }
            set
            {
                if( _secondedBy != value )
                {
                    _secondedBy = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the specifics.
        /// </summary>
        /// <value>
        /// The specifics.
        /// </value>
        public string Specifics
        {
            get { return _specifics; }
            set
            {
                if( _specifics != value )
                {
                    _specifics = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public MotionResults? Results
        {
            get { return _results; }
            set
            {
                if( _results != value )
                {
                    _results = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the radio command.
        /// </summary>
        /// <value>
        /// The radio command.
        /// </value>
        public DelegateCommand RadioButtonCommand
        {
            get
            {
                return new DelegateCommand( ( p ) =>
                {
                    var temp = p.ToString().ToLower();

                    switch( temp )
                    {
                        case "passed":
                            Results = MotionResults.Passed;
                            break;

                        case "failed":
                            Results = MotionResults.FailedToPass;
                            break;

                        case "amendedpassed":
                            Results = MotionResults.AmdendedPass;
                            break;

                        case "amendedfailed":
                            Results = MotionResults.AmendedFail;
                            break;

                        default:
                            Results = null;
                            break;

                    }
                } );
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MotionBase"/> class.
        /// </summary>
        public MotionBase()
        {
            _madeBy = String.Empty;
            _secondedBy = String.Empty;
            _specifics = String.Empty;
            _results = MotionResults.Passed;
        }
        
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid()
        {
            if( String.IsNullOrWhiteSpace( this.MadeBy ) || String.IsNullOrWhiteSpace( this.SecondedBy ) || String.IsNullOrWhiteSpace( this.Specifics ) )
            {
                return false;
            }

            return true;
        }

    }
}
