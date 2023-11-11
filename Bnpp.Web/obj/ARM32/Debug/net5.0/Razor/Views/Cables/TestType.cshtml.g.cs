#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b91dc7faa0b30233f2110f1e9811a8f1cce5109"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cables_TestType), @"mvc.1.0.view", @"/Views/Cables/TestType.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b91dc7faa0b30233f2110f1e9811a8f1cce5109", @"/Views/Cables/TestType.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cables_TestType : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable< Bnpp.DataLayer.Entities.TestType>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
  
    ViewData["Title"] = "TestType";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Test Type</h2>

<table cellpadding=""3"" cellspacing=""0"">
    <tbody>
        <tr>
            <td>
                <label style=""margin:10px"">

                    <a class=""btn-defaults-equip"" onclick=""CreateOperatingData()"">
                        Back
                    </a>

                </label>
            </td>
        </tr>
    </tbody>
</table>

<div id=""iContent"">
    <div id=""tab1"" class=""tab-item"" style=""display: block;"">
        <div id=""newPage"">
            <div id=""newAgeingMechanism"">
                <div>


                    <a class=""btn-new-equip"" style=""cursor:pointer"" onclick=""CreateNewTestType()"">New</a>
                    <input type=""button"" id=""delete"" class=""btn-delete-equip"" value=""Delete"">
                    <br />
");
#nullable restore
#line 35 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
                      
                        int rowCount = 1;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table id=""myOwnerTable"" cellpadding=""3"" cellspacing=""0"" class=""show-table"">
                        <thead>
                            <tr role=""row"">
                                <th>
                                    <input type=""checkbox"" id=""checkAll"" />
                                </th>
                                <th></th>
                                <th>
                                    <b>TypeofMaintenance Title</b>
                                </th>

                                <th style=""width: 120px"">
                                    <b>Actions</b>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 55 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 2036, "\"", 2052, 1);
#nullable restore
#line 59 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
WriteAttributeValue("", 2044, item.ID, 2044, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 62 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 65 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
                                   Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2482, "\"", 2514, 3);
            WriteAttributeValue("", 2492, "EditTestType(", 2492, 13, true);
#nullable restore
#line 68 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
WriteAttributeValue("", 2505, item.ID, 2505, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2513, ")", 2513, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 73 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
                                rowCount++;
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </div>
</div>





<script src=""/js/jquery.min.js""></script>

<script src=""/js/datatables.min.js""></script>

<script>

    $(document).ready(function () {
        $(""#myOwnerTable"").DataTable();
    });



    function CreateOperatingData() {
        if (");
#nullable restore
#line 101 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 1) {\r\n            $(\"#newPage\").load(\"/Cables/CreateGeneralCables/\");\r\n        }\r\n        if (");
#nullable restore
#line 104 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 2) {\r\n            $(\"#newPage\").load(\"/Cables/CreateOperatingData/\");\r\n        }\r\n        if (");
#nullable restore
#line 107 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 3) {\r\n            $(\"#newPage\").load(\"/Cables/CreateMaintenanceData/\");\r\n        }\r\n        if (");
#nullable restore
#line 110 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\TestType.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"== 4) {
            $(""#newPage"").load(""/Cables/CreateCablereport/"");
        }
    }

    function CreateNewTestType() {
        $(""#newAgeingMechanism"").load(""/Cables/CreateTestType/"");
    }



    function EditTestType(id) {
        $(""#newAgeingMechanism"").load(""/Cables/EditTestType/"" + id);

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
                url: ""/Cables/DeleteTestType"",
                data: { ""typeId"": selectedIDs },

                success: function (response) {
                  ");
            WriteLiteral(@"  $(""#newData"").load(""/Cables/TestType/"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable< Bnpp.DataLayer.Entities.TestType>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
