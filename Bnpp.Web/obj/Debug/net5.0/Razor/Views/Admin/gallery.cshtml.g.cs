#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Admin\gallery.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f8e52fc883d10218fbfe7aa59b9ec3d34030e862a852e5798dad747119b2c90a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_gallery), @"mvc.1.0.view", @"/Views/Admin/gallery.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f8e52fc883d10218fbfe7aa59b9ec3d34030e862a852e5798dad747119b2c90a", @"/Views/Admin/gallery.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_gallery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bnpp.DataLayer.Entities.InspectionData.InspectionDocument>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Admin\gallery.cshtml"
  
	ViewData["Title"] = "gallery";
	Layout = "~/Views/Shared/_Layout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<style>\r\n\t.demo {\r\n\t\twidth: 600px;\r\n\t}\r\n\r\n</style>\r\n<div class=\"dcontent\">\r\n\t<div class=\"demo\">\r\n\t\t<ul id=\"lightSlider\" style=\"list-style: none outside none;padding-left: 0;margin-bottom: 0;\">\r\n");
#nullable restore
#line 18 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Admin\gallery.cshtml"
             foreach (var item in Model)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<li data-thumb=\"/DocumentImage/");
#nullable restore
#line 20 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Admin\gallery.cshtml"
                                          Write(item.InspectionImage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" style=\"display: block;float: left;margin-right: 6px;cursor: pointer;\">\r\n\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 542, "\"", 584, 2);
            WriteAttributeValue("", 548, "/DocumentImage/", 548, 15, true);
#nullable restore
#line 21 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Admin\gallery.cshtml"
WriteAttributeValue("", 563, item.InspectionImage, 563, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display: block;height: auto;max-width: 100%;\" />\r\n\t\t\t\t</li>\r\n");
#nullable restore
#line 23 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Admin\gallery.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"		</ul>
	</div>
</div>


<link type=""text/css"" rel=""stylesheet"" href=""/css/lightslider.css"" />
<link type=""text/css"" rel=""stylesheet"" href=""/css/CustomCss.css"" />

<script src=""/js/jquery.min.js""></script>
<script src=""/js/lightslider.js""></script>




<script type=""text/javascript"">
	$('#lightSlider').lightSlider({
		gallery: true,
		item: 1,
		loop: true,
		slideMargin: 0,
		thumbItem: 9,

		keyPress: false,
		controls: true,
		prevHtml: '',
		nextHtml: ''

	});

			// $(document).ready(function () {
			// 	$(""#lightSlider"").lightSlider({
			// 		item: 3,
			// 		autoWidth: false,
			// 		slideMove: 1, // slidemove will be 1 if loop is true
			// 		slideMargin: 10,

			// 		addClass: '',
			// 		mode: ""slide"",
			// 		useCSS: true,
			// 		cssEasing: 'ease', //'cubic-bezier(0.25, 0, 0.25, 1)',//
			// 		easing: 'linear', //'for jquery animation',////

			// 		speed: 400, //ms'
			// 		auto: false,
			// 		loop: false,
			// 		slideEndAnimation: true,
			// 		pau");
            WriteLiteral(@"se: 2000,

			// 		keyPress: false,
			// 		controls: true,
			// 		prevHtml: '',
			// 		nextHtml: '',

			// 		rtl: false,
			// 		adaptiveHeight: false,

			// 		vertical: false,
			// 		verticalHeight: 500,
			// 		vThumbWidth: 100,

			// 		thumbItem: 10,
			// 		pager: true,
			// 		gallery: false,
			// 		galleryMargin: 5,
			// 		thumbMargin: 5,
			// 		currentPagerPosition: 'middle',

			// 		enableTouch: true,
			// 		enableDrag: true,
			// 		freeMove: true,
			// 		swipeThreshold: 40,

			// 		responsive: [],

			// 		onBeforeStart: function (el) { },
			// 		onSliderLoad: function (el) { },
			// 		onBeforeSlide: function (el) { },
			// 		onAfterSlide: function (el) { },
			// 		onBeforeNextSlide: function (el) { },
			// 		onBeforePrevSlide: function (el) { }
			// 	});
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bnpp.DataLayer.Entities.InspectionData.InspectionDocument>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
