using LodgeMinutesMiddleWare.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    /// <summary>
    /// Class that represents a Motion made in lodge.
    /// </summary>
    /// <seealso cref="LodgeMinutesMiddleWare.Models.ModelBase" />
    public class Motion: MotionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Motion"/> class.
        /// </summary>
        public Motion()
            : base() {}

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format( "A motion was made by ({0}) and seconded by ({1}), to ({2}).\nThe motion {3}.", this.MadeBy, this.SecondedBy, this.Specifics, this.Results );
        }

    }
}