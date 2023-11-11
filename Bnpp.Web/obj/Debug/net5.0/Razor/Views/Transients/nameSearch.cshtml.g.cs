#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51ae142d49c6775fa31474e6745333d288db22dd23a3139e582bf6756c02fcf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transients_nameSearch), @"mvc.1.0.view", @"/Views/Transients/nameSearch.cshtml")]
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
#nullable restore
#line 1 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
using Bnpp.DataLayer.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"51ae142d49c6775fa31474e6745333d288db22dd23a3139e582bf6756c02fcf7", @"/Views/Transients/nameSearch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Transients_nameSearch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.TransientGroups>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
  
    ViewData["Title"] = "nameSearch";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 id=""iH1"">
    Results For Name Search
</h1>

<table id=""nameSearch"" cellpadding=""3"" cellspacing=""0"" aria-describedby=""example_info"" class=""display dataTable"">
    <thead>
        <tr role=""row"">
            <th>
                <b>Code</b>
            </th>
            <th>
                <b>Name</b>
            </th>
        </tr>
    </thead>
    <tbody id=""searchForName"">
");
#nullable restore
#line 24 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
          
            List<TransientGroups> codes = ViewBag.Codes as List<TransientGroups>;
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n");
#nullable restore
#line 31 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
                 if (codes.Any(g => g.GroupId == item.ParentId))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n");
#nullable restore
#line 34 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
                         foreach (var code in codes.Where(g => g.GroupId == item.ParentId))
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
                       Write(code.GroupTitle);

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
                                            
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
                   Write(item.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 42 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 44 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\nameSearch.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>



<script src=""/js/jquery.min.js""></script>
<script src=""/js/datatables.min.js""></script>

<script>
    $(document).ready(function () {
        $(""#nameSearch"").DataTable({
            ""info"": false,
            searching: false
        });
    });

    //$(""#searchForName td"").click(function () {
    //    var vlues = $(this).text();
        
    //    vlues = vlues.replace(/\s/g, '');

    //    $(""#transientCode"").val("""");
    //    $(""#transientCode"").val(vlues);
        
    //    $('#transientCode').trigger('change');
    //});

    //$(function () {
    //    $(""#transientCode"").on(""change paste keyup"", function () {
    //        var groupTitle = $(""#transientCode"").val();
           
    //        $.ajax({
    //            type: ""POST"",
    //            url: ""/Transients/GetSubGroups"",
    //            data: { ""title"": groupTitle },

    //            success: function (response) {
    //                $.each(response,
    //           ");
            WriteLiteral(@"         function () {
    //                        $(""#Name"").empty();
    //                        $(""#Name"").append('<option value=' + this.value + '>' + this.text + '</option>');

    //                    });

    //            },
    //            failure: function (response) {
    //                alert(response.responseText);
    //            },
    //            error: function (response) {
    //                alert(response.responseText);
    //                $(""#Name"").empty();
    //            }
    //        });
    //    });
    //});

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.TransientGroups>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
