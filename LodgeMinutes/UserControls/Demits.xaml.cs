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
    /// Interaction logic for Demits.xaml
    /// </summary>
    public partial class Demits : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Demits"/> class.
        /// </summary>
        public Demits()
        {
            InitializeComponent();
        }

        #region Button Methods

        /// <summary>
        /// Handles the Click event of the buttonCommitDemit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCommitDemit_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if ( this.ValidateDemit() )
                {
                    if ( this.SaveDemit() )
                    {
                        this.tbDemitName.Text = String.Empty;
                        this.dtDemit.Value = null;
                        this.ClearErrorControl( this.tbDemitName );
                        this.ClearErrorControl( this.dtDemit );
                        MessageBox.Show( "Demit saved.", "Success" );
                    }
                    else
                    {
                        MessageBox.Show( "Error saving Demit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                    }
                }
                else
                {
                    this.SetDemitControls();
                }
            }
            catch ( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error saving Demit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonSuspension control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonSuspension_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if ( this.ValidateSuspension() )
                {
                    if( this.SaveSuspension() )
                    {
                        this.tbSuspension.Text = String.Empty;
                        this.dtSuspension.Value = null;
                        this.ClearErrorControl( this.tbSuspension );
                        this.cbSuspension.IsChecked = false;
                        this.ClearErrorControl( this.dtSuspension );
                        MessageBox.Show( "Suspension saved.", "Success" );
                    }
                    else
                    {
                        MessageBox.Show( "Error saving Suspension.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                    }
                }
                else
                {
                    this.SetSuspensionControls();
                }
            }
            catch ( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error saving Suspension.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the demit controls.
        /// </summary>
        private void SetDemitControls()
        {
            if( String.IsNullOrWhiteSpace(this.tbDemitName.Text))
            {
                this.SetErrorControl( this.tbDemitName );
            }
            else
            {
                this.ClearErrorControl( this.tbDemitName );
            }

            if(  this.dtDemit.Value == null )
            {
                this.SetErrorControl( this.dtDemit );
            }
            else
            {
                this.ClearErrorControl( this.dtDemit );
            }
        }

        /// <summary>
        /// Sets the suspension controls.
        /// </summary>
        private void SetSuspensionControls()
        {
            if ( String.IsNullOrWhiteSpace( this.tbSuspension.Text ) )
            {
                this.SetErrorControl( this.tbSuspension );
            }
            else
            {
                this.ClearErrorControl( this.tbSuspension );
            }

            if ( this.dtSuspension.Value == null )
            {
                this.SetErrorControl( this.dtSuspension );
            }
            else
            {
                this.ClearErrorControl( this.dtSuspension );
            }
        }

        /// <summary>
        /// Validates the demit.
        /// </summary>
        /// <returns></returns>
        private bool ValidateDemit()
        {
            return !( String.IsNullOrWhiteSpace( this.tbDemitName.Text ) || this.dtDemit.Value == null );
        }

        /// <summary>
        /// Validates the suspension.
        /// </summary>
        /// <returns></returns>
        private bool ValidateSuspension()
        {
            return !( String.IsNullOrWhiteSpace( this.tbSuspension.Text ) || this.dtSuspension.Value == null );
        }

        /// <summary>
        /// Sets the error control.
        /// </summary>
        /// <param name="control">The control.</param>
        private void SetErrorControl( Control control )
        {
            control.BorderBrush = Brushes.Red;
            control.ToolTip = "This field is required.";
        }

        /// <summary>
        /// Clears the error control.
        /// </summary>
        /// <param name="control">The control.</param>
        private void ClearErrorControl( Control control )
        {
            control.BorderBrush = Brushes.Gray;
            control.ToolTip = null;
        }

        /// <summary>
        /// Saves the demit.
        /// </summary>
        /// <returns></returns>
        private bool SaveDemit()
        {
            var message = String.Format( "{0} was demmited on {1}, demmital type - {2}.", this.tbDemitName.Text, this.dtDemit.Value.Value.ToShortDateString(), this.cbDemit.Text );

            MinutesViewModel.Instance.Notes = String.Format( "{0}{1}{2}", MinutesViewModel.Instance.Notes, Environment.NewLine, message );

            return MinutesViewModel.Instance.Save();
        }

        /// <summary>
        /// Saves the suspension.
        /// </summary>
        /// <returns></returns>
        private bool SaveSuspension()
        {
            var message = String.Format( "{0} was suspended on {1}, were the grand lodge policies documented and followd - {2}.", this.tbSuspension.Text, this.dtSuspension.Value.Value.ToShortDateString(), this.cbSuspension.IsChecked );

            MinutesViewModel.Instance.Notes = String.Format( "{0}{1}{2}", MinutesViewModel.Instance.Notes, Environment.NewLine, message );

            return MinutesViewModel.Instance.Save();
        }
    
        #endregion

    }
}