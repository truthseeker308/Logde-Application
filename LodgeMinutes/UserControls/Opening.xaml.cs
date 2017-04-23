using LodgeMinutesMiddleWare.Helpers;
using LodgeMinutesMiddleWare.Models;
using LodgeMinutesMiddleWare.Views;
using System;
using System.IO;
using System.Text;
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
        /// Initializes a new instance of the <see cref="Opening"/> class.
        /// </summary>
        public Opening()
        {
            InitializeComponent();

            this.dtDate.SelectedDate = DateTime.Now;

        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click( object sender, RoutedEventArgs e )
        {
            // set the current opening 
            this.lblMeetingTime.Content = FormattingHelper.GetShortTimeWithAmPm();
        }

        /// <summary>
        /// Handles the Click event of the buttonCompleteOpening control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCompleteOpening_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                string location = String.Empty;

                // we need to do some processing of the location
                // it can be a bit tricky
                if( !String.IsNullOrWhiteSpace( this.tbLocation.Text ) )
                {
                    // this is a new manually entered location so save it and add it to the combobox
                    location = this.tbLocation.Text;
                    SettingsViewModel.Instance.MeetingLocations.Insert( 0, location + "," );
                    SettingsViewModel.Instance.Locations.Add( location );
                    SettingsViewModel.Instance.Save();
                }
                else
                { 
                    location = this.ddlLocations.SelectedValue != null ? this.ddlLocations.Text : "No location specified";
                }

                string time = this.lblMeetingTime.Content == null ? DateTime.Now.ToShortTimeString() : this.lblMeetingTime.Content.ToString();

                var message = String.Empty;

                // 0 means regular, 1 means special
                if ( this.ddlMeetingYType.SelectedIndex == 0  )
                {
                    message = String.Format( Properties.Resources.regularOpen, SettingsViewModel.Instance.LodgeName, location, DateTime.Now.ToLongDateString(), this.ddlDegree.Text, this.ddlOpeningForm.Text, this.tbWM.Text , time ).Trim();
                }
                else
                {
                    message = String.Format( Properties.Resources.regularOpen, SettingsViewModel.Instance.LodgeName, location, DateTime.Now.ToLongDateString(), this.ddlDegree.Text, this.ddlOpeningForm.Text, this.tbWM.Text, time ).Trim();
                }

                // add by dispensation if needed
                if ( this.cbByDispensation.IsChecked.HasValue && this.cbByDispensation.IsChecked.Value )
                {
                    message = String.Format( "{0}{1}.{2}", message, Properties.Resources.byDispensation, Environment.NewLine );
                }
                else
                {
                    message = String.Format( "{0}.{1}", message, Environment.NewLine );
                }

                // set the notes so they bind in the appropriate text box
                MinutesViewModel.Instance.Notes = String.Format( "{0}{1}{2}", MinutesViewModel.Instance.Notes, message,  Environment.NewLine );

                if( MinutesViewModel.Instance.Save() )
                {
                    MessageBox.Show( "Lodge opened.", "Success" );
                }
                else
                {
                    MessageBox.Show( "Error opening lodge.", "Error" );
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( ex.ToString(), "Error opening lodge.", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

    }
}