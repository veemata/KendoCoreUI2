#pragma checksum "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adb41dfec3f8e58f83fc940a27775a39e73ee401"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserInRoles_Index), @"mvc.1.0.view", @"/Views/UserInRoles/Index.cshtml")]
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
#line 1 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\_ViewImports.cshtml"
using MH.PLCM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\_ViewImports.cshtml"
using MH.PLCM.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\_ViewImports.cshtml"
using MH.PLCM.Models.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\_ViewImports.cshtml"
using MH.PLCM.Northwind.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adb41dfec3f8e58f83fc940a27775a39e73ee401", @"/Views/UserInRoles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9838e3d302c9bef2f4d6c467f2a39c2efd9fe77b", @"/Views/_ViewImports.cshtml")]
    public class Views_UserInRoles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserInRolesViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
  
    ViewData["Title"] = "User In Roles";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 6 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    ");
#nullable restore
#line 9 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
Write(Model.User.ContactName);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    ");
#nullable restore
#line 10 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
Write(Model.User.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    ");
#nullable restore
#line 11 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
Write(Model.User.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    ");
#nullable restore
#line 12 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
Write(Model.User.Company);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    ");
#nullable restore
#line 13 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
Write(Model.User.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    ");
#nullable restore
#line 14 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
Write(Model.User.ContributionLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n</div>\r\n\r\n\r\n<div>\r\n    ");
#nullable restore
#line 20 "C:\Users\3051752\source\repos\KendoCoreUI2\MH.PLCM.Web\Views\UserInRoles\Index.cshtml"
Write(Html.Kendo().Grid(Model.Roles)
                        .Name("userRoles")
                        .Columns(columns =>
                        {
                            columns.Select();
                            columns.Bound(r=>r.ApplicationRoleName);
                            columns.Command(command => { command.Edit(); command.Destroy(); }).Width(300);
                        })
                         .ToolBar(toolbar =>
                         {
                             toolbar.Create().Text("Add Role");
                        })
                        .HtmlAttributes(new { style = "height:550px;" })
                         );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserInRolesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
