#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\TypicalPrograms.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "937b95d0eea5e9def55b735cf856e3e4b9991b242a95d0f7397fc2ab7820dbb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inspection_TypicalPrograms), @"mvc.1.0.view", @"/Views/Inspection/TypicalPrograms.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"937b95d0eea5e9def55b735cf856e3e4b9991b242a95d0f7397fc2ab7820dbb0", @"/Views/Inspection/TypicalPrograms.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Inspection_TypicalPrograms : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\TypicalPrograms.cshtml"
  
    ViewData["Title"] = "TypicalPrograms";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""bevel-box"">
    <div id=""newPage"">
        <div>

            <div id=""iLoading22"" style=""display: none;"">
                <img src=""/images/loading.gif"">
            </div>

            <h1>Typical Programs</h1>

            <a class=""btn-new-equip"" onclick=""Create()"">New</a>
            <input type=""button"" ");
            WriteLiteral(" class=\"btn-delete-equip\" value=\"Delete\">\r\n            <br />\r\n");
#nullable restore
#line 19 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\TypicalPrograms.cshtml"
              
                int rowCount = 1;
            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table id=""myTable"" cellpadding=""3"" cellspacing=""0"" class=""show-table"">
                <thead>
                    <tr role=""row"">
                        <th>
                            <input type=""checkbox"" id=""checkAll"" />
                        </th>
                        <th></th>
                        <th style=""width: 150px"">
                            <b>Type</b>
                        </th>
                        <th style=""width: 250px"">
                            <b>Date</b>
                        </th>
                        <th style=""width: 120px"">
                            <b>Frequency</b>
                        </th>
                        <th style=""width: 120px"">
                            <b>Prepaired by</b>
                        </th>

                        <th style=""width: 120px"">
                            <b>	Approved</b>
                        </th>
                        <th style=""width: 120px"">
                          ");
            WriteLiteral(@"  <b>	Authorized</b>
                        </th>

                        <th style=""width: 120px"">
                            <b>Actions</b>
                        </th>
                    </tr>
                </thead>
                <tbody>
");
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n\r\n            <br>\r\n            <div style=\"clear: both;\">\r\n            </div>\r\n            <br>\r\n            <br>\r\n            <iframe style=\"display: none\" id=\"if_-2_119\"");
            BeginWriteAttribute("src", " src=\"", 3069, "\"", 3075, 0);
            EndWriteAttribute();
            WriteLiteral("></iframe>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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