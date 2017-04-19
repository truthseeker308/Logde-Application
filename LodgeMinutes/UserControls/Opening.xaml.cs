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
        #region Fields

        private StringBuilder _sb = new StringBuilder();

        #endregion

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

                // set the opening text in the notes
                _sb.AppendFormat( "Lodge Opening{0}{0}Date - {1}  Time - {2}{0}Meeting Type - {3}{0}Location - {4}{0}Opening Degree - {5}{0}Opening Form - {6}{0}By - {7}{0}Members Attending - {8}{0}Visitors Attending - {9}{0}",
                    Environment.NewLine,
                    this.dtDate.SelectedDate.Value.ToShortDateString(),
                    time,
                    this.ddlMeetingYType.Text,
                    location,
                    this.ddlDegree.Text,
                    this.ddlOpeningForm.Text,
                    this.tbWM.Text.Trim(),
                    this.iudMemberCount.Value.ToString(),
                    this.iudVisitorCount.Value.ToString() );

                // set the notes so they bind in the appropriate text box
                MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, Environment.NewLine, _sb.ToString() );

                // clear our string builder
                _sb.Clear();

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