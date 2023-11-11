#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1e71556c0a1ccc36e3a1bbbb1a4c80b9182c50fbc4c54741c3353e7d679c3384"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inspection_VisualForm), @"mvc.1.0.view", @"/Views/Inspection/VisualForm.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"1e71556c0a1ccc36e3a1bbbb1a4c80b9182c50fbc4c54741c3353e7d679c3384", @"/Views/Inspection/VisualForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Inspection_VisualForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.InspectionData.InspectionDocument>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Inspection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExportVisualForm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ImportVisualForm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
  
	ViewData["Title"] = "VisualForm";
	Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""tab1"" class=""tab-item"" style=""display: block;"">
	<h1 id=""iH1"">Inspection Results</h1>

	<div class=""tab-buttons"">
		<ul>
			<li id=""tab-button1"" class=""tab-buttons-li"" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"" ");
            WriteLiteral(">\r\n\t\t\t\t<a id=\"tab-button-a1\"\r\n\t\t\t\t   onclick=\"showsubPage1()\" style=\"cursor:pointer;color: rgb(0, 113, 158);\">\r\n\t\t\t\t\tVisual Control\r\n\t\t\t\t</a>\r\n\t\t\t</li>\r\n\t\t\t<li id=\"tab-button2\" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage2()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Leakage Test of Weld
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage3()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Liquid Penetrated Test
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage4()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Magnetic Powder test
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage5()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Radiographics Test
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage6()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Ultrasonic Tests
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage7()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Metal thickness ultrasonic measurement
				</a>
			</li>

			<li id=""tab-button1"" class=""tab-buttons-li"" style=""background-color: rgb(208, 208, 208); border-color: rgb(128, 128, 128); font-weight: bold;"">
				<a id=""tab-button-a1""
				   onclick=""showsubPage8()"" style=""cursor:pointer;color: rgb(0, 113, 158);"">
					Visual Inspection Form
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage9()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Leakage Test Form
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage10()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Liquid Penetration Test Form
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage11()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Magnetic Powder Test Form
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage12()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Radiographics Test Form
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(@" style=""background-color: rgb(240, 240, 240); border-color: rgb(192, 192, 192); font-weight: normal;"">
				<a id=""tab-buttona2"" onclick=""showsubPage13()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Ultrasonic Test Form
				</a>
			</li>
			<li id=""tab-button2"" ");
            WriteLiteral(" ");
            WriteLiteral(@">
				<a id=""tab-buttona2"" onclick=""showsubPage14()"" style=""cursor:pointer;color: rgb(110, 110, 255);"">
					Metal thickness ultrasonic Test Form
				</a>
			</li>
		</ul>

		<div style=""clear:both;""></div>
	</div>
	<div>
		<div id=""newPage"">
			<div class=""bevel-box"">
				<table cellpadding=""3"" cellspacing=""0"">
					<tbody>
						<tr>
							<td>
								");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e71556c0a1ccc36e3a1bbbb1a4c80b9182c50fbc4c54741c3353e7d679c33849796", async() => {
                WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t<input type=\"number\"");
                BeginWriteAttribute("value", " value=\"", 5024, "\"", 5053, 1);
#nullable restore
#line 97 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
WriteAttributeValue("", 5032, ViewBag.MechanicalId, 5032, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"mechanicalId\" style=\"display:none\" />\r\n\t\t\t\t\t\t\t\t\t<input type=\"text\" id=\"exportSelectedData\" name=\"reportId\" style=\"display:none\" />\r\n\t\t\t\t\t\t\t\t\t<input type=\"submit\" onclick=\"refreshPage()\" value=\"Export Excel\" />\r\n\t\t\t\t\t\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                                                                                WriteLiteral(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e71556c0a1ccc36e3a1bbbb1a4c80b9182c50fbc4c54741c3353e7d679c338413486", async() => {
                WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t<input type=\"number\"");
                BeginWriteAttribute("value", " value=\"", 5500, "\"", 5529, 1);
#nullable restore
#line 104 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
WriteAttributeValue("", 5508, ViewBag.MechanicalId, 5508, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"mechanicalId\" style=\"display:none\" />\r\n\t\t\t\t\t\t\t\t\t<input type=\"file\" name=\"FormFile\" />\r\n\t\t\t\t\t\t\t\t\t<input type=\"submit\" onclick=\"refreshPage()\" value=\"Import Excel\" />\r\n\t\t\t\t\t\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 103 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                                                                                WriteLiteral(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
							</td>
						</tr>
					</tbody>
				</table>
			</div>

			<div id=""iLoading22"" style=""display: none;"">
				<img src=""/images/loading.gif"">
			</div>

			<h1>Visual Inspection Form</h1>

			<a class=""btn-new-equip"" style=""cursor:pointer""");
            BeginWriteAttribute("onclick", " onclick=\"", 5976, "\"", 6015, 3);
            WriteAttributeValue("", 5986, "Create(", 5986, 7, true);
#nullable restore
#line 120 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
WriteAttributeValue("", 5993, ViewBag.MechanicalId, 5993, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6014, ")", 6014, 1, true);
            EndWriteAttribute();
            WriteLiteral(">New</a>\r\n\t\t\t<input type=\"button\" id=\"delete\" class=\"btn-delete-equip\" value=\"Delete\">\r\n\t\t\t<br />\r\n");
#nullable restore
#line 123 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
              
				int rowCount = 1;
			

#line default
#line hidden
#nullable disable
            WriteLiteral(@"			<table id=""myTable"" cellpadding=""3"" cellspacing=""0"" class=""show-table"">
				<thead>
					<tr role=""row"">
						<th>
							<input type=""checkbox"" id=""checkAll"" />
						</th>
						<th></th>
						<th style=""width: 150px"">
							<b>Form No</b>
						</th>
						<th style=""width: 250px"">
							<b>	Form Name</b>
						</th>
						<th style=""width: 250px"">
							<b>File Name</b>
						</th>
						<th style=""width: 120px"">
							<b>Date</b>
						</th>
						<th style=""width: 120px"">
							<b>		Remarks</b>
						</th>


						<th style=""width: 120px"">
							<b>Actions</b>
						</th>
					</tr>
				</thead>
				<tbody>
");
#nullable restore
#line 156 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                     foreach (var item in Model)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<tr role=\"row\">\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t<input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 6939, "\"", 6965, 1);
#nullable restore
#line 160 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
WriteAttributeValue("", 6947, item.InspectionId, 6947, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 163 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                           Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t</td>\r\n\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 167 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                           Write(item.FormName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 170 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                           Write(item.FormNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 173 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                           Write(item.Filename);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 176 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                           Write(item.InspectionDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 179 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t<a class=\"btn-edit-equip\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7364, "\"", 7398, 3);
            WriteAttributeValue("", 7374, "Edit(", 7374, 5, true);
#nullable restore
#line 182 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
WriteAttributeValue("", 7379, item.InspectionId, 7379, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7397, ")", 7397, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\tEdit\r\n\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 187 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
						rowCount++;
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</tbody>\r\n\t\t\t</table>\r\n\r\n\r\n\t\t\t<br>\r\n\t\t\t<div style=\"clear: both;\">\r\n\t\t\t</div>\r\n\t\t\t<br>\r\n\t\t\t<br>\r\n\t\t\t<iframe style=\"display: none\" id=\"if_-2_119\"");
            BeginWriteAttribute("src", " src=\"", 7632, "\"", 7638, 0);
            EndWriteAttribute();
            WriteLiteral(@"></iframe>

		</div>
	</div>
</div>

<script src=""/js/jquery.min.js""></script>
<script src=""/js/jquery.unobtrusive-ajax.min.js""></script>


<script src=""/js/datatables.min.js""></script>




<script>
	$(document).ready(function () {
		$(""#myTable"").DataTable();
	});
</script>
<script>

	function Create(mechanicalId) {
		$(""#newPage"").load(""/Inspection/CreateVisualForm/"" + mechanicalId);
	}

	function Edit(id) {
		$(""#newPage"").load(""/Inspection/EditVisualForm/"" + id);
	}



	function showPage1() {
		$(""#Tabs"").load(""/Inspection/InspectionReports/");
#nullable restore
#line 231 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                  Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showPage2() {\r\n\t\t$(\"#Tabs\").load(\"/Inspection/InspectionInstructions/");
#nullable restore
#line 235 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                       Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showPage3() {\r\n\t\t$(\"#Tabs\").load(\"/Inspection/InspectionPrograms/");
#nullable restore
#line 239 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                   Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showPage4() {\r\n\t\t$(\"#Tabs\").load(\"/Inspection/InspectionResults/");
#nullable restore
#line 243 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                  Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\r\n\t//SUB MENU\r\n\r\n\tfunction showsubPage1() {\r\n\t\t//$(\"#newPage\").load(\"/Inspection/WorkingPrograms/\");\r\n\t\t$(\"#Tabs\").load(\"/Inspection/InspectionResults/");
#nullable restore
#line 251 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                  Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage2() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/LeakageTest/");
#nullable restore
#line 255 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                               Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage3() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/LiquidPenetrated/");
#nullable restore
#line 259 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                    Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage4() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/MagneticPowder/");
#nullable restore
#line 263 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                  Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage5() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/RadiographicsTest/");
#nullable restore
#line 267 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                     Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage6() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/UltrasonicTests/");
#nullable restore
#line 271 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                   Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage7() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/MetalThickness/");
#nullable restore
#line 275 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                  Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage8() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/VisualForm/");
#nullable restore
#line 279 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                              Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage9() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/LeakageForm/");
#nullable restore
#line 283 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                               Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage10() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/PenetrationForm/");
#nullable restore
#line 287 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                   Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage11() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/MagneticForm/");
#nullable restore
#line 291 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage12() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/RadiographicsForm/");
#nullable restore
#line 295 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                     Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage13() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/UltrasonicForm/");
#nullable restore
#line 299 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                  Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n\t}\r\n\r\n\tfunction showsubPage14() {\r\n\t\t$(\"#submenu\").load(\"/Inspection/MetalForm/");
#nullable restore
#line 303 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                             Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""");
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
				url: ""/Inspection/DeleteVisualForm/");
#nullable restore
#line 325 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                              Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n\t\t\t\tdata: { \"visualformId\": selectedIDs },\r\n\r\n\t\t\t\tsuccess: function (response) {\r\n\t\t\t\t\t$(\"#submenu\").load(\"/Inspection/VisualForm/");
#nullable restore
#line 329 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                          Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""");
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

	$('input:checkbox.checkBox').change(function () {
		var selectedIDs = new Array();
		$('input:checkbox.checkBox').each(function () {
			if ($(this).prop('checked')) {
				selectedIDs.push($(this).val());
			}
		});

		$('#exportSelectedData').val(selectedIDs);

	});

	function refreshPage() {
		// Your delay in milliseconds
		var delay = 2000;
		setTimeout(function () { $(""#submenu"").load(""/Inspection/VisualForm/");
#nullable restore
#line 358 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Inspection\VisualForm.cshtml"
                                                                       Write(ViewBag.MechanicalId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"); }, delay);\r\n\t}\r\n</script>");
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
