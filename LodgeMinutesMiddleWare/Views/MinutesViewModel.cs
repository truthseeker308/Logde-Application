using LodgeMinutesMiddleWare.Enums;
using LodgeMinutesMiddleWare.Helpers;
using LodgeMinutesMiddleWare.Models;
using LodgeMinutesMiddleWare.Views;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LodgeMinutesMiddleWare.Views
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="LodgeMinutesMiddleWare.Views.ViewModeBase" />
    public sealed class MinutesViewModel : ViewModeBase
    {
        #region Fields

        private string _notes = String.Empty;

        private static object s_lock = new object();

        private static MinutesViewModel s_instance;

        public event EventHandler Saved;
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static MinutesViewModel Instance
        {
            get
            {
                // since we can be saving this automatically we need 
                // to ensure thread safety
                lock( s_lock )
                {
                    if( s_instance == null )
                    {
                        s_instance = new MinutesViewModel();
                    }

                    return s_instance;
                }
            }
            set
            {
                lock( s_lock )
                {
                    s_instance = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                if( _notes != value )
                {
                    _notes = value;
                    NotifyPropertyChanged();
                }
            }

        }
        
        #endregion

        /// <summary>
        /// Initializes the <see cref="MinutesViewModel"/> class.
        /// </summary>
        static MinutesViewModel()
        {
            
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="MinutesViewModel"/> class from being created.
        /// </summary>
        private MinutesViewModel()
        {
            _notes = String.Empty;
        }

        #region Private Methods

        /// <summary>
        /// Called when [save].
        /// </summary>
        private void OnSave( )
        {
            var myEvent = Saved;

            if( myEvent != null )
            {
                Saved(this,new EventArgs());
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                // if the don't have a filename, create one
                if (String.IsNullOrWhiteSpace(SettingsViewModel.Instance.LastFilename))
                {
                    // TODO: check the settings for txt, word, or rtf and set the appropriate extension
                    SettingsViewModel.Instance.LastFilename = String.Format( "minutes__{0}.txt", FormattingHelper.GetDateForFileSystem() );
                    SettingsViewModel.Instance.Save();
                }

                // dump it to a text file
                File.WriteAllText( SettingsViewModel.Instance.LastFilename, Notes );

                OnSave();

                return true;

            }
            catch(Exception ex)
            {
                LogHelper.LogError( ex );
                return false;
            }
        }

        /// <summary>
        /// Exports this instance to a word document.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public bool Export()
        {
            var result = true;

            try
            {
                // do some basic validation
                if(String.IsNullOrWhiteSpace(SettingsViewModel.Instance.LastFilename))
                {
                    throw new InvalidOperationException("No notes filename was found to export from.");
                }

                if(String.IsNullOrWhiteSpace(this.Notes))
                {
                    throw new InvalidOperationException("No note data found to export.");
                }

                // export to the specified file format
                var filename = SettingsViewModel.Instance.LastFilename.Replace(".txt", ".docx");

                
                var document = new Document();

                var paragraph = document.AddSection().AddParagraph();

                paragraph.AppendText(this.Notes);

                document.SaveToFile(filename, FileFormat.Docx2013);
            }
            catch(Exception ex)
            {
                LogHelper.LogError(ex);
                result = false;
            }

            return result;

        }

        #endregion

    }
}