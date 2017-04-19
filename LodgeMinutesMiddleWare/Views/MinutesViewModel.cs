using LodgeMinutesMiddleWare.Enums;
using LodgeMinutesMiddleWare.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

namespace LodgeMinutesMiddleWare.Models
{
    [Serializable]
    [XmlRoot("Minutes",IsNullable =false)]
    public sealed class MinutesViewModel : ViewModeBase
    {
        #region Fields

        private ObservableCollection<VisitorModel> _visitors;

        [NonSerialized]
        private List<string> _locations;

        private ObservableCollection<Bill> _bills;

        private ObservableCollection<Money> _monies;

        private ObservableCollection<Candidate> _candidates;

        private string _location = String.Empty;

        private DateTime _meetingDate = DateTime.Now;

        private int _membersCount = 0;

        private int _visitorsCount = 0;

        private string _wm = String.Empty;

        private string _sw = String.Empty;

        private string _jw = String.Empty;

        private bool _byDispenstation = false;

        private MeetingTypes _meetingType = MeetingTypes.Regular;

        private Degrees _openingDegree = Degrees.EnteredApprentice;

        private Degrees _closingDegree = Degrees.EnteredApprentice;

        private Forms _openingForm = Forms.InDueForm;

        private int _regularMeetingCount;

        private int _specialMeetingCount;

        private string _notes = String.Empty;

        private bool _isOpen = false;

        private string _filename = String.Empty;

        [NonSerialized]
        private static object s_lock = new object();

        [NonSerialized]
        private static MinutesViewModel s_instance;

        public event EventHandler Saved;
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance of the MinutesModel class.
        /// </summary>
        public static MinutesViewModel Instance
        {
            get
            {
                // since we can be saving this automatically we need 
                // to ensure thread safety
                lock( s_lock )
                {
                    if( s_instance == null )
                    {
                        s_instance = new MinutesViewModel();
                    }

                    return s_instance;
                }
            }
            set
            {
                lock( s_lock )
                {
                    s_instance = value;
                }
            }
        }

        /// <summary>
        /// Gets the visitors
        /// </summary>
        public ObservableCollection<VisitorModel> Visitors
        {
            get { return _visitors; }
        }
        
        public ObservableCollection<Bill> Bills
        {
            get { return _bills; }
        }

        public ObservableCollection<Money> Monies
        {
            get { return _monies; }
        }

        public ObservableCollection<Candidate> Candidates
        {
            get { return _candidates; }
        }

        /// <summary>
        /// Gets the lodge meeting locations
        /// </summary>
        public List<string> Locations
        {
            get { return _locations; }
        }

