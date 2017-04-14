using LodgeMinutesMiddleWare.Views;
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
using System.Windows.Shapes;

namespace LodgeMinutes.Forms
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        #region Fields

        private SettingsViewModel _settings;

        #endregion

        /// <summary>
        /// Creates a new instance of the settings class
        /// </summary>
        public Settings()
        {
            InitializeComponent();

            // get our settings and bind them to the form
            _settings = new SettingsViewModel();
            this.DataContext = _settings;

        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            Mouse.OverrideCursor = null;
        }
    }
}
