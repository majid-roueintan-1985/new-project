#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "986865ef5868538110e605e39d294f64d08fc183d5be376b08af83157297bca6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cables_CableID), @"mvc.1.0.view", @"/Views/Cables/CableID.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"986865ef5868538110e605e39d294f64d08fc183d5be376b08af83157297bca6", @"/Views/Cables/CableID.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cables_CableID : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.CableIdentity>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
  
    ViewData["Title"] = "CableID";
    Layout =null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>CableID</h2>

<table cellpadding=""3"" cellspacing=""0"">
    <tbody>
        <tr>
            <td>
                <label style=""margin:10px"">

                    <a class=""btn-defaults-equip"" onclick=""CreatingOwner()"">
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


                    <a class=""btn-new-equip"" style=""cursor:pointer"" onclick=""CreateNewCableID()"">New</a>
                    <input type=""button"" id=""delete"" class=""btn-delete-equip"" value=""Delete"">
                    <br />
");
#nullable restore
#line 35 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
                      
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
                                    <b>CableID Title</b>
                                </th>

                                <th style=""width: 120px"">
                                    <b>Actions</b>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 55 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 2019, "\"", 2040, 1);
#nullable restore
#line 59 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
WriteAttributeValue("", 2027, item.CableId, 2027, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 62 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 65 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
                                   Write(item.CableTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2475, "\"", 2511, 3);
            WriteAttributeValue("", 2485, "EditCableID(", 2485, 12, true);
#nullable restore
#line 68 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
WriteAttributeValue("", 2497, item.CableId, 2497, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2510, ")", 2510, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 73 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
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



    function CreatingOwner() {
        if (");
#nullable restore
#line 101 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 1) {\r\n            $(\"#newPage\").load(\"/Cables/CreateGeneralCables/\");\r\n        }\r\n        if (");
#nullable restore
#line 104 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 2) {\r\n            $(\"#newPage\").load(\"/Cables/CreateOperatingData/\");\r\n        }\r\n        if (");
#nullable restore
#line 107 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 3) {\r\n            $(\"#newPage\").load(\"/Cables/CreateMaintenanceData/\");\r\n        }\r\n        if (");
#nullable restore
#line 110 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\CableID.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"== 4) {
            $(""#newPage"").load(""/Cables/CreateCablereport/"");
        }
    }

    function CreateNewCableID() {
        $(""#newAgeingMechanism"").load(""/Cables/CreateCableID/"");
    }



    function EditCableID(id) {
        $(""#newAgeingMechanism"").load(""/Cables/EditCableID/"" + id);

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
                url: ""/Cables/DeleteCableID"",
                data: { ""cableId"": selectedIDs },

                success: function (response) {
                    $(");
            WriteLiteral(@"""#newData"").load(""/Cables/CableID/"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.CableIdentity>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591