#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "39bb679085e75abca4d2db81411a128d10fcb951d6f4b9d1546dd5d91c0be80e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Import_OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ), @"mvc.1.0.view", @"/Views/Import/OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"39bb679085e75abca4d2db81411a128d10fcb951d6f4b9d1546dd5d91c0be80e", @"/Views/Import/OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Import_OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.DamageabilityReport>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
  
	ViewData["Title"] = "OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ";
	Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
  
	int rowCount = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<table");
            BeginWriteAttribute("id", " id=\"", 211, "\"", 228, 1);
#nullable restore
#line 12 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
WriteAttributeValue("", 216, ViewBag.AKZ, 216, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" cellpadding=\"3\" cellspacing=\"0\" aria-describedby=\"example_info\" class=\"display dataTable\">\r\n\t<thead>\r\n\t\t<tr role=\"row\">\r\n\t\t\t<th data-orderable=\"false\">\r\n\t\t\t\t<input type=\"checkbox\"");
            BeginWriteAttribute("id", " id=\"", 409, "\"", 435, 2);
            WriteAttributeValue("", 414, "checkAll_", 414, 9, true);
#nullable restore
#line 16 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
WriteAttributeValue("", 423, ViewBag.AKZ, 423, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t</th>\r\n\t\t\t<th data-orderable=\"false\">\r\n\r\n\t\t\t</th>\r\n");
            WriteLiteral(@"			<th data-orderable=""false"">
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
");
            WriteLiteral("\t\t\t\t<b>\r\n\t\t\t\t\tAllowable Changing Ratio\r\n\t\t\t\t</b>\r\n\t\t\t</th>\r\n\t\t\t<th data-orderable=\"false\">\r\n\t\t\t\t<b>\r\n\t\t\t\t\tFile Date\r\n\t\t\t\t</b>\r\n\t\t\t</th>\r\n\t\t\t<th data-orderable=\"false\">\r\n\t\t\t\t<b>\r\n\r\n\t\t\t\t</b>\r\n\t\t\t</th>\r\n\t\t</tr>\r\n\t</thead>\r\n\r\n\t<tbody id=\"myBody\">\r\n\r\n");
#nullable restore
#line 91 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
         foreach (var item in Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr role=\"row\">\r\n\t\t\t\t<td>\r\n\t\t\t\t\t<input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("name", " name=\"", 1915, "\"", 1939, 2);
            WriteAttributeValue("", 1922, "item_", 1922, 5, true);
#nullable restore
#line 95 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
WriteAttributeValue("", 1927, ViewBag.AKZ, 1927, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1940, "\"", 1956, 1);
#nullable restore
#line 95 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
WriteAttributeValue("", 1948, item.ID, 1948, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 98 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n");
            WriteLiteral("\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 104 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.ReportDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 107 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.Locationofthecheckpoint);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 110 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.Actionperiodofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 113 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.Lifetimeofequipmentindesign);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\r\n");
#nullable restore
#line 116 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                 if ((Convert.ToDecimal(item.LifetimeofequipmentperRALDS)) <= (Convert.ToDecimal(item.AllowableLifeTime)))
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<td style=\"background-color:red;\">\r\n\t\t\t\t\t\t");
#nullable restore
#line 119 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n");
#nullable restore
#line 121 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
				}
				else
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 125 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n");
#nullable restore
#line 127 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 130 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.Damageabilitypercoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 133 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.Damageabilityperuncoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\r\n");
#nullable restore
#line 136 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                 if ((Convert.ToDecimal(item.Totaldamageabilityofequipment)) >= (Convert.ToDecimal(item.AllowableCUF)))
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<td style=\"background-color:red;\">\r\n\t\t\t\t\t\t");
#nullable restore
#line 139 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n");
#nullable restore
#line 141 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
				}
				else
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 145 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n");
#nullable restore
#line 147 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 150 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.AllowableCUF);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 154 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.AllowableLifeTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\r\n");
#nullable restore
#line 157 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                 if ((Convert.ToDecimal(item.AllowableChangingRatio)) <= (Convert.ToDecimal(item.ChangingRatio)))
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<td style=\"background-color:red;\">\r\n\t\t\t\t\t\t");
#nullable restore
#line 160 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n");
#nullable restore
#line 162 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
				}
				else
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 166 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n");
#nullable restore
#line 168 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 171 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.AllowableChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 175 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
               Write(item.CreateDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t<a class=\"btn-edit-equip\"");
            BeginWriteAttribute("href", " href=\"", 3581, "\"", 3628, 2);
            WriteAttributeValue("", 3588, "/Import/EditDamageabilityReport/", 3588, 32, true);
#nullable restore
#line 178 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
WriteAttributeValue("", 3620, item.ID, 3620, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t\t\tEdit\r\n\t\t\t\t\t</a>\r\n\t\t\t\t</td>\r\n\t\t\t</tr>\r\n");
#nullable restore
#line 183 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
			rowCount++;
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n\r\n</table>\r\n\r\n<script src=\"/js/jquery.min.js\"></script>\r\n\r\n<script src=\"/js/datatables.min.js\"></script>\r\n<script>\r\n\t$(document).ready(function () {\r\n\t\t$(\"#");
#nullable restore
#line 194 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
       Write(ViewBag.AKZ);

#line default
#line hidden
#nullable disable
            WriteLiteral("\").DataTable(\r\n\t\t\t{\r\n\t\t\t\t//searching: false,\r\n\t\t\t}\r\n\t\t);\r\n\t});\r\n\r\n\t$(\"#checkAll_");
#nullable restore
#line 201 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
            Write(ViewBag.AKZ);

#line default
#line hidden
#nullable disable
            WriteLiteral("\").click(function () {\r\n\r\n\r\n\t\t$(\"input[name=\'item_");
#nullable restore
#line 204 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\OrderByDescendingLifetimeofequipmentindesignByNumberOfAKZ.cshtml"
                       Write(ViewBag.AKZ);

#line default
#line hidden
#nullable disable
            WriteLiteral("\']\").prop(\'checked\',\r\n\t\t\t$(this).prop(\'checked\'));\r\n\t});\r\n</script>\r\n\r\n");
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
