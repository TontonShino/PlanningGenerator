#pragma checksum "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a38db422853b76a273b82a2a9cf7938e777453e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employes_Details), @"mvc.1.0.view", @"/Views/Employes/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employes/Details.cshtml", typeof(AspNetCore.Views_Employes_Details))]
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
#line 1 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\_ViewImports.cshtml"
using PlanningGenerator;

#line default
#line hidden
#line 2 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\_ViewImports.cshtml"
using PlanningGenerator.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a38db422853b76a273b82a2a9cf7938e777453e", @"/Views/Employes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"622bd40be78ea308b4d3d253804caf1068cf0c35", @"/Views/_ViewImports.cshtml")]
    public class Views_Employes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PlanningGenerator.Models.Pln.Employe>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(90, 196, true);
            WriteLiteral("<div class=\"container\">\r\n    <h2>Détails</h2>\r\n\r\n    <div class=\"container-fluid\">\r\n        <h4>Employé</h4>\r\n        <hr />\r\n        <dl class=\"dl-horizontal\">\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(287, 39, false);
#line 14 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Nom));

#line default
#line hidden
            EndContext();
            BeginContext(326, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(382, 35, false);
#line 17 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayFor(model => model.Nom));

#line default
#line hidden
            EndContext();
            BeginContext(417, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(473, 42, false);
#line 20 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Prenom));

#line default
#line hidden
            EndContext();
            BeginContext(515, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(571, 38, false);
#line 23 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayFor(model => model.Prenom));

#line default
#line hidden
            EndContext();
            BeginContext(609, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(665, 47, false);
#line 26 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.TypeEmp.Nom));

#line default
#line hidden
            EndContext();
            BeginContext(712, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(768, 43, false);
#line 29 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayFor(model => model.TypeEmp.Nom));

#line default
#line hidden
            EndContext();
            BeginContext(811, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(867, 51, false);
#line 32 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.TypeEmp.NbHeure));

#line default
#line hidden
            EndContext();
            BeginContext(918, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(974, 47, false);
#line 35 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayFor(model => model.TypeEmp.NbHeure));

#line default
#line hidden
            EndContext();
            BeginContext(1021, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(1077, 48, false);
#line 38 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.TypeEmp.Half));

#line default
#line hidden
            EndContext();
            BeginContext(1125, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(1181, 44, false);
#line 41 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
           Write(Html.DisplayFor(model => model.TypeEmp.Half));

#line default
#line hidden
            EndContext();
            BeginContext(1225, 85, true);
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n    <div class=\"btn-group\">\r\n        ");
            EndContext();
            BeginContext(1310, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cac6a5e892c845e5b8caf588aa804fd8", async() => {
                BeginContext(1380, 8, true);
                WriteLiteral("Modifier");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Employes\Details.cshtml"
                               WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1392, 11, true);
            WriteLiteral(" \r\n        ");
            EndContext();
            BeginContext(1403, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "188ea889a4834f8aacabc2432861ba51", async() => {
                BeginContext(1448, 17, true);
                WriteLiteral("Retour à la liste");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1469, 20, true);
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PlanningGenerator.Models.Pln.Employe> Html { get; private set; }
    }
}
#pragma warning restore 1591