        /// <summary>
        /// Gets or sets the meeting date
        /// </summary>
        public DateTime MeetingDate
        {
            get { return _meetingDate; }
            set
            {
                if( _meetingDate != value )
                {
                    _meetingDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of members attending
        /// </summary>
        public int MembersCount
        {
            get { return _membersCount; }
            set
            {
                if( _membersCount != value )
                {
                    _membersCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of visitors attending
        /// </summary>
        public int VisitorsCount
        {
            get { return _visitorsCount; }
            set
            {
                if( _visitorsCount != value )
                {
                    _visitorsCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string WorshipfulMaster
        {
            get { return _wm; }
            set
            {
                if( _wm != value )
                {
                    _wm = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string SeniorWarden
        {
            get { return _sw; }
            set
            {
                if( _sw != value )
                {
                    _sw = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string JuniorWarden
        {
            get { return _jw; }
            set
            {
                if( _jw != value )
                {
                    _jw = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool ByDispensation
        {
            get { return _byDispenstation; }
            set
            {
                if( _byDispenstation != value )
                {
                    _byDispenstation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int MeetingType
        {
            get { return (int)_meetingType; }
            set
            {
                if( (int)_meetingType != value )
                {
                    _meetingType = (MeetingTypes)value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int OpeningDegree
        {
            get { return (int)_openingDegree; }
            set
            {
                if( (int)_openingDegree != value )
                {
                    _openingDegree = (Degrees)value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int ClosingDegree
        {
            get { return (int)_closingDegree; }
            set
            {
                if( (int)_closingDegree != value )
                {
                    _closingDegree = (Degrees)value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int OpeningForm
        {
            get { return (int)_openingForm; }
            set
            {
                if( (int)_openingForm != value )
                {
                    _openingForm = (Forms)value;
                    NotifyPropertyChanged();
                }
            }
        }

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

        public string Location
        {
            get { return _location; }
            set
            {
                if( _location != value)
                {
                    _location = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string FileName
        {
            get { return _filename; }
            set
            {
                if( _filename != value)
                {
                    _filename = value;
                    SettingsViewModel.Instance.LastFilename = _filename;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                if( _notes != value )
                {
                    _notes = value;
                    NotifyPropertyChanged();
                }
            }

        }

        public bool IsRegular
        {
            get { return _meetingType == MeetingTypes.Regular; }
        }

        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                if( _isOpen !=value)
                {
                    _isOpen = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        #endregion

        /// <summary>
        /// 
        /// </summary>
        static MinutesViewModel()
        {
            
        }

        public void Clear()
        {
            // since we're dealing with a singleton we need to do some manual clearing
            this.Bills.Clear();
            this.Candidates.Clear();
            this.Visitors.Clear();
            this.Monies.Clear();
            this.Locations.Clear();

            this.SeniorWarden = String.Empty;
            this.WorshipfulMaster = String.Empty;
            this.SeniorWarden = String.Empty;
            this.Location = String.Empty;

            this.FileName = String.Empty;
            this.IsOpen = false;

            this.ByDispensation = false;
            this.ClosingDegree = (int)Degrees.EnteredApprentice;
            this.MeetingDate = DateTime.Now;
            this.MeetingType = (int)MeetingTypes.Regular;
            this.MembersCount = 0;
            this.Notes = String.Empty;
            this.OpeningDegree = (int)Degrees.EnteredApprentice;
            this.OpeningForm = (int)Forms.InDueForm;
            this.RegularMeetingCount = 0;
            this.SpecialMeetingCount = 0;
            this.VisitorsCount = 0;

            this.LoadValuesFromSettings();

            
        }

        /// <summary>
        /// Prevents a default instance of the MinutesViewModel class from being instantiated.
        /// </summary>
        private MinutesViewModel()
        {
            // make sure our collections are OK to start
            _visitors = new ObservableCollection<VisitorModel>();

            _bills = new ObservableCollection<Models.Bill>();

            _monies = new ObservableCollection<Models.Money>();

            _candidates = new ObservableCollection<Candidate>();

            _notes = String.Empty;

            _location = String.Empty;

            _locations = new List<string>();

            _meetingDate = DateTime.Now;
            
            LoadValuesFromSettings();

        }

        #region Private Methods

        private void OnSave( )
        {
            Saved?.Invoke( this, EventArgs.Empty );
        }

        /// <summary>
        /// Loads the values from the settings for default use
        /// </summary>
        private void LoadValuesFromSettings()
        {
            _locations.AddRange( SettingsViewModel.Instance.MeetingLocations.Split( ',' ) );

            _wm = SettingsViewModel.Instance.WorshipfulMaster;
            _sw = SettingsViewModel.Instance.SeniorWarden;
            _jw = SettingsViewModel.Instance.JuniorWarden;
            
            _regularMeetingCount = SettingsViewModel.Instance.RegularMeetingCount;
            _specialMeetingCount = SettingsViewModel.Instance.SpecialMeetingCount;
            _membersCount = SettingsViewModel.Instance.RegularMeetingCount;
            _visitorsCount = 0;

        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                if( String.IsNullOrWhiteSpace( FileName ) )
                {
                    FileName = String.Format( "temp__{0}.lodge", DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss-tt") );
                }

                XmlSerializer xsSubmit = new XmlSerializer( typeof( MinutesViewModel ) );
                
                using( var writer = XmlWriter.Create( this.FileName ) )
                {
                    xsSubmit.Serialize( writer, this );
                }

                OnSave();

                return true;

            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Reset()
        {
            this.LoadValuesFromSettings();
        }

        /// <summary>
        /// Saves this instance to the specified filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool SaveAs( string filename )
        {
            this.FileName = filename;
            return this.Save();
        }

        /// <summary>
        /// Loads this instance from the specified filename.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool Load( string fileName )
        {
            this.FileName = fileName;
            return Load();
            
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer( typeof( MinutesViewModel ) );

                using( StreamReader reader = new StreamReader( this.FileName ) )
                {
                    MinutesViewModel.Instance = (MinutesViewModel)serializer.Deserialize( reader );
                }
                
                return true;

            }
            catch( Exception ex )
            {
                File.AppendAllText( "error.log", Environment.NewLine + Environment.NewLine + DateTime.Now + Environment.NewLine + ex.ToString() );
                return false;
            }
        }
        
        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        /// <returns></returns>
        public bool Refresh()
        {
            return false;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            // TODO: build a to string from our values
            return "Justin LeCheminant";

        }

        #endregion

    }

}
