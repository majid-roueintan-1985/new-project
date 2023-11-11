#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "047e909842c3e59e85eea33a6229db96d8aae1b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Import_Search), @"mvc.1.0.view", @"/Views/Import/Search.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"047e909842c3e59e85eea33a6229db96d8aae1b2", @"/Views/Import/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Import_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.DamageabilityReport>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
  
    ViewData["Title"] = "Search";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
  
    int rowCount = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<table id=""myTable"" cellpadding=""3"" cellspacing=""0"" aria-describedby=""example_info"" class=""display dataTable"">
    <thead>
        <tr role=""row"">
            <th data-orderable=""false"">
                <input type=""checkbox"" id=""checkAll"" onchange=""selectAll()"" />
            </th>
            <th data-orderable=""false"">

            </th>
            <th>
                <b>AKZ</b>
            </th>
            <th data-orderable=""false"">
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
            <");
            WriteLiteral(@"/th>
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
                    Total damageability of equipment
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
        ");
            WriteLiteral(@"        </b>
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
#line 91 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr role=\"row\">\r\n                <td>\r\n                    <input type=\"checkbox\" class=\"checkBox\" onchange=\"selected()\"");
            BeginWriteAttribute("value", " value=\"", 2718, "\"", 2734, 1);
#nullable restore
#line 95 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
WriteAttributeValue("", 2726, item.ID, 2726, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 98 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 101 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.Akz);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 104 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.ReportDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 107 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.Locationofthecheckpoint);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 110 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.Actionperiodofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 113 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.Lifetimeofequipmentindesign);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 116 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                 if ((Convert.ToDecimal(item.LifetimeofequipmentperRALDS)) <= (Convert.ToDecimal(item.AllowableLifeTime)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 119 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 121 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 125 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 127 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 130 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.Damageabilitypercoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 133 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.Damageabilityperuncoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 136 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                 if ((Convert.ToDecimal(item.Totaldamageabilityofequipment)) >= (Convert.ToDecimal(item.AllowableCUF)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 139 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 141 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 145 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 147 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 150 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.AllowableCUF);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 154 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.AllowableLifeTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 157 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                 if ((Convert.ToDecimal(item.AllowableChangingRatio)) <= (Convert.ToDecimal(item.ChangingRatio)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 160 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 162 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 166 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 168 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 171 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.AllowableChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 175 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
               Write(item.CreateDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("href", " href=\"", 5368, "\"", 5415, 2);
            WriteAttributeValue("", 5375, "/Import/EditDamageabilityReport/", 5375, 32, true);
#nullable restore
#line 178 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
WriteAttributeValue("", 5407, item.ID, 5407, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        Edit\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 183 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\Search.cshtml"
            rowCount++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>

</table>

<script>
    $(document).ready(function () {
        $('tbody tr[role=""row""]').hide();
    });

    $(document).ready(function () {
        var groupColumn = 2;
        var table = $('#myTable').DataTable({


            columnDefs: [{ visible: false, targets: groupColumn }],
            order: [[groupColumn, 'asc']],


            // hide ""Showing 1 of N Entries"" with the dataTables.js library
            ""info"": false,



            //colReorder: {
            //    order: [ 5,6]
            //},

            //""ordering"": true,
            //columnDefs: [{
            //    orderable: false,
            //    targets: ""no-sort""
            //}],
            //displayLength: 1000,
            paging: false,

            //lengthMenu: [
            //    [-1, 10, 25, 50,75],
            //    ['All', 10, 25, 50,75],
            //],


            drawCallback: function (settings) {


                var api = this.api();
                va");
            WriteLiteral(@"r rows = api.rows({ page: 'current' }).nodes();



                var last = null;

                api
                    .column(groupColumn, { page: 'current' })
                    .data()
                    .each(function (group, i) {


                        if (last !== group) {
                            $(rows)
                                .eq(i)
                                .before('<tr class=""group"" id=""' + i + '"" style=""background-color: rgba(0, 0, 0, 0.15);""><td class=""dt-control""></td><td colspan=""16"">' + group + '</td></tr>');

                            last = group;

                        }
                    });
            },
        });


        //Add parameter to class  class=""group'+i+'""
        // Order by the grouping
        $('#myTable tbody').on('click', 'tr.group', function () {





            $($(this)).nextUntil("".group"").filter('tr[role=""row""]').toggle();


        });


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.DamageabilityReport>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
