#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a7eac11a17b62accb9dcb63928e4d5c8b03f381"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transients_SaveTransients), @"mvc.1.0.view", @"/Views/Transients/SaveTransients.cshtml")]
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
#line 1 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
using Bnpp.DataLayer.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a7eac11a17b62accb9dcb63928e4d5c8b03f381", @"/Views/Transients/SaveTransients.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Transients_SaveTransients : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/SACOR-446"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
  
    ViewData["Title"] = "SaveTransients";
    Layout = null;

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
            BeginWriteAttribute("style", " style=\"", 685, "\"", 693, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        <b><a class=""breadcumb2-link"" href=""/Admin"">Main</a></b>
                    </td>
                </tr>
            </tbody>
        </table>
        <a id=""iHelp"" style=""float: right; position: relative; top: -32px;"" href=""javascript:;"" onclick=""showHelp();"">
            <img src=""/images/help.png"" style=""width: 48px;"" class=""imgHelp"">
        </a>
    </div>

    <h1 id=""iH1""></h1>
    <div id=""iContent"">

        <div class=""tab-buttons"">
            <ul>
                <li id=""tab-button1"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-button-a1""
                       onclick=""showPage1()"" style=""cursor:pointer;color: rgb(0, 113, 158);"">
                        Create Transients
                    </a>
                </li>
                <li id=""tab-button2"" style=""background-color: rgb(208, 208, 208); border-color: rgb(128, 128, 128); font-weig");
            WriteLiteral(@"ht: bold;"">
                    <a id=""tab-buttona2"" onclick=""showPage2()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Save Transients
                    </a>

                </li>
                <li id=""tab-button3"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-button-a3"" onclick=""showPage3()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Results
                    </a>
                </li>
            </ul>

            <div style=""clear:both;""></div>
        </div>

        <div id=""tab1"" class=""tab-item"" style=""display: block;"">

            <h1 id=""iH1"">
                Save Transients
            </h1>



            <div id=""newPage"">

                <div class=""bevel-box"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a7eac11a17b62accb9dcb63928e4d5c8b03f3816793", async() => {
                WriteLiteral(@"
                        <table cellpadding=""3"" cellspacing=""0"">
                            <tbody>
                                <tr>
                                    <td>
                                        Code:
                                    </td>
                                    <td>
                                        <input name=""code"" id=""code"" type=""text"" style=""direction: ltr; text-align: left;"">
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <input type=""button"" onclick=""codeSearch();"" value=""Search"" style=""direction: ltr; text-align: left;"">
                                        <input type=""button"" onclick=""cancelSearch();"" class=""butn-cancel"" style=""direction: ltr; text-align: center;margin-bottom:-7px;"">
                                    </td>
                                </tr>
                     ");
                WriteLiteral("       </tbody>\r\n                        </table>\r\n                    ");
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
            WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"bevel-box\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a7eac11a17b62accb9dcb63928e4d5c8b03f3819561", async() => {
                WriteLiteral(@"
                        <table cellpadding=""3"" cellspacing=""0"">
                            <tbody>
                                <tr>
                                    <td>
                                        Name:
                                    </td>
                                    <td>
                                        <input name=""transientName"" id=""transientName"" type=""text"" style=""direction: ltr; text-align: left;"">
                                    </td>

                                </tr>
                                <tr>
                                    <td>

                                        <input type=""button"" onclick=""nameSearch();"" value=""Search"" style=""direction: ltr; text-align: left;"">
                                        <input type=""button"" onclick=""cancelSearch();"" class=""butn-cancel"" style=""direction: ltr; text-align: center;margin-bottom:-7px;"">
                                    </td>
                                </tr>
 ");
                WriteLiteral("                           </tbody>\r\n                        </table>\r\n                    ");
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
                <div class=""bevel-box"">
                    <div id=""result"">
                    </div>
                </div>


                <a class=""btn-new-equip"" onclick=""CreateNewTransient()"" style=""cursor:pointer"">Create New Transient</a>
                <input type=""button"" id=""delete"" class=""btn-delete-equip"" value=""Delete"">
                <div id=""newTransient""></div>

                <div class=""bevel-box"">

");
#nullable restore
#line 124 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                      
                        List<Transients> savedTransient = ViewBag.SavedTransient as List<Transients>;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 128 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                      
                        int rowCount = 1;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table id=""savedTransient"" cellpadding=""3"" cellspacing=""0"" class=""show-table"">
                        <thead>
                            <tr role=""row"">
                                <th>
                                    <input type=""checkbox"" id=""checkAll"" />
                                </th>
                                <th>

                                </th>
                                <th>
                                    <b>Code </b>
                                </th>
                                <th>
                                    <b>Name</b>
                                </th>
                                <th>
                                    <b>Transient Date</b>
                                </th>
                                <th>
                                    <b>Transient Time</b>
                                </th>
                                <th>
                                    <b>Description");
            WriteLiteral(@"</b>
                                </th>
                                <th>
                                    <b>Document</b>
                                </th>
                                <th>

                                </th>

                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 165 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                             foreach (var item in savedTransient)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 7380, "\"", 7406, 1);
#nullable restore
#line 169 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
WriteAttributeValue("", 7388, item.TransientsId, 7388, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 172 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 175 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                                   Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 178 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 181 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                                   Write(item.TransientDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 184 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                                   Write(item.TransientTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 187 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 8408, "\"", 8467, 2);
            WriteAttributeValue("", 8415, "/Transients/ShowTransientDocument/", 8415, 34, true);
#nullable restore
#line 190 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
WriteAttributeValue("", 8449, item.TransientsId, 8449, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" target=""_blank"">
                                            Transient Document
                                        </a>
                                    </td>
                                    <td>
                                        <a class=""btn-edit-equip""");
            BeginWriteAttribute("onclick", " onclick=\"", 8747, "\"", 8790, 3);
            WriteAttributeValue("", 8757, "EditTransient(", 8757, 14, true);
#nullable restore
#line 195 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
WriteAttributeValue("", 8771, item.TransientsId, 8771, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8789, ")", 8789, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 201 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SaveTransients.cshtml"
                                rowCount++;
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
                <!-- Modal -->
                <div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"">
                    <div class=""modal-dialog"" role=""document"">
                        <div class=""modal-content"">
                            <div class=""modal-header"">
                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                                <h4 class=""modal-title"" id=""myModalLabel"">Modal title</h4>
                            </div>
                            <div class=""modal-body"" id=""myModalBody"">
                                ...
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal -->

            </div>

        </div>
    </div>
</div>

<link hre");
            WriteLiteral(@"f=""/css/bootstrap-modal1.css"" rel=""stylesheet"" type=""text/css"" />

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

<script src=""/js/bootstrap.min.js""></script>







<script>



    function showPage1() {
        $(""#Tabs"").load(""/Transients/CreateTransientGroups/"");
    }

    function showPage2() {
        $(""#Tabs"").load(""/Transients/SaveTransients/"");
    }


    function showPage3() {
        $(""#Tabs"")");
            WriteLiteral(@".load(""/Transients/Results/"");
    }

    function CreateNewTransient() {

        $(""#newTransient"").load(""/Transients/CreateTransient/"");
    }



    function EditTransient(id) {
        $(""#newTransient"").load(""/Transients/EditTransients/"" + id);
    }



    function CancelCreate() {
        $(""#newTransient"").html("""");
    }

    //$(document).ready(function () {
    //    $(""#savedTransient"").DataTable();
    //});

    $(document).ready(function () {
        $('#savedTransient').DataTable({
            dom: 'Bfrtip',
            buttons: [

                'excel',

            ],
            select: true
        });
    });

    $(document).ready(function () {
        $(""#nameSearch"").DataTable();
    });

    $(document).ready(function () {
        $(""#codeSearch"").DataTable();
    });


    //function codeSearch() {
    //    var code = $('#code').val();
    //    if (code != """") {
    //        $.ajax({

    //            type: ""POST"",
    //     ");
            WriteLiteral(@"       url: ""/Transients/Search"",
    //            data: {
    //                ""code"": code,

    //            },
    //            success:
    //                function (response) {
    //                    $(""#result"").html(response);

                       
    //                },
    //            failure: function (response) {
    //                alert(response.responseText);
    //            },
    //            error: function (response) {
    //                alert(response.responseText);
    //            }
    //        });
    //    }
    //}

    function codeSearch() {
        var code = $('#code').val();
        if (code != """") {
            $.ajax({

                type: ""POST"",
                url: ""/Transients/SearchInGroupedOfTransientCode"",
                data: {
                    ""code"": code,

                },
                success:
                    function (response) {
                        $(""#result"").html(response);


   ");
            WriteLiteral(@"                 },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        }
    }


    //function nameSearch() {

    //    var transientName = $('#transientName').val();
    //    if (transientName != """") {
    //        $.ajax({

    //            type: ""POST"",
    //            url: ""/Transients/nameSearch"",
    //            data: {

    //                ""transientName"": transientName
    //            },
    //            success:
    //                function (response) {
    //                    $(""#result"").html(response);
    //                    //selectedRow.after(response);
    //                },
    //            failure: function (response) {
    //                alert(response.responseText);
    //            },
    //            error: function (response) {
");
            WriteLiteral(@"    //                alert(response.responseText);
    //            }
    //        });
    //    }
    //}


    function nameSearch() {

        var transientName = $('#transientName').val();
        if (transientName != """") {
            $.ajax({

                type: ""POST"",
                url: ""/Transients/SearchInGroupedOfTransientName"",
                data: {

                    ""transientName"": transientName
                },
                success:
                    function (response) {
                        $(""#result"").html(response);
                        //selectedRow.after(response);
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

    function cancelSearch() {
        $(""#result"").html("""");

        $(""#transien");
            WriteLiteral(@"tName"").val("""");
        $(""#code"").val("""");
    }

    function Create(parentId) {
        $.get(""/Transients/Create/"" + parentId,
            function (result) {
                $(""#myModal"").modal();
                $(""#myModalLabel"").html("""");
                $(""#myModalBody"").html(result);
            });
    }

    $(""#checkAll"").click(function () {
        $("".checkBox"").prop('checked',
            $(this).prop('checked'));
    });

    $(""#delete"").click(
        
        function () {
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
                url: ""/Transients/DeleteTransients"",
                data: { ""transientsId"": selectedIDs },

                success:");
            WriteLiteral(@" function (response) {
                    //window.location.href = ""/Cables"";
                    $(""#Tabs"").load(""/Transients/SaveTransients/"");
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

    $(function () {
        $(""#code"").change(function () {
            $(""#transientCode"").val($(this).val());
        });
    })

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