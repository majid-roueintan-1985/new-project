#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsPeriod.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "510e8752df815a9f1da236ed2ade46ed73f92c65676dfab71f092014d98ad9b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AgeingAssessment_TransientsPeriod), @"mvc.1.0.view", @"/Views/AgeingAssessment/TransientsPeriod.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"510e8752df815a9f1da236ed2ade46ed73f92c65676dfab71f092014d98ad9b4", @"/Views/AgeingAssessment/TransientsPeriod.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_AgeingAssessment_TransientsPeriod : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/SACOR-446"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.unobtrusive.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsPeriod.cshtml"
  
    ViewData["Title"] = "TransientsReport";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<div id=\"tab1\" class=\"tab-item\" style=\"display: block;\">\r\n\r\n");
            WriteLiteral(@"

    <div class=""tab-buttons"">
        <ul>
            <li id=""tab-button1"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                <a id=""tab-button-a1""
                   onclick=""showsubPage1()"" style=""cursor:pointer;color: rgb(0, 113, 158);"">
                    All Transients
                </a>
            </li>
            <li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(208, 208, 208); border-color: rgb(128, 128, 128); font-weight: bold;"">
                <a id=""tab-buttona2"" onclick=""showsubPage2()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                    Transients in a Period
                </a>
            </li>
        </ul>

        <div style=""clear:both;""></div>
    </div>


    <div id=""newPage"">
");
            WriteLiteral("        <div>\r\n\r\n            <div id=\"iLoading22\" style=\"display: none;\">\r\n                <img src=\"/images/loading.gif\">\r\n            </div>\r\n\r\n            <h1>Transients in a Period</h1>\r\n\r\n            <div class=\"bevel-box\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "510e8752df815a9f1da236ed2ade46ed73f92c65676dfab71f092014d98ad9b46239", async() => {
                WriteLiteral(@"
                    <table cellpadding=""3"" cellspacing=""0"">
                        <tbody>
                            <tr>
                                <td>
                                    Date From:
                                </td>
                                <td>
                                    <input name=""searchDateFrom"" id=""searchDateFrom"" ");
                WriteLiteral(@" style=""direction: ltr; text-align: left;"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    To:
                                </td>
                                <td>
                                    <input name=""searchDateTo"" id=""searchDateTo"" ");
                WriteLiteral(" >\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>\r\n");
                WriteLiteral("                                    <input type=\"button\" onclick=\"SearchInTransients();\" value=\"Search\" style=\"direction: ltr; text-align: left;\">\r\n                                    <input type=\"button\" onclick=\"transientsPeriod();\" ");
                WriteLiteral(" class=\"butn-cancel\" style=\"direction: ltr; text-align: center;margin-bottom:-7px;\">\r\n                                </td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>

            <div id=""transientList"">
            </div>

        </div>
    </div>

</div>






<link href=""/css/kendo.common.min.css"" rel=""stylesheet"" />
<link href=""/css/kendo.default.min.css"" rel=""stylesheet"" />

<script src=""/js/jquery.min.js""></script>
<script src=""/js/kendo.all.min.js""></script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "510e8752df815a9f1da236ed2ade46ed73f92c65676dfab71f092014d98ad9b49717", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "510e8752df815a9f1da236ed2ade46ed73f92c65676dfab71f092014d98ad9b410780", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script src=""/js/datatables.min.js""></script>




<script>
    $(document).ready(function () {
        $(""#myTable"").DataTable();
    });


    $(""#reportDate"").kendoDatePicker();

    $(""#searchfileDate"").kendoDatePicker(
        {
            format: ""yyyy/MM/dd""
        });

    $(""#schDate"").kendoDatePicker(
        {
            format: ""yyyy/MM/dd""
        });
    $(""#searchDateFrom"").kendoDatePicker(
        {
            format: ""yyyy/MM/dd""
        });
    $(""#searchDateTo"").kendoDatePicker(
        {
            format: ""yyyy/MM/dd""
        });

    $(""input#searchDateFrom"").prop('disabled', true);

    $(""input#searchDateTo"").prop('disabled', true);

    function showPage1() {
        $(""#Tabs"").load(""/AgeingAssessment/SACORReport/"");
    }

    function showPage2() {
        $(""#Tabs"").load(""/AgeingAssessment/TransientsReport/"");
    }

    function showPage3() {
        $(""#Tabs"").load(""/AgeingAssessment/WaterChemistryReport/"");
    }


    functi");
            WriteLiteral(@"on showsubPage1() {
        //$(""#newPage"").load(""/Inspection/WorkingPrograms/"");
        $(""#Tabs"").load(""/AgeingAssessment/TransientsReport/"");
    }

    function showsubPage2() {
        $(""#submenu"").load(""/AgeingAssessment/TransientsPeriod/"");
    }

    function transientsPeriod() {
        $(""#submenu"").load(""/AgeingAssessment/TransientsPeriod/"");
    }


    $(""#checkAll"").click(function () {
        $("".checkBox"").prop('checked',
            $(this).prop('checked'));
    });



    function CreateTypicalyDocument() {
        $(""#newPage"").load(""/Inspection/CreateTypicalDocument/"");
    }

    function EditTypicalyDocument(id) {
        $(""#newPage"").load(""/Inspection/EditTypicalDocument/"" + id);
    }

    $(""#checkAllPrograms"").click(function () {
        $("".checkBoxProgram"").prop('checked',
            $(this).prop('checked'));
    });

    function SearchInTransients() {

        var dateFrom = $('#searchDateFrom').val();
        var dateTo = $('#searchDateTo");
            WriteLiteral(@"').val();

        $.ajax({

            type: ""POST"",
            url: ""/AgeingAssessment/SearchTramsients"",
            data: {

                ""dateFrom"": dateFrom,
                ""dateTo"": dateTo,
            },
            success:
                function (response) {

                    $(""#transientList"").html(response);

                },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }

</script>


");
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
