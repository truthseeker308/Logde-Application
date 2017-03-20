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

namespace LodgeMinutes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

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
            _aboutBox = new AboutBox();

            _saveTimer = new DispatcherTimer();
            _saveTimer.Interval = new TimeSpan( 0, 0, 0, 30 );
            _saveTimer.Tick += saveTimer_Tick;

            _uiTimer = new DispatcherTimer();
            _uiTimer.Interval = new TimeSpan( 0, 0, 0, 30 );
            _uiTimer.Tick += _uiTimer_Tick;// uiTimer_Tick;
            _uiTimer.Start();
            _uiTimer.IsEnabled = true;

        }

        private void _uiTimer_Tick( object sender, EventArgs e )
        {
            this.textboxTime.Text = DateTime.Now.ToString( "HH::mm tt" );
        }

        #region Timer Events

        /// <summary>
        /// Handles the Tick event of the uiTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void uiTimer_Tick( object sender, EventArgs e )
        {
            this.textboxTime.Text = DateTime.Now.ToString( "HH::mm tt" );
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void saveTimer_Tick( object sender, EventArgs e )
        {
            // TODO: Save all inputs...
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
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void menuAbout_Click( object sender, RoutedEventArgs e )
        {
            // show our about box
            _aboutBox.ShowDialog();
        }

        #endregion

    }
}