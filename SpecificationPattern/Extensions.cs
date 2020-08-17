using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificationPattern
{
    public static class Extensions
    {
        public static void AddTableData(this StringBuilder columnBuilder, string val)
        {            
            int right = (30 - val.Length);            
            columnBuilder.Append(val);
            columnBuilder.Append(' ', right);
            columnBuilder.Append(" |");            
        }
    }
}
