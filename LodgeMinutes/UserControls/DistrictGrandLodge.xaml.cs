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
    /// Interaction logic for DistrictGrandLodge.xaml
    /// </summary>
    public partial class DistrictGrandLodge : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DistrictGrandLodge"/> class.
        /// </summary>
        public DistrictGrandLodge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the buttonCommitVisitor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCommitVisitor_Click( object sender, RoutedEventArgs e )
        {
            MessageBox.Show( "Commit" );
        }
    }
}
