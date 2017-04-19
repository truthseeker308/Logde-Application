using LodgeMinutesMiddleWare.Views;
using Syncfusion.Windows.Reports;
using Syncfusion.Windows.Reports.Viewer;
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
using System.Windows.Shapes;

namespace LodgeMinutes.Forms
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        public Reports()
        {
            InitializeComponent();

            // try and set our report stuff           
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.ReportPath = "..//Resources//Minutes.rdlc";

            ReportDataSource reportDS = new ReportDataSource();
            reportDS.Name = "LodgeMinutes";
            reportDS.Value = MinutesViewModel.Instance;

            this.reportViewer.DataSources.Add(reportDS);

            
        }

        
        protected override void OnActivated(EventArgs e)
        {
            Mouse.OverrideCursor = null;

            base.OnActivated(e);
        }

    }
}
