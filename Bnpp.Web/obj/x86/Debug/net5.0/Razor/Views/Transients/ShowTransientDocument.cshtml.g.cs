#pragma checksum "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1bc2078516cf926461e72da20d97e51d6f5679a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transients_ShowTransientDocument), @"mvc.1.0.view", @"/Views/Transients/ShowTransientDocument.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1bc2078516cf926461e72da20d97e51d6f5679a", @"/Views/Transients/ShowTransientDocument.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Transients_ShowTransientDocument : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable< Bnpp.DataLayer.Entities.TransientDocuments>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
  
    ViewData["Title"] = "ShowTransientDocument";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<link href=""/css/bootstrap.css"" rel=""stylesheet"" />
<style>
    /* img {
                            display: block;
                            width: 100%;
                            height: auto;
                        }*/

    p {
        background: none;
        color: #ffffff;
    }

    #slideShow #slideShowWindow {
        width: 650px;
        height: 450px;
        margin: 0;
        padding: 0;
        position: relative;
        overflow: hidden;
        margin-left: auto;
        margin-right: auto;
    }

        #slideShow #slideShowWindow .slide {
            margin: 0;
            padding: 0;
            width: 650px;
            height: 450px;
            float: left;
            position: relative;
            margin-left: auto;
            margin-right: auto;
        }

        #slideshow #slideshowWindow .slide, .slideText {
            position: absolute;
            bottom: 18px;
            left: 27%;
            width: 100%;
            h");
            WriteLiteral(@"eight: auto;
            margin: 0;
            padding: 0;
            color: black;
            font-family: Myriad Pro, Arial, Helvetica, sans-serif;
        }

    .slideText {
        background: white;
    }

    #slideshow #slideshowWindow .slide .slideText h2,
    #slideshow #slideshowWindow .slide .slideText p {
        margin: 10px;
        padding: 15px;
    }

    .slideNav {
        display: block;
        text-indent: -10000px;
        position: absolute;
        cursor: pointer;
    }

    #leftNav {
        left: 0;
        bottom: 10px;
        width: 48px;
        height: 48px;
        background-image: url(""/images/indent_fa.png"");
        background-repeat: no-repeat;
        z-index: 10;
    }

    #rightNav {
        right: 0;
        bottom: 0;
        width: 48px;
        height: 48px;
        background-image: url(""/images/indent.png"");
        background-repeat: no-repeat;
        z-index: 10;
    }
</style>

<div id=""editDocument"">
    <");
            WriteLiteral("div id=\"slideShow\">\r\n        <div id=\"slideShowWindow\">\r\n");
#nullable restore
#line 97 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
             foreach (var item in Model)
            {


                var extn = item.Filename.Split(".").Last();

                

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
                 if (extn == "png" || extn == "jpeg" || extn == "jpg")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"slide\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 2560, "\"", 2611, 2);
            WriteAttributeValue("", 2566, "/transientFiles/", 2566, 16, true);
#nullable restore
#line 106 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
WriteAttributeValue("", 2582, item.TransientDocumentsImage, 2582, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" />\r\n                        <div class=\"slideText\">\r\n                            <h2>");
#nullable restore
#line 108 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
                           Write(item.Filename);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n                        </div><!--</slideText> -->\r\n                    </div>\r\n");
#nullable restore
#line 112 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2925, "\"", 2977, 2);
            WriteAttributeValue("", 2932, "/transientFiles/", 2932, 16, true);
#nullable restore
#line 116 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
WriteAttributeValue("", 2948, item.TransientDocumentsImage, 2948, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 116 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
                                                                           Write(item.Filename);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </p>\r\n");
#nullable restore
#line 118 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 118 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <!-- </slide> repeat as many times as needed -->
        </div><!--</slideShowWindow> -->
    </div><!--</slideshow> -->
    <div>
        <input type=""button"" onclick=""EditDocuments()"" class=""btn-edit-equip"" value=""Edit Documents"">
    </div>
</div>


<script src=""/js/jquery.min.js""></script>
<script src=""/js/bootstrap.min.js""></script>
<script>
    $(document).ready(function () {

        var currentPosition = 0;
        var slideWidth = 650;
        var slides = $('.slide');
        var numberOfSlides = slides.length;
        var slideShowInterval;
        var speed = 5000;

        //Assign a timer, so it will run periodically
        slideShowInterval = setInterval(changePosition, speed);

        slides.wrapAll('<div id=""slidesHolder""></div>');

        slides.css({ 'float': 'left' });

        //set #slidesHolder width equal to the total width of all the slides
        $('#slidesHolder').css('width', slideWidth * numberOfSlides);

        $('#slideShowWindow')");
            WriteLiteral(@"
            .prepend('<span class=""slideNav"" id=""leftNav"">Move Left</span>')
            .append('<span class=""slideNav"" id=""rightNav"">Move Right</span>');

        manageNav(currentPosition);

        //tell the buttons what to do when clicked
        $('.slideNav').bind('click', function () {

            //determine new position
            currentPosition = ($(this).attr('id') === 'rightNav')
                ? currentPosition + 1 : currentPosition - 1;

            //hide/show controls
            manageNav(currentPosition);
            clearInterval(slideShowInterval);
            slideShowInterval = setInterval(changePosition, speed);
            moveSlide();
        });

        function manageNav(position) {
            //hide left arrow if position is first slide
            if (position === 0) {
                $('#leftNav').hide();
            }
            else {
                $('#leftNav').show();
            }
            //hide right arrow is slide position is las");
            WriteLiteral(@"t slide
            if (position === numberOfSlides - 1) {
                $('#rightNav').hide();
            }
            else {
                $('#rightNav').show();
            }
        }


        //changePosition: this is called when the slide is moved by the timer and NOT when the next or previous buttons are clicked
        function changePosition() {
            if (currentPosition === numberOfSlides - 1) {
                currentPosition = 0;
                manageNav(currentPosition);
            } else {

                currentPosition++;
                manageNav(currentPosition);
            }
            moveSlide();
        }


        //moveSlide: this function moves the slide
        function moveSlide() {
            $('#slidesHolder').animate({ 'marginLeft': slideWidth * (-currentPosition) });
        }

    });

    

    function EditDocuments(){
        $(""#editDocument"").load(""/Transients/EditDocument/""+");
#nullable restore
#line 213 "C:\Users\taban\source\repos\Bnpp\Bnpp.Web\Views\Transients\ShowTransientDocument.cshtml"
                                                       Write(ViewBag.TransientId);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable< Bnpp.DataLayer.Entities.TransientDocuments>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
