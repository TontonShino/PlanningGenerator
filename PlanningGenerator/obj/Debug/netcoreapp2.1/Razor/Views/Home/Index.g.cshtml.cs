#pragma checksum "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1a2461ba12a17ae6908e9689af1d71d7809db7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1a2461ba12a17ae6908e9689af1d71d7809db7e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"622bd40be78ea308b4d3d253804caf1068cf0c35", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\bouba\OneDrive\Documents\PlanningGenerator\PlanningGenerator\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Page d'accueil";

#line default
#line hidden
            BeginContext(50, 1758, true);
            WriteLiteral(@"
<div class=""container"">
    <h3>Planning Generator - Générateur de Planning</h3>
    <div class=""row"">
        <div class=""col-md-6 offset-md-3"">
            <iframe src=""https://giphy.com/embed/EPlff1MynUFyM"" width=""480"" height=""480"" frameBorder=""0"" class=""giphy-embed"" allowFullScreen></iframe><p><a href=""https://giphy.com/gifs/work-simpsons-genius-EPlff1MynUFyM"">via GIPHY</a></p>
        </div>
    </div>
</div>
<div class=""container"">
    <div class=""row align-items-center"">
        <h4>Présentation de l'application</h4>
    </div>
    <div class=""row"">
        <p class=""col"">L'application vous propose de générer des plannings comprenant une tranche de jour (ex: du Lund au Jeudi ou Lundi au Dimanche, etc ...) en choisissant également une tranche horaire.
        </p>
        </div>
    <div class=""row align-items-center"">
        <p class=""col"">
            Pour générer un planning il vous faudra passer des étapes:
        </p>

    </div>
    <div class=""row"">
        <ul class=""a");
            WriteLiteral(@"lign-items-center"">
            <li>Créer les types d'employé [exemple : Temps plein : 7h , demi heure comprise.]</li>
            <li>Créer des employés/personnes</li>
            <li>Créer un groupe d'employés</li>
            <li>Attribuer les employés au groupe concerné</li>

            <li>Créer des postes[de travail]</li>
            <li>Créer un groupe de postes</li>
            <li>Attribuer les postes au groupe concerné</li>
        </ul>
        <p>Vous pourrez ensuite créer un planning et générer ainsi automatiquement le planning en fonction des horaires et autres paramètres</p>
        <p>L'un des objectifs sera également de pouvoir exporter sous Google Agenda, csv etc ... </p>
    </div>

</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
