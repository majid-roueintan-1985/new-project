#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b585c79c75d867019924ebd0c4223e91692e9177"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Import_OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ), @"mvc.1.0.view", @"/Views/Import/OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b585c79c75d867019924ebd0c4223e91692e9177", @"/Views/Import/OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Import_OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.DamageabilityReport>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
  
    ViewData["Title"] = "OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
  
    int rowCount = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<table");
            BeginWriteAttribute("id", " id=\"", 220, "\"", 237, 1);
#nullable restore
#line 12 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
WriteAttributeValue("", 225, ViewBag.AKZ, 225, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" cellpadding=""3"" cellspacing=""0"" aria-describedby=""example_info"" class=""display dataTable"">
    <thead>
        <tr role=""row"">
            <th data-orderable=""false"">
                <input type=""checkbox"" id=""checkAll"" onchange=""selectAll()"" />
            </th>
            <th data-orderable=""false"">

            </th>
");
            WriteLiteral(@"            <th data-orderable=""false"">
                <b>Date</b>
            </th>
            <th data-orderable=""false"">
                <b>Location of the checkpoint</b>
            </th>
            <th data-orderable=""false"">
                <b>Action period of equipment (years)</b>
            </th>
            <th data-orderable=""false"">
                <b>Life time of equipment in design (years)</b>
            </th>
            <th data-orderable=""false"">
                <b>
                    Life time of equipment per RALDS (years)
                </b>
            </th>
            <th data-orderable=""false"">
                <b>
                    Damageability per coiled cycles
                </b>
            </th>
            <th data-orderable=""false"">
                <b>
                    Damageability per uncoiled cycles
                </b>
            </th>
            <th data-orderable=""false"">
                <b>
                    Total damageability");
            WriteLiteral(@" of equipment
                </b>
            </th>
            <th data-orderable=""false"">
                <b>
                    Allowable CUF
                </b>
            </th>
            <th data-orderable=""false"">
                <b>
                    Allowable Remaining Life Time
                </b>
            </th>
            <th data-orderable=""false"">
                <b>
                    Changing Ratio
                </b>
            </th>
            <th data-orderable=""false"">
                <b>
                    Allowable Changing Ratio
                </b>
            </th>
            <th data-orderable=""false"">
                <b>
                    File Date
                </b>
            </th>
            <th data-orderable=""false"">
                <b>

                </b>
            </th>
        </tr>
    </thead>

    <tbody id=""myBody"">

");
#nullable restore
#line 91 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr role=\"row\">\r\n                <td>\r\n                    <input type=\"checkbox\" class=\"checkBox\" onchange=\"selected()\"");
            BeginWriteAttribute("value", " value=\"", 2775, "\"", 2791, 1);
#nullable restore
#line 95 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
WriteAttributeValue("", 2783, item.ID, 2783, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 98 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 104 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.ReportDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 107 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.Locationofthecheckpoint);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 110 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.Actionperiodofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 113 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.Lifetimeofequipmentindesign);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 116 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                 if ((Convert.ToDecimal(item.LifetimeofequipmentperRALDS)) <= (Convert.ToDecimal(item.AllowableLifeTime)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 119 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 121 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 125 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 127 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 130 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.Damageabilitypercoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 133 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.Damageabilityperuncoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 136 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                 if ((Convert.ToDecimal(item.Totaldamageabilityofequipment)) >= (Convert.ToDecimal(item.AllowableCUF)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 139 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 141 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 145 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 147 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 150 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.AllowableCUF);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 154 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.AllowableLifeTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 157 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                 if ((Convert.ToDecimal(item.AllowableChangingRatio)) <= (Convert.ToDecimal(item.ChangingRatio)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 160 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 162 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 166 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 168 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 171 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.AllowableChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 175 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
               Write(item.CreateDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("href", " href=\"", 5418, "\"", 5465, 2);
            WriteAttributeValue("", 5425, "/Import/EditDamageabilityReport/", 5425, 32, true);
#nullable restore
#line 178 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
WriteAttributeValue("", 5457, item.ID, 5457, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        Edit\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 183 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
            rowCount++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n</table>\r\n\r\n<script src=\"/js/jquery.min.js\"></script>\r\n\r\n<script src=\"/js/datatables.min.js\"></script>\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\"#");
#nullable restore
#line 194 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentperRALDSByNumberOfAKZ.cshtml"
       Write(ViewBag.AKZ);

#line default
#line hidden
#nullable disable
            WriteLiteral("\").DataTable(\r\n            {\r\n                //searching: false,\r\n            }\r\n        );\r\n    });\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.DamageabilityReport>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
