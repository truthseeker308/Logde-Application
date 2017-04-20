using LodgeMinutesMiddleWare.Models;
using LodgeMinutesMiddleWare.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Monies.xaml
    /// </summary>
    public partial class Monies : UserControl
    {
        #region Fields

        private ObservableCollection<Money> _monies;

        private ObservableCollection<Bill> _bills;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Monies"/> class.
        /// </summary>
        public Monies()
        {
            InitializeComponent();
            
            _monies = new ObservableCollection<Money>();

            _bills = new ObservableCollection<Bill>();

            this.gridMonies.DataContext = _monies;
            this.gridBills.DataContext = _bills;
        }

        /// <summary>
        /// Handles the Click event of the buttonCommit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCommit_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // write the info from the bills to our notes
                StringBuilder sb = new StringBuilder();

                sb.AppendLine( "Monies Paid to the Treasurer" );
                sb.AppendLine();
                sb.AppendLine();

                foreach( var money in _monies )
                {
                    sb.AppendLine( money.ToString() );
                    sb.AppendLine();
                }

                sb.AppendLine( "Bills" );
                sb.AppendLine();
                sb.AppendLine();

                foreach( var bill in _bills )
                {
                    sb.AppendLine( bill.ToString() );
                    sb.AppendLine();
                }

                sb.AppendLine();
                sb.AppendLine();

                MinutesViewModel.Instance.Notes = String.Concat( MinutesViewModel.Instance.Notes, sb.ToString() );

                MinutesViewModel.Instance.Save();

            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}