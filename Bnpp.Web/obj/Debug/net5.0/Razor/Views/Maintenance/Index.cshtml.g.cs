#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9da02421737695d67092d35c86f80566074097ceadefdc935272a529f46d6853"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Maintenance_Index), @"mvc.1.0.view", @"/Views/Maintenance/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"9da02421737695d67092d35c86f80566074097ceadefdc935272a529f46d6853", @"/Views/Maintenance/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Maintenance_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml"
  
	ViewData["Title"] = "Index";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"Tabs\">\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\t<script src=\"/js/jquery.unobtrusive-ajax.min.js\"></script>\r\n\t<script>\r\n\r\n\t\t$(document).ready(function () {\r\n\t\t\t$(\"#Tabs\").load(\"/Maintenance/MaintenancePrograms/");
#nullable restore
#line 15 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml"
                                                         Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t});\r\n\r\n\t\tfunction showPage1() {\r\n\t\t\t$(\"#Tabs\").load(\"/Maintenance/MaintenancePrograms/");
#nullable restore
#line 19 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml"
                                                         Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t}\r\n\r\n\t\tfunction showPage2() {\r\n\t\t\t$(\"#Tabs\").load(\"/Maintenance/Defections/");
#nullable restore
#line 23 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml"
                                                Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t}\r\n\r\n\t\tfunction showPage3() {\r\n\t\t\t$(\"#Tabs\").load(\"/Maintenance/SpareParts/");
#nullable restore
#line 27 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml"
                                                Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t}\r\n\r\n\t\tfunction showPage4() {\r\n\t\t\t$(\"#Tabs\").load(\"/Maintenance/MaintenanceForms/");
#nullable restore
#line 31 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml"
                                                      Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t}\r\n\r\n\t\tfunction showPage5() {\r\n\t\t\t$(\"#Tabs\").load(\"/Maintenance/Measurements/");
#nullable restore
#line 35 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml"
                                                  Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t}\r\n\r\n\t\tfunction showPage6() {\r\n\t\t\t$(\"#Tabs\").load(\"/Maintenance/DefectsReport/");
#nullable restore
#line 39 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Maintenance\Index.cshtml"
                                                   Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t}\r\n\r\n\r\n\t</script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591