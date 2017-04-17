using LodgeMinutesMiddleWare.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LodgeMinutes.UserControls
{
    /// <summary>
    /// Interaction logic for Opening.xaml
    /// </summary>
    public partial class Opening : UserControl
    {
        /// <summary>
        /// Creates a new instance of the Opening class.
        /// </summary>
        public Opening()
        {
            InitializeComponent();
        }

        private void comboboxLocations_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            if( sender != null )
            {
                // update the location value of our meeting
                MinutesViewModel.Instance.Location = this.comboboxLocations.SelectedValue.ToString();
            }
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            // set the current opening time
            MinutesViewModel.Instance.MeetingDate = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCompleteOpening_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if( MinutesViewModel.Instance.Save() )
                {
                    buttonCompleteOpening.IsEnabled = false;
                    buttonSetTime.IsEnabled = false;
                    MessageBox.Show( "Lodge opened.","Success");
                }
                else
                {
                    buttonCompleteOpening.IsEnabled = true;
                    buttonSetTime.IsEnabled = true;
                    MessageBox.Show( "Error opening lodge.", "Error" );
                }
            }
            catch(Exception ex)
            {
                buttonCompleteOpening.IsEnabled = false;
                File.AppendAllText( "error.log", Environment.NewLine + Environment.NewLine + DateTime.Now + Environment.NewLine + ex.ToString() );
                MessageBox.Show( ex.ToString(), "Error opening lodge.", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}
