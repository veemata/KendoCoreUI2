using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamic
{
    public class MhEntityDynanicRow
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public MhDynamicColumn ColumnType { get; set; }
        public string ColumnValue { get; set; }
        public int Sequence { get; set; }

    }
}
