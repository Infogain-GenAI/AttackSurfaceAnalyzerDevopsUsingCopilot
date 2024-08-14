// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Microsoft.CST.AttackSurfaceAnalyzer.Cli.Components.CollectorOptions
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Cli.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Types;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.CST.OAT.Blazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.CST.OAT.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Cli.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Cli.Components.States;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Objects;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\_Imports.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Collectors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\Components\CollectorOptions\FileCollectorOptions.razor"
using Microsoft.CST.AttackSurfaceAnalyzer.Cli;

#line default
#line hidden
#nullable disable
    public partial class FileCollectorOptions : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 66 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\Components\CollectorOptions\FileCollectorOptions.razor"
      
    Helper.GlowClass directorySelectElementGlowClass = new Helper.GlowClass();

    string SelectedDirectoryInput = string.Empty;
    int SelectedDirectoryTop;

    void RemoveInputFromList()
    {
        if (appData.CollectOptions.SelectedDirectories.Count() > SelectedDirectoryTop)
        {
            appData.CollectOptions.SelectedDirectories = appData.CollectOptions.SelectedDirectories.Except(appData.CollectOptions.SelectedDirectories.Skip(SelectedDirectoryTop-1).Take(1));
            Helper.ToggleGlow(() => InvokeAsync(StateHasChanged), directorySelectElementGlowClass, false);
        }
    }

    void PushInputToList()
    {
        appData.CollectOptions.SelectedDirectories = appData.CollectOptions.SelectedDirectories.Union(new string[] { SelectedDirectoryInput });
        SelectedDirectoryTop = appData.CollectOptions.SelectedDirectories.Count() - 1;
        Helper.ToggleGlow(() => InvokeAsync(StateHasChanged), directorySelectElementGlowClass, true);
        SelectedDirectoryInput = string.Empty;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.CST.AttackSurfaceAnalyzer.Cli.AppData appData { get; set; }
    }
}
#pragma warning restore 1591
