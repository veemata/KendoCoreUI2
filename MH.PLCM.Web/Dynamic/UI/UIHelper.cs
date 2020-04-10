
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dynamic
{
    public static class UIHelper
    {
        public static string RenderDynamicForm(bool isPostBack = false, IFormCollection form = null)
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
                    (File.ReadAllText(@"C:\Users\3051752\source\PrakGitRepo\DynamicUI\assets\ItemProps.json"));
            return (mhItemAttributes);

        }

        /* Convert to Json first */
        public static List<MhDynamicColumn> GetFieldList()
        {

            var list = JsonConvert.DeserializeObject<List<MhDynamicColumn>>
                (File.ReadAllText(@"C:\Users\3051752\source\PrakGitRepo\DynamicUI\assets\fields.json"));

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
