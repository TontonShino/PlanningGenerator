#pragma checksum "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69b10532279357d00ff3eb8ac67d92aeb822b61b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GroupEmps_Gest), @"mvc.1.0.view", @"/Views/GroupEmps/Gest.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/GroupEmps/Gest.cshtml", typeof(AspNetCore.Views_GroupEmps_Gest))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69b10532279357d00ff3eb8ac67d92aeb822b61b", @"/Views/GroupEmps/Gest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"622bd40be78ea308b4d3d253804caf1068cf0c35", @"/Views/_ViewImports.cshtml")]
    public class Views_GroupEmps_Gest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PlanningGenerator.Models.Pln.GroupEmp>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddEmp", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "GroupEmps", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveEmp", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
   
    ViewData["Title"] ="Gestion Groupe employés" ;

#line default
#line hidden
            BeginContext(119, 43, true);
            WriteLiteral("\r\n    <div class=\"container\">\r\n        <h4>");
            EndContext();
            BeginContext(163, 17, false);
#line 7 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(180, 226, true);
            WriteLiteral("</h4>\r\n    </div>\r\n    <!--Section information du modèle-->\r\n    <div class=\"container\">\r\n        <h4>Groupe</h4>\r\n        <i class=\"fas fa-users\"></i>\r\n\r\n        <dl>\r\n            <dt>Identifiant Groupe</dt>\r\n            <dd>");
            EndContext();
            BeginContext(407, 16, false);
#line 16 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
           Write(ViewBag.Group.Id);

#line default
#line hidden
            EndContext();
            BeginContext(423, 59, true);
            WriteLiteral("</dd>\r\n            <dt>Nom du groupe</dt>\r\n            <dd>");
            EndContext();
            BeginContext(483, 18, false);
#line 18 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
           Write(ViewBag.Group.Name);

#line default
#line hidden
            EndContext();
            BeginContext(501, 551, true);
            WriteLiteral(@"</dd>
        </dl>
        <hr />
    </div>
    

    <!--Section des employés à ajouter-->
    <div class=""container"">
  

        <table class=""table table-hover table-sm "">
            <thead>
                <tr>
                    <th colspan=""12"">Employé à rajouter</th>
                </tr>
                <tr>
                    <th scope=""col"">Nom</th>
                    <th scope=""col"">Prénom</th>
                    <th scope=""col"">Action</th>
                </tr>

            </thead>
            <tbody>
");
            EndContext();
#line 41 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
                 foreach (var i in ViewBag.NoReg)
                {
                    

#line default
#line hidden
            BeginContext(1144, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1160, 521, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07281732f899464b8afceeda07aba631", async() => {
                BeginContext(1213, 56, true);
                WriteLiteral("\r\n                    <tr>\r\n                        <td>");
                EndContext();
                BeginContext(1270, 5, false);
#line 46 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
                       Write(i.Nom);

#line default
#line hidden
                EndContext();
                BeginContext(1275, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1311, 8, false);
#line 47 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
                       Write(i.Prenom);

#line default
#line hidden
                EndContext();
                BeginContext(1319, 76, true);
                WriteLiteral("</td>\r\n                        \r\n                        <input name=\"IdEmp\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1395, "\"", 1408, 1);
#line 49 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
WriteAttributeValue("", 1403, i.Id, 1403, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1409, 67, true);
                WriteLiteral(" type=\"hidden\" />\r\n                        <input name=\"IdGroupEmp\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1476, "\"", 1502, 2);
#line 50 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
WriteAttributeValue("", 1484, ViewBag.Group.Id, 1484, 17, false);

#line default
#line hidden
                WriteAttributeValue(" ", 1501, "", 1502, 1, true);
                EndWriteAttribute();
                BeginContext(1503, 171, true);
                WriteLiteral(" type=\"hidden\" />\r\n                        <td><button type=\"submit\" class=\"btn btn-success\">Ajouter au groupe</button></td>\r\n\r\n                    </tr>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1681, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 55 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
                }

#line default
#line hidden
            BeginContext(1702, 559, true);
            WriteLiteral(@"            </tbody>
        </table>
        <hr />
    </div>

    <!--Section des employés déjà ajoutéé-->
    <div class=""container"">
        

        <table class=""table table-hover table-sm "">
            <thead>
                <tr>
                    <th colspan=""12"">Liste des employés ajoutés</th>
                </tr>
                <tr>
                    <th scope=""col"">Nom</th>
                    <th scope=""col"">Prénom</th>
                    <th scope=""col"">Action</th>
                </tr>
            </thead>

");
            EndContext();
#line 77 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
             foreach (var l in Model)
            {

#line default
#line hidden
            BeginContext(2315, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2327, 481, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cd3e45f733e4c7a88020553bb38ced3", async() => {
                BeginContext(2383, 66, true);
                WriteLiteral("\r\n                <tr>\r\n                    <input name=\"toRemove\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2449, "\"", 2462, 1);
#line 81 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
WriteAttributeValue("", 2457, l.Id, 2457, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2463, 58, true);
                WriteLiteral(" type=\"hidden\"/>\r\n                    <input name=\"idGest\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2521, "\"", 2546, 1);
#line 82 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
WriteAttributeValue("", 2529, ViewBag.Group.Id, 2529, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2547, 42, true);
                WriteLiteral(" type=\"hidden\"/>\r\n                    <td>");
                EndContext();
                BeginContext(2590, 13, false);
#line 83 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
                   Write(l.Employe.Nom);

#line default
#line hidden
                EndContext();
                BeginContext(2603, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(2635, 16, false);
#line 84 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
                   Write(l.Employe.Prenom);

#line default
#line hidden
                EndContext();
                BeginContext(2651, 150, true);
                WriteLiteral("</td>\r\n                    <td><button type=\"submit\" class=\"btn btn-danger\">Retirer du groupe</button></td>\r\n\r\n\r\n\r\n                </tr>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2808, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 91 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\GroupEmps\Gest.cshtml"
            }

#line default
#line hidden
            BeginContext(2825, 48, true);
            WriteLiteral("        </table>\r\n        <hr />\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PlanningGenerator.Models.Pln.GroupEmp>> Html { get; private set; }
    }
}
#pragma warning restore 1591
