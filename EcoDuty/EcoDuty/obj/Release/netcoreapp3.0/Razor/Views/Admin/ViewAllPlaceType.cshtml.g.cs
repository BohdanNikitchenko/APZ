#pragma checksum "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24b7451f4c57c9786706d3c51bb05adc2439b726"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ViewAllPlaceType), @"mvc.1.0.view", @"/Views/Admin/ViewAllPlaceType.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24b7451f4c57c9786706d3c51bb05adc2439b726", @"/Views/Admin/ViewAllPlaceType.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37113bf3b6086b461ca53532fbc2cec3440875cc", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ViewAllPlaceType : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PlaceType>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
  
    ViewData["Title"] = "ViewAllPlaceType";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ViewAllPlaceType</h1>\r\n<br/>\r\n<a");
            BeginWriteAttribute("href", " href=\'", 121, "\'", 167, 1);
#nullable restore
#line 8 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
WriteAttributeValue("", 128, Url.Action("AddPlaceTypePage","Admin"), 128, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link__dish\">Add Place Type</a>\r\n<br/>\r\n");
#nullable restore
#line 10 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
 foreach (var placeType in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <a");
            BeginWriteAttribute("href", " href=\'", 274, "\'", 341, 1);
#nullable restore
#line 13 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
WriteAttributeValue("", 281, Url.Action("PlaceTypePage","Admin", new{id = placeType.Id}), 281, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link__dish\">");
#nullable restore
#line 13 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
                                                                                             Write(placeType.HousingType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 13 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
                                                                                                                    Write(placeType.EcoType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        <a");
            BeginWriteAttribute("href", " href=\'", 419, "\'", 487, 1);
#nullable restore
#line 14 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
WriteAttributeValue("", 426, Url.Action("PlaceTypeRemove","Admin",new{id = placeType.Id}), 426, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link__dish\">Delete</a>\r\n    </div>\r\n");
#nullable restore
#line 16 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<a");
            BeginWriteAttribute("href", " href=\'", 539, "\'", 574, 1);
#nullable restore
#line 18 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\ViewAllPlaceType.cshtml"
WriteAttributeValue("", 546, Url.Action("Index","Admin"), 546, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"back__list\">Back</a>");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PlaceType>> Html { get; private set; }
    }
}
#pragma warning restore 1591
