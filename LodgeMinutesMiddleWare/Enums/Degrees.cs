using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Enums
{
    public enum Degrees
    {
        [Description( "Entered Apprentice" )]
        EnteredApprentice = 0,

        [Description( "Fellowcraft" )]
        FellowCraft = 1,

        [Description( "Master Mason" )]
        MasterMason = 2

    }
}