using LodgeMinutesMiddleWare.Models;
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
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : UserControl
    {
        public Notes CurrentNotes {  get { return this; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notes"/> class.
        /// </summary>
        public Notes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click( object sender, RoutedEventArgs e )
        {
            MinutesViewModel.Instance.Notes = MinutesViewModel.Instance.Notes.Insert( 0, String.Format( "{0}{1}{2}", DateTime.Now.ToString( "MM/dd/yyyy hh:mm:ss tt" ), Environment.NewLine, Environment.NewLine ) );
        }
    }
}
