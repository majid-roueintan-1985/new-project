#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "67ca16e113c599eeb245768be8ae5102362c3a700e9e95a6248bd0214f69bd0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cables_TypeofCable), @"mvc.1.0.view", @"/Views/Cables/TypeofCable.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"67ca16e113c599eeb245768be8ae5102362c3a700e9e95a6248bd0214f69bd0c", @"/Views/Cables/TypeofCable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cables_TypeofCable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.TypeofCable>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml"
  
    ViewData["Title"] = "TypeofCable";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Type of Cable</h2>

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


                    <a class=""btn-new-equip"" style=""cursor:pointer"" onclick=""CreateNewTypeofCable()"">New</a>
                    <input type=""button"" id=""delete"" class=""btn-delete-equip"" value=""Delete"">
                    <br />
");
#nullable restore
#line 35 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml"
                      
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
                                    <b>Type of CableTitle</b>
                                </th>

                                <th style=""width: 120px"">
                                    <b>Actions</b>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 55 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr role=\"row\">\r\n                                    <td>\r\n                                        <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 2037, "\"", 2053, 1);
#nullable restore
#line 59 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml"
WriteAttributeValue("", 2045, item.ID, 2045, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 62 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml"
                                   Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 65 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml"
                                   Write(item.TypeofCableTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2494, "\"", 2522, 3);
            WriteAttributeValue("", 2504, "EditType(", 2504, 9, true);
#nullable restore
#line 68 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml"
WriteAttributeValue("", 2513, item.ID, 2513, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2521, ")", 2521, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Edit\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 73 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Cables\TypeofCable.cshtml"
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
        $(""#newPage"").load(""/Cables/CreateGeneralCables/"");
    }

    function CreateNewTypeofCable() {
        $(""#newAgeingMechanism"").load(""/Cables/CreateTypeofCable/"");
    }



    function EditType(id) {
        $(""#newAgeingMechanism"").load(""/Cables/EditTypeofCable/"" + id);

    }

    $(""#checkAll"").click(function () {
        $("".checkBox"").prop('checked',
            $(this).prop('checked'));
    });

    $(""#delete"").click(function () {
        var selectedIDs = new Array();

        $('input:checkbox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selec");
            WriteLiteral(@"tedIDs.push($(this).val());
            }
        });


        var result = confirm(""are you sure you want to delete?"");
        if (result) {
            $.ajax({
                type: ""POST"",
                url: ""/Cables/DeleteTypeofCable"",
                data: { ""typeId"": selectedIDs },

                success: function (response) {
                    $(""#newData"").load(""/Cables/TypeofCable/"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.TypeofCable>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
