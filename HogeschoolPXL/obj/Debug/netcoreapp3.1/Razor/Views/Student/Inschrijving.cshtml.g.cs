#pragma checksum "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b050933e956e89eb710106171c520600ad5fde63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Inschrijving), @"mvc.1.0.view", @"/Views/Student/Inschrijving.cshtml")]
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
#line 1 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\_ViewImports.cshtml"
using HogeschoolPXL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\_ViewImports.cshtml"
using HogeschoolPXL.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b050933e956e89eb710106171c520600ad5fde63", @"/Views/Student/Inschrijving.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cf08dbac3995c3f588ffc748a1ab203173a7093", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Inschrijving : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HogeschoolPXL.ViewModels.StudentCard>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Student inschrijven</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
       Write(Html.DisplayNameFor(model => model.Naam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
       Write(Html.DisplayFor(model => model.Naam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
       Write(Html.DisplayNameFor(model => model.Voornaam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
       Write(Html.DisplayFor(model => model.Voornaam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 28 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 31 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n<student-card");
            BeginWriteAttribute("student-card-view-model", " student-card-view-model=\"", 832, "\"", 864, 1);
#nullable restore
#line 36 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
WriteAttributeValue("", 858, Model, 858, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></student-card>\r\n\r\n<div>\r\n    ");
#nullable restore
#line 39 "C:\Users\emer-\OneDrive\Documenten\CWeb\ProjectHogeschoolPXL\HogeschoolPXL\Views\Student\Inschrijving.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.StudentId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b050933e956e89eb710106171c520600ad5fde636765", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HogeschoolPXL.ViewModels.StudentCard> Html { get; private set; }
    }
}
#pragma warning restore 1591