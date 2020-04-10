using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamic
{
    public class MhEntityDynamicProperties
    {
        public int Id { get; set; }
        public List<MhEntityDynanicRow> Rows { get; set; }
    }
}
