#pragma checksum "C:\Abner\UDEMY\Secao18-SalesWebMvc-EntityFramework\SalesWebMVC2\SalesWebMVC\SalesWebMVC\Views\Shared\ErrorIntegrityDepatment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80b8674579e39c2ca731ca2ace8aca81331ad765"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ErrorIntegrityDepatment), @"mvc.1.0.view", @"/Views/Shared/ErrorIntegrityDepatment.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/ErrorIntegrityDepatment.cshtml", typeof(AspNetCore.Views_Shared_ErrorIntegrityDepatment))]
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
#line 1 "C:\Abner\UDEMY\Secao18-SalesWebMvc-EntityFramework\SalesWebMVC2\SalesWebMVC\SalesWebMVC\Views\_ViewImports.cshtml"
using SalesWebMVC;

#line default
#line hidden
#line 2 "C:\Abner\UDEMY\Secao18-SalesWebMvc-EntityFramework\SalesWebMVC2\SalesWebMVC\SalesWebMVC\Views\_ViewImports.cshtml"
using SalesWebMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80b8674579e39c2ca731ca2ace8aca81331ad765", @"/Views/Shared/ErrorIntegrityDepatment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a6df1509d91b065201157174002cf59bdfba603", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ErrorIntegrityDepatment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SalesWebMVC.Models.ViewModels.ErrorIGeneric>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Abner\UDEMY\Secao18-SalesWebMvc-EntityFramework\SalesWebMVC2\SalesWebMVC\SalesWebMVC\Views\Shared\ErrorIntegrityDepatment.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
            BeginContext(93, 26, true);
            WriteLiteral("\r\n<h1 class=\"text-danger\">");
            EndContext();
            BeginContext(120, 17, false);
#line 6 "C:\Abner\UDEMY\Secao18-SalesWebMvc-EntityFramework\SalesWebMVC2\SalesWebMVC\SalesWebMVC\Views\Shared\ErrorIntegrityDepatment.cshtml"
                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(137, 31, true);
            WriteLiteral("</h1>\r\n<h2 class=\"text-danger\">");
            EndContext();
            BeginContext(169, 13, false);
#line 7 "C:\Abner\UDEMY\Secao18-SalesWebMvc-EntityFramework\SalesWebMVC2\SalesWebMVC\SalesWebMVC\Views\Shared\ErrorIntegrityDepatment.cshtml"
                   Write(Model.Message);

#line default
#line hidden
            EndContext();
            BeginContext(182, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SalesWebMVC.Models.ViewModels.ErrorIGeneric> Html { get; private set; }
    }
}
#pragma warning restore 1591
