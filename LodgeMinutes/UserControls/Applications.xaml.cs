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
        /// Handles the Click event of the buttonOutcome control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonOutcome_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                this.SaveApplicant();
               
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
        /// Saves the name of the applicant.
        /// </summary>
        private void SaveApplicant()
        {
            var message = String.Empty;

            var type = GetApplicationType();

            var readOrBalloted = (this.rbRead.IsChecked.HasValue && this.rbRead.IsChecked.Value) ? "read" : "balloted";

            message = String.Format("An Application {0} from {1} was {2}", type, this.tbApplicantName.Text, readOrBalloted);

            // handle read or balloted
            if( this.rbRead.IsChecked.HasValue && this.rbRead.IsChecked.Value)
            {
                message = String.Concat(message, " at ", DateTime.Now.ToShortDateString(), ". The application will be referred to an Investigating Committee.");
            }
            else
            {
                message = String.Concat(message, ". The Investigation Committee report was ", this.cbInvestigation.Text, " and ", this.tbApplicantName.Text, " was elected to ", GetBallotType() );

                if (this.rbFailed.IsChecked.HasValue && this.rbFailed.IsChecked.Value)
                {
                    message = String.Concat(message, ". The Investigation Committee report was ", this.cbInvestigation.Text, " and failed to pass.");
                }

            }

            MinutesViewModel.Instance.Notes = String.Format("{0}{1}{2}", MinutesViewModel.Instance.Notes, Environment.NewLine,message );
            MinutesViewModel.Instance.Save();

        }

        private string GetBallotType()
        {
            var result = String.Empty;

            if (this.rbForDegrees.IsChecked.HasValue && this.rbForDegrees.IsChecked.Value)
            {
                result = "for the Degrees";
            }
            else if (this.rbForAffiliation.IsChecked.HasValue && this.rbForAffiliation.IsChecked.Value)
            {
                result = "for Affilitation";
            }
            else
            {
                result = "for Reinstatement";
            }

            return result;
        }

        private string GetApplicationType()
        {
            var result = String.Empty;

            if (this.rbForDegrees.IsChecked.HasValue && this.rbForDegrees.IsChecked.Value)
            {
                result = "to take the degrees in " + SettingsViewModel.Instance.LodgeAbreviatedName;
            }
            else if(this.rbForAffiliation.IsChecked.HasValue && this.rbForAffiliation.IsChecked.Value)
            {
                result = "to take membership in " + SettingsViewModel.Instance.LodgeAbreviatedName;      
            }
            else
            {
                result = "to reinstated membership in " + SettingsViewModel.Instance.LodgeAbreviatedName;
            }

            return result;

        }

        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbRead_Checked(object sender, RoutedEventArgs e)
        {
            // read means we gray out investigation
            this.cbInvestigation.IsEnabled = this.rbPassed.IsEnabled = this.rbFailed.IsEnabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbBalloted_Checked(object sender, RoutedEventArgs e)
        {
           this.cbInvestigation.IsEnabled = this.rbPassed.IsEnabled = this.rbFailed.IsEnabled = true;
        }

    }
}