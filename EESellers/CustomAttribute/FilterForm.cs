using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace EESellers.CustomAttribute
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct | System.AttributeTargets.Property)]
    public class FilterForm : System.Attribute
    {

        public FilterForm()
        {
        }
    }
}