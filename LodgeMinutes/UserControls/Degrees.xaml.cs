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
        /// <summary>
        /// Initializes a new instance of the <see cref="Degrees"/> class.
        /// </summary>
        public Degrees()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the buttonSecond control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonSecond_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( "Second Begun" );
        }

        /// <summary>
        /// Handles the Click event of the buttonThird control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonThird_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( "Second/Third Ended" );
        }

        /// <summary>
        /// Handles the Click event of the FirstSectionBegun control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void FirstSectionBegun_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( "First Begun" );
        }

        /// <summary>
        /// Handles the Click event of the FirstSectionEnded control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void FirstSectionEnded_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( "First Ended" );
        }

    }
}