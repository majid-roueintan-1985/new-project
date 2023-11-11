#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a785128bd10dc45c31e0f5789b226c27379bd3791195c1fffd76a1bb28d1bac5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transients_ListGroups), @"mvc.1.0.view", @"/Views/Transients/ListGroups.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a785128bd10dc45c31e0f5789b226c27379bd3791195c1fffd76a1bb28d1bac5", @"/Views/Transients/ListGroups.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Transients_ListGroups : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.TransientGroups>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
  
    ViewData["Title"] = "ListGroups";
    Layout = "~/Views/Shared/_Layout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>ListGroups</h2>\r\n\r\n\r\n<div class=\"inner\">\r\n\r\n    <ul>\r\n");
#nullable restore
#line 13 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
         foreach (var group in Model.Where(g => g.ParentId == null))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\r\n                <input onchange=\"changeGroup()\" type=\"checkbox\" name=\"selectedGroups\"");
            BeginWriteAttribute("value", " value=\"", 399, "\"", 421, 1);
#nullable restore
#line 16 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 407, group.GroupId, 407, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"cat-1\">\r\n                <label for=\"cat-1\"> ");
#nullable restore
#line 17 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                               Write(group.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 18 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                 if (Model.Any(g => g.ParentId == group.GroupId))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <ul>\r\n");
#nullable restore
#line 21 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                         foreach (var sub in Model.Where(g => g.ParentId == group.GroupId))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                <input onchange=\"changeGroup()\" type=\"checkbox\" name=\"selectedGroups\"");
            BeginWriteAttribute("value", " value=\"", 867, "\"", 887, 1);
#nullable restore
#line 24 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 875, sub.GroupId, 875, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"cat-1\">\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 936, "\"", 968, 3);
            WriteAttributeValue("", 946, "Create(", 946, 7, true);
#nullable restore
#line 25 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 953, group.GroupId, 953, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 967, ")", 967, 1, true);
            EndWriteAttribute();
            WriteLiteral(" ");
            WriteLiteral(">createsub</a>\r\n                                <label for=\"cat-1\"> ");
#nullable restore
#line 26 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                                               Write(sub.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n                            </li>\r\n");
#nullable restore
#line 28 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n");
#nullable restore
#line 30 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 33 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</div>\r\n\r\n<table class=\"table table-bordered\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 40 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
       Write(Html.DisplayNameFor(model => model.GroupTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            زیر گروه ها\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 48 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
     foreach (var group in Model.Where(g => g.ParentId == null))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr");
            BeginWriteAttribute("id", " id=\"", 1578, "\"", 1605, 2);
            WriteAttributeValue("", 1583, "group_", 1583, 6, true);
#nullable restore
#line 50 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 1589, group.GroupId, 1589, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
           Write(Html.DisplayFor(modelItem => group.GroupTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 55 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                 if (Model.Any(g => g.ParentId == group.GroupId))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <ul>\r\n");
#nullable restore
#line 58 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                         foreach (var subGroup in Model.Where(g => g.GroupId == group.GroupId))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li");
            BeginWriteAttribute("id", " id=\"", 1996, "\"", 2026, 2);
            WriteAttributeValue("", 2001, "group_", 2001, 6, true);
#nullable restore
#line 60 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 2007, subGroup.GroupId, 2007, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 61 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                           Write(subGroup.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"text-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2109, "\"", 2142, 3);
            WriteAttributeValue("", 2119, "Edit(", 2119, 5, true);
#nullable restore
#line 61 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 2124, subGroup.GroupId, 2124, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2141, ")", 2141, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"glyphicon glyphicon-edit\"></i>\r\n                                </a>\r\n                                <a class=\"text-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2316, "\"", 2351, 3);
            WriteAttributeValue("", 2326, "Delete(", 2326, 7, true);
#nullable restore
#line 64 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 2333, subGroup.GroupId, 2333, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2350, ")", 2350, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"glyphicon glyphicon-trash\"></i>\r\n                                </a>\r\n                            </li>\r\n");
#nullable restore
#line 68 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n");
#nullable restore
#line 70 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n            <td>\r\n                <a class=\"btn btn-primary btn-xs\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2666, "\"", 2698, 3);
            WriteAttributeValue("", 2676, "Create(", 2676, 7, true);
#nullable restore
#line 73 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 2683, group.GroupId, 2683, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2697, ")", 2697, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <i class=\"glyphicon glyphicon-plus\"></i>\r\n                </a>\r\n                <a class=\"btn btn-warning btn-xs\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2835, "\"", 2865, 3);
            WriteAttributeValue("", 2845, "Edit(", 2845, 5, true);
#nullable restore
#line 76 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 2850, group.GroupId, 2850, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2864, ")", 2864, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <i class=\"glyphicon glyphicon-edit\"></i>\r\n                </a>\r\n                <a class=\"btn btn-danger btn-xs\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3001, "\"", 3033, 3);
            WriteAttributeValue("", 3011, "Delete(", 3011, 7, true);
#nullable restore
#line 79 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
WriteAttributeValue("", 3018, group.GroupId, 3018, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3032, ")", 3032, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <i class=\"glyphicon glyphicon-trash\"></i>\r\n                </a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 84 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Transients\ListGroups.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</table>

<!-- Modal -->
<div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <h4 class=""modal-title"" id=""myModalLabel"">Modal title</h4>
            </div>
            <div class=""modal-body"" id=""myModalBody"">
                ...
            </div>
        </div>
    </div>
</div>
<!-- Modal -->
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <link href=""/css/bootstrap.min.css"" rel=""stylesheet"" type=""text/css"" />
    <script src=""/js/jquery.min.js""></script>

    <script src=""/js/bootstrap.min.js""></script>

    <script src=""/js/datatables.min.js""></script>



    <script>
        $(document).ready(function () {
            $(""#myTable"").DataTable();
        });
    </script>

    <script>

        function Create(parentId) {
            $.get(""/MyTransient/Create/"" + parentId,
                function (result) {
                    $(""#myModal"").modal();
                    $(""#myModalLabel"").html(""Code"");
                    $(""#myModalBody"").html(result);
                });
        }

        $(""#checkAll"").click(function () {
            $("".checkBox"").prop('checked',
                $(this).prop('checked'));
        });

        $(""#delete"").click(function () {
            var selectedIDs = new Array();

            $('input:checkbox.checkBox').each(function () {
                if ($(this).prop('chec");
                WriteLiteral(@"ked')) {
                    selectedIDs.push($(this).val());
                }
            });

            var result = confirm(""are you sure you want to delete?"");
            if (result) {

                $.ajax({
                    type: ""POST"",
                    url: ""/Cables/DeleteCable"",
                    data: { ""cableId"": selectedIDs },



                    success: function (response) {
                        window.location.href = ""/Cables"";
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
            );
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
