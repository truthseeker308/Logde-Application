using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Enums
{
    public enum Forms
    {
        [Description( "In Due Form" )]
        InDueForm = 0,

        [Description("In Form")]
        InForm = 1,
        
        [Description( "In Ample Form" )]
        InAmpleForm = 2
    }

}