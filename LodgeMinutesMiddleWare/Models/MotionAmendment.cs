using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Models
{
    public class MotionAmendment
    {
        public Motion Motion { get; set; }
        public Amendment Amendment { get; set; }

        public MotionAmendment()
        {
            Motion = new Motion();
            Amendment = new Amendment();
        }
    }
}