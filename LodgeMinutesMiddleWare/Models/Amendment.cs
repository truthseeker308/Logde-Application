using LodgeMinutesMiddleWare.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    /// <summary>
    /// Class that represents a Motion Amdendment made in lodge.
    /// </summary>
    /// <seealso cref="LodgeMinutesMiddleWare.Models.ModelBase" />
    public class Amendment: MotionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Motion"/> class.
        /// </summary>
        public Amendment()
            : base() {}

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format( "Amdendment Made By {0}, Seconded By: {1}, Specifics - {2}, Status - {3}", this.MadeBy, this.SecondedBy, this.Specifics, this.Results );
        }

    }
}