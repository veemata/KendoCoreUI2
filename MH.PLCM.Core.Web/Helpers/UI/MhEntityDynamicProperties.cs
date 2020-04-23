using System.Collections.Generic;

namespace MH.PLCM.Core.Dynamic
{
    public class MhEntityDynamicProperties
    {
        public int Id { get; set; }
        public List<MhEntityDynanicRow> Rows { get; set; }
    }
}
