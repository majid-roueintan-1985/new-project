#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "959a75de8936c7013484e3dabf39cdaf0865c22e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Import_SortByByDamageabilityperuncoiledcycles), @"mvc.1.0.view", @"/Views/Import/SortByByDamageabilityperuncoiledcycles.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"959a75de8936c7013484e3dabf39cdaf0865c22e", @"/Views/Import/SortByByDamageabilityperuncoiledcycles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Import_SortByByDamageabilityperuncoiledcycles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.DamageabilityReport>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.unobtrusive.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
  
    ViewData["Title"] = "SortByByDamageabilityperuncoiledcycles";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 9 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
  
    int rowCount = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table id=\"myTable\" ");
            WriteLiteral(@" aria-describedby=""example_info"" class=""display dataTable"">
   
    <thead id=""myThead"">
        <tr role=""row"">
            <th data-orderable=""false"">
                <input type=""checkbox"" id=""checkAll"" />
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
            </th>
            <th data-orderable=""false"">
             ");
            WriteLiteral(@"   <b>
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
                </b>
            </th>
            <th data-ordera");
            WriteLiteral(@"ble=""false"">
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
    <tbody>

");
#nullable restore
#line 92 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr role=\"row\">\r\n                <td>\r\n                    <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 2715, "\"", 2731, 1);
#nullable restore
#line 96 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
WriteAttributeValue("", 2723, item.ID, 2723, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 99 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 102 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.Akz);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 105 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.ReportDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 108 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.Locationofthecheckpoint);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 111 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.Actionperiodofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 114 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.Lifetimeofequipmentindesign);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 117 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                 if ((Convert.ToDecimal(item.LifetimeofequipmentperRALDS)) <= (Convert.ToDecimal(item.AllowableLifeTime)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 120 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 122 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 126 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 128 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 132 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.Damageabilitypercoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 135 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.Damageabilityperuncoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 138 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                 if ((Convert.ToDecimal(item.Totaldamageabilityofequipment)) >= (Convert.ToDecimal(item.AllowableCUF)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 141 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 143 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 147 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 149 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 152 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.AllowableCUF);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 156 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.AllowableLifeTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 159 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                 if ((Convert.ToDecimal(item.AllowableChangingRatio)) <= (Convert.ToDecimal(item.ChangingRatio)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 162 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 164 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 168 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 170 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 173 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.AllowableChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 177 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
               Write(item.CreateDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("href", " href=\"", 5367, "\"", 5414, 2);
            WriteAttributeValue("", 5374, "/Import/EditDamageabilityReport/", 5374, 32, true);
#nullable restore
#line 180 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
WriteAttributeValue("", 5406, item.ID, 5406, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        Edit\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 185 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
            rowCount++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </tbody>
</table>
<br>


<link href=""/css/kendo.common.min.css"" rel=""stylesheet"" />
<link href=""/css/kendo.default.min.css"" rel=""stylesheet"" />
<link href=""/css/jquery.dataTables.min.css"" rel=""stylesheet"" />

<script src=""/js/jquery.min.js""></script>
<script src=""/js/kendo.all.min.js""></script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "959a75de8936c7013484e3dabf39cdaf0865c22e17649", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "959a75de8936c7013484e3dabf39cdaf0865c22e18689", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"<script src=""/js/jquery.min.js""></script>

<script src=""/js/datatables.min.js""></script>

<script>
    $(document).ready(function () {
        $(""#mySecondTable"").DataTable();
    });
</script>


<script>

    function Edit(id) {
        $(""#newPage"").load(""/Import/EditDamageabilityReport/"" + id);
    }

    //function GetGroupByDate() {
    //    $(""#GroupBy"").load(""/Import/GroupByDatessss/"");
    //}



    function refreshPage() {
        // Your delay in milliseconds
        var delay = 3000;
        setTimeout(function () { window.location = ""/SACOR-446""; }, delay);
    }

    function ShowAllRecords() {
        window.location = ""/SACOR-446"";
    }

    $('input:checkbox.checkBox').change(function () {
        var selectedIDs = new Array();
        $('input:checkbox.checkBox').each(function () {
            if ($(this).prop('checked')) {
                selectedIDs.push($(this).val());
            }
        });

        $('#exportSelectedData').val(selectedIDs);");
            WriteLiteral(@"


        //alert(selectedIDs);
    });




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
                url: ""/Import/DeleteDamageabilityReport"",
                data: { ""damagingId"": selectedIDs },
                success: function (response) {
                    window.location.href = ""/SACOR-446"";
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.re");
            WriteLiteral(@"sponseText);
                }
            });
        }
    });


    function GetDate() {
        var date = $('#searchDate').val();

        $('input[type=search]').val(date);

        $('input[type=search]').focus();

        //$('searchDate').on('change', function () {
        //table.draw();


        $('#searchDate').val("""");

    };

    function GetSearchhDate() {
        var date = $('#searchfileDate').val();

        $('#schfileDate').val(date);

        $('#searchfileDate').val("""");

    };

    function GetSearchfromDate() {
        var date = $('#schDate').val();

        $('#srchDate').val(date);

        $('#schDate').val("""");

    };

    //<------ Sort By Selected Items ----->

    function SortByByActionperiodofequipment() {
        
        var selectInput = $('select[name=SortBySelectedColumns] option').filter(':selected').val();

        if (selectInput == 1) {
            window.location.href = ""/SACOR-446"";
        }

        if (select");
            WriteLiteral(@"Input == 2) {
            $(""#newColumnSort"").load(""/Import/SortByByLocationofthecheckpoint/"");
        }

        if (selectInput == 3) {
            $(""#newColumnSort"").load(""/Import/SortByByActionperiodofequipment/"");
        }

        if (selectInput == 4) {
            $(""#newColumnSort"").load(""/Import/SortByByLifetimeofequipmentindesign/"");
        }

        if (selectInput == 5) {
            $(""#newColumnSort"").load(""/Import/SortByByLifetimeofequipmentperRALDS/"");
        }

        if (selectInput == 6) {
            $(""#newColumnSort"").load(""/Import/SortByByDamageabilitypercoiledcycles/"");
        }

        if (selectInput == 7) {
            $(""#newColumnSort"").load(""/Import/SortByByDamageabilityperuncoiledcycles/"");
        }

        if (selectInput == 8) {
            $(""#newColumnSort"").load(""/Import/SortByByTotaldamageabilityofequipment/"");
        }

        if (selectInput == 9) {
            $(""#newColumnSort"").load(""/Import/SortByByAllowableCUF/"");
        ");
            WriteLiteral(@"}

        if (selectInput == 10) {
            $(""#newColumnSort"").load(""/Import/SortByByAllowableRemainingLifeTime/"");
        }

        if (selectInput == 11) {
            $(""#newColumnSort"").load(""/Import/SortByByChangingRatio/"");
        }

        if (selectInput == 12) {
            $(""#newColumnSort"").load(""/Import/SortByByAllowableChangingRatio/"");
        }

        if (selectInput == 13) {
            $(""#newColumnSort"").load(""/Import/SortByByByFileDate/"");
        }
    }

    //<------End Sort By Selected Items ----->

    //<----- ----->
    function ShowRecords() {
        //debugger;
        var akz = $(""#akzText"").val();

        if (akz != """") {

            var numberOfUploadedList = '");
#nullable restore
#line 402 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                                   Write(ViewBag.NumberOfUploadedList);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';

            var lenghtOfAkz = $('#lenghtOfAkz option:selected').val();

            var kind = $('#kindOfSorting option:selected').val();

            var rowId = $(""#akzLocation"").val();

            if (lenghtOfAkz == ""All"") {
                lenghtOfAkz = numberOfUploadedList;
            }

            //var rowTable = $(""#"" + rowId).nextUntil("".group"").filter(""#myTable"");
            var rowTable = $(""#"" + rowId).nextUntil("".group"").not('tr[style=""display: none;""]');

            $.ajax({

                type: ""POST"",
                url: ""/Import/OrderByDescendingDamageabilityperuncoiledcyclesByNumberOfAKZ"",
                data: {
                    ""akz"": akz,

                    ""take"": lenghtOfAkz,
                    ""kind"": kind
                },
                success:
                    function (response) {


                        rowTable.remove();
                        //if (rowTable.length == 0) {

                        //selectedRow.after(resp");
            WriteLiteral(@"onse);
                        $(""#"" + rowId).after(response);
                        $(""#myThead"").remove();
                        //}
                    },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        }
    }

   

    function OrderByAscendingDate() {

        var selectInput = $('select[name=SortByAscendingSelectedColumns] option').filter(':selected').val();

        if (selectInput == 14) {
            $(""#newColumnSort"").load(""/Import/OrderByAscendingDamageabilityperuncoiledcycles/"");
        }

        if (selectInput == 13) {
            $(""#newColumnSort"").load(""/Import/SortByByDamageabilityperuncoiledcycles/"");
        }
    }

    //<------End Sort By Ascending Selected Items ----->

    //<------ Show Selected Items ----->

    function ShowSelectedRecords");
            WriteLiteral(@"() {

        var selectInput = $('select[name=lenghtOfTable] option').filter(':selected').val();
        //var numberOfShownRecords = $(""#ShowEntries"").val();

        var steps = $("".group"").eq(1).attr('id');
        var end = $("".group"").eq(97).attr('id');

        for (i = 0; i <= end; i += +steps) {
            $(""#"" + i).hide();

        }

        //var start = numberOfShownRecords * steps;
        var start = selectInput * steps;




        for (i = 0; i < start; i += +steps) {
            $(""#"" + i).show();

        }

        //for (i = start; i <= end; i += +steps) {
        //    $(""#"" + i).hide();

        //}

    }

    //<------End Show Selected Items ----->

    $(document).ready(function () {
        $('tbody tr[role=""row""]').hide();
    });

    //Group By Akz


    //group
    $(document).ready(function () {
        var groupColumn = 2;
        var table = $('#myTable').DataTable({


            columnDefs: [{ visible: false, targets: groupCol");
            WriteLiteral(@"umn }],
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
                var rows = api.rows({ page: 'current' }).nodes();

                var last = null;

                api
                    .column(groupColumn, { page: 'current' })
                    .data()
                    .each(function (group, i) {
                        if (last !== group) {
               ");
            WriteLiteral(@"             $(rows)
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



            var akz = $($(this)).text();
            var numberOfUploadedList = '");
#nullable restore
#line 573 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByDamageabilityperuncoiledcycles.cshtml"
                                   Write(ViewBag.NumberOfUploadedList);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';

            //send value for show selected records
            $(""#akzText"").val(akz);
            var rowId = $($(this)).attr('id');
            $(""#akzLocation"").val(rowId);

            var lenghtOfAkz = $('#lenghtOfAkz option:selected').val();

            var kind = $('#kindOfSorting option:selected').val();



            if (lenghtOfAkz == ""All"") {
                lenghtOfAkz = numberOfUploadedList;
            }

            var selectedRow = $($(this)).nextUntil("".group"");


            //var rowTable = $($(this)).nextUntil("".group"").filter(""#myTable"");
            //var rowTable = $(""#"" + rowId).nextUntil("".group"").filter(""#myTable"");

            var rowTable1 = $(""#"" + rowId).nextUntil("".group"").not('tr[style=""display: none;""]');
            //console.log(rowTable1);

            $.ajax({



                type: ""POST"",
                url: ""/Import/OrderByDescendingDamageabilityperuncoiledcyclesByNumberOfAKZ"",
                data: {
                    ""akz""");
            WriteLiteral(@": akz,

                    ""take"": numberOfUploadedList,
                    ""kind"": kind
                },
                success:
                    function (response) {



                        rowTable1.remove();
                        if (rowTable1.length == 0) {

                            //selectedRow.after(response);
                            $(""#"" + rowId).after(response);
                            $(""#myThead"").remove();
                        }
                    },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });

        });

       

    });


    $('input[type=file]').change(function () {

        $('#reportDates').attr('value', this.files[0].name);
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
