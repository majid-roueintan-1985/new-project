#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6517862386500ee7b97ca769c01550dcdbf720af0b0fba88cf7448d1cb8aebc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cables_Owner), @"mvc.1.0.view", @"/Views/Cables/Owner.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"6517862386500ee7b97ca769c01550dcdbf720af0b0fba88cf7448d1cb8aebc8", @"/Views/Cables/Owner.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cables_Owner : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.Owner>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
  
    ViewData["Title"] = "Owner";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Owner</h2>

<table cellpadding=""3"" cellspacing=""0"">
    <tbody>
        <tr>
            <td>
                <label style=""margin:10px"">

                    <a class=""btn-defaults-equip"" onclick=""CreateGeneralData()"">
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


                    <a class=""btn-new-equip"" style=""cursor:pointer""");
            BeginWriteAttribute("onclick", " onclick=\"", 739, "\"", 778, 3);
            WriteAttributeValue("", 749, "CreateNewOwner(", 749, 15, true);
#nullable restore
#line 32 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
WriteAttributeValue("", 764, ViewBag.Code, 764, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 777, ")", 777, 1, true);
            EndWriteAttribute();
            WriteLiteral(">New</a>\r\n                    <input type=\"button\" id=\"delete\" class=\"btn-delete-equip\" value=\"Delete\">\r\n                    <br />\r\n");
#nullable restore
#line 35 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
                      
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
                                    <b>Owner Title</b>
                                </th>

                                <th style=""width: 120px"">
                                    <b>Actions</b>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 55 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 2021, "\"", 2042, 1);
#nullable restore
#line 59 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
WriteAttributeValue("", 2029, item.OwnerId, 2029, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 62 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 65 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
                                   Write(item.OwnerTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2477, "\"", 2511, 3);
            WriteAttributeValue("", 2487, "EditOwner(", 2487, 10, true);
#nullable restore
#line 68 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
WriteAttributeValue("", 2497, item.OwnerId, 2497, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2510, ")", 2510, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 73 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
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



    function CreateGeneralData() {
        if (");
#nullable restore
#line 101 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 1) {\r\n            $(\"#newPage\").load(\"/Cables/CreateGeneralCables/\");\r\n        }\r\n        if (");
#nullable restore
#line 104 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 2) {\r\n            $(\"#newPage\").load(\"/Cables/CreateOperatingData/\");\r\n        }\r\n        if (");
#nullable restore
#line 107 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 3) {\r\n            $(\"#newPage\").load(\"/Cables/CreateMaintenanceData/\");\r\n        }\r\n        if (");
#nullable restore
#line 110 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("== 4) {\r\n            $(\"#newPage\").load(\"/Cables/CreateCablereport/\");\r\n        }\r\n\r\n    }\r\n\r\n    //function CreateNewOwner(code) {\r\n    //    //alert(code);\r\n    //    $(\"#newAgeingMechanism\").load(\"/Cables/CreateOwner/\" + \"?code=\" + ");
#nullable restore
#line 118 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
                                                                       Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral(@");
    //}

    function CreateNewOwner() {
        $(""#newAgeingMechanism"").load(""/Cables/CreateOwner/"");
    }

    function EditOwner(id) {
        $(""#newAgeingMechanism"").load(""/Cables/EditOwner/"" + id);
    }

    //function EditOwner(id) {
    //    $(""#newAgeingMechanism"").load(""/Cables/EditOwner/"" + id + ""?code="" + ");
#nullable restore
#line 130 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\Owner.cshtml"
                                                                          Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral(@");
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
                url: ""/Cables/DeleteOwner"",
                data: { ""ownerId"": selectedIDs },

                success: function (response) {
                    $(""#newData"").load(""/Cables/Owner/"");
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }

           ");
            WriteLiteral(" });\r\n        }\r\n    });\r\n</script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.Owner>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591