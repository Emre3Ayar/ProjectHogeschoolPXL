using HogeschoolPXL.ViewModels;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes = "student-card-view-model")]
    public class StudentCardTagHelper : TagHelper
    {
        public StudentCard StudentCardViewModel { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = $@"<div class = 'card'>";
            content += $@"<h4 class = 'card-title'>{StudentCardViewModel.Naam}</h4>";
            content += $@"<p class = 'card-position'>{StudentCardViewModel.Voornaam}</p>";
            content += $@"<p class = 'card-description'>{StudentCardViewModel.Email}</p>";
            output.TagName = "div";
            output.Content.SetHtmlContent(content);
        }
    }
}
