#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50bdf3919d25a9eca0d7a102a06f7497d7e4337c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cables_FailedParts), @"mvc.1.0.view", @"/Views/Cables/FailedParts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50bdf3919d25a9eca0d7a102a06f7497d7e4337c", @"/Views/Cables/FailedParts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cables_FailedParts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.FailedParts>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
  
    ViewData["Title"] = "FailedParts";
    Layout =null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Failed Parts</h2>

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


                    <a class=""btn-new-equip"" style=""cursor:pointer"" onclick=""CreateNewFailedParts()"">New</a>
                    <input type=""button"" id=""delete"" class=""btn-delete-equip"" value=""Delete"">
                    <br />
");
#nullable restore
#line 35 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
                      
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
                                    <b>Failed Parts Title</b>
                                </th>

                                <th style=""width: 120px"">
                                    <b>Actions</b>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 55 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 2041, "\"", 2057, 1);
#nullable restore
#line 59 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
WriteAttributeValue("", 2049, item.ID, 2049, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 62 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 65 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
                                   Write(item.FailedPartsTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2498, "\"", 2533, 3);
            WriteAttributeValue("", 2508, "EditFailedParts(", 2508, 16, true);
#nullable restore
#line 68 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
WriteAttributeValue("", 2524, item.ID, 2524, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2532, ")", 2532, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 73 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
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
#line 101 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 1) {\r\n            $(\"#newPage\").load(\"/Cables/CreateGeneralCables/\");\r\n        }\r\n        if (");
#nullable restore
#line 104 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 2) {\r\n            $(\"#newPage\").load(\"/Cables/CreateOperatingData/\");\r\n        }\r\n        if (");
#nullable restore
#line 107 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 3) {\r\n            $(\"#newPage\").load(\"/Cables/CreateMaintenanceData/\");\r\n        }\r\n        if (");
#nullable restore
#line 110 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Cables\FailedParts.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"== 4) {
            $(""#newPage"").load(""/Cables/CreateCablereport/"");
        }
    }

    function CreateNewFailedParts() {
        $(""#newAgeingMechanism"").load(""/Cables/CreateFailedParts/"");
    }



    function EditFailedParts(id) {
        $(""#newAgeingMechanism"").load(""/Cables/EditFailedParts/"" + id);

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
                url: ""/Cables/DeleteFailedParts"",
                data: { ""partsId"": selectedIDs },

                success: function (response) {
  ");
            WriteLiteral(@"                  $(""#newData"").load(""/Cables/FailedParts/"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.FailedParts>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591