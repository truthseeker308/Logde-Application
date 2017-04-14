using LodgeMinutesMiddleWare.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
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
            return String.Format( "Visit Type: {0}, Visitor Type: {1}, Name: {2}, Chairperson: {3}", VisitType, VisitorType, Name, ChairpersonName );
        }

    }
}