#pragma checksum "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d14c744a676747d998ad1bfd069f16799c2da2b8"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FoodCalculator.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using FoodCalculator;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\_Imports.razor"
using FoodCalculator.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\Pages\Index.razor"
using FoodCalculator.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 68 "C:\Users\Nik\RiderProjects\CostsCalculator\CostsCalculator\Pages\Index.razor"
       
    private DayInfo[] _mealsInfos;

    protected override async Task OnInitializedAsync()
    {
        _mealsInfos = await CostsService.GetRandomDaysAsync(DateTime.Now);
    }

    int _calculatedData;
    bool _editPressed;
        
    private void CalculateMeal()
    {
        _mealsInfos = CostsService.SetFilter(_mealsInfos);
        _calculatedData = _mealsInfos.Where(x => x.Day == DayType.FirstDay || x.Day == DayType.WorkDay || x.Day == DayType.LastDay).Select(c=> c.BasePay).Sum();
        _editPressed = false;
    }
    
    private void EditMeals()
    {
        _editPressed = !_editPressed;
    }
    
    private async Task RefreshMeals()
    {
        _calculatedData = 0;
        _mealsInfos = await CostsService.GetRandomDaysAsync(DateTime.Now);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private CostsService _mealsService { get; set; }
    }
}
#pragma warning restore 1591