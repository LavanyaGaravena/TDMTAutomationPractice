using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDMTAutomation.DataEntities
{
    public class CommonInput
    {
        public static string TDMT;
        public CommonInput(DataRow dr)
        {
            if (dr == null)
                return;

            if (dr["TDMT"] != null && !string.IsNullOrEmpty(dr["TDMT"].ToString()))
                TDMT = dr["TDMT"].ToString().Trim(' ');

        }
    }
}
