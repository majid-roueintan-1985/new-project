#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66da7d41635002ab00cb84fe449aca5790efe858"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_ExternalEvents), @"mvc.1.0.view", @"/Views/Events/ExternalEvents.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66da7d41635002ab00cb84fe449aca5790efe858", @"/Views/Events/ExternalEvents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Events_ExternalEvents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.ExternalEvents>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Events", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExportEvents", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""dcontent"">
    <div style=""margin-top: 10px; background-color: #6b8d9e; padding-top: 5px; padding-bottom: 5px; padding-right: 10px; border-radius: 5px; border: solid 1px #cccccc; background: repeating-linear-gradient(-45deg, #7fa1b3, #6b8d9e 1px, #6b8d9e 1px, #6b8d9e 20px);"">
        &nbsp;
    </div>

    <div style=""border-radius: 5px; margin-top: 5px; margin-bottom: 5px; padding: 15px; border: solid 1px #cea001; background-color: #ffe100;"">
        <table cellpadding=""3"" cellspacing=""0"">
            <tbody>
                <tr>
                    <td");
            BeginWriteAttribute("style", " style=\"", 736, "\"", 744, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <b><a class=\"breadcumb2-link\" href=\"#\">Mechanical Equipments</a></b>\r\n                    </td>\r\n                    <td");
            BeginWriteAttribute("style", " style=\"", 892, "\"", 900, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        »
                        <a class=""breadcumb2-link"" href=""/Events"">Events</a>

                        <b id=""subTitle22a""></b>
                    </td>
                    <td>
                        <b style=""color: #ff0000;"" id=""subTitle22""></b>
                    </td>
                </tr>
            </tbody>
        </table>
        <a id=""iHelp"" style=""float: right; position: relative; top: -32px;"" href=""javascript:;"" onclick=""showHelp();"">
            <img src=""/images/help.png"" style=""width: 48px;"" class=""imgHelp"">
        </a>
    </div>

    <h1 id=""iH1"">
        External Events
    </h1>

    <div id=""iContent"">
        <div id=""tab1"" class=""tab-item"" style=""display: block;"">
            <div id=""newPage"">
                <div class=""bevel-box"">
                    <table cellpadding=""3"" cellspacing=""0"">
                        <tbody>
                            <tr>
                                <td>
                                  ");
            WriteLiteral("  <input type=\"file\" name=\"uploadedFile\" id=\"uploadedFile\" style=\"direction: ltr; text-align: left;\">\r\n");
            WriteLiteral("                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66da7d41635002ab00cb84fe449aca5790efe8586519", async() => {
                WriteLiteral("\r\n                                        <input type=\"submit\" value=\"Export Excel\" />\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </td>

                                <td style=""width: 200px;"">
                                    <span id=""message"">
                                    </span>
                                </td>
                                <td>
                                    <a href=""#"" target=""_blank"">
                                        <img src=""/images/print_printer.png"" title=""Print"">
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>


                <div>

                    <div id=""iLoading22"" style=""display: none;"">
                        <img src=""/images/loading.gif"">
                    </div>


                    <a class=""btn-new-equip"" style=""cursor:pointer"" onclick=""Create()"">New</a>
                    <input type=""button"" id=""delete"" class=""btn-delete-equip"" value=""Delete"">
  ");
            WriteLiteral("                  <br />\r\n");
#nullable restore
#line 85 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                      
                        int rowCount = 1;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table id=""myExternalEventsTable"" cellpadding=""3"" cellspacing=""0"" class=""show-table"">
                        <thead>
                            <tr role=""row"">
                                <th>
                                    <input type=""checkbox"" id=""checkAll"" />
                                </th>
                                <th></th>
                                <th>
                                    <b>NPP Name</b>
                                </th>
                                <th>
                                    <b>Reactor Type</b>
                                </th>
                                <th>
                                    <b>Report Code</b>
                                </th>
                                <th>
                                    <b>Event Nmae</b>
                                </th>
                                <th>
                                    <b>Event Date</b>
                    ");
            WriteLiteral(@"            </th>
                                <th>
                                    <b>Report Date</b>
                                </th>
                                <th>
                                    <b>Related Ageing Mechanism</b>
                                </th>
                                <th>
                                    <b>Description</b>
                                </th>
                                <th>
                                    <b>Attached Files</b>
                                </th>
                                <th style=""width: 120px"">
                                    <b>Actions</b>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 128 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 5772, "\"", 5802, 1);
#nullable restore
#line 132 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
WriteAttributeValue("", 5780, item.ExternalEventsId, 5780, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 135 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 138 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.NPPName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 141 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.ReactorType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 144 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.ReportCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 147 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.EventName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 150 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.EventDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 153 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.ReportDate.ToString("yyyy/MM"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 156 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.RelatedAgeingMechanism);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 159 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 162 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                   Write(item.EventsImage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7434, "\"", 7472, 3);
            WriteAttributeValue("", 7444, "Edit(", 7444, 5, true);
#nullable restore
#line 165 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
WriteAttributeValue("", 7449, item.ExternalEventsId, 7449, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7471, ")", 7471, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 170 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Events\ExternalEvents.cshtml"
                                rowCount++;
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>


                    <br>
                    <div style=""clear: both;"">
                    </div>
                    <br>
                    <br>
                    <iframe style=""display: none"" id=""if_-2_119""");
            BeginWriteAttribute("src", " src=\"", 8016, "\"", 8022, 0);
            EndWriteAttribute();
            WriteLiteral(@"></iframe>

                </div>
            </div>
        </div>
    </div>
</div>



<link href=""/css/datatables.min.css"" rel=""stylesheet"" />
<link href=""/css/buttons.dataTables.min.css"" rel=""stylesheet"" />
<link href=""/css/select.dataTables.min.css"" rel=""stylesheet"" />



<script src=""/js/jquery.min.js""></script>
<script src=""/js/datatables.min.js""></script>
<script src=""/js/dataTables.buttons.min.js""></script>
<script src=""/js/jszip.min.js""></script>
<script src=""/js/pdfmake.min.js""></script>
<script src=""/js/vfs_fonts.js""></script>
<script src=""/js/buttons.html5.min.js""></script>
<script src=""/js/buttons.print.min.js""></script>


<script src=""/js/dataTables.select.min.js.download.js""></script>

<script>


    $(document).ready(function () {
        $('#myExternalEventsTable').DataTable({
            dom: 'Bfrtip',
            buttons: [

                'excel',

            ],
            select: true
        });
    });


    function Create() {
        $");
            WriteLiteral(@"(""#newPage"").load(""/Events/CraeteExternalEvents/"");
    }

    function Edit(id) {
        $(""#newPage"").load(""/Events/EditExternalEvents/"" + id);
    }


    //function ShowStatusbeforeEvent(id) {
    //    $(""#newPage"").load(""/Events/BeforeStatus/"" + id);
    //}


    //function ShowStatusFterEvent(id) {
    //    $(""#newPage"").load(""/Events/AfterStatus/"" + id);
    //}



    $(""#checkAll"").click(function () {
        $("".checkBox"").prop('checked',
            $(this).prop('checked'));
    });

    $(""#delete"").click(function () {
        var selectedIDs = new Array();

        $('input:checkbox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });


        var result = confirm(""are you sure you want to delete?"");
        if (result) {
            $.ajax({
                type: ""POST"",
                url: ""/Events/DeleteExternalEvents"",
                data: { ""eventId"": s");
            WriteLiteral(@"electedIDs },

                success: function (response) {
                    window.location.href = ""/Events/ExternalEvents/"";
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }

            });
        }

    });

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.ExternalEvents>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
