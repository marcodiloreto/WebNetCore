#pragma checksum "C:\Users\Marco\Desktop\academicos\Cuat4\Plataformas de desarrollo\WebNetCore\WebNetCore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf7ac267f5c5ced1ad602ec63dbf0d1cee53a72a"
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
#nullable restore
#line 1 "C:\Users\Marco\Desktop\academicos\Cuat4\Plataformas de desarrollo\WebNetCore\WebNetCore\Views\_ViewImports.cshtml"
using WebNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Marco\Desktop\academicos\Cuat4\Plataformas de desarrollo\WebNetCore\WebNetCore\Views\_ViewImports.cshtml"
using WebNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Marco\Desktop\academicos\Cuat4\Plataformas de desarrollo\WebNetCore\WebNetCore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Session;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf7ac267f5c5ced1ad602ec63dbf0d1cee53a72a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42e3c0b410a3c7dae1fed4797509efea536326a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Marco\Desktop\academicos\Cuat4\Plataformas de desarrollo\WebNetCore\WebNetCore\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Welcome!</h1>\r\n<p>Esto va a estar mucho mas lindo para la entrega final, por ahora es un front muy pedorro y el back completo</p>\r\n");
#nullable restore
#line 7 "C:\Users\Marco\Desktop\academicos\Cuat4\Plataformas de desarrollo\WebNetCore\WebNetCore\Views\Home\Index.cshtml"
  
    
    
    if (ViewBag.pay != null)
    {
        if (ViewBag.pay)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1 class=\"text-success\">Estas listo para usar FFMPEG Translator!!</h1>\r\n");
#nullable restore
#line 15 "C:\Users\Marco\Desktop\academicos\Cuat4\Plataformas de desarrollo\WebNetCore\WebNetCore\Views\Home\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1 class=\"text-danger\">Deberás validar una clave antes de poder utlizar FFMPEG Translator</h1>\r\n");
#nullable restore
#line 19 "C:\Users\Marco\Desktop\academicos\Cuat4\Plataformas de desarrollo\WebNetCore\WebNetCore\Views\Home\Index.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
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
