#pragma checksum "E:\DotNet\ProjectPrep_MVC\Music Store MVC Practice Project\MusicStore\Views\Shared\_albumThumbnail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c271d631ab157065e7659fea71b4574b8c9a1c3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__albumThumbnail), @"mvc.1.0.view", @"/Views/Shared/_albumThumbnail.cshtml")]
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
#nullable restore
#line 1 "E:\DotNet\ProjectPrep_MVC\Music Store MVC Practice Project\MusicStore\Views\_ViewImports.cshtml"
using MusicStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\DotNet\ProjectPrep_MVC\Music Store MVC Practice Project\MusicStore\Views\_ViewImports.cshtml"
using MusicStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c271d631ab157065e7659fea71b4574b8c9a1c3e", @"/Views/Shared/_albumThumbnail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b8018c2a0b0564885bf042b2edba49f4f4d24c4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__albumThumbnail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlbumModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n<div class=\"card mb-4 shadow-sm\">\n    <img src=\"/images/grey background.jpg\" class=\"img-fluid shadow rounded\" />\n    <div class=\"card-body\">\n        <h3 class=\"card-text\">");
#nullable restore
#line 7 "E:\DotNet\ProjectPrep_MVC\Music Store MVC Practice Project\MusicStore\Views\Shared\_albumThumbnail.cshtml"
                          Write(string.IsNullOrEmpty(Model.Title) ? "Name is not available" : Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n\n    </div>\n</div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlbumModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
