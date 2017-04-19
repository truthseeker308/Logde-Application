using LodgeMinutesMiddleWare.Helpers;
using LodgeMinutesMiddleWare.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LodgeMinutes.UserControls
{
    /// <summary>
    /// Interaction logic for Closing.xaml
    /// </summary>
    public partial class Closing : UserControl
    {
        public Closing()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the buttonCloseMeeting Control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCloseMeeting_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // we need to build some notes on closing
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("{0}{0}Lodge closed on {1}{0}Closing Form - {2}", Environment.NewLine, FormattingHelper.GetDateAndTime(), this.comboboxClosingForm.Text );

                // append to our minutes
                MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, Environment.NewLine, Environment.NewLine, sb.ToString() );

                // finally save our minutes
                if( MinutesViewModel.Instance.Save() )
                {
                    this.buttonOutputMinutes.IsEnabled = true;

                    MessageBox.Show( "Lodge closed." );
                }
                else
                {
                    MessageBox.Show( "Error closing lodge." );
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error closing meeting.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the comboboxFromDegree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void comboboxFromDegree_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            // we changed the drop down that says we changed the meeting type so show
            // that by endable the to degree combo
            this.comboboxToDegree.IsEnabled = true;
        }

        /// <summary>
        /// Handles the Click event of the buttonOutputMinutes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonOutputMinutes_Click( object sender, RoutedEventArgs e )
        {
            // output to word document
            MinutesViewModel.Instance.Export();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the comboboxToDegree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void comboboxToDegree_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            try
            {
                if( !String.IsNullOrWhiteSpace( this.comboboxToDegree.Text ) )
                {
                    Mouse.OverrideCursor = Cursors.Wait;

                    // we need to build some notes on closing
                    StringBuilder sb = new StringBuilder();

                    sb.AppendFormat( "{0}Degree type changed From - {1}{0}To - {2}", Environment.NewLine, this.comboboxFromDegree.Text , this.comboboxToDegree.Text );

                    // append to our minutes
                    MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, Environment.NewLine, Environment.NewLine, sb.ToString() );

                    // finally save our minutes
                    MinutesViewModel.Instance.Save();
                }

            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error chaging degree type.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

    }
}
