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
        [Description("In Form")]
        InForm,

        [Description( "In Due Form" )]
        InDueForm,

        [Description( "In Ample Form" )]
        InAmpleForm
    }

}