#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8ffd660cc69ffa5268d356c57064e02fc6e2cf318c6716064f9a364f6f3443f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Operational_WaterSensorDocument), @"mvc.1.0.view", @"/Views/Operational/WaterSensorDocument.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"8ffd660cc69ffa5268d356c57064e02fc6e2cf318c6716064f9a364f6f3443f4", @"/Views/Operational/WaterSensorDocument.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Operational_WaterSensorDocument : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.InspectionData.InspectionDocument>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
  
    ViewData["Title"] = "WaterSensorDocument";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""tab1"" class=""tab-item"" style=""display: block;"">

    <h1 id=""iH1"">
        Operational Data - Chemical Water - Sensor Positions
    </h1>

    <div>

        <div id=""iLoading22"" style=""display: none;"">
            <img src=""/images/loading.gif"">
        </div>


        <a class=""btn-new-equip"" style=""cursor: pointer"" onclick=""CreatewaterSensorDocuments()"">New</a>
        <input type=""button"" id=""deleteProgram"" class=""btn-delete-equip"" value=""Delete"">
        <input type=""button"" onclick=""showPage2()"" value=""Back"" id=""Button2"" class=""butn-cancel"" style=""direction: ltr; text-align: left;"">
        <br />
");
#nullable restore
#line 24 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
          
            int rowCount = 1;
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table id=""myTableDocument"" cellpadding=""3"" cellspacing=""0"" class=""show-table"">
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
                        <b> Name </b>
                    </th>

");
            WriteLiteral("\r\n                    <th style=\"width: 120px\">\r\n                        <b>Actions</b>\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 58 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr role=\"row\">\r\n                        <td>\r\n                            <input type=\"checkbox\" class=\"checkBoxProgram\"");
            BeginWriteAttribute("value", " value=\"", 2117, "\"", 2143, 1);
#nullable restore
#line 62 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
WriteAttributeValue("", 2125, item.InspectionId, 2125, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 65 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
                       Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 69 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
                       Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 72 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
                       Write(item.Filename);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 75 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
                       Write(item.DocumentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2680, "\"", 2734, 3);
            WriteAttributeValue("", 2690, "EditWaterSensorDocuments(", 2690, 25, true);
#nullable restore
#line 78 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
WriteAttributeValue("", 2715, item.InspectionId, 2715, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2733, ")", 2733, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                Edit\r\n                            </a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 83 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Operational\WaterSensorDocument.cshtml"
                    rowCount++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n\r\n        <br>\r\n        <div style=\"clear: both;\">\r\n        </div>\r\n        <br>\r\n        <br>\r\n        <iframe style=\"display: none\" id=\"if_-2_119\"");
            BeginWriteAttribute("src", " src=\"", 3110, "\"", 3116, 0);
            EndWriteAttribute();
            WriteLiteral(@"></iframe>

    </div>

</div>

<script src=""/js/jquery.min.js""></script>
<script src=""/js/jquery.unobtrusive-ajax.min.js""></script>


<script src=""/js/datatables.min.js""></script>


<script>
    $(document).ready(function () {
        $(""#myTableDocument"").DataTable();
    });
</script>
<script>
    function CreatewaterSensorDocuments() {
        $(""#newPage"").load(""/Operational/CreateWaterSensorDocument/"");
    }

    function EditWaterSensorDocuments(id) {
        $(""#newPage"").load(""/Operational/EditWaterSensorDocument/"" + id);
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

        var result = confirm(""ar");
            WriteLiteral(@"e you sure you want to delete?"");
        if (result) {
            $.ajax({
                type: ""POST"",
                url: ""/Operational/DeleteWaterSensorDocument"",
                data: { ""watersensorId"": selectedIDs },

                success: function (response) {
                    $(""#newPage"").load(""/Operational/WaterSensorDocument/"");
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
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.InspectionData.InspectionDocument>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
