#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "77bf75a445ce8232ab6c22db4a538c3ec7a86a3b22d5d10af672ef8e3725d17e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Import_SortByByByFileDate), @"mvc.1.0.view", @"/Views/Import/SortByByByFileDate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"77bf75a445ce8232ab6c22db4a538c3ec7a86a3b22d5d10af672ef8e3725d17e", @"/Views/Import/SortByByByFileDate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Import_SortByByByFileDate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.DamageabilityReport>>
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
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
  
    ViewData["Title"] = "SortByByByFileDate";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 9 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
  
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
#line 92 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr role=\"row\">\r\n                <td>\r\n                    <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", " value=\"", 2695, "\"", 2711, 1);
#nullable restore
#line 96 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
WriteAttributeValue("", 2703, item.ID, 2703, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 99 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(rowCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 102 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.Akz);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 105 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.ReportDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 108 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.Locationofthecheckpoint);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 111 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.Actionperiodofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 114 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.Lifetimeofequipmentindesign);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 117 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                 if ((Convert.ToDecimal(item.LifetimeofequipmentperRALDS)) <= (Convert.ToDecimal(item.AllowableLifeTime)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 120 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 122 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 126 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                   Write(item.LifetimeofequipmentperRALDS);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 128 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 132 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.Damageabilitypercoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 135 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.Damageabilityperuncoiledcycles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 138 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                 if ((Convert.ToDecimal(item.Totaldamageabilityofequipment)) >= (Convert.ToDecimal(item.AllowableCUF)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 141 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 143 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 147 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                   Write(item.Totaldamageabilityofequipment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 149 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 152 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.AllowableCUF);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 156 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.AllowableLifeTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n");
#nullable restore
#line 159 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                 if ((Convert.ToDecimal(item.AllowableChangingRatio)) <= (Convert.ToDecimal(item.ChangingRatio)))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"background-color:red;\">\r\n                        ");
#nullable restore
#line 162 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 164 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 168 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                   Write(item.ChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 170 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
#nullable restore
#line 173 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.AllowableChangingRatio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 177 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
               Write(item.CreateDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a class=\"btn-edit-equip\"");
            BeginWriteAttribute("href", " href=\"", 5347, "\"", 5394, 2);
            WriteAttributeValue("", 5354, "/Import/EditDamageabilityReport/", 5354, 32, true);
#nullable restore
#line 180 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
WriteAttributeValue("", 5386, item.ID, 5386, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        Edit\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 185 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77bf75a445ce8232ab6c22db4a538c3ec7a86a3b22d5d10af672ef8e3725d17e17035", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77bf75a445ce8232ab6c22db4a538c3ec7a86a3b22d5d10af672ef8e3725d17e18099", async() => {
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
            WriteLiteral(@"
<script src=""/js/jquery.min.js""></script>

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

        $('#exportSelectedData').val(selectedIDs)");
            WriteLiteral(@";


        //alert(selectedIDs);
    });

    function selected() {

        var arr = [];
        $('input.checkBox:checkbox:checked').each(function () {
            arr.push($(this).val());
        });

        $('#exportSelectedData').val(arr);
    };


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
");
            WriteLiteral(@"                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
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
     ");
            WriteLiteral(@"   
        var selectInput = $('select[name=SortBySelectedColumns] option').filter(':selected').val();

        if (selectInput == 1) {
            window.location.href = ""/SACOR-446"";
        }

        if (selectInput == 2) {
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

        if (selectInput ==");
            WriteLiteral(@" 8) {
            $(""#newColumnSort"").load(""/Import/SortByByTotaldamageabilityofequipment/"");
        }

        if (selectInput == 9) {
            $(""#newColumnSort"").load(""/Import/SortByByAllowableCUF/"");
        }

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
#line 410 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
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
                url: ""/Import/OrderByDescendingFileDateByNumberOfAKZ"",
                data: {
                    ""akz"": akz,

                    ""take"": lenghtOfAkz,
                    ""kind"": kind
                },
                success:
                    function (response) {


                        rowTable.remove();
                        //if (rowTable.length == 0) {

                        //selectedRow.after(response);
              ");
            WriteLiteral(@"          $(""#"" + rowId).after(response);
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

        if (selectInput == 26) {
            $(""#newColumnSort"").load(""/Import/OrderByAscendingFileDate/"");
        }

        if (selectInput == 25) {
            $(""#newColumnSort"").load(""/Import/SortByByByFileDate/"");
        }
    }

    //<------End Sort By Ascending Selected Items ----->

    //<------ Show Selected Items ----->

    function ShowSelectedRecords() {

        var selectInput = $('select[name=lenghtOfTabl");
            WriteLiteral(@"e] option').filter(':selected').val();
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


            columnDefs: [{ visible: false, targets: groupColumn }],
            order: [[groupColumn, 'asc']],


    ");
            WriteLiteral(@"        // hide ""Showing 1 of N Entries"" with the dataTables.js library
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
                            $(rows)
                                .eq(i)");
            WriteLiteral(@"
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
#line 581 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Import\SortByByByFileDate.cshtml"
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
                url: ""/Import/OrderByDescendingFileDateByNumberOfAKZ"",
                data: {
                    ""akz"": akz,

            ");
            WriteLiteral(@"        ""take"": numberOfUploadedList,
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
