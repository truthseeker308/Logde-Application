using LodgeMinutesMiddleWare.Helpers;
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
    /// Interaction logic for Motions.xaml
    /// </summary>
    public partial class Motions : UserControl
    {
        #region Fields

        private MotionAmendment _motionAmendments;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Motions"/> class.
        /// </summary>
        public Motions()
        {
            InitializeComponent();

            _motionAmendments = new MotionAmendment();

            this.DataContext = _motionAmendments;

        }

        #region Button Methods

        /// <summary>
        /// Handles the Click event of the buttonAdmendmentCommit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonAdmendmentCommit_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // check if our motion is valid and act accordingly
                if( _motionAmendments.Amendment.IsValid() )
                {
                    this.AddAmendmentToNotes();
                    if( MinutesViewModel.Instance.Save() )
                    {
                        _motionAmendments.Amendment.MadeBy = String.Empty;
                        _motionAmendments.Amendment.SecondedBy = String.Empty;
                        _motionAmendments.Amendment.Specifics = String.Empty;
                        _motionAmendments.Amendment.Results = null;

                        this.ClearAmendmentErrorStates();

                        MessageBox.Show( "Amendment added" );
                    }
                }
                else
                {
                    this.SetAmendmentErrorStates();
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "A error occured saving amendment.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonCommit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonCommit_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                // check if our motion is valid and act accordingly
                if( _motionAmendments.Motion.IsValid() )
                {
                    this.AddMotionsToNotes();

                    if( MinutesViewModel.Instance.Save() )
                    {
                        _motionAmendments.Motion.MadeBy = String.Empty;
                        _motionAmendments.Motion.SecondedBy = String.Empty;
                        _motionAmendments.Motion.Specifics = String.Empty;
                        _motionAmendments.Motion.Results = null;

                        this.ClearMotionErrorStates();

                        MessageBox.Show( "Motion added" );
                    }
                }
                else
                {
                    this.SetMotionErrorStates();
                }
            }
            catch( Exception ex )
            {
                LogHelper.LogError( ex );
                MessageBox.Show( "A error occured saving motion.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds the amendment to notes.
        /// </summary>
        private void AddAmendmentToNotes()
        {
            MinutesViewModel.Instance.Notes = String.Format( "{0}{1}{2}", MinutesViewModel.Instance.Notes, Environment.NewLine, _motionAmendments.Amendment.ToString() );

            MinutesViewModel.Instance.Save();

        }

        /// <summary>
        /// Adds the motions to notes.
        /// </summary>
        private void AddMotionsToNotes()
        {
            MinutesViewModel.Instance.Notes = String.Format( "{0}{1}{2}", MinutesViewModel.Instance.Notes, Environment.NewLine, _motionAmendments.Motion.ToString() );

            MinutesViewModel.Instance.Save();


        }

        /// <summary>
        /// Sets the motion error states.
        /// </summary>
        private void SetMotionErrorStates()
        {
            if( String.IsNullOrWhiteSpace( _motionAmendments.Motion.MadeBy ) )
            {
                this.SetError( this.tbMotionMadeBy );
            }
            else
            {
                this.ClearError( tbMotionMadeBy );
            }

            if( String.IsNullOrWhiteSpace( _motionAmendments.Motion.SecondedBy ) )
            {
                this.SetError( this.tbMotionSecondedBy );
            }

            else
            {
                this.ClearError( tbMotionSecondedBy );
            }
            if( String.IsNullOrWhiteSpace( _motionAmendments.Motion.Specifics ) )
            {
                this.SetError( this.tbMotionSpecifics );
            }
            else
            {
                this.ClearError( tbMotionSpecifics );
            }
        }

        /// <summary>
        /// Clears the motion error states.
        /// </summary>
        private void ClearMotionErrorStates()
        {
            // clear our text boxes
            ClearError( this.tbMotionMadeBy );
            ClearError( this.tbMotionSecondedBy );
            ClearError( this.tbMotionSpecifics );
        }

        /// <summary>
        /// Sets the motion error states.
        /// </summary>
        private void SetAmendmentErrorStates()
        {
            if( String.IsNullOrWhiteSpace( _motionAmendments.Amendment.MadeBy ) )
            {
                this.SetError( this.tbAmdendmentMadedBy );
            }
            else
            {
                this.ClearError( tbAmdendmentMadedBy );
            }

            if( String.IsNullOrWhiteSpace( _motionAmendments.Amendment.SecondedBy ) )
            {
                this.SetError( this.tbAmdendmentSecondedBy );
            }

            else
            {
                this.ClearError( tbAmdendmentSecondedBy );
            }

            if( String.IsNullOrWhiteSpace( _motionAmendments.Amendment.Specifics ) )
            {
                this.SetError( this.tbAmendmentSpecifics );
            }
            else
            {
                this.ClearError( tbAmendmentSpecifics );
            }
        }

        /// <summary>
        /// Clears the amendment error states.
        /// </summary>
        private void ClearAmendmentErrorStates()
        {
            // clear our text boxes
            ClearError( this.tbAmdendmentMadedBy );
            ClearError( this.tbAmdendmentSecondedBy );
            ClearError( this.tbAmendmentSpecifics );
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="control">The control.</param>
        private void SetError( Control control )
        {
            control.BorderBrush = Brushes.Red;
            control.ToolTip = "This field is required";
        }

        /// <summary>
        /// Clears the error.
        /// </summary>
        /// <param name="control">The control.</param>
        private void ClearError( Control control )
        {
            control.BorderBrush = null;
            control.ToolTip = null;
        }

        #endregion


    }
}
