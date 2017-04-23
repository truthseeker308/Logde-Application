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
using LodgeMinutesMiddleWare.Helpers;

namespace LodgeMinutes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private readonly string HEADER = "Secretary Application - ";

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

            // initialize some member fields/controls
            this.textboxTime.Text = FormattingHelper.GetShortTimeWithAmPm();
            
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

            this.CreateDirectories();

            this.LoadMinuteValues();

            MinutesViewModel.Instance.Saved += Instance_Saved;

            this.ucLodge.Opening.buttonCompleteOpening.Click += ButtonCommitOpening_Click;

        }

        /// <summary>
        /// Creates the directories.
        /// </summary>
        private void CreateDirectories()
        {
            try
            {
                var minutesDirectory = String.Format( "{0}\\{1}", Environment.CurrentDirectory, SettingsViewModel.Instance.SaveMinutesDirectory );

                // if our minutes directory doesn't exist we need to create it
                if( !Directory.Exists( minutesDirectory ) )
                {
                    Directory.CreateDirectory( minutesDirectory );
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
            }

            try
            {
                var wordDirectory = String.Format( "{0}\\{1}", Environment.CurrentDirectory, SettingsViewModel.Instance.SaveWordDirectory );

                // if our word exports directory doesn't exist we need to create it
                if( !Directory.Exists( wordDirectory ) )
                {
                    Directory.CreateDirectory( wordDirectory );
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
            }
        }

        /// <summary>
        /// Handles the Saved event of the Instance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Instance_Saved( object sender, EventArgs e )
        {
            this.textboxFilename.Text = SettingsViewModel.Instance.LastFilename;
        }

        /// <summary>
        /// Sets the data contexts for all our user controls
        /// </summary>
        private void SetDataContexts()
        {
            this.DataContext = MinutesViewModel.Instance;
            this.ucLodge.Opening.DataContext = SettingsViewModel.Instance;
            this.ucNotes.CurrentNotes.DataContext = MinutesViewModel.Instance;
        }

        /// <summary>
        /// Loads the minute values.
        /// </summary>
        private void LoadMinuteValues()
        {
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
            this.textboxTime.Text = FormattingHelper.GetDateAndTime();
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
        /// Handles the Click event of the menuExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void menuExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
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
            _saveTimer.Stop();

            if( !String.IsNullOrWhiteSpace( SettingsViewModel.Instance.LastFilename ) )
            {
                var result = MessageBox.Show( "Open previously saved minutes?\nThis will cause any unsaved changes to be lost.", "Open Minutes", MessageBoxButton.YesNoCancel, MessageBoxImage.Question );

                if( result == MessageBoxResult.Yes )
                {
                    this.LoadLastMinuteValues();
                }
            }
            else
            {
                MessageBox.Show( "No previous minutes could be found.", "No Minutes" );
            }

            _saveTimer.Start();

        }

        /// <summary>
        /// Handles the Click event of the buttonReoutput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonReoutput_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // create a new minutes set and re-bind it
                MinutesViewModel.Instance.Export();
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonNewMeeting control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonNewMeeting_Click( object sender, RoutedEventArgs e )
        {
            _saveTimer.Stop();

            if( MessageBox.Show( "Do you want to create new minutes?\n\nAll un-saved changes will be lost.\n\nAnd any previously created minutes for this day will be lost.", "New Minutes?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question ) == MessageBoxResult.Yes )
            {
                try
                {
                    Mouse.OverrideCursor = Cursors.Wait;

                    // create a new minutes set and re-bind it
                    MinutesViewModel.Instance.Notes = String.Empty;
                }
                finally
                {
                    Mouse.OverrideCursor = null;
                }
            }

            _saveTimer.Start();

        }

        /// <summary>
        /// Handles the Click event of the ButtonCommitOpening control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonCommitOpening_Click(object sender, RoutedEventArgs e)
        {
            this.LoadMinuteValues();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads the last minute values.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadLastMinuteValues()
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // clear the minutes and re-load them from the last used file
                MinutesViewModel.Instance.Notes = String.Empty;

                MinutesViewModel.Instance.Notes = File.ReadAllText( SettingsViewModel.Instance.LastFilename );

            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error loading last minutes.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        #endregion


    }
}