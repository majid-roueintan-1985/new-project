#pragma checksum "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a19148004c39b4ef22d0d5822bf27dbc239b2fba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Maintenance_Measurements), @"mvc.1.0.view", @"/Views/Maintenance/Measurements.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a19148004c39b4ef22d0d5822bf27dbc239b2fba", @"/Views/Maintenance/Measurements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Maintenance_Measurements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.Maintenance.Measurements>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Maintenance", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExportMeasurements", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
  
    ViewData["Title"] = "Measurements";
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
            BeginWriteAttribute("style", " style=\"", 720, "\"", 728, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <b><a class=\"breadcumb2-link\" href=\"#\">Mechanical Equipments</a></b>\r\n                    </td>\r\n                    <td");
            BeginWriteAttribute("style", " style=\"", 876, "\"", 884, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        »  Maintenance <b id=""subTitle22a""></b>
                    </td>
                    <td>
                        » <b style=""color: #ff0000;"" id=""subTitle22"">Result of Measurements before & after Maintenance
                        </b>
                    </td>
                </tr>
            </tbody>
        </table>
        <a id=""iHelp"" style=""float: right; position: relative; top: -32px;"" href=""javascript:;"" onclick=""showHelp();"">
            <img src=""/images/help.png"" style=""width: 48px;"" class=""imgHelp"">
        </a>
    </div>

<h1 id=""iH1"">
    Maintenance
</h1>
    <div id=""iContent"">

        <div class=""tab-buttons"">
            <ul>
                <li id=""tab-button1"" class=""tab-buttons-li"" ");
            WriteLiteral(" ");
            WriteLiteral(@">
                    <a id=""tab-button-a1""
                       onclick=""showPage1()"" style=""cursor:pointer;color: rgb(0, 113, 158);"">
                        Maintenance Programs
                    </a>
                </li>
                <li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-buttona2"" onclick=""showPage2()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        List of Defections
                    </a>

                </li>
                <li id=""tab-button3"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-button-a3"" onclick=""showPage3()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Spare Parts List
                    </a>
                </li>
                <li id=""tab-button3"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-button-a3"" onclick=""showPage4()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Maintenance Forms
                  ");
            WriteLiteral(@"  </a>
                </li>
                
                <li id=""tab-button3"" class=""tab-buttons-li"" style=""background-color: rgb(208, 208, 208); border-color: rgb(128, 128, 128); font-weight: bold;"">
                    <a id=""tab-button-a3"" onclick=""showPage5()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Controls & Measurements before & after Maintenance
                    </a>
                </li>
                <li id=""tab-button3"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-button-a3"" onclick=""showPage6()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Defection Reports
                    </a>
                </li>
                
            </ul>

            <div style=""clear:both;""></div>
        </div>

        <div id=""tab1"" class=""tab-item"" style=""display: block;"">

            <h1 id=""iH1"">Result ");
            WriteLiteral(@"of Measurements before & after Maintenance
            </h1>

            <div class=""bevel-box"">
                <table cellpadding=""3"" cellspacing=""0"">
                    <tbody>
                        <tr>
                           
                            <td>
                                <input type=""file"" name=""uploadedFile"" id=""uploadedFile"" style=""direction: ltr; text-align: left;"">
");
            WriteLiteral("                            </td>\r\n\r\n                             <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a19148004c39b4ef22d0d5822bf27dbc239b2fba9097", async() => {
                WriteLiteral("\r\n                                    <input type=\"submit\" value=\"Export Excel\" />\r\n                                ");
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
");
            WriteLiteral(@"            </div>

            <div  id=""newPage"">
                <div>

                    <div id=""iLoading22"" style=""display: none;"">
                        <img src=""/images/loading.gif"">
                    </div>


                    <a class=""btn-new-equip"" style=""cursor:pointer"" onclick=""Create()"">New</a>
                    <input type=""button"" id=""delete"" class=""btn-delete-equip"" value=""Delete"">
                    <br />
");
#nullable restore
#line 152 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
                      
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
                                <th >
                                    <b>Date of measurement</b>
                                </th>
                                <th >
                                    <b>Type of measurement</b>
                                </th>
                                <th >
                                    <b>Result measurement</b>
                                </th>
                                
                                <th >
                                    <b>  Description</b>
                                </th>
                                
                           ");
            WriteLiteral("      \r\n                                <th >\r\n                                    <b>Actions</b>\r\n                                </th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 183 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 8920, "\"", 8947, 1);
#nullable restore
#line 187 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
WriteAttributeValue("", 8928, item.MeasurementId, 8928, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 190 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 193 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
                                   Write(item.Dateofmeasurement.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 196 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
                                   Write(item.Typeofmeasurement);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 199 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
                                   Write(item.Resultmeasurement);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 202 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
                                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 9856, "\"", 9891, 3);
            WriteAttributeValue("", 9866, "Edit(", 9866, 5, true);
#nullable restore
#line 205 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
WriteAttributeValue("", 9871, item.MeasurementId, 9871, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9890, ")", 9890, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 210 "C:\Users\mohsen\source\New folder\Bnpp.Web\Views\Maintenance\Measurements.cshtml"
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
            BeginWriteAttribute("src", " src=\"", 10435, "\"", 10441, 0);
            EndWriteAttribute();
            WriteLiteral(@"></iframe>

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
</script>
<script>

    function Create() {
        $(""#newPage"").load(""/Maintenance/CreateMeasurements/"");
    }

    function Edit(id) {
        $(""#newPage"").load(""/Maintenance/EditMeasurements/"" + id);
    }

    
     function showPage1() {
        $(""#Tabs"").load(""/Maintenance/MaintenancePrograms/"");
    }

    function showPage2() {
        $(""#Tabs"").load(""/Maintenance/Defections/"");
    }

    function showPage3() {
        $(""#Tabs"").load(""/Maintenance/SpareParts/"");
    }
    
    function showPage4() {
        $(""#Tabs"").load(""/Maintenance/MaintenanceForms/"");
    }
    
    function showPage5() {
        $(""#Tabs"").load(""/Mainte");
            WriteLiteral(@"nance/Measurements/"");
    }
    
     function showPage6() {
        $(""#Tabs"").load(""/Maintenance/DefectsReport"");
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
            url: ""/Maintenance/DeleteMeasurements"",
            data: { ""measureId"": selectedIDs },

            success: function (response) {
                $(""#Tabs"").load(""/Maintenance/Measurements/"");
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (r");
            WriteLiteral("esponse) {\r\n                alert(response.responseText);\r\n            }\r\n\r\n        });\r\n        }\r\n\r\n    });\r\n\r\n\r\n</script>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.Maintenance.Measurements>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591