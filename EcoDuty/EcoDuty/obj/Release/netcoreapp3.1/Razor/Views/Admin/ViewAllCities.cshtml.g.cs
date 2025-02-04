#pragma checksum "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a05ec7403df6823725867d78e277c68b908cf2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ViewAllCities), @"mvc.1.0.view", @"/Views/Admin/ViewAllCities.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a05ec7403df6823725867d78e277c68b908cf2d", @"/Views/Admin/ViewAllCities.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"567306d9ff0a7622502f3b67b79895274b91dc3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ViewAllCities : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<City>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
  
    ViewData["Title"] = "ViewAllCities";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>ViewAllCities</h1>
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
#line 16 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
                                                       Write(Localizer["Cities"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                </div>\r\n                                <div class=\"col col-xs-6 text-right\">\r\n                                    <button type=\"button\" class=\"btn btn-sm btn-primary btn-create\"");
            BeginWriteAttribute("onclick", "\r\n                                            onclick=\"", 799, "\"", 904, 3);
            WriteAttributeValue("", 854, "location.href=\'", 854, 15, true);
#nullable restore
#line 20 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
WriteAttributeValue("", 869, Url.Action("AddCityPage","Admin"), 869, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 903, "\'", 903, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 21 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
                                   Write(Localizer["Create New"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class=""panel-body"">
                            <table class=""table table-striped table-bordered table-list"">
                                <thead>
                                    <tr>
                                        <th style=""width: 20%""><em class=""fa fa-cog""></em></th>
                                        <th>");
#nullable restore
#line 31 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
                                       Write(SharedLocalizer["City"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th>");
#nullable restore
#line 32 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
                                       Write(SharedLocalizer["Country"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 36 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
                                     foreach (var city in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td align=\"center\">\r\n                                                <a");
            BeginWriteAttribute("href", " href=\'", 1995, "\'", 2052, 1);
#nullable restore
#line 40 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
WriteAttributeValue("", 2002, Url.Action("CityPage","Admin", new{id = city.Id}), 2002, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\"><em class=\"fa fa-pencil\"></em></a>\r\n                                                <a");
            BeginWriteAttribute("href", " href=\'", 2164, "\'", 2222, 1);
#nullable restore
#line 41 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
WriteAttributeValue("", 2171, Url.Action("CityRemove","Admin",new{id = city.Id}), 2171, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\"><em class=\"fa fa-trash\"></em></a>\r\n                                            </td>\r\n                                            <td>");
#nullable restore
#line 43 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
                                           Write(city.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 44 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
                                           Write(city.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 46 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllCities.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<City>> Html { get; private set; }
    }
}
#pragma warning restore 1591
