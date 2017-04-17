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
    /// Interaction logic for LodgeOpenClose.xaml
    /// </summary>
    public partial class LodgeOpenClose : UserControl
    {
        /// <summary>
        /// Gets the opening form.
        /// </summary>
        public Opening Opening {  get { return ucOpening; } }

        /// <summary>
        /// Gets the closing form.
        /// </summary>
        public Closing Closing {  get { return ucClose; } }

        /// <summary>
        /// Creates a new instance of the LodgeOpenClose class.
        /// </summary>
        public LodgeOpenClose()
        {
            InitializeComponent();
        }
    }
}
