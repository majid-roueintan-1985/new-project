#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4209544121b0af324c7dc0cc842df59e61a5337a8a3d05d58c640c53961d8d27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transients_EditDocument), @"mvc.1.0.view", @"/Views/Transients/EditDocument.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4209544121b0af324c7dc0cc842df59e61a5337a8a3d05d58c640c53961d8d27", @"/Views/Transients/EditDocument.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Transients_EditDocument : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable< Bnpp.DataLayer.Entities.TransientDocuments>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("designForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditTransientDocument", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
  
    ViewData["Title"] = "EditDocument";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Edit Document</h2>\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral(@"
<link rel=""stylesheet"" type=""text/css"" href=""/css/bootstrap-rtl.min.css"">
<link rel=""stylesheet"" type=""text/css"" href=""/css/style.css"">





<section class=""single-page"">

    <article>

        <!-- Gallery -->
        <div class=""col-md-6  pull-right product-gallery"">
           
            <div class=""thumbnails-image"">
                <div class=""row"">
");
#nullable restore
#line 35 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-md-3 col-sm-3 col-xs-4 border-radius\">\r\n\r\n");
#nullable restore
#line 39 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
                              
                                var extn = item.Filename.Split(".").Last();
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
                             if (extn == "png" || extn == "jpeg" || extn == "jpg")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <img");
            BeginWriteAttribute("id", " id=\"", 1377, "\"", 1408, 1);
#nullable restore
#line 44 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
WriteAttributeValue("", 1382, item.TransientDocumentsId, 1382, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"border-radius\" onclick=\"ChangeImage(this.id)\"");
            BeginWriteAttribute("alt", " alt=\"", 1462, "\"", 1482, 1);
#nullable restore
#line 44 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
WriteAttributeValue("", 1468, item.Filename, 1468, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 1483, "\"", 1534, 2);
            WriteAttributeValue("", 1489, "/transientFiles/", 1489, 16, true);
#nullable restore
#line 44 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
WriteAttributeValue("", 1505, item.TransientDocumentsImage, 1505, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 45 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1709, "\"", 1761, 2);
            WriteAttributeValue("", 1716, "/transientFiles/", 1716, 16, true);
#nullable restore
#line 49 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
WriteAttributeValue("", 1732, item.TransientDocumentsImage, 1732, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 49 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
                                                                                       Write(item.Filename);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </p>\r\n");
#nullable restore
#line 51 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <input type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1902, "\"", 1954, 3);
            WriteAttributeValue("", 1912, "DeleteDocument(", 1912, 15, true);
#nullable restore
#line 53 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
WriteAttributeValue("", 1927, item.TransientDocumentsId, 1927, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1953, ")", 1953, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-delete-equip\" value=\"Delete\">\r\n                        </div>\r\n");
#nullable restore
#line 55 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"clearfix\"></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!-- End Gallery -->\r\n        <div class=\"clearfix\"></div>\r\n    </article>\r\n</section>\r\n\r\n<div id=\"normal\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4209544121b0af324c7dc0cc842df59e61a5337a8a3d05d58c640c53961d8d279601", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"transientsId\" id=\"transientsId\"");
                BeginWriteAttribute("value", " value=\"", 2425, "\"", 2453, 1);
#nullable restore
#line 68 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
WriteAttributeValue("", 2433, ViewBag.TransientId, 2433, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
        <table cellpadding=""3"" cellspacing=""0"">
            <tbody>
                <tr>
                    <td>
                        Select File:
                    </td>
                    <td>
                        <input type=""file"" multiple=""multiple"" name=""imgTrnsientUp"" id=""imgTrnsientUp"" style=""direction: ltr; text-align: left;"">
                    </td>
                </tr>
                <tr>
                    <td>
                        <img id=""imgCourse"" class=""thumbnail"" style=""max-width: 800px;max-height:800px"" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type=""button"" onclick=""AjaxdocumentFormSubmit()"" value=""Edit"" class=""butn-save"" style=""direction: ltr; text-align: left;"">

                    </td>
                </tr>
            </tbody>
        </table>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n<div>\r\n    <input type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3418, "\"", 3493, 3);
            WriteAttributeValue("", 3428, "location=\'/Transients/ShowTransientDocument/", 3428, 44, true);
#nullable restore
#line 96 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
WriteAttributeValue("", 3472, ViewBag.TransientId, 3472, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3492, "\'", 3492, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-edit-equip\" value=\"Back To Documents\">\r\n</div>\r\n<script src=\"/js/jquery.min.js\"></script>\r\n<script src=\"/js/bootstrap.min.js\"></script>\r\n");
            WriteLiteral(@"
<script src=""/js/script.js""></script>

<script>

    function ChangeImage(clicked_id) {

        var imageId = clicked_id;

        var thumbImage = $('#' + imageId).prop('src');

        $('#bigImages').prop(""src"", thumbImage);
    }

    function DeleteDocument(id) {

        var result = confirm(""are you sure you want to delete?"");
        if (result) {

            $.ajax({
                type: ""POST"",
                url: ""/Transients/DeletetransientDocument/"" + id,

                success: function (response) {

                   
                    $(""#editDocument"").load(""/Transients/EditDocument/"" + ");
#nullable restore
#line 127 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
                                                                     Write(ViewBag.TransientId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@");
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }

            });
        }

    }

    function AjaxdocumentFormSubmit() {

        //Set the URL.
        var url = $(""#designForm"").attr(""action"");
        //Add the Field values to FormData object.
        var formData = new FormData();


        var files = $(""#imgTrnsientUp"").get(0).files;
        for (var i = 0; i < files.length; i++) {
            formData.append(""fileTransient"", files[i]);
        }


        formData.append(""transientsId"", $(""#transientsId"").val());

        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            processData: false,
            contentType: false
        }).done(function () {
            $(""#editDocument"").load(""/Transients/EditDocument/"" + ");
#nullable restore
#line 164 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\EditDocument.cshtml"
                                                             Write(ViewBag.TransientId);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        });\r\n\r\n    }\r\n\r\n    //Documents\r\n</script>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable< Bnpp.DataLayer.Entities.TransientDocuments>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
