#pragma checksum "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\Components\CollectorOptions\WifiCollectorOptions.Razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "710454f826fd2b4a70bbc73c1b0b90df279da6303d5754416176a7bf74bd1a2d"
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
    public partial class WifiCollectorOptions : global::Microsoft.AspNetCore.Components.ComponentBase
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
            __builder.AddAttribute(8, "id", "enableWifiCollectionCheckbox");
            __builder.AddAttribute(9, "checked", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 6 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\Components\CollectorOptions\WifiCollectorOptions.Razor"
                                                                                                     appData.CollectOptions.EnableWifiCollector

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => appData.CollectOptions.EnableWifiCollector = __value, appData.CollectOptions.EnableWifiCollector));
            __builder.SetUpdatesAttributeName("checked");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n            ");
            __builder.AddMarkupContent(12, "<label class=\"form-check-label\" for=\"enableWifiCollectionCheckbox\">Enable Wi-Fi Collector</label>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "form-group");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "form-check");
            __builder.OpenElement(18, "input");
            __builder.AddAttribute(19, "type", "checkbox");
            __builder.AddAttribute(20, "class", "form-check-input");
            __builder.AddAttribute(21, "id", "enableWifiPasswordCollectionCheckbox");
            __builder.AddAttribute(22, "checked", global::Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 12 "D:\GIT\ASA-DevopsUsingCopilot\AttackSurfaceAnalyzerDevopsUsingCopilot\Cli\Components\CollectorOptions\WifiCollectorOptions.Razor"
                                                                                                             appData.CollectOptions.GatherWifiPasswords

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(23, "onchange", global::Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => appData.CollectOptions.GatherWifiPasswords = __value, appData.CollectOptions.GatherWifiPasswords));
            __builder.SetUpdatesAttributeName("checked");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n            ");
            __builder.AddMarkupContent(25, "<label class=\"form-check-label\" for=\"enableWifiPasswordCollectionCheckbox\">Enable Password Collection</label>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.CST.AttackSurfaceAnalyzer.Cli.AppData appData { get; set; }
    }
}
#pragma warning restore 1591
