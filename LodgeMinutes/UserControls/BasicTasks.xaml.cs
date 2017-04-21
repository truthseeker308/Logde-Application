using LodgeMinutesMiddleWare.Helpers;
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
    /// Interaction logic for BasicTasks.xaml
    /// </summary>
    public partial class BasicTasks : UserControl
    {
        #region Fields

        private bool _isOpen = false;

        private bool _isSuspended = false;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicTasks"/> class.
        /// </summary>
        public BasicTasks()
        {
            InitializeComponent();
        }

        #region Button Methods

        /// <summary>
        /// Handles the Click event of the buttonBusinessOpened control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonBusinessOpened_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if( _isOpen )
                {
                    if( this.CloseBusinessMeeting() )
                    {
                        _isOpen = false;
                        this.buttonBusinessOpened.Content = "Open Business Meeting";
                        MessageBox.Show( "Business meeting closed" );
                    }
                    else
                    {
                        MessageBox.Show( "Error opening business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                    }
                }
                else
                {
                    if( this.OpenBusinessMeeting() )
                    {
                        _isOpen = true;
                        this.buttonBusinessOpened.Content = "Close Business Meeting";
                        MessageBox.Show( "Business meeting opened" );
                    }
                    else
                    {
                        MessageBox.Show( "Error opening business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                    }
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error with business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonBusinessClosedReopened control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonBusinessClosedReopened_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if( _isSuspended )
                {
                    if( this.ReOpenBusinessMeeting() )
                    {
                        _isSuspended = false;
                        this.buttonBusinessClosedReopened.Content = "Suspend Business Meeting";
                        MessageBox.Show( "Business meeting re-opened" );
                    }
                    else
                    {
                        MessageBox.Show( "Error opening business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                    }
                }
                else
                {
                    if( this.SuspendBusinessMeeting() )
                    {
                        _isSuspended = true;
                        this.buttonBusinessClosedReopened.Content = "Re-open Business Meeting";
                        MessageBox.Show( "Business meeting suspended" );
                    }
                    else
                    {
                        MessageBox.Show( "Error opening business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                    } 
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error with business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonGrandCellPhone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonGrandCellPhone_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                var grandCommunications = this.tbGrandConstitutions.Text.Trim();
                var celPhonePolicyRad = this.cbCellPhonePolicy.IsChecked;

                if( String.IsNullOrWhiteSpace( grandCommunications ) )
                {
                    grandCommunications = "No grand communications read.";
                }
                else
                {
                    grandCommunications = String.Concat("The following grand communications were read",Environment.NewLine,grandCommunications);
                }

                if( celPhonePolicyRad.HasValue && celPhonePolicyRad.Value )
                {
                    grandCommunications = String.Concat( grandCommunications,  Environment.NewLine, "The cell phone policy was read." );
                }
                else
                {
                    grandCommunications = String.Concat( grandCommunications,  Environment.NewLine, "The cell phone policy was not read." );
                }

                MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, Environment.NewLine, grandCommunications );

                if( MinutesViewModel.Instance.Save() )
                {
                    MessageBox.Show( "Grand constitution saved." );
                }
                else
                {
                    MessageBox.Show( "Error saving grand constitution.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error with business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonSecretaryReports control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonSecretaryReports_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // if we have a valid report then proc
                if( this.ValidateSecretaryReport() )
                {
                    // save the secretary report to the notes
                    if( this.SaveSecretaryReport() )
                    {
                        this.ClearErrorState( this.dtSecreataryDate );
                        MessageBox.Show( "Secretaries report saved", "Success" );
                    }
                }
                else
                {
                    this.SetSecretaryErrorControls();
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error with business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonTreasurerReports control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonTreasurerReports_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // validate the report stuff
                // if we have a valid report then proc
                if( this.ValidateTreasurerReport() )
                {
                    // save the secretary report to the notes
                    if( this.SaveTreasurerReport() )
                    {
                        this.ClearErrorState( this.dtDateTreasurer1 );
                        this.ClearErrorState( this.dtDateTreasurer2 );
                        MessageBox.Show( "Treasurers report saved", "Success" );
                    }
                }
                else
                {
                    this.SetTreasurerErrorControls();
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error with business meeting", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        #endregion
        
        #region Private Methods

        /// <summary>
        /// Sets the secretary error controls.
        /// </summary>
        private void SetSecretaryErrorControls()
        {
            if( this.dtSecreataryDate.Value == null )
            {
                this.SetErrorState( this.dtSecreataryDate );
            }
            else
            {
                this.ClearErrorState( this.dtSecreataryDate );
            }
        }

        /// <summary>
        /// Sets the treasurer error controls.
        /// </summary>
        private void SetTreasurerErrorControls()
        {
            if( this.dtDateTreasurer1.Value == null )
            {
                this.SetErrorState( this.dtDateTreasurer1 );
            }
            else
            {
                this.ClearErrorState( this.dtDateTreasurer1 );
            }

            if( this.dtDateTreasurer2.Value == null )
            {
                this.SetErrorState( this.dtDateTreasurer2 );
            }
            else
            {
                this.ClearErrorState( this.dtDateTreasurer2 );
            }
        }

        /// <summary>
        /// Sets the state of the error.
        /// </summary>
        /// <param name="control">The control.</param>
        private void SetErrorState( Control control )
        {
            control.BorderBrush = Brushes.Red;
            control.ToolTip = "This field is required";
        }

        /// <summary>
        /// Clears the state of the error.
        /// </summary>
        /// <param name="control">The control.</param>
        private void ClearErrorState( Control control )
        {
            control.BorderBrush = null;
            control.ToolTip = null;
        }

        /// <summary>
        /// Validates the secretary report.
        /// </summary>
        private bool ValidateSecretaryReport()
        {
            return !(this.dtSecreataryDate.Value == null);
        }

        /// <summary>
        /// Saves the secretary report.
        /// </summary>
        /// <returns></returns>
        private bool SaveSecretaryReport()
        {
            var message = String.Format( "The Secretarie's report was read on '{0}' and was '{1}'", this.dtSecreataryDate.Value.Value.ToShortDateString(), cbMinutesState.Text );

            MinutesViewModel.Instance.Notes = String.Format("{0}{1}{2}",MinutesViewModel.Instance.Notes,Environment.NewLine,message);

            return MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Validates the treasurer report.
        /// </summary>
        private bool ValidateTreasurerReport()
        {
            return !(this.dtDateTreasurer1.Value == null || this.dtDateTreasurer2.Value == null);
        }

        /// <summary>
        /// Saves the treasurer report.
        /// </summary>
        /// <returns></returns>
        private bool SaveTreasurerReport()
        {
            var message = String.Format( "The Treasurer's report from '{0} to '{1} and was '{2}", this.dtDateTreasurer1.Value.Value.ToShortDateString(), this.dtDateTreasurer2.Value.Value.ToShortDateString(), cbMinutesState.Text );
            
            MinutesViewModel.Instance.Notes = String.Format("{0}{1}{2}",MinutesViewModel.Instance.Notes,Environment.NewLine,message);

            return MinutesViewModel.Instance.Save();

        }

        /// <summary>
        /// Re the open business meeting.
        /// </summary>
        /// <returns></returns>
        private bool ReOpenBusinessMeeting()
        {
            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, Environment.NewLine, "Business Meeting Re-opened at: ", FormattingHelper.GetDateAndTime() );

            return MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Suspends the business meeting.
        /// </summary>
        /// <returns></returns>
        private bool SuspendBusinessMeeting()
        {
            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, Environment.NewLine, "Business Meeting Suspened at: ", FormattingHelper.GetDateAndTime() );

            return MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Closes the business meeting.
        /// </summary>
        /// <returns></returns>
        private bool CloseBusinessMeeting()
        {
            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, Environment.NewLine, "Business Meeting Closed at: ", FormattingHelper.GetDateAndTime() );

            return MinutesViewModel.Instance.Save();
        }
        
        /// <summary>
        /// Opens the business meeting.
        /// </summary>
        /// <returns></returns>
        private bool OpenBusinessMeeting()
        {
            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, Environment.NewLine, "Business Meeting Opened at: ", FormattingHelper.GetDateAndTime() );

            return MinutesViewModel.Instance.Save();

        }

        #endregion

    }
}
