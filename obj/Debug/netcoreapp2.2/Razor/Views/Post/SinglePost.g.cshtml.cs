#pragma checksum "C:\Users\Lenovo\Desktop\NepConfess\Views\Post\SinglePost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8e59142fe26b20b2c8eafbb088157e747752c6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_SinglePost), @"mvc.1.0.view", @"/Views/Post/SinglePost.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Post/SinglePost.cshtml", typeof(AspNetCore.Views_Post_SinglePost))]
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
#line 1 "C:\Users\Lenovo\Desktop\NepConfess\Views\_ViewImports.cshtml"
using NepConfess;

#line default
#line hidden
#line 2 "C:\Users\Lenovo\Desktop\NepConfess\Views\_ViewImports.cshtml"
using NepConfess.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8e59142fe26b20b2c8eafbb088157e747752c6f", @"/Views/Post/SinglePost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19caef3230ecac71dbd1c302cf624c45712638ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_SinglePost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 21, true);
            WriteLiteral("\r\n      \r\n     \r\n  \r\n");
            EndContext();
            BeginContext(36, 65, true);
            WriteLiteral("<div class=\"jumbotron\">\r\n<h1 style=\"text-transform:Capitalize;\"> ");
            EndContext();
            BeginContext(102, 11, false);
#line 7 "C:\Users\Lenovo\Desktop\NepConfess\Views\Post\SinglePost.cshtml"
                                   Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(113, 37, true);
            WriteLiteral(" </h1>\r\n<div class=\"mb-1 text-muted\">");
            EndContext();
            BeginContext(151, 10, false);
#line 8 "C:\Users\Lenovo\Desktop\NepConfess\Views\Post\SinglePost.cshtml"
                        Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(161, 38, true);
            WriteLiteral("</div> by <i class=\"fa fa-user\"> </i> ");
            EndContext();
            BeginContext(200, 12, false);
#line 8 "C:\Users\Lenovo\Desktop\NepConfess\Views\Post\SinglePost.cshtml"
                                                                         Write(Model.Author);

#line default
#line hidden
            EndContext();
            BeginContext(212, 73, true);
            WriteLiteral("\r\n</div>\r\n<hr>\r\n \r\n<div class=\"container\" >\r\n<p style=\"text-size:2px;\">\r\n");
            EndContext();
            BeginContext(286, 27, false);
#line 14 "C:\Users\Lenovo\Desktop\NepConfess\Views\Post\SinglePost.cshtml"
Write(Html.Raw(Model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(313, 86, true);
            WriteLiteral("\r\n</p>\r\n\r\n10 <i class=\"fa fa-eye\"> </i>   10 <i class=\"fa fa-user \"> </i>\r\n </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591