#pragma checksum "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Northwind\Areas\Northwind\Views\Grid\ParentChild.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61e862c59f281f85d9608277483df5f397d390b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Northwind_Views_Grid_ParentChild), @"mvc.1.0.view", @"/Areas/Northwind/Views/Grid/ParentChild.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Northwind\Areas\Northwind\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Northwind\Areas\Northwind\Views\_ViewImports.cshtml"
using MH.PLCM.Northwind.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61e862c59f281f85d9608277483df5f397d390b6", @"/Areas/Northwind/Views/Grid/ParentChild.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dd16744adca206054eb44459c4f9cbfa231fd9b", @"/Areas/Northwind/Views/_ViewImports.cshtml")]
    public class Areas_Northwind_Views_Grid_ParentChild : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Northwind\Areas\Northwind\Views\Grid\ParentChild.cshtml"
  
    ViewData["Title"] = "ParentChild";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Employee Orders</h1>\r\n");
#nullable restore
#line 7 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Northwind\Areas\Northwind\Views\Grid\ParentChild.cshtml"
Write(Html.Kendo().Grid<Employee>()
        .Name("grid")
        .Columns(columns =>
        {
            columns.Bound(e => e.FirstName).Width(110);
            columns.Bound(e => e.LastName).Width(110);
            columns.Bound(e => e.Country).Width(110);
            columns.Bound(e => e.City).Width(110);
            columns.Bound(e => e.Title);

        })
        .Sortable()
        .Pageable()
        .Scrollable()
        .ClientDetailTemplateId("template")
        .HtmlAttributes(new { style = "height:430px;" })
        .DataSource(dataSource => dataSource
            .Ajax()
            .ServerOperation(true)
            .PageSize(6)
            .Read(read => read.Action("HierarchyBinding_Employees", "Grid"))
            )
        .Events(events => events.DataBound("dataBound"))
     
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script id=\"template\" type=\"text/kendo-tmpl\">\r\n        ");
#nullable restore
#line 36 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Northwind\Areas\Northwind\Views\Grid\ParentChild.cshtml"
    Write(Html.Kendo().Grid<Order>()
                .Name("grid_#=EmployeeID#")
                .Columns(columns =>
                {
                    columns.Bound(o => o.OrderId).Width(110);
                    columns.Bound(o => o.ShipCountry).Width(110);
                    columns.Bound(o => o.ShipAddress);
                    columns.Bound(o => o.ShipName).Width(200);
                })
                .DataSource(dataSource => dataSource
                    .Ajax()
                    .ServerOperation(true)
                    .PageSize(10)
                    .Read(read => read.Action("HierarchyBinding_Orders", "Grid", new { employeeID = "#=EmployeeID#" }))
                )
                .Pageable()
                .Sortable()
                .ToClientTemplate()


        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </script>\r\n    <script>\r\n    function dataBound() {\r\n        this.expandRow(this.tbody.find(\"tr.k-master-row\").first());\r\n    }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
