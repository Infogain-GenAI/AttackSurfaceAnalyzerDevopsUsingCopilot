#pragma checksum "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\Components\CollectorOptions\OpenPortCollectorOptions.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5cd801ed8098fbcfc1ee91a6ace5ee7eae7ef01a205aaf3288fc34de996c545f"
// <auto-generated/>
#pragma warning disable 1591
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
    public partial class OpenPortCollectorOptions : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "form-group");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "form-check");
            __builder.OpenElement(5, "input");
            __builder.AddAttribute(6, "type", "checkbox");
            __builder.AddAttribute(7, "class", "form-check-input");
            __builder.AddAttribute(8, "id", "enableNetworkPortCollectionCheckbox");
            __builder.AddAttribute(9, "checked", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 6 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\Components\CollectorOptions\OpenPortCollectorOptions.razor"
                                                                                                            appData.CollectOptions.EnableNetworkPortCollector

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => appData.CollectOptions.EnableNetworkPortCollector = __value, appData.CollectOptions.EnableNetworkPortCollector));
            __builder.SetUpdatesAttributeName("checked");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n            ");
            __builder.AddMarkupContent(12, "<label class=\"form-check-label\" for=\"enableNetworkPortCollectionCheckbox\">Enable NetworkPort Collector</label>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.CST.AttackSurfaceAnalyzer.Cli.AppData appData { get; set; }
    }
}
#pragma warning restore 1591
