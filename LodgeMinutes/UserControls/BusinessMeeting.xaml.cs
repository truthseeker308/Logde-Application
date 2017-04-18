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
        public Necrologies Necrologies { get { return ucNecrologies; } }

        public BusinessMeeting()
        {
            InitializeComponent();
        }
    }
}