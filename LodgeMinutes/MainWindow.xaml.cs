using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LodgeMinutes.Forms;
using System.Threading;
using System.Windows.Threading;
using LodgeMinutesMiddleWare.Views;
using Microsoft.Win32;
using System.IO;
using LodgeMinutesMiddleWare.Models;
using LodgeMinutesMiddleWare.Enums;

namespace LodgeMinutes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private readonly string HEADER = "Secretary Application - ";

        private SaveFileDialog _saveFile = new SaveFileDialog();

        private OpenFileDialog _openFile = new OpenFileDialog();

        private AboutBox _aboutBox;

        private DispatcherTimer _saveTimer;
        private DispatcherTimer _uiTimer;
        
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // get our settings from the app.config
            
            // initialize some member fields/controls
            this.textboxTime.Text = DateTime.Now.ToString( "hh:mm:ss tt" );
            
            _aboutBox = new AboutBox();

            _saveTimer = new DispatcherTimer();
            _saveTimer.Interval = new TimeSpan( 0, 0, 0, 30 );
            _saveTimer.Tick += saveTimer_Tick;
            _saveTimer.Start();

            _uiTimer = new DispatcherTimer();
            _uiTimer.Interval = new TimeSpan( 0, 0, 0, 0, 500 );
            _uiTimer.Tick += uiTimer_Tick;
            _uiTimer.Start();
            _uiTimer.IsEnabled = true;

            this.Title = HEADER + SettingsViewModel.Instance.LodgeName;

            _saveFile.AddExtension = true;
            _saveFile.CreatePrompt = true;
            _saveFile.CheckPathExists = true;
            _saveFile.DefaultExt = "lodge";
            _saveFile.Filter = "Lodge files (*.lodge)|*.lodge|All files (*.*)|*.*";
            _saveFile.InitialDirectory = new DirectoryInfo( "Saved" ).ToString();
            _saveFile.ValidateNames = true;
            _saveFile.FileOk += saveFile_FileOk;

            _openFile.Filter = "Lodge files (*.lodge)|*.lodge|All files (*.*)|*.*";
            _openFile.RestoreDirectory = true;
            _openFile.CheckFileExists = true;
            _openFile.CheckPathExists = true;
            _openFile.DefaultExt = "lodge";
            _openFile.Multiselect = false;
            _openFile.FileOk += openFile_FileOk;

            this.LoadMinuteValues();

            MinutesViewModel.Instance.Saved += Instance_Saved;

            this.ucLodge.Opening.buttonCompleteOpening.Click += ButtonCommitOpening_Click;

        }

        private void ButtonCommitOpening_Click( object sender, RoutedEventArgs e )
        {
            this.LoadMinuteValues();
        }

        private void Instance_Saved( object sender, EventArgs e )
        {
            this.textboxFilename.Text = MinutesViewModel.Instance.FileName;
        }

        /// <summary>
        /// Sets the data contexts for all our user controls
        /// </summary>
        private void SetDataContexts()
        {
            this.DataContext = MinutesViewModel.Instance;
            this.ucLodge.Opening.DataContext = MinutesViewModel.Instance;
            this.ucLodge.Closing.DataContext = MinutesViewModel.Instance;
            this.ucVisitors.DataContext = MinutesViewModel.Instance.Visitors;
            this.ucExtras.Monies.DataContext = MinutesViewModel.Instance;
            this.ucNotes.CurrentNotes.DataContext = MinutesViewModel.Instance;
            this.ucBusiness.Necrologies.DataContext = MinutesViewModel.Instance;

            // TODO: set all our user controls data contexts

        }

        private void openFile_FileOk( object sender, System.ComponentModel.CancelEventArgs e )
        {
            try
            {
                if( !e.Cancel )
                {
                    Mouse.OverrideCursor = Cursors.Wait;

                    MinutesViewModel.Instance.FileName = ( (OpenFileDialog)sender ).FileName;

                    MinutesViewModel.Instance.Load();

                    LoadMinuteValues();
                                        
                }
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        private void saveFile_FileOk( object sender, System.ComponentModel.CancelEventArgs e )
        {
            try
            {
                if( !e.Cancel )
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    
                    MinutesViewModel.Instance.FileName = ( (SaveFileDialog)sender ).FileName;

                    if( MinutesViewModel.Instance.Save() )
                    {
                        MessageBox.Show( "Minutes saved.", "Success" );
                    }
                    else
                    {
                        MessageBox.Show( "Error saving minutes.", "Error" );
                    }
                }
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        private void LoadMinuteValues()
        {
            var meetingType = (MeetingTypes)MinutesViewModel.Instance.MeetingType;

            this.ucBusiness.IsEnabled = meetingType == MeetingTypes.Regular;

            this.SetDataContexts();

        }

        #region Timer Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiTimer_Tick( object sender, EventArgs e )
        {
            this.textboxTime.Text = DateTime.Now.ToString( "hh:mm:ss tt" );
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void saveTimer_Tick( object sender, EventArgs e )
        { 
            MinutesViewModel.Instance.Save();
        }

        #endregion

        #region Menu Events

        /// <summary>
        /// Handles the Click event of the menuSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void menuSettings_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                Settings formSettings = new Settings();
                formSettings.ShowDialog();

                this.Title = HEADER + SettingsViewModel.Instance.LodgeName;

            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
        
        /// <summary>
        /// Handles the Click event of the menuExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void menuExit_Click( object sender, RoutedEventArgs e )
        {
            // if they click yes then we quit
            if( MessageBox.Show("Are you sure you want to quit?","Quit Lodge Minutes",MessageBoxButton.YesNoCancel,MessageBoxImage.Question) == MessageBoxResult.Yes )
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Handles the Click event of the menuAbout control.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void menuAbout_Click( object sender, RoutedEventArgs e )
        {
            // show our about box
            _aboutBox.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the menuNew control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.></param>
        private void menuNew_Click( object sender, RoutedEventArgs e )
        {
            _saveTimer.Stop();

            if( MessageBox.Show("Do you want to create new minutes?nAll un-saved changes will be lost.", "New Minutes?",MessageBoxButton.YesNoCancel,MessageBoxImage.Question) == MessageBoxResult.Yes )
            {
                try
                {
                    Mouse.OverrideCursor = Cursors.Wait;

                    // create a new minutes set and re-bind it
                    MinutesViewModel.Instance.Clear();
                }
                finally
                {
                    Mouse.OverrideCursor = null;
                }
            }

            _saveTimer.Start();

        }

        /// <summary>
        /// Handles the Click event of the menuOpen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.></param>
        private void menuOpen_Click( object sender, RoutedEventArgs e )
        {
            _openFile.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the menuSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.></param>
        private void menuSave_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // get a new filename if we don't have one
                if( String.IsNullOrWhiteSpace( MinutesViewModel.Instance.FileName ) )
                {
                    _saveFile.ShowDialog();
                }
                // otherwise use the existing filename
                else
                {
                    MinutesViewModel.Instance.Save();
                }
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }

            // save the data if we have an existing filename
            MinutesViewModel.Instance.Save();

            // otherwise ask for one

        }

        private void menuSaveAs_Click(object sender, RoutedEventArgs e )
        {
            _saveFile.ShowDialog();
        }


        #endregion

        #region Button Methods

        /// <summary>
        /// Handles the Click event of the buttonReopen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonReopen_Click( object sender, RoutedEventArgs e )
        {
            if( !String.IsNullOrWhiteSpace( SettingsViewModel.Instance.LastFilename ) )
            {
                var result = MessageBox.Show( "Open previously saved minutes?\nThis will cause any unsaved changes to be lost.", "Open Minutes", MessageBoxButton.YesNoCancel, MessageBoxImage.Question );

                if( result == MessageBoxResult.Yes )
                {
                    MinutesViewModel.Instance.Load( SettingsViewModel.Instance.LastFilename );
                    this.LoadMinuteValues();
                }
            }
            else
            {
                MessageBox.Show( "No previous minutes could be found.", "No Minutes" );
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonReoutput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonReoutput_Click( object sender, RoutedEventArgs e )
        {

        }

        /// <summary>
        /// Handles the Click event of the buttonNewMeeting control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonNewMeeting_Click( object sender, RoutedEventArgs e )
        {
            _saveTimer.Stop();

            if( MessageBox.Show( "Do you want to create new minutes?nAll un-saved changes will be lost.", "New Minutes?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question ) == MessageBoxResult.Yes )
            {
                try
                {
                    Mouse.OverrideCursor = Cursors.Wait;

                    // create a new minutes set and re-bind it
                    MinutesViewModel.Instance.Clear();
                }
                finally
                {
                    Mouse.OverrideCursor = null;
                }
            }

            _saveTimer.Start();

        }

        #endregion

        private void menuExport_Click(object sender, RoutedEventArgs e)
        {
            new Reports().ShowDialog();
        }

    }
}