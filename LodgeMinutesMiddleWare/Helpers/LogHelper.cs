using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Helpers
{
    public static class LogHelper
    {
        public static void LogError( Exception ex )
        {
            File.AppendAllText( "error.log", String.Format( "{0}{0}***********************************{0}{1}{0}{2}{0}***********************************{0}{0}", Environment.NewLine, DateTime.Now, ex.ToString() ), Encoding.UTF8 );
        }
    }
}
