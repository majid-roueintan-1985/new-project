#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cec2f4979830be06e61e5e020f717faa1789234"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AgeingAssessment_TransientsReport), @"mvc.1.0.view", @"/Views/AgeingAssessment/TransientsReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cec2f4979830be06e61e5e020f717faa1789234", @"/Views/AgeingAssessment/TransientsReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_AgeingAssessment_TransientsReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.ViewModels.TransientsListViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
  
    ViewData["Title"] = "TransientsReport";
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
            BeginWriteAttribute("style", " style=\"", 726, "\"", 734, 0);
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

");
            WriteLiteral(@"    <div id=""iContent"">

        <div class=""tab-buttons"">
            <ul>
                <li id=""tab-button1"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-button-a1""
                       onclick=""showPage1()"" style=""cursor:pointer;color: rgb(0, 113, 158);"">
                        SACOR Report
                    </a>
                </li>
                <li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(208, 208, 208); border-color: rgb(128, 128, 128); font-weight: bold;"">
                    <a id=""tab-buttona2"" onclick=""showPage2()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Transients Report
                    </a>

                </li>
                <li id=""tab-button3"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                    <a id=""tab-button-a3"" onclick=""showPage3()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                        Deviation of water chemistry parameters Report
                    </a>
                </li>

            </ul>

            <div style=""clear:both;""></div>
        </div>
        <div id=""submenu"">
            <div id=""tab1"" class=""tab-item"" style=""display: block;"">

");
            WriteLiteral("\r\n\r\n                <div class=\"tab-buttons\">\r\n                    <ul>\r\n                        <li id=\"tab-button1\" class=\"tab-buttons-li\" ");
            WriteLiteral(@" style=""background-color: rgb(208, 208, 208); border-color: rgb(128, 128, 128); font-weight: bold;"">
                            <a id=""tab-button-a1""
                               onclick=""showsubPage1()"" style=""cursor:pointer;color: rgb(0, 113, 158);"">
                                All Transients
                            </a>
                        </li>
                        <li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
                            <a id=""tab-buttona2"" onclick=""showsubPage2()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
                                Transients in a Period
                            </a>
                        </li>
                    </ul>

                    <div style=""clear:both;""></div>
                </div>




                <div id=""newPage"">
");
            WriteLiteral("                    <div>\r\n");
            WriteLiteral("                        <div id=\"iLoading22\" style=\"display: none;\">\r\n                            <img src=\"/images/loading.gif\">\r\n                        </div>\r\n\r\n                        <h1>All Transients</h1>\r\n\r\n");
            WriteLiteral("                        <br />\r\n");
#nullable restore
#line 139 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                          
                            int rowCount = 1;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <table id=\"myTransientsReportTable\" cellpadding=\"3\" cellspacing=\"0\" class=\"show-table\">\r\n                            <thead>\r\n                                <tr role=\"row\">\r\n\r\n");
            WriteLiteral(@"                                    <th>
                                        <b>Transient Code </b>
                                    </th>
                                    <th>
                                        <b>Transient Name</b>
                                    </th>
                                    <th>
                                        <b>Allowable No. of Transients</b>
                                    </th>
                                    <th>
                                        <b>Actual No. of Transients</b>
                                    </th>
                                    <th>
                                        <b>Remaining No. of Transients</b>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 167 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr role=\"row\">\r\n\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 172 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                                       Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 175 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 178 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                                       Write(item.Values);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 181 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                                       Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n\r\n\r\n                                        <td>\r\n");
#nullable restore
#line 186 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                                              
                                                int res = Convert.ToInt32(item.Values) - item.Count;
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
#nullable restore
#line 189 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                                       Write(res);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 193 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\AgeingAssessment\TransientsReport.cshtml"
                                    rowCount++;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>

                    </div>
                </div>

            </div>
        </div>
    </div>
</div>




<link href=""/css/datatables.min.css"" rel=""stylesheet"" />
<link href=""/css/buttons.dataTables.min.css"" rel=""stylesheet"" />



<script src=""/js/jquery.min.js""></script>
<script src=""/js/datatables.min.js""></script>
<script src=""/js/dataTables.buttons.min.js""></script>
<script src=""/js/jszip.min.js""></script>
<script src=""/js/pdfmake.min.js""></script>
<script src=""/js/vfs_fonts.js""></script>
<script src=""/js/buttons.html5.min.js""></script>
<script src=""/js/buttons.print.min.js""></script>



<script src=""/js/jquery.unobtrusive-ajax.min.js""></script>


<script>
   

    $(document).ready(function () {
        $('#myTransientsReportTable').DataTable({
            dom: 'Bfrtip',
            buttons: [
                 'excel'
            ]
        });
    });

    
</script>
<script>

    func");
            WriteLiteral(@"tion Create() {
        $(""#newPage"").load(""/Inspection/CreateTypicalPrograms/"");
    }

    function Edit(id) {
        $(""#newPage"").load(""/Inspection/EditTypicalPrograms/"" + id);
    }



    function showPage1() {
        $(""#Tabs"").load(""/AgeingAssessment/SACORReport/"");
    }

    function showPage2() {
        $(""#Tabs"").load(""/AgeingAssessment/TransientsReport/"");
    }

    function showPage3() {
        $(""#Tabs"").load(""/AgeingAssessment/WaterChemistryReport/"");
    }


    function showsubPage1() {
        //$(""#newPage"").load(""/Inspection/WorkingPrograms/"");
        $(""#Tabs"").load(""/AgeingAssessment/TransientsReport/"");
    }

    function showsubPage2() {
        $(""#submenu"").load(""/AgeingAssessment/TransientsPeriod/"");
    }


    $(""#checkAll"").click(function () {
        $("".checkBox"").prop('checked',
            $(this).prop('checked'));
    });

    $(""#delete"").click(function () {
        var selectedIDs = new Array();

        $('input:checkbox.ch");
            WriteLiteral(@"eckBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });


        var result = confirm(""are you sure you want to delete?"");
        if (result) {
            $.ajax({
                type: ""POST"",
                url: ""/Inspection/DeletTypicalPrograms"",
                data: { ""typicalsId"": selectedIDs },

                success: function (response) {
                    $(""#Tabs"").load(""/Inspection/InspectionPrograms/"");
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

    function CreateTypicalyDocument() {
        $(""#newPage"").load(""/Inspection/CreateTypicalDocument/"");
    }

    function EditTypicalyDocument(id) {
        $(""#newPage"").load(""/Inspec");
            WriteLiteral(@"tion/EditTypicalDocument/"" + id);
    }

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
                url: ""/Inspection/DeletTypicalDocument"",
                data: { ""typicalsId"": selectedIDs },

                success: function (response) {
                    $(""#Tabs"").load(""/Inspection/InspectionPrograms/"");
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) ");
            WriteLiteral("{\r\n                    alert(response.responseText);\r\n                }\r\n\r\n            });\r\n        }\r\n\r\n    });\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.ViewModels.TransientsListViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
