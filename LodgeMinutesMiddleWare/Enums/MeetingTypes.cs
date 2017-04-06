using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Enums
{ 
    public enum MeetingTypes
    {
        [Description( "Regular" )]
        Regular,

        [Description( "Special" )]
        Special
    }

}