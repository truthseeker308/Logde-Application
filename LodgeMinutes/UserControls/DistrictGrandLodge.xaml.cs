using LodgeMinutesMiddleWare.Enums;
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
    /// Interaction logic for DistrictGrandLodge.xaml
    /// </summary>
    public partial class DistrictGrandLodge : UserControl
    {
        private string _district;
        private string _visitorName;
        private string _chairpersonName;

        private VisitTypes _visitType;

        private VisitorTypes _visitorType;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistrictGrandLodge"/> class.
        /// </summary>
        public DistrictGrandLodge()
        {
            InitializeComponent();

            this.comboVisitorType.SelectedIndex = 0;

            this.listBoxVisitors.DataContext = MinutesModel.Instance.Visitors;

        }

        /// <summary>
        /// Handles the Click event of the buttonCommitVisitor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCommitVisitor_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // get our values from the form
                _district = this.textboxDDGM.Text.Trim();
                _visitorName = this.textboxName.Text.Trim();
                _chairpersonName = this.textboxTitle.Text.Trim();
                _visitorType = (VisitorTypes)this.comboVisitorType.SelectedIndex;
                _visitType = (VisitTypes)this.comboVisitType.SelectedIndex;

                bool _isValid = true;

                // do some basic required validation
                if( String.IsNullOrWhiteSpace( _visitorName ) )
                {
                    SetErrorControl( this.textboxName );
                    _isValid = false;
                    this.textboxName.ToolTip = "Visitor name is required";
                }
                else
                {
                    SetClearControl( this.textboxName );
                }

                if( String.IsNullOrWhiteSpace( _chairpersonName ) )
                {
                    SetErrorControl( this.textboxTitle );
                    _isValid = false;
                    this.textboxTitle.ToolTip = "Chairperson is required";
                }
                else
                {
                    SetClearControl( this.textboxTitle );
                }


                // if we have a grand master visit we need district
                if( _visitorType == VisitorTypes.DistrictDeputyGrandMaster &&
                    String.IsNullOrWhiteSpace( _district ) )
                {
                    SetErrorControl( this.textboxDDGM );
                    _isValid = false;
                    this.textboxDDGM.ToolTip = "District is required";
                }
                else
                {
                    SetClearControl( this.textboxDDGM );
                }

                // if we passed our validation we need to add it to our list below
                // I'm sure this could be cleaned up to use databinding instead of directly accessing the controls
                if( _isValid )
                {
                    VisitorModel newVisitor = new VisitorModel( _visitorName, _district, _chairpersonName, _visitorType, _visitType );

                    MinutesModel.Instance.Visitors.Add( newVisitor );

                    this.textboxDDGM.Text = this.textboxName.Text = this.textboxTitle.Text = String.Empty;

                    //this.listBoxVisitors.ItemsSource = null;
                    //this.listBoxVisitors.ItemsSource = MinutesModel.Instance.Visitors;
                }
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        private void SetErrorControl( TextBox control )
        {
            control.BorderBrush = Brushes.Red;
        }

        private void SetClearControl( TextBox control )
        {
            control.BorderBrush = null;
            control.ToolTip = null;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the comboVisitorType control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboVisitorType_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {

            if( (VisitorTypes)this.comboVisitorType.SelectedIndex == VisitorTypes.DistrictDeputyGrandMaster)
            {
                this.textboxDDGM.IsEnabled = true;
            }
            else
            {
                this.textboxDDGM.IsEnabled = false;
                this.textboxDDGM.Text = String.Empty;
            }
            
        }
    }
}