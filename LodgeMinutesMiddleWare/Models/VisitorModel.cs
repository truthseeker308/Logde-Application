using LodgeMinutesMiddleWare.Enums;
using LodgeMinutesMiddleWare.Helpers;
using LodgeMinutesMiddleWare.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    [Serializable]
    public sealed class VisitorModel
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the District.
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Gets or sets the ChairpersonName.
        /// </summary>
        public string ChairpersonName { get; set; }

        /// <summary>
        /// Gets or sets the VisitorType.
        /// </summary>
        public VisitorTypes VisitorType { get; set; }

        /// <summary>
        /// Gets or sets the VisitType.
        /// </summary>
        public VisitTypes VisitType { get; set; }

        /// <summary>
        /// Creates a new instance of the VisitorModel class.
        /// </summary>
        public VisitorModel()
        {

        }

        /// <summary>
        /// Creates a new instance of the VisitorModel class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="district"></param>
        /// <param name="chairperson"></param>
        /// <param name="visitorType"></param>
        /// <param name="visitType"></param>
        public VisitorModel( string name, string district, string chairperson, VisitorTypes visitorType, VisitTypes visitType )
        {
            Name = name;
            District = district;
            ChairpersonName = chairperson;
            VisitorType = visitorType;
            VisitType = visitType;
        }

        /// <summary>
        /// Returns a string representation of the VisitorModel class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat( "At {0}, {1}, ", FormattingHelper.GetShortTimeWithAmPm(), Name  );

            if( VisitorType == VisitorTypes.DeputyGrandMaster )
            {
                sb.AppendFormat("from District {0}",  this.District );
            }

            sb.AppendFormat( "accompanied by a suite of distinguished Masons, was received by a committee, chaired by {0}, for the purpoe of making a {1} visit to {2}", this.ChairpersonName, this.VisitType, SettingsViewModel.Instance.LodgeName );

            return sb.ToString();
        }

    }
}