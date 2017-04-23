using LodgeMinutesMiddleWare.Helpers;
using LodgeMinutesMiddleWare.Models;
using LodgeMinutesMiddleWare.Views;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LodgeMinutes.UserControls
{
    /// <summary>
    /// Interaction logic for Necrologies.xaml
    /// </summary>
    public partial class Necrologies : UserControl
    {
        #region Fields

        private ObservableCollection<Necrology> _necrologies;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Necrologies"/> class.
        /// </summary>
        public Necrologies()
        {
            InitializeComponent();

            _necrologies = new ObservableCollection<Necrology>();

            this.gridNecrologies.DataContext = _necrologies;


        }

        /// <summary>
        /// Handles the Click event of the buttonCommit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCommit_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if ( this.SaveNecrologies() )
                {
                    MessageBox.Show( "Necrologies saved.", "Success" );
                }
                else
                {
                    MessageBox.Show( "Error saving necrologies.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                }
            }
            catch( Exception ex)
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "Error saving necrologies.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Saves the necrologies.
        /// </summary>
        /// <returns></returns>
        private bool SaveNecrologies()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine( "Necrologies" );
            sb.AppendLine();

            // write necrologies to notes
            foreach ( var necrology in _necrologies )
            {
                sb.AppendLine( necrology.ToString() );
            }

            sb.AppendLine();

            MinutesViewModel.Instance.Notes = String.Format("{0}{1}{2}", MinutesViewModel.Instance.Notes,Environment.NewLine, sb.ToString() );

            return MinutesViewModel.Instance.Save();

        }

    }
}