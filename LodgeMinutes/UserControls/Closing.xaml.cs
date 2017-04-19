using LodgeMinutesMiddleWare.Models;
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
    /// Interaction logic for Closing.xaml
    /// </summary>
    public partial class Closing : UserControl
    {
        public Closing()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the buttonCloseMeeting Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCloseMeeting_Click( object sender, RoutedEventArgs e )
        {
            // the save event triggers other UI things to happen
            // in the main window
            MinutesViewModel.Instance.Save();
        }
    }
}
