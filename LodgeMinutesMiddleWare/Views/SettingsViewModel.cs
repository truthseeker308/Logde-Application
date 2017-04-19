using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Views
{
    [Serializable]
    public sealed class SettingsViewModel : ViewModeBase
    {
        #region Fields

        private string _lodgeFullName;

        private string _lodgeAbreviatedName;

        private int _specialMeetingCount;

        private int _regularMeetingCount;

        private Bitmap _seal;

        private string _worshipfulMaster;

        private string _seniorWaden;

        private string _juniorWarden;

        private string _meetingLocations;

        private int _regularMeetingsPerMonth;

        private List<string> _monthsDark;

        private bool _isTwelveHourTime;

        private int _officerInstallationMonth;

        private bool _rememberMinuteDates;

        private static SettingsViewModel _instance;

        private static object _lock = new object();

        private string _savedMinutesDirectory;

        private string _savedWordDirectory;

        private string _lastUsedFilename;

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
        public int SpecialMeetingCount
        {
            get { return _specialMeetingCount; }
            set
            {
                if( _specialMeetingCount != value )
                {
                    _specialMeetingCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Regular Meeting Current Count
        /// </summary>
        public int RegularMeetingCount
        {
            get { return _regularMeetingCount; }
            set
            {
                if( _regularMeetingCount != value )
                {
                    _regularMeetingCount = value;
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
        public string JuniorWarden
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
        public string MeetingLocations
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
        public int OfficerInstallationMonth
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

        /// <summary>
        /// Gets or sets the last filename used by the application
        /// </summary>
        public string LastFilename
        {
            get { return _lastUsedFilename; }
            set
            {
                if( _lastUsedFilename != value )
                {
                    _lastUsedFilename = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        /// <summary>
        /// Returns the single instance of the SettingsViewModel
        /// </summary>
        public static SettingsViewModel Instance
        {
            get
            {
                lock( _lock )
                {
                    if( _instance == null )
                    {
                        _instance = new SettingsViewModel();
                    }

                    return _instance;
                }
            }
        }

        #endregion

        /// <summary>
        /// Creates a new instance of the SettingsViewModel class
        /// </summary>
        private SettingsViewModel()
        {
            // make sure we have our lists created to avoid NULL errors
            _monthsDark = new List<string>();

            this.Load();

        }

        #region Private Methods

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
                _specialMeetingCount = int.Parse( ConfigurationManager.AppSettings[Constants.SpecialMeetingCount] );
                _regularMeetingCount = int.Parse( ConfigurationManager.AppSettings[Constants.RegularMeetingCount] );

                // TODO: how are we going to handle images
                //_seal = Bitmap.FromFile( ConfigurationManager.AppSettings[Constants.LodgeLogo] );

                _worshipfulMaster = ConfigurationManager.AppSettings[Constants.WorshipfulMaster];
                _seniorWaden = ConfigurationManager.AppSettings[Constants.SeniorWaden];
                _juniorWarden = ConfigurationManager.AppSettings[Constants.JuniorWarden];

                _meetingLocations = ConfigurationManager.AppSettings[Constants.UsualLodgeMeetingLocations];

                _regularMeetingsPerMonth = int.Parse( ConfigurationManager.AppSettings[Constants.NumberOfRegularMeetingsPerYear] );

                // TODO: we need to do some parsing of dates here
                //_monthsDark = new List<string>( ConfigurationManager.AppSettings[Constants.MonthsDark].Split( ',' ).Select( DateTime.Parse ).ToList() );

                _isTwelveHourTime = bool.Parse( ConfigurationManager.AppSettings[Constants.TimeFormat] );

                _officerInstallationMonth = int.Parse( ConfigurationManager.AppSettings[Constants.OfficerInstallationMonth] );

                _rememberMinuteDates = bool.Parse( ConfigurationManager.AppSettings[Constants.RememberedMinuteDates] );

                _savedWordDirectory = ConfigurationManager.AppSettings[Constants.SavedWordFilesDirectory];
                _savedMinutesDirectory = ConfigurationManager.AppSettings[Constants.SavedMinutesDirectory];

                _lastUsedFilename = ConfigurationManager.AppSettings[Constants.LastUseFilename];

            }
            catch( Exception  ex)
            {
                File.AppendAllText( "error.log", Environment.NewLine + Environment.NewLine + DateTime.Now + Environment.NewLine + ex.ToString() );
                throw;
            }
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Refreshes this instance
        /// </summary>
        public void Refresh()
        {
            this.Load();
        }

        /// <summary>
        /// Saves this instance
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );

                config.AppSettings.Settings[Constants.LodgeFullName].Value = _lodgeFullName;
                config.AppSettings.Settings[Constants.LodgeAbreviatedName].Value = _lodgeAbreviatedName;
                config.AppSettings.Settings[Constants.SpecialMeetingCount].Value = _specialMeetingCount.ToString();
                config.AppSettings.Settings[Constants.RegularMeetingCount].Value = _regularMeetingCount.ToString();

                // TODO: how are we going to handle images
                //_seal = Bitmap.FromFile( ConfigurationManager.AppSettings[Constants.LodgeLogo] );

                config.AppSettings.Settings[Constants.WorshipfulMaster].Value = _worshipfulMaster;
                config.AppSettings.Settings[Constants.SeniorWaden].Value = _seniorWaden;
                config.AppSettings.Settings[Constants.JuniorWarden].Value = _juniorWarden;

                config.AppSettings.Settings[Constants.UsualLodgeMeetingLocations].Value = _meetingLocations;

                config.AppSettings.Settings[Constants.NumberOfRegularMeetingsPerYear].Value = _regularMeetingsPerMonth.ToString();

                // TODO: we need to do some parsing of dates here
                //_monthsDark = new List<string>( ConfigurationManager.AppSettings[Constants.MonthsDark].Split( ',' ).Select( DateTime.Parse ).ToList() );

                config.AppSettings.Settings[Constants.TimeFormat].Value = _isTwelveHourTime.ToString();

                config.AppSettings.Settings[Constants.OfficerInstallationMonth].Value = _officerInstallationMonth.ToString();

                config.AppSettings.Settings[Constants.RememberedMinuteDates].Value = _rememberMinuteDates.ToString();

                config.AppSettings.Settings[Constants.LastUseFilename].Value = _lastUsedFilename;

                config.Save( ConfigurationSaveMode.Full );
                ConfigurationManager.RefreshSection( "appSettings" );

                return true;
            }
            catch( Exception ex )
            {
                File.AppendAllText( "error.log", Environment.NewLine + Environment.NewLine + DateTime.Now + Environment.NewLine + ex.ToString() );
                return false;
            }
        }

        #endregion

    }
}