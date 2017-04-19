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
    /// Interaction logic for Degrees.xaml
    /// </summary>
    public partial class Degrees : UserControl
    {
        #region Fields

        private bool _firstTime = false;

        private string _header = "\n\nDegrees\n______________________________\n";

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Degrees"/> class.
        /// </summary>
        public Degrees()
        {
            InitializeComponent();
        }

        #region Button Methods

        /// <summary>
        /// Handles the Click event of the FirstSectionBegun control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonFirstBegun_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if( !CheckDegreeCandidates() )
                {
                    this.BeginFirstSection();
                }
                else
                {
                    MessageBox.Show( "At least one candidate name must be entered.", "No Candidates", MessageBoxButton.OK, MessageBoxImage.Error );
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nIf this contues please consult the error log.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the FirstSectionEnded control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonFirstEnded_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                this.EndFirstSection();

            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nIf this contues please consult the error log.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the FirstSectionBegun control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonSecondBegun_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if( !CheckDegreeCandidates() )
                {
                    this.BeginSecondSection();
                }
                else
                {
                    MessageBox.Show( "At least one candidate name must be entered.", "No Candidates", MessageBoxButton.OK, MessageBoxImage.Error );
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nIf this contues please consult the error log.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the FirstSectionEnded control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonSecondEnded_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                this.EndSecondSection();

            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nIf this contues please consult the error log.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonSecond control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonThirdBegun_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                this.BeginThirdSection();


            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nIf this contues please consult the error log.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonThird control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonThirdEnded_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                this.EndThirdSection();

            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nIf this contues please consult the error log.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

       

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks the degree candidates.
        /// </summary>
        /// <returns></returns>
        private bool CheckDegreeCandidates()
        {
            // we have to have at least one candidate name
            return String.IsNullOrWhiteSpace( this.tb1.Text ) &&
                String.IsNullOrWhiteSpace( this.tb2.Text ) &&
                String.IsNullOrWhiteSpace( this.tb3.Text ) &&
                String.IsNullOrWhiteSpace( this.tb4.Text ) &&
                String.IsNullOrWhiteSpace( this.tb5.Text ) &&
                String.IsNullOrWhiteSpace( this.tb6.Text ) &&
                String.IsNullOrWhiteSpace( this.tb7.Text ) &&
                String.IsNullOrWhiteSpace( this.tb8.Text );
        }

        /// <summary>
        /// Clears the candidates.
        /// </summary>
        private void ClearCandidates()
        {
            this.tb1.Text =
            this.tb2.Text =
            this.tb3.Text =
            this.tb4.Text =
            this.tb5.Text =
            this.tb6.Text =
            this.tb7.Text =
            this.tb8.Text = String.Empty;
        }
        
        /// <summary>
        /// Handles the SelectionChanged event of the comboboxDegreeType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void comboboxDegreeType_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            //this.ClearCandidates();
            //this.FirstSectionBegun.IsEnabled = true;
            //this.FirstSectionEnded.IsEnabled = false;
            //this.buttonSecond.IsEnabled = false;
            //this.buttonThird.IsEnabled = false;
        }

        /// <summary>
        /// Gets the candidate names.
        /// </summary>
        /// <returns></returns>
        private string GetCandidateNames()
        {
            StringBuilder sb = new StringBuilder();

            if( !String.IsNullOrWhiteSpace( this.tb1.Text ) )
            {
                sb.AppendLine( this.tb1.Text);
            }

            if( !String.IsNullOrWhiteSpace( this.tb2.Text ) )
            {
                sb.AppendLine( this.tb2.Text);
            }

            if( !String.IsNullOrWhiteSpace( this.tb3.Text ) )
            {
                sb.AppendLine( this.tb3.Text);
            }

            if( !String.IsNullOrWhiteSpace( this.tb4.Text ) )
            {
                sb.AppendLine( this.tb4.Text);
            }

            if( !String.IsNullOrWhiteSpace( this.tb5.Text ) )
            {
                sb.AppendLine( this.tb5.Text);
            }

            if( !String.IsNullOrWhiteSpace( this.tb6.Text ) )
            {
                sb.AppendLine( this.tb6.Text);
            }

            if( !String.IsNullOrWhiteSpace( this.tb7.Text ) )
            {
                sb.AppendLine( this.tb7.Text);
            }

            if( !String.IsNullOrWhiteSpace( this.tb8.Text ) )
            {
                sb.AppendLine( this.tb8.Text);
            }

            sb.AppendLine();

            return sb.ToString();

        }

        /// <summary>
        /// Sets the text box enabled status.
        /// </summary>
        /// <param name="isEnabled">if set to <c>true</c> [is enabled].</param>
        private void SetTextBoxEnabledStatus( bool isEnabled )
        {
            this.tb1.IsEnabled =
            this.tb2.IsEnabled =
            this.tb3.IsEnabled =
            this.tb4.IsEnabled =
            this.tb5.IsEnabled =
            this.tb6.IsEnabled =
            this.tb7.IsEnabled =
            this.tb8.IsEnabled = isEnabled;
        }

        /// <summary>
        /// Sets the ComboBox enabled status.
        /// </summary>
        /// <param name="isEnabled">if set to <c>true</c> [is enabled].</param>
        private void SetComboBoxEnabledStatus( bool isEnabled )
        {
            this.comboboxDegreeType.IsEnabled = isEnabled;
        }

        /// <summary>
        /// Sets the CheckBox enabled status.
        /// </summary>
        /// <param name="isEnabled">if set to <c>true</c> [is enabled].</param>
        private void SetCheckBoxEnabledStatus( bool isEnabled )
        {
            this.checkboxDispensation.IsEnabled = isEnabled;
        }

        /// <summary>
        /// Begins the first section.
        /// </summary>
        private void BeginFirstSection()
        {
            // set our control states
            this.buttonFirstBegun.IsEnabled = false;
            this.buttonFirstEnded.IsEnabled = true;
            this.buttonSecondBegun.IsEnabled = false;
            this.buttonSecondEnded.IsEnabled = false;
            this.buttonThirdBegun.IsEnabled = false;
            this.buttonThirdEnded.IsEnabled = false;

            this.SetTextBoxEnabledStatus( false );

            this.SetCheckBoxEnabledStatus( false );

            this.SetComboBoxEnabledStatus( false );

            // get our names
            var candidates = this.GetCandidateNames();

            // write out to our notes
            StringBuilder sb = new StringBuilder();

            var notes = String.Format( "{0}Degree - {1}{0}Dispensation for more than 5 candidates - {2}{0}Candidates - {0}{4}{0}First section started on - {3}{0}", Environment.NewLine, this.comboboxDegreeType.Text, this.checkboxDispensation.IsChecked, FormattingHelper.GetDateAndTime(), candidates );

            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, notes );

            MinutesViewModel.Instance.Save();

        }

        /// <summary>
        /// Ends the first section.
        /// </summary>
        private void EndFirstSection()
        {
            // set our control states
            this.buttonFirstBegun.IsEnabled = false;
            this.buttonFirstEnded.IsEnabled = false;
            this.buttonSecondBegun.IsEnabled = true;
            this.buttonSecondEnded.IsEnabled = false;
            this.buttonThirdBegun.IsEnabled = false;
            this.buttonThirdEnded.IsEnabled = false;

            this.SetTextBoxEnabledStatus( false );

            this.SetCheckBoxEnabledStatus( false );

            this.SetComboBoxEnabledStatus( false );

            // get our names
            var candidates = this.GetCandidateNames();

            // write out to our notes
            StringBuilder sb = new StringBuilder();

            var notes = String.Format( "{0}First section ended on - {1}{0}", Environment.NewLine, FormattingHelper.GetDateAndTime() );

            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, notes );

            MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Begins the second section.
        /// </summary>
        private void BeginSecondSection()
        {
            // set our control states
            this.buttonFirstBegun.IsEnabled = false;
            this.buttonFirstEnded.IsEnabled = false;
            this.buttonSecondBegun.IsEnabled = false;
            this.buttonSecondEnded.IsEnabled = true;
            this.buttonThirdBegun.IsEnabled = false;
            this.buttonThirdEnded.IsEnabled = false;

            // get our names
            var candidates = this.GetCandidateNames();

            // write out to our notes
            StringBuilder sb = new StringBuilder();

            var notes = String.Format( "{0}Second section started on - {1}{0}", Environment.NewLine, FormattingHelper.GetDateAndTime() );

            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, notes );

            MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Ends the second section.
        /// </summary>
        private void EndSecondSection()
        {
            // set our control states
            this.buttonFirstBegun.IsEnabled = false;
            this.buttonFirstEnded.IsEnabled = false;
            this.buttonSecondBegun.IsEnabled = false;
            this.buttonSecondEnded.IsEnabled = false;
            this.buttonThirdBegun.IsEnabled = true;
            this.buttonThirdEnded.IsEnabled = false;

            // get our names
            var candidates = this.GetCandidateNames();

            // write out to our notes
            StringBuilder sb = new StringBuilder();

            var notes = String.Format( "{0}Second section ended on - {1}{0}", Environment.NewLine, FormattingHelper.GetDateAndTime() );

            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, notes );

            MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Begins the third section.
        /// </summary>
        private void BeginThirdSection()
        {
            // set our control states
            this.buttonFirstBegun.IsEnabled = false;
            this.buttonFirstEnded.IsEnabled = false;
            this.buttonSecondBegun.IsEnabled = false;
            this.buttonSecondEnded.IsEnabled = false;
            this.buttonThirdBegun.IsEnabled = false;
            this.buttonThirdEnded.IsEnabled = true;

            // get our names
            var candidates = this.GetCandidateNames();

            // write out to our notes
            StringBuilder sb = new StringBuilder();

            var notes = String.Format( "{0}Third section started on - {1}{0}", Environment.NewLine, FormattingHelper.GetDateAndTime() );

            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, notes );

            MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Ends the third section.
        /// </summary>
        private void EndThirdSection()
        {
            // set our control states
            this.buttonFirstBegun.IsEnabled = true;
            this.buttonFirstEnded.IsEnabled = false;
            this.buttonSecondBegun.IsEnabled = false;
            this.buttonSecondEnded.IsEnabled = false;
            this.buttonThirdBegun.IsEnabled = false;
            this.buttonThirdEnded.IsEnabled = false;

            this.SetTextBoxEnabledStatus( true );

            this.SetCheckBoxEnabledStatus( true );

            this.SetComboBoxEnabledStatus( true );

            // get our names
            var candidates = this.GetCandidateNames();

            // write out to our notes
            StringBuilder sb = new StringBuilder();

            var notes = String.Format( "{0}Third section ended on - {1}{0}", Environment.NewLine, FormattingHelper.GetDateAndTime() );

            MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, notes );

            MinutesViewModel.Instance.Save();
        }

        #endregion

    }
}