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
    /// Interaction logic for Applications.xaml
    /// </summary>
    public partial class Applications : UserControl
    {
        #region Fields

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Applications"/> class.
        /// </summary>
        public Applications()
        {
            InitializeComponent();
        }

        #region Button Methods

        /// <summary>
        /// Handles the Click event of the buttonApplicationType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonApplicationType_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // we need to check if we have a checked radio button value
                var hasValidRadioButton = true;

                var message = String.Empty;

                // check the first radio button group
                if ( ( this.rbRead.IsChecked.HasValue && !this.rbRead.IsChecked.Value ) &&
                    ( this.rbBalloted.IsChecked.HasValue && !this.rbBalloted.IsChecked.Value ) )
                {
                    message = "Read or balloted must be selected.";
                    hasValidRadioButton = false;
                }

                // check the second radio button group
                if ( ( this.rbForDegrees.IsChecked.HasValue && !this.rbForDegrees.IsChecked.Value ) &&
                    ( this.rbForAffiliation.IsChecked.HasValue && !this.rbForAffiliation.IsChecked.Value ) &&
                    ( this.rbFoReinstatement.IsChecked.HasValue && !this.rbFoReinstatement.IsChecked.Value ) )
                {
                    message = "For type must be selected.";
                    hasValidRadioButton = false;
                }

                if( hasValidRadioButton )
                {
                    this.SaveApplicantType();

                    this.rbRead.IsChecked = false;
                    this.rbBalloted.IsChecked = false;
                    this.rbForDegrees.IsChecked = false;
                    this.rbForAffiliation.IsChecked = false;
                    this.rbFoReinstatement.IsChecked = false;

                    MessageBox.Show( "Applicant data saved.","Success" );
                }
                else
                {
                    MessageBox.Show(message,"Error",MessageBoxButton.OK,MessageBoxImage.Error); ;
                }
            }
            catch ( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nSee the error log for details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
        
        /// <summary>
        /// Handles the Click event of the buttonCommitApplicationName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCommitApplicationName_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if( !String.IsNullOrWhiteSpace(this.tbApplicantName.Text))
                {
                    this.tbApplicantName.BorderBrush = Brushes.Gray;
                    this.tbApplicantName.ToolTip = null;

                    this.SaveApplicantName();

                    MessageBox.Show( "Applicant name saved.","Success" );
                    
                }
                else
                {
                    this.tbApplicantName.BorderBrush = Brushes.Red;
                    this.tbApplicantName.ToolTip = "This field is required.";
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nSee the error log for details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
        
        /// <summary>
        /// Handles the Click event of the buttonInvestigationReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonInvestigationReport_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                this.SaveInvestigationReport();

            }
            catch ( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nSee the error log for details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonOutcome control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonOutcome_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if ( ( this.rbPassed.IsChecked.HasValue && !this.rbRead.IsChecked.Value ) &&
                    ( this.rbFailed.IsChecked.HasValue && !this.rbFailed.IsChecked.Value ) )
                {
                    MessageBox.Show( "Passed or failed must be selected." );
                }
                else
                {
                    this.SavePassedOrFailed();
                }
            }
            catch ( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "An error occured.\nSee the error log for details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Saves the investigation report.
        /// </summary>
        private void SaveInvestigationReport()
        {
            MinutesViewModel.Instance.Notes = String.Format( "{0} {1}Investigation commitee report - {2}", MinutesViewModel.Instance.Notes, Environment.NewLine, cbInvestigation.Text );
            MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Saves the passed or failed.
        /// </summary>
        private void SavePassedOrFailed()
        {
            string passed = rbPassed.IsChecked.HasValue && rbPassed.IsChecked.Value ? "Passed" : "Failed";

            MinutesViewModel.Instance.Notes = String.Format( "{0} {1}Applicant vote - {2}", MinutesViewModel.Instance.Notes, Environment.NewLine, passed );
            MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Saves the type of the applicant.
        /// </summary>
        private void SaveApplicantType()
        {
            string type = rbRead.IsChecked.HasValue && rbRead.IsChecked.Value ? "Read" : "Balloted";
            string degree = String.Empty;

            if( rbRead.IsChecked.HasValue && rbRead.IsChecked.Value )
            {
                degree = "For degrees";
            }
            else if( rbRead.IsChecked.HasValue && rbRead.IsChecked.Value )
            {
                degree = "For affiliation";
            }
            else
            {
                degree = "For resintatment M 5 years";
            }

            MinutesViewModel.Instance.Notes = String.Format( "{0} {1}Applicant Type - {2} and {3}", MinutesViewModel.Instance.Notes, Environment.NewLine, type, degree );
            MinutesViewModel.Instance.Save();

        }

        /// <summary>
        /// Saves the name of the applicant.
        /// </summary>
        private void SaveApplicantName()
        {
            MinutesViewModel.Instance.Notes = String.Format( "{0} {1}Applicant name {2}", MinutesViewModel.Instance.Notes, Environment.NewLine, tbApplicantName.Text );
            MinutesViewModel.Instance.Save();
        }

        #endregion

    }
}