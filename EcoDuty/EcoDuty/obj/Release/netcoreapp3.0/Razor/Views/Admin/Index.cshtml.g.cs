#pragma checksum "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3158c57425f2fa0ec2d9680ad403a405300e4a05"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3158c57425f2fa0ec2d9680ad403a405300e4a05", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37113bf3b6086b461ca53532fbc2cec3440875cc", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\'", 65, "\'", 111, 1);
#nullable restore
#line 8 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\Index.cshtml"
WriteAttributeValue("", 72, Url.Action("ViewAllPlaceType","Admin"), 72, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link__dish\">Place Type</a>\r\n<br />\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\'", 166, "\'", 214, 1);
#nullable restore
#line 11 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\Index.cshtml"
WriteAttributeValue("", 173, Url.Action("ViewAllTechnicType","Admin"), 173, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link__dish\">Technic Type</a>\r\n<br />\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\'", 271, "\'", 318, 1);
#nullable restore
#line 14 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\Index.cshtml"
WriteAttributeValue("", 278, Url.Action("ViewAllSensorType","Admin"), 278, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link__dish\">Sensor Type</a>\r\n<br />\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\'", 374, "\'", 417, 1);
#nullable restore
#line 17 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\Index.cshtml"
WriteAttributeValue("", 381, Url.Action("ViewAllCities","Admin"), 381, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link__dish\">Cities</a>\r\n<br />\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\'", 468, "\'", 509, 1);
#nullable restore
#line 20 "D:\Github\APZ\EcoDuty\EcoDuty\Views\Admin\Index.cshtml"
WriteAttributeValue("", 475, Url.Action("ViewAllUser","Admin"), 475, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link__dish\">Users</a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
