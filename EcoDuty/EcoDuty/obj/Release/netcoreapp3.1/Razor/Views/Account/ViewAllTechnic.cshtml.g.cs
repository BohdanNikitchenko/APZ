#pragma checksum "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "344ac8ceb01514b7d0c8e69698b8a2cc14af64ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ViewAllTechnic), @"mvc.1.0.view", @"/Views/Account/ViewAllTechnic.cshtml")]
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
#line 1 "D:\Github\APZ\EcoDuty\EcoDuty\Views\_ViewImports.cshtml"
using EcoDuty;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github\APZ\EcoDuty\EcoDuty\Views\_ViewImports.cshtml"
using EcoDuty.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Github\APZ\EcoDuty\EcoDuty\Views\_ViewImports.cshtml"
using BusinessLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Github\APZ\EcoDuty\EcoDuty\Views\_ViewImports.cshtml"
using DataLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Github\APZ\EcoDuty\EcoDuty\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"344ac8ceb01514b7d0c8e69698b8a2cc14af64ea", @"/Views/Account/ViewAllTechnic.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"567306d9ff0a7622502f3b67b79895274b91dc3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ViewAllTechnic : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Technic>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
  
    ViewData["Title"] = "ViewAllTechnic";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<link href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css"" rel='stylesheet' type='text/css'>
<h1>ViewAllTechnic</h1>

<main class=""my-form"">
    <div class=""cotainer"">
        <div class=""row justify-content-center"">
            <div class=""col-md-8"">
                <div class=""card"">
                    <div class=""panel panel-default panel-table"">
                        <div class=""panel-heading"">
                            <div class=""row"">
                                <div class=""col col-xs-6"">
                                    <h3 class=""panel-title"">");
#nullable restore
#line 19 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
                                                       Write(SharedLocalizer["Technics"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                </div>\r\n                                <div class=\"col col-xs-6 text-right\">\r\n                                    <button type=\"button\" class=\"btn btn-sm btn-primary btn-create\"");
            BeginWriteAttribute("onclick", "\r\n                                            onclick=\"", 947, "\"", 1057, 3);
            WriteAttributeValue("", 1002, "location.href=\'", 1002, 15, true);
#nullable restore
#line 23 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
WriteAttributeValue("", 1017, Url.Action("AddTechnicPage","Account"), 1017, 39, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1056, "\'", 1056, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 24 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
                                   Write(SharedLocalizer["Create New"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class=""panel-body"">
                            <table class=""table table-striped table-bordered table-list"" id=""dev-table"">
                                <thead>
                                    <tr>
                                        <th style=""width: 20%""><em class=""fa fa-cog""></em></th>
                                        <th>");
#nullable restore
#line 34 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
                                       Write(SharedLocalizer["TechnicNumber"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 38 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
                                     foreach (var technic in Model)
                                    {
                                        if (technic.AutoNumber != null)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td align=\"center\">\r\n                                                    <a");
            BeginWriteAttribute("href", " href=\'", 2231, "\'", 2296, 1);
#nullable restore
#line 44 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
WriteAttributeValue("", 2238, Url.Action("TechnicPage","Account", new{id = technic.Id}), 2238, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\"><em class=\"fa fa-info\"></em></a>\r\n                                                    <a");
            BeginWriteAttribute("href", " href=\'", 2410, "\'", 2476, 1);
#nullable restore
#line 45 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
WriteAttributeValue("", 2417, Url.Action("TechnicRemove","Account",new{id = technic.Id}), 2417, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\"><em class=\"fa fa-trash\"></em></a>\r\n                                                </td>\r\n                                                <td>");
#nullable restore
#line 47 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
                                               Write(technic.AutoNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 49 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                            <div>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2951, "\"", 2990, 1);
#nullable restore
#line 54 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
WriteAttributeValue("", 2958, Url.Action("Account","Account"), 2958, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 54 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Account\ViewAllTechnic.cshtml"
                                                                      Write(SharedLocalizer["Back"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHtmlLocalizer<SharedResource> SharedLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Technic>> Html { get; private set; }
    }
}
#pragma warning restore 1591
