#pragma checksum "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb88ef289d19c6a0fb87a9aee072c953c9fbcd75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb88ef289d19c6a0fb87a9aee072c953c9fbcd75", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
   
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section id=""news"">
    <div class=""container section-padding"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""section-heading"">
                    <h2 class=""section-heading-h2"">WiseTime Son xəbərlər</h2>
                </div>
            </div>
        </div>
        <div class=""row justify-content-center"">
");
#nullable restore
#line 14 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
             foreach (var item in ViewBag.Posts)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-4 newsbox\">\r\n                    <div class=\"news-item\">\r\n                        <a href=\"#\" class=\"news-img\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 638, "\"", 685, 2);
            WriteAttributeValue("", 644, "/Images/TumbnailImage/", 644, 22, true);
#nullable restore
#line 19 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
WriteAttributeValue("", 666, item.TumbnailImage, 666, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 686, "\"", 692, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </a>\r\n                        <div class=\"news-info\">\r\n                            <div class=\"news-day\">\r\n");
#nullable restore
#line 23 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
                                 if (item.CreateDate == item.EditDate)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 25 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
                                  Write(item.CreateDate.ToString("dd-MMM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 26 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 29 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
                                  Write(item.EditDate.ToString("dd-MMM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 30 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <div class=\"news-item-title\">\r\n                                <a href=\"#!\">\r\n                                    <h4>");
#nullable restore
#line 34 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
                                   Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                </a>\r\n                            </div>\r\n                            <div class=\"news-item-text\">\r\n                                <p>\r\n                                    ");
#nullable restore
#line 39 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
                               Write(item.Content.Substring(0, item.Content.Substring(0, 130).LastIndexOf(" ")));

#line default
#line hidden
#nullable disable
            WriteLiteral("...\r\n                                </p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 45 "C:\Users\Ruslan-PC\source\repos\WiseTimeProject\WiseTime.UI\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
        <div class=""row"">
            <div class=""col-12 d-flex justify-content-center"">
                <div class=""bttn-row"">
                    <a href=""./blog.html"">
                        <div class=""bttn"">
                            <span>Bütün Xəbərlərə Baxın</span>
                            <i class=""material-icons""> east</i>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
