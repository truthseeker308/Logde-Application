using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    public sealed class MinutesModel
    {
        #region Fields

        public ObservableCollection<VisitorModel> _visitors = new ObservableCollection<VisitorModel>();

        private static MinutesModel _instance;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance of the MinutesModel class.
        /// </summary>
        public static MinutesModel Instance
        {
            get
            {
                if( _instance == null )
                {
                    _instance = new MinutesModel();
                }

                return _instance;

            }
        }

        /// <summary>
        /// Gets the visitors
        /// </summary>
        public ObservableCollection<VisitorModel> Visitors
        {
            get { return _visitors; }
        }

        #endregion

        /// <summary>
        /// Prevents an instance of the MinutesModel class from being instantiated.
        /// </summary>
        private MinutesModel()
        {

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return false;
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            return false;
        }
        
        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        /// <returns></returns>
        public bool Refresh()
        {
            return false;
        }

    }

}
