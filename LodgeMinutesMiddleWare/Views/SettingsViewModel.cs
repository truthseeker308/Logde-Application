using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Views
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _lodgeFullName;

        private string _lodgeAbreviatedName;

        private int _totalMeetingCurrentCount;

        private int _regularMeetingCurrentCount;

        private Bitmap _seal;

        private string _worshipfulMaster;

        private string _seniorWaden;

        private string _juniorWarden;

        private List<string> _meetingLocations;

        private int _regularMeetingsPerMonth;

        private List<string> _monthsDark;

        private bool _isTwelveHourTime;

        private string _officerInstallationMonth;

        private bool _rememberMinuteDates;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the LodgeName
        /// </summary>
        public string LodgeName
        {
            get { return _lodgeFullName; }
            set
            {
                if( _lodgeFullName != value )
                {
                    _lodgeFullName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Lodge Abreviated Name
        /// </summary>
        public string LodgeAbreviatedName
        {
            get { return _lodgeAbreviatedName; }
            set
            {
                if( _lodgeAbreviatedName != value )
                {
                    _lodgeAbreviatedName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Total Meeting Current Count
        /// </summary>
        public int TotalMeetingCurrentCount
        {
            get { return _totalMeetingCurrentCount; }
            set
            {
                if( _totalMeetingCurrentCount != value )
                {
                    _totalMeetingCurrentCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Regular Meeting Current Count
        /// </summary>
        public int RegularMeetingCurrentCount
        {
            get { return _regularMeetingCurrentCount; }
            set
            {
                if( _regularMeetingCurrentCount != value )
                {
                    _regularMeetingCurrentCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Lodge Seal
        /// </summary>
        public Bitmap LodgeSeal
        {
            get { return _seal; }
            set
            {
                if( _seal != value )
                {
                    _seal = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Worshipful Master
        /// </summary>
        public string WorshipfulMaster
        {
            get { return _worshipfulMaster; }
            set
            {
                if( _worshipfulMaster != value )
                {
                    _worshipfulMaster = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Senior Warden
        /// </summary>
        public string SeniorWarden
        {
            get { return _seniorWaden; }
            set
            {
                if( _seniorWaden != value )
                {
                    _seniorWaden = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Junior Warden
        /// </summary>
        public string JunirWaden
        {
            get { return _juniorWarden; }
            set
            {
                if( _juniorWarden != value )
                {
                    _juniorWarden = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Usual Lodge Meeting Locations
        /// </summary>
        public List<string> MeetingLocations
        {
            get { return _meetingLocations; }
            set
            {
                if( _meetingLocations != value )
                {
                    _meetingLocations = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Number of Regular Meetings Per Month
        /// </summary>
        public int NumberOfRegularMeetingPerMonth
        {
            get { return _regularMeetingsPerMonth; }
            set
            {
                if( _regularMeetingsPerMonth != value )
                {
                    _regularMeetingsPerMonth = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets Usual Dark Months
        /// </summary>
        public List<string> DarkMonths
        {
            get { return _monthsDark; }
            set
            {
                if( _monthsDark != value )
                {
                    _monthsDark = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the 12/24 time format
        /// </summary>
        public bool IsTwelveHourFormat
        {
            get { return _isTwelveHourTime; }
            set
            {
                if( _isTwelveHourTime != value )
                {
                    _isTwelveHourTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Officer Installation Month
        /// </summary>
        public string OfficerInstallationMonth
        {
            get { return _officerInstallationMonth; }
            set
            {
                if( _officerInstallationMonth != value )
                {
                    _officerInstallationMonth = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets if Remember Minute Dates
        /// </summary>
        public bool RememberMinuteDates
        {
            get { return _rememberMinuteDates; }
            set
            {
                if( _rememberMinuteDates != value )
                {
                    _rememberMinuteDates = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        /// <summary>
        /// Creates a new instance of the SettingsViewModel class
        /// </summary>
        public SettingsViewModel()
        {
            // make sure we have our lists created to avoid NULL errors
            _monthsDark = new List<string>();
            _meetingLocations = new List<string>();

            this.Load();

        }

        /// <summary>
        /// Creates a new instance of the SettingsViewModel class
        /// </summary>
        /// <param name="lodgeName"></param>
        public SettingsViewModel( string lodgeName ) : this()
        {
            _lodgeFullName = lodgeName;
        }

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged( [CallerMemberName] String propertyName = "" )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }

        /// <summary>
        /// Loads this instance
        /// </summary>
        private void Load()
        {
            try
            {
                // read the values from the app.config file
                _lodgeFullName = ConfigurationManager.AppSettings[Constants.LodgeFullName];
                _lodgeAbreviatedName = ConfigurationManager.AppSettings[Constants.LodgeAbreviatedName];
                _totalMeetingCurrentCount = int.Parse( ConfigurationManager.AppSettings[Constants.TotalMeetingCount] );
                _regularMeetingCurrentCount = int.Parse( ConfigurationManager.AppSettings[Constants.RegularMeetingCount] );

                // TODO: how are we going to handle images
                //_seal = Bitmap.FromFile( ConfigurationManager.AppSettings[Constants.LodgeLogo] );

                _worshipfulMaster = ConfigurationManager.AppSettings[Constants.LodgeFullName];
                _seniorWaden = ConfigurationManager.AppSettings[Constants.SeniorWaden];
                _juniorWarden = ConfigurationManager.AppSettings[Constants.JuniorWarden];
                
                _meetingLocations = new List<string>( ConfigurationManager.AppSettings[Constants.UsualLodgeMeetingLocations].Split( ',' ).ToList() );

                _regularMeetingsPerMonth = int.Parse( ConfigurationManager.AppSettings[Constants.NumberOfRegularMeetingsPerYear] );

                // TODO: we need to do some parsing of dates here
                //_monthsDark = new List<string>( ConfigurationManager.AppSettings[Constants.MonthsDark].Split( ',' ).Select( DateTime.Parse ).ToList() );

                _isTwelveHourTime = bool.Parse( ConfigurationManager.AppSettings[Constants.TimeFormat] );

                _officerInstallationMonth = ConfigurationManager.AppSettings[Constants.OfficerInstallationMonth];

                _rememberMinuteDates = bool.Parse( ConfigurationManager.AppSettings[Constants.RememberedMinuteDates] );

            }
            catch( Exception )
            {
                // TODO: add some logging or something
                throw;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                return true;
            }
            catch( Exception )
            {
                // TODO: add some logging or something
                return false;
            }
        }

        #endregion

    }
}