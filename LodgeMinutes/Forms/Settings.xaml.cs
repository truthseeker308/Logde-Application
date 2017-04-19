using LodgeMinutesMiddleWare.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LodgeMinutes.Forms
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        #region Fields

        #endregion

        /// <summary>
        /// Creates a new instance of the settings class
        /// </summary>
        public Settings()
        {
            InitializeComponent();

            // get our settings and bind them to the form
            this.DataContext = SettingsViewModel.Instance;

            // set the time combo since the setting is a boolean we can't bind
            this.cbTimeFormat.SelectedIndex = SettingsViewModel.Instance.IsTwelveHourFormat ? 0 : 1;
            
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

        /// <summary>
        /// Handles the Click event of the buttonSave control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if( SettingsViewModel.Instance.Save() )
                {
                    MessageBox.Show( "Settings saved successfully", "Success", MessageBoxButton.OK );
                }
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                var item = sender as ComboBox;

                if (item != null)
                {
                    SettingsViewModel.Instance.IsTwelveHourFormat = item.SelectedIndex == 0;
                }
            }
        }
    }

}