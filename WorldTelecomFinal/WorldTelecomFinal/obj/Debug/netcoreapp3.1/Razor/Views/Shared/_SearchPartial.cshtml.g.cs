#pragma checksum "C:\Users\aziye\Desktop\Back-End-FinalProject\WorldTelecomFinal\WorldTelecomFinal\Views\Shared\_SearchPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "156a68c021dfa0fddb3f899578581697809aed72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchPartial), @"mvc.1.0.view", @"/Views/Shared/_SearchPartial.cshtml")]
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
#line 2 "C:\Users\aziye\Desktop\Back-End-FinalProject\WorldTelecomFinal\WorldTelecomFinal\Views\_ViewImports.cshtml"
using WorldTelecomFinal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\aziye\Desktop\Back-End-FinalProject\WorldTelecomFinal\WorldTelecomFinal\Views\_ViewImports.cshtml"
using WorldTelecomFinal.ViewModels.BasketViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\aziye\Desktop\Back-End-FinalProject\WorldTelecomFinal\WorldTelecomFinal\Views\_ViewImports.cshtml"
using WorldTelecomFinal.ViewModels.HeaderViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"156a68c021dfa0fddb3f899578581697809aed72", @"/Views/Shared/_SearchPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d101437b5ed87e6af833f3a9b69ae05985c6d299", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__SearchPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\aziye\Desktop\Back-End-FinalProject\WorldTelecomFinal\WorldTelecomFinal\Views\Shared\_SearchPartial.cshtml"
     foreach (Product product in Model)
   {

#line default
#line hidden
#nullable disable
            WriteLiteral("       <li  class=\"list-group-item\" style=\"display:flex; list-style-type:none; padding:5px; color:black; border:1px solid black; width:88%; height:auto; border-radius:5px; background-color:white;\">\r\n                   \r\n        <img");
            BeginWriteAttribute("src", " src=\"", 301, "\"", 347, 2);
            WriteAttributeValue("", 307, "assets/img/productjpg/", 307, 22, true);
#nullable restore
#line 7 "C:\Users\aziye\Desktop\Back-End-FinalProject\WorldTelecomFinal\WorldTelecomFinal\Views\Shared\_SearchPartial.cshtml"
WriteAttributeValue("", 329, product.MainImage, 329, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:60px\" />\r\n                    \r\n        <p style=\"margin-top:auto; margin-bottom:auto; display:block;\">");
#nullable restore
#line 9 "C:\Users\aziye\Desktop\Back-End-FinalProject\WorldTelecomFinal\WorldTelecomFinal\Views\Shared\_SearchPartial.cshtml"
                                                                  Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n    </li>\n");
#nullable restore
#line 12 "C:\Users\aziye\Desktop\Back-End-FinalProject\WorldTelecomFinal\WorldTelecomFinal\Views\Shared\_SearchPartial.cshtml"
   }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
