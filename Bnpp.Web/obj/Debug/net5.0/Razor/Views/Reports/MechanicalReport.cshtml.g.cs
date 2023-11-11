#pragma checksum "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Reports\MechanicalReport.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "bf736bb8718eaabc4bec4b0d0ba128bf6c5fd01f0603256138be3bfebe05f16d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_MechanicalReport), @"mvc.1.0.view", @"/Views/Reports/MechanicalReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"bf736bb8718eaabc4bec4b0d0ba128bf6c5fd01f0603256138be3bfebe05f16d", @"/Views/Reports/MechanicalReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Reports_MechanicalReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\mohsen\source\repos\Bnpp\Bnpp.Web\Views\Reports\MechanicalReport.cshtml"
  
    ViewData["Title"] = "MechanicalReport";
    Layout = "~/Views/Shared/_Layout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""dcontent""><div style=""margin-top: 10px;background-color: #6b8d9e;padding-top: 5px;padding-bottom: 5px;padding-right: 10px;border-radius: 5px;border: solid 1px #cccccc;background: repeating-linear-gradient( -45deg, #7fa1b3, #6b8d9e 1px, #6b8d9e 1px, #6b8d9e 20px );"">&nbsp;</div><div style=""border-radius:5px; margin-top:5px;margin-bottom:5px; padding:15px; border:solid 1px #cea001; background-color:#ffe100;""><table cellpadding=""3"" cellspacing=""0""><tbody><tr><td");
            BeginWriteAttribute("style", " style=\"", 579, "\"", 587, 0);
            EndWriteAttribute();
            WriteLiteral("><b><a class=\"breadcumb2-link\" href=\"/Reports\">Main</a></b></td><td");
            BeginWriteAttribute("style", " style=\"", 655, "\"", 663, 0);
            EndWriteAttribute();
            WriteLiteral(@"> » <b><a class=""breadcumb2-link"" href=""/Equipments"">Mechanical Equipments</a></b></td><td> » <b style=""color:#ff0000;"" id=""subTitle22"">Reports</b></td></tr></tbody></table><a id=""iHelp"" style=""float:right;position:relative; top:-32px;"" href=""javascript:;"" onclick=""showHelp();""><img src=""/images/help.png"" style=""width:48px;"" class=""imgHelp""></a></div>

<h1>Reports</h1>
    <div class=""bevel-box"" style=""background-color:#ffffff;padding:15px; max-width:600px;"">
        <table cellpadding=""3"" cellspacing=""0"">
            <tbody><tr>
                <td style=""text-align:right;"">Search:</td>
                <td><input name=""iSearch"" type=""text"" id=""iSearch"" style=""direction: ltr; text-align: left;""></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style=""text-align:right;"">AKZ:</td>
                <td><input name=""iAkz"" type=""text"" id=""iAkz"" style=""direction: ltr; text-align: left;""></td>
                <td>&nbsp;</td>
            </tr>
            <tr>");
            WriteLiteral(@"
                <td style=""text-align:right;"">Name of Equipment:</td>
                <td><input name=""iName"" type=""text"" id=""iName"" style=""direction: ltr; text-align: left;""></td>
                <td>&nbsp;</td>
            </tr>            
            <tr>
                <td style=""text-align:right;"">Subject:</td>
                <td style=""position:relative;""><input name=""iSubject"" type=""text"" id=""iSubject"" onclick=""cancelClose();showReportMenus();"" style=""direction: ltr; text-align: left;"">
                
    <div class=""repMainMenu"" id=""iSubjectMenu"" onclick=""cancelClose();"">
        <ul>
            <li><a href=""javascript:;"" onclick=""showRepMenu(0);"">Basic Data</a>
                <div id=""iBasicData0"" class=""repMainMenu submenu"">
                    <ul>
                        <li><a href=""javascript:select22(0, 0);"">General Data</a></li>
                        <li class=""hide-electrical""><a href=""javascript:select22(0, 1);"">Design Data</a></li>
                        <li><a hre");
            WriteLiteral(@"f=""javascript:select22(0, 2);"">Documents</a></li>
                        <li><a href=""javascript:select22(0, 3);"">Safety Class &amp; Seismic category</a></li>
                        <li class=""hide-electrical hide-structure""><a href=""javascript:select22(0, 4);"">Components</a></li>
                        <li class=""hide-electrical hide-structure""><a href=""javascript:select22(0, 5);"">Chemical Norms</a></li>
                        <li><a href=""javascript:select22(0, 6);"">Technical Programs</a></li>
                        <li class=""hide-electrical""><a href=""javascript:select22(0, 7);"">Sensors</a></li>
                        <li class=""hide-electrical""><a href=""javascript:select22(0, 8);"">Control Points</a></li>
                        <li class=""hide-electrical""><a href=""javascript:select22(0, 9);"">H-Forms</a></li>
                        <!--<li><a href='javascript:select22(0, 10);'>Operational modes</a></li>-->
                    </ul>
                </div>
            </li>
            <li");
            WriteLiteral(@"><a href=""javascript:;"" onclick=""showRepMenu(1);"">Documents</a>
                <div id=""iBasicData1"" class=""repMainMenu submenu"">
                    <ul>
                        <li><a href=""javascript:select22(1, 0);"">Operational Documents</a></li>
                        <li><a href=""javascript:select22(1, 1);"">Drawing</a></li>
                        <li><a href=""javascript:select22(1, 2);"">Standards</a></li>
                        <li><a href=""javascript:select22(1, 3);"">Manufacture Documents</a></li>
                        <li><a href=""javascript:select22(1, 4);"">Installation Documents</a></li>
                        <li><a href=""javascript:select22(1, 5);"">Maintenance Documents</a></li>
                        <li><a href=""javascript:select22(1, 6);"">Ageing Documents</a></li>
                    </ul>
                </div>
            </li>
            <li><a href=""javascript:;"" onclick=""showRepMenu(2);"">Ageing Mechanism</a>
                <div id=""iBasicData2"" class=""repMainMenu su");
            WriteLiteral(@"bmenu"">
                    <ul>
                        <li><a href=""javascript:select22(2, 0);"">Ageing Mechanism</a></li>
                        <li><a href=""javascript:select22(2, 1);"">Documents</a></li>
                    </ul>
                </div>
            </li>
            <li><a href=""javascript:select21(3);"">Installation and Commissioning</a></li>
            <li><a href=""javascript:;"" onclick=""showRepMenu(3);"">Operational Data</a>
                <div id=""iBasicData3"" class=""repMainMenu submenu"">
                    <ul>
                        <li><a href=""javascript:select22(4, 0);"">Sensors Data</a></li>
                        <li><a href=""javascript:select22(4, 1);"">Water Chemical Data</a></li>
                        <li><a href=""javascript:select22(4, 2);"">Environmental Data</a></li>
                    </ul>
                </div>
            </li>
            <li class=""hide-electrical hide-structure""><a href=""javascript:select21(5);"">Events</a></li>
            <li c");
            WriteLiteral(@"lass=""hide-electrical hide-structure""><a href=""javascript:select21(11);"">On / Off Data</a></li>
            <li><a href=""javascript:;"" onclick=""showRepMenu(4);"">Maintenance</a>
                <div id=""iBasicData4"" class=""repMainMenu submenu2"">
                    <ul>
                        <li><a href=""javascript:select22(6, 0);"">Maintenance Programs</a></li>
                        <li><a href=""javascript:select22(6, 1);"">List of Defection</a></li>
                        <li><a href=""javascript:select22(6, 2);"">Spare Parts</a></li>
                        <li><a href=""javascript:select22(6, 3);"">Maintenance Forms</a></li>
                        <li><a href=""javascript:select22(6, 4);"">Meassurements before &amp; after Maintenance</a></li>
                        <li><a href=""javascript:select22(6, 5);"">Defection Reports</a></li>
                    </ul>
                </div>            
            </li>
            <li><a href=""javascript:;"" onclick=""showRepMenu(5);"">Inspection Data</a>
");
            WriteLiteral(@"                <div id=""iBasicData5"" class=""repMainMenu submenu2"">
                    <ul>
                        <li><a href=""javascript:select22(7, 0);"">Inspection Reports</a></li>
                        <li><a href=""javascript:select22(7, 1);"">Inspection Instructions</a></li>
                        <li><a href=""javascript:;"" onclick=""showRepMenu(6);"">Inspection Programs</a>
                            <div id=""iBasicData6"" class=""repMainMenu submenu2"">
                                <ul>
                                    <li><a href=""javascript:select22(8, 0);"">Typical Programs</a></li>
                                    <li><a href=""javascript:select22(8, 1);"">Working Programs</a></li>
                                </ul>
                            </div> 
                        </li>
                        <li><a href=""javascript:;"" onclick=""showRepMenu(7);"">Inspection Results</a>
                            <div id=""iBasicData7"" class=""repMainMenu submenu2"">
                  ");
            WriteLiteral(@"              <ul>
                                    <li><a href=""javascript:;"" onclick=""showRepMenu(8);"">Tests</a>
                                        <div id=""iBasicData8"" class=""repMainMenu submenu2"">
                                            <ul>
                                                <li><a href=""javascript:select22(9, 0);"">Visual Control</a></li>
                                                <li><a href=""javascript:select22(9, 1);"">Leakage Test of Weld</a></li>
                                                <li><a href=""javascript:select22(9, 2);"">Liquid penetrated Test</a></li>
                                                <li><a href=""javascript:select22(9, 3);"">Magnetic Powder Test</a></li>
                                                <li><a href=""javascript:select22(9, 4);"">Radiographics Test</a></li>
                                                <li><a href=""javascript:select22(9, 5);"">Ultrasonic Test</a></li>
                                                <li>");
            WriteLiteral(@"<a href=""javascript:select22(9, 6);"">Metal Thickness ultrasonic Meassurement</a></li>
                                            </ul>
                                        </div> 

                                    </li>
                                    <li><a href=""javascript:;"" onclick=""showRepMenu(9);"">Forms</a>
                                        <div id=""iBasicData9"" class=""repMainMenu submenu2"">
                                            <ul>
                                                <li><a href=""javascript:select22(9, 7);"">Visual Control</a></li>
                                                <li><a href=""javascript:select22(9, 8);"">Leakage Test of Weld</a></li>
                                                <li><a href=""javascript:select22(9, 9);"">Liquid penetrated Test</a></li>
                                                <li><a href=""javascript:select22(9, 10);"">Magnetic Powder Test</a></li>
                                                <li><a href=""javascript:");
            WriteLiteral(@"select22(9, 11);"">Radiographics Test</a></li>
                                                <li><a href=""javascript:select22(9, 12);"">Ultrasonic Test</a></li>
                                                <li><a href=""javascript:select22(9, 13);"">Metal Thickness ultrasonic Meassurement</a></li>
                                            </ul>
                                        </div>                                     
                                    </li>
                                </ul>
                            </div> 
                        </li>
                    </ul>
                </div>                  
            </li>
        </ul>
    </div>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr id=""iSensorTD"" style=""display:none;"">
                <td style=""text-align:right;"">Sensor/Parameter:</td>
                <td><select name=""iSensor"" id=""iSensor"" style=""width:154px;"">
</select></td>
                <td>&nb");
            WriteLiteral(@"sp;</td>
            </tr>
            <tr id=""iSensorTD2"" style=""display:none;"">
                <td style=""text-align:right;"">From:</td>
                <td><input id=""iFrom"" type=""date"" style=""direction: ltr; text-align: left;""></td>
                <td>&nbsp;</td>
            </tr>
            <tr id=""iSensorTD3"" style=""display:none;"">
                <td style=""text-align:right;"">To:</td>
                <td><input id=""iTo"" type=""date"" style=""direction: ltr; text-align: left;""></td>
                <td>&nbsp;</td>
            </tr>
        </tbody></table>
        <input type=""button"" value=""Report"" class=""butn-search"" onclick=""search_results();"" style=""position: relative; top: -30px; left: 285px; direction: ltr; text-align: left;"">
    </div>

    </div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
