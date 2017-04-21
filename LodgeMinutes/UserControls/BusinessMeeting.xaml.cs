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
    /// Interaction logic for BusinessMeeting.xaml
    /// </summary>
    public partial class BusinessMeeting : UserControl
    {
        /// <summary>
        /// Gets the basic tasks.
        /// </summary>
        /// <value>
        /// The basic tasks.
        /// </value>
        public BasicTasks BasicTasks { get { return ucBasicTasks; } }

        /// <summary>
        /// Gets the motions.
        /// </summary>
        /// <value>
        /// The motions.
        /// </value>
        public Motions Motions { get { return ucMotions; } }

        /// <summary>
        /// Gets the applications.
        /// </summary>
        /// <value>
        /// The applications.
        /// </value>
        public Applications Applications { get { return ucApplications; } }

        /// <summary>
        /// Gets the demits.
        /// </summary>
        /// <value>
        /// The demits.
        /// </value>
        public Demits Demits { get { return ucDemits; } }

        /// <summary>
        /// Gets the necrologies.
        /// </summary>
        /// <value>
        /// The necrologies.
        /// </value>
        public Necrologies Necrologies { get { return ucNecrologies; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessMeeting"/> class.
        /// </summary>
        public BusinessMeeting()
        {
            InitializeComponent();
        }
    }
}