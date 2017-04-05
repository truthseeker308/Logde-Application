using LodgeMinutesMiddleWare.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare
{
    /// <summary>
    /// This is the main class for the lodge, it's going to be big since the UI has a lot of info in it
    /// </summary>
    public class LodgeModel
    {
        public string FullName { get; set; }

        public string AbbreviatedName { get; set; }

        public string WorshipfulMaster { get; set; }

        public string SeniorWarden { get; set; }

        public string JuniorWarden { get; set; }

        public LodgeStatus LodgeStatus { get; set; }

    }
}