﻿using LodgeMinutesMiddleWare.Models;
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
        /// Handles the Click event of the buttonBills control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonBills_Click( object sender, RoutedEventArgs e )
        {

        }

        /// <summary>
        /// Handles the Click event of the buttonMoney control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonMoney_Click( object sender, RoutedEventArgs e )
        {
             
        }

        private void buttonCommit_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                MinutesViewModel.Instance.Save();

            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}