#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SearchInGroupedOfTransientCode.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "571ad02ec175b51e859ca2d31dbc250475b21c06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transients_SearchInGroupedOfTransientCode), @"mvc.1.0.view", @"/Views/Transients/SearchInGroupedOfTransientCode.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571ad02ec175b51e859ca2d31dbc250475b21c06", @"/Views/Transients/SearchInGroupedOfTransientCode.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Transients_SearchInGroupedOfTransientCode : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.GroupedTransients>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SearchInGroupedOfTransientCode.cshtml"
  
    ViewData["Title"] = "SearchInGroupedOfTransientCode";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Results of Code</h2>\r\n\r\n<div class=\"bevel-box\">\r\n\r\n\r\n\r\n");
#nullable restore
#line 13 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SearchInGroupedOfTransientCode.cshtml"
      
        int rowCount = 1;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <table id=\"codingSearchTable\" cellpadding=\"3\" cellspacing=\"0\" aria-describedby=\"example_info\" class=\"cell-border\">\r\n        <thead>\r\n            <tr role=\"row\">\r\n\r\n");
            WriteLiteral(@"
                <th>
                    <b>
                        Code
                    </b>
                </th>
                <th>
                    <b>
                        Name
                    </b>
                </th>

            </tr>
        </thead>
        <tbody id=""searchForCode"">
");
#nullable restore
#line 39 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SearchInGroupedOfTransientCode.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 46 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SearchInGroupedOfTransientCode.cshtml"
                   Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SearchInGroupedOfTransientCode.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 52 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\SearchInGroupedOfTransientCode.cshtml"
                rowCount++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>



<script src=""/js/jquery.min.js""></script>
<script src=""/js/datatables.min.js""></script>

<script>
    $(document).ready(function () {
        $(""#codingSearchTable"").DataTable({
            ""info"": false,
            searching: false
        });
    });

    $(""#searchForCode td"").click(function () {
        var vlues = $(this).text();
        
        vlues =vlues.trim();

        $(""#transientCode"").val("""");
        $(""#transientCode"").val(vlues);
        //alert($(""#transientCode"").val());
        $('#transientCode').trigger('change');
    });





    $(function () {
        $(""#transientCode"").on(""change paste keyup"", function () {
            var groupTitle = $(""#transientCode"").val();
            //alert(typeof groupTitle);
            $.ajax({
                type: ""POST"",
                url: ""/Transients/GetSubGroupsInGroupedTransient"",
                data: { ""title"": groupTitle },

                success: function (r");
            WriteLiteral(@"esponse) {
                    $.each(response,
                        function () {
                            $(""#Name"").empty();
                            $(""#Name"").append('<option value=' + this.value + '>' + this.text + '</option>');

                        });

                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                    $(""#Name"").empty();
                }
            });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.GroupedTransients>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
