using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH.PLCM
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Sequence { get; set; }

        public string MenuText { get; set; }
        public bool IsSection { get; set; }
        public bool IsDivider { get; set; }

        /* If No Url specified, Item is considered Parent and
         not clickable. If Url is specified it is clickable*/
        public string Url { get; set; }
        public string CssClassForIcon { get; set; }

    }

  
}
