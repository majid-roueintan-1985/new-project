#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingMechanism\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "569d70909798501689737bcb06e376f8638aa928c84eb84ecb9d96dd898fc1d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AgeingMechanism_Index), @"mvc.1.0.view", @"/Views/AgeingMechanism/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"569d70909798501689737bcb06e376f8638aa928c84eb84ecb9d96dd898fc1d5", @"/Views/AgeingMechanism/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_AgeingMechanism_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingMechanism\Index.cshtml"
  
	ViewData["Title"] = "Index";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div id=\"Tabs\">\r\n\t\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\t<script src=\"/js/jquery.unobtrusive-ajax.min.js\"></script>\r\n\t<script>\r\n\r\n\t\t$(document).ready(function () {\r\n\t\t\t$(\"#Tabs\").load(\"/AgeingMechanism/Mechanism/");
#nullable restore
#line 17 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingMechanism\Index.cshtml"
                                                   Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t});\r\n\r\n\t\tfunction showPage1() {\r\n\t\t\t$(\"#Tabs\").load(\"/AgeingMechanism/Mechanism/");
#nullable restore
#line 21 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingMechanism\Index.cshtml"
                                                   Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t}\r\n\r\n\t\tfunction showPage2() {\r\n\t\t\t$(\"#Tabs\").load(\"/AgeingMechanism/Documents/");
#nullable restore
#line 25 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingMechanism\Index.cshtml"
                                                   Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\r\n\t\t}\r\n\r\n\t\t\t\t\t\t// function showPage1() {\r\n\t\t\t\t\t\t// \t$(\"#Tabs\").load(\"/AgeingMechanism/Documents/");
#nullable restore
#line 30 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingMechanism\Index.cshtml"
                                                                      Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\t\t\t\t\t\t// }\r\n\r\n\t\t\t\t\t\t// function showPage2() {\r\n\t\t\t\t\t\t// \t$(\"#Tabs\").load(\"/ManagementDocuments/OtherDocuments/");
#nullable restore
#line 34 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingMechanism\Index.cshtml"
                                                                               Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n\r\n\t\t\t\t\t\t// \t$(\"li\").css({ \"background-color\": \"yellow\", \"padding\": \"25px\", \"width\": \"200px\" });\r\n\r\n\t\t\t\t\t\t// }\r\n\r\n\t\t\t\t\t\t// function showPage3() {\r\n\t\t\t\t\t\t// \t$(\"#Tabs\").load(\"/ManagementDocuments/ManagementReviews/\");\r\n\t\t\t\t\t\t// }\r\n\r\n\t</script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
