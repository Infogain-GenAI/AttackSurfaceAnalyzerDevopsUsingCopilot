#pragma checksum "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1a3bbf3ad53a6bf22486d385aa206d75cfeb79d971d8afc72c868d992b46627c"
// <auto-generated/>
#pragma warning disable 1591
namespace Microsoft.CST.AttackSurfaceAnalyzer.Cli.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Cli.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Types;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.CST.OAT.Blazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.CST.OAT.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Cli.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Cli.Components.States;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Objects;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Collectors;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/configure")]
    public partial class Configure : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h4>Manage Runs</h4>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "container-fluid bg-custom py-1");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "form-inline py-1");
            __builder.AddMarkupContent(5, "<label class=\"mr-2\" for=\"CollectionRunsSelect\">Collection Runs:</label>\r\n        ");
            __builder.OpenElement(6, "select");
            __builder.AddAttribute(7, "class", "form-control mr-3");
            __builder.AddAttribute(8, "id", "CollectionRunsSelect");
            __builder.AddAttribute(9, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 8 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
                                                                           SelectedRun

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => SelectedRun = __value, SelectedRun));
            __builder.SetUpdatesAttributeName("value");
#nullable restore
#line 9 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
             for (int i = 0; i < Runs.Count; i++)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(11, "option");
            __builder.AddAttribute(12, "value", 
#nullable restore
#line 11 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
                                i

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 11 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
__builder.AddContent(13, Runs[i]);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 12 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n        ");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "class", "btn btn-primary");
            __builder.AddAttribute(17, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
                                                  DeleteSelected

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(18, "Delete Run");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n    ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "form-inline py-1");
            __builder.AddMarkupContent(22, "<label class=\"mr-2\" for=\"CompareRunsSelect\">Comparison Runs:</label>\r\n        ");
            __builder.OpenElement(23, "select");
            __builder.AddAttribute(24, "class", "form-control mr-3");
            __builder.AddAttribute(25, "id", "CompareRunsSelect");
            __builder.AddAttribute(26, "value", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 18 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
                                                                        SelectedCompareRun

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(27, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => SelectedCompareRun = __value, SelectedCompareRun));
            __builder.SetUpdatesAttributeName("value");
#nullable restore
#line 19 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
             for (int i = 0; i < CompareRuns.Count; i++)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(28, "option");
            __builder.AddAttribute(29, "value", 
#nullable restore
#line 21 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
                                i

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 21 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
__builder.AddContent(30, CompareRuns[i]);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 22 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n        ");
            __builder.OpenElement(32, "button");
            __builder.AddAttribute(33, "class", "btn btn-primary");
            __builder.AddAttribute(34, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
                                                  DeleteSelectedCompare

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(35, "Delete Run");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "D:\GIT\ASA-Devops\AttackSurfaceAnalyzerDevops\Cli\Pages\Configure.razor"
       
    public int SelectedRun { get; set; }

    public int SelectedCompareRun { get; set; }

    public List<string> Runs = AttackSurfaceAnalyzerClient.DatabaseManager.GetRuns();

    public List<(string firstRunId, string secondRunId, string analysesHash, RUN_STATUS runStatus)> CompareRuns = AttackSurfaceAnalyzerClient.DatabaseManager.GetCompareRuns();

    public void DeleteSelected()
    {
        AttackSurfaceAnalyzerClient.DatabaseManager.DeleteRun(Runs[SelectedRun]);
        Runs = AttackSurfaceAnalyzerClient.DatabaseManager.GetRuns();
        this.StateHasChanged();
    }

    public void DeleteSelectedCompare()
    {
        AttackSurfaceAnalyzerClient.DatabaseManager.DeleteCompareRun(CompareRuns[SelectedCompareRun].firstRunId, CompareRuns[SelectedCompareRun].secondRunId, CompareRuns[SelectedCompareRun].analysesHash);
        CompareRuns = AttackSurfaceAnalyzerClient.DatabaseManager.GetCompareRuns();
        this.StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.CST.AttackSurfaceAnalyzer.Cli.AppData appData { get; set; }
    }
}
#pragma warning restore 1591
