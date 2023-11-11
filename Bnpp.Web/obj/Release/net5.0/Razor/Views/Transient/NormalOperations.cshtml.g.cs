#pragma checksum "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d215ca8b3bc19461cc8df1c492ddad9ececab3a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transient_NormalOperations), @"mvc.1.0.view", @"/Views/Transient/NormalOperations.cshtml")]
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
#line 1 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
using Bnpp.DataLayer.Entities.InspectionData;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d215ca8b3bc19461cc8df1c492ddad9ececab3a4", @"/Views/Transient/NormalOperations.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Transient_NormalOperations : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.Core.ViewModels.NormalOperationListViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Transient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExportNormalOperations", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
  
    ViewData["Title"] = "NormalOperations";
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
            BeginWriteAttribute("style", " style=\"", 775, "\"", 783, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <b><a class=\"breadcumb2-link\" href=\"#\">Mechanical Equipments</a></b>\r\n                    </td>\r\n                    <td");
            BeginWriteAttribute("style", " style=\"", 931, "\"", 939, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        » <b id=""subTitle22a"">Transients</b>
                    </td>
                    <td>
                        » <b style=""color: #ff0000;"" id=""subTitle22"">Normal Operations</b>
                    </td>
                </tr>
            </tbody>
        </table>
        <a id=""iHelp"" style=""float: right; position: relative; top: -32px;"" href=""javascript:;"" onclick=""showHelp();"">
            <img src=""/images/help.png"" style=""width: 48px;"" class=""imgHelp"">
        </a>
    </div>

    <h1 id=""iH1"">Operational Data</h1>
    <div id=""iContent"">

        <div class=""tab-buttons"">
            <ul>
                <li id=""tab-button1"" class=""tab-buttons-li""  style=""background-color: rgb(208, 208, 208); border-color: rgb(128, 128, 128); font-weight: bold;"">
                    <a id=""tab-button-a1""
                       onclick=""showPage1()"" style=""cursor:pointer;color: rgb(0, 113, 158);"">
                        Normal Operations
                    </a>
        ");
            WriteLiteral("        </li>\r\n                <li id=\"tab-button2\" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-buttona2"" onclick=""showPage2()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Operational Occurances
                    </a>

                </li>
                <li id=""tab-button3"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-button-a3"" onclick=""showPage3()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Design Basis accidents
                    </a>
                </li>
            </ul>

            <div style=""clear:both;""></div>
        </div>

        <div id=""tab1"" class=""tab-item"" style=""display: block;"">

            <h1 id=""iH1"">Normal Operations</h1>

            <div class=""bevel-box"">
                <table cellpadding=""3"" cellspacing=""0"">
                    <tbody>
    ");
            WriteLiteral("                    <tr>\r\n");
            WriteLiteral("\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d215ca8b3bc19461cc8df1c492ddad9ececab3a47844", async() => {
                WriteLiteral("\r\n                                    <input type=\"submit\" value=\"Export\" />\r\n                                ");
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

            <div  id=""newPage"">
                <div>

                    <div id=""iLoading22"" style=""display: none;"">
                        <img src=""/images/loading.gif"">
                    </div>


                    <a class=""btn-new-equip"" onclick=""Create()"" style=""cursor: pointer"">New</a>
                    <input type=""button"" id=""delete"" class=""btn-delete-equip"" value=""Delete"">
          ");
            WriteLiteral("          <br />\r\n");
#nullable restore
#line 107 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                      
                        int rowCount = 1;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table id=""myTable"" cellpadding=""3"" cellspacing=""0"" class=""show-table"">
                        <thead>
                            <tr role=""row"">
                                <th>
                                    <input type=""checkbox"" id=""checkAll"" />
                                </th>
                                <th></th>
                                <th style=""width: 150px"">
                                    <b>Date</b>
                                </th>
                                <th style=""width: 250px"">
                                    <b>Name of Conditions</b>
                                </th>
                                <th style=""width: 120px"">
                                    <b>Allowable Num.</b>
                                </th>
                                <th style=""width: 120px"">
                                    <b>Occurrances</b>
                                </th>
                                <th s");
            WriteLiteral("tyle=\"width: 120px\">\r\n                                    <b>Actions</b>\r\n                                </th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 135 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 6376, "\"", 6403, 1);
#nullable restore
#line 139 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
WriteAttributeValue("", 6384, item.OperationalId, 6384, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 142 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 145 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                   Write(item.NormalDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 148 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                   Write(item.NameOfCondition);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 151 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                   Write(item.AllowableNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 154 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                   Write(item.Occurrances);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7301, "\"", 7336, 3);
            WriteAttributeValue("", 7311, "Edit(", 7311, 5, true);
#nullable restore
#line 157 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
WriteAttributeValue("", 7316, item.OperationalId, 7316, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7335, ")", 7335, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 162 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                rowCount++;
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n\r\n\r\n                    <br>\r\n                    <div style=\"clear: both;\">\r\n                    </div>\r\n                    <br>\r\n                    <br>\r\n                    <hr />\r\n");
#nullable restore
#line 174 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                      
                        List<InspectionDocument> NormalDocuments = ViewData["NormalDocuments"] as List<InspectionDocument>;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div id=""tab1"" class=""tab-item"" style=""display: block;"">

                        <h1 id=""iH1"">Documents</h1>

                       

                        
                            <div>

                                <div id=""iLoading22"" style=""display: none;"">
                                    <img src=""/images/loading.gif"">
                                </div>


                            <a class=""btn-new-equip"" style=""cursor: pointer"" onclick=""CreateNormalDocument()"">New</a>
                                <input type=""button"" id=""deleteProgram"" class=""btn-delete-equip"" value=""Delete"">
                                <br />
");
#nullable restore
#line 194 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                  
                                    int rowCount1 = 1;
                                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <table id=""myTableDocument"" cellpadding=""3"" cellspacing=""0"" class=""show-table"">
                                    <thead>
                                        <tr role=""row"">
                                            <th>
                                                <input type=""checkbox"" id=""checkAllPrograms"" />
                                            </th>
                                            <th></th>
                                            <th style=""width: 150px"">
                                                <b>Code</b>
                                            </th>
                                            <th style=""width: 250px"">
                                                <b>File Name</b>
                                            </th>

                                            <th style=""width: 120px"">
                                                <b>Doc. Name </b>
                                            <");
            WriteLiteral("/th>\r\n\r\n");
            WriteLiteral(@"
                                            <th style=""width: 120px"">
                                                <b>Actions</b>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 228 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                      foreach (var item in NormalDocuments)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr role=\"row\">\r\n                                                <td>\r\n                                                    <input type=\"checkbox\" class=\"checkBoxProgram\"");
            BeginWriteAttribute("value", " value=\"", 10904, "\"", 10930, 1);
#nullable restore
#line 232 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
WriteAttributeValue("", 10912, item.InspectionId, 10912, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 235 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                               Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 239 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                               Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 242 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                               Write(item.Filename);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                    ");
#nullable restore
#line 245 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                               Write(item.DocumentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td>\r\n                                                <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 11823, "\"", 11871, 3);
            WriteAttributeValue("", 11833, "EditNormalDocument(", 11833, 19, true);
#nullable restore
#line 248 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
WriteAttributeValue("", 11852, item.InspectionId, 11852, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 11870, ")", 11870, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                        Edit\r\n                                                    </a>\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 253 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Transient\NormalOperations.cshtml"
                                            rowCount1++;
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>


                                <br>
                                <div style=""clear: both;"">
                                </div>
                                <br>
                                <br>
                                <iframe style=""display: none"" id=""if_-2_119""");
            BeginWriteAttribute("src", " src=\"", 12584, "\"", 12590, 0);
            EndWriteAttribute();
            WriteLiteral(@"></iframe>

                            </div>
                        
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>

<script src=""/js/jquery.min.js""></script>
<script src=""/js/jquery.unobtrusive-ajax.min.js""></script>


<script src=""/js/datatables.min.js""></script>


<script>
    $(document).ready(function () {
        $(""#myTable"").DataTable();
    });

    $(document).ready(function () {
        $(""#myTableDocument"").DataTable();
    });
</script>
<script>

    function Create() {
        $(""#newPage"").load(""/Transient/CreateNormalOperations/"");
    }

    function Edit(id) {
        $(""#newPage"").load(""/Transient/EditNormalOperations/""+id);
    }

    

    function showPage1() {
        $(""#Tabs"").load(""/Transient/NormalOperations/"");
    }

    function showPage2() {
        $(""#Tabs"").load(""/Transient/OperationalOccurence/"");
        //$(""li"").css({""background-color"": ""yellow"", ""padding"": ""25px"", ""wi");
            WriteLiteral(@"dth"": ""200px""});
        //$(""li"").css({""background-color"": ""yellow"", ""padding"": ""25px"", ""width"": ""200px""});

    }

    function showPage3() {
        $(""#Tabs"").load(""/Transient/DesignBasisAccidents/"");
        //,function() {
        //    $(""li #tab-button3"").css({""background-color"": ""yellow"", ""padding"": ""25px"", ""width"": ""200px""});
        //}
    }

    

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
            url: ""/Transient/DeleteNormalOperations"",
            data: { ""operationalId"": selectedIDs },

           ");
            WriteLiteral(@" success: function (response) {
                $(""#Tabs"").load(""/Transient/NormalOperations/"");
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

    $(""#checkAllPrograms"").click(function () {
        $("".checkBoxProgram"").prop('checked',
            $(this).prop('checked'));
    });

    $(""#deleteProgram"").click(function () {
        var selectedIDs = new Array();

        $('input:checkbox.checkBoxProgram').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });

        var result = confirm(""are you sure you want to delete?"");
        if (result) {
            $.ajax({
                type: ""POST"",
                url: ""/Transient/DeleteNormalOperationsDocuments"",
                data: { ""nor");
            WriteLiteral(@"malDocId"": selectedIDs },

                success: function (response) {
                    $(""#Tabs"").load(""/Transient/NormalOperations/"");
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

    function CreateNormalDocument() {
        $(""#newPage"").load(""/Transient/CreateNormalOperationsDocument/"");
    }

    function EditNormalDocument(id) {
        $(""#newPage"").load(""/Transient/EditNormalOperationsDocument/"" + id);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.Core.ViewModels.NormalOperationListViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
