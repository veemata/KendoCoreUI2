
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MH.PLCM.Core.Dynamic
{
    public static class DynamicForm
    {
        public static string Render(bool isPostBack = false, IFormCollection form = null)
        {

            StringBuilder sb = new StringBuilder();
            MhEntityDynamicProperties entity = GetEntityDynamicProperties();

            //if  postback fill the values
            if (isPostBack)
            {
                if (form != null)
                {
                    FillDynamicProperties(form, entity);
                }

            }

            foreach (MhEntityDynanicRow iv in entity.Rows.OrderBy(mh => mh.Sequence))
            {
                sb.Append(GetDynamicHtml.ForFormControl(iv));
            }

            return sb.ToString();
        }

        /* Convert this to database */
        public static MhEntityDynamicProperties GetEntityDynamicProperties()
        {
            var mhItemAttributes = JsonConvert.DeserializeObject<MhEntityDynamicProperties>
                    (FileContentFromAssembly.Read("ItemProps.json"));
            return (mhItemAttributes);

        }

        /* Convert to Json first */
        public static List<MhDynamicColumn> GetFieldList()
        {

            var list = JsonConvert.DeserializeObject<List<MhDynamicColumn>>
                (FileContentFromAssembly.Read("fields.json"));
            return (list);
        }

        public static void FillDynamicProperties(IFormCollection form, MhEntityDynamicProperties pe)
        {
            foreach (MhEntityDynanicRow row in pe.Rows)
            {
                row.ColumnValue = form[row.ColumnType.Name];
            }
        }


    }
}
