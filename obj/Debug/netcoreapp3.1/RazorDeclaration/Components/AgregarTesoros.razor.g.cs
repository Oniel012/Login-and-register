// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TesorosApp.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using TesorosApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\_Imports.razor"
using TesorosApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\Components\AgregarTesoros.razor"
using TesorosApp.Data;

#line default
#line hidden
#nullable disable
    public partial class AgregarTesoros : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "C:\Users\timon\Desktop\Loginparcial\TesorosApp\Components\AgregarTesoros.razor"
 
    [Parameter]
    public Guid Uid { get; set; }
    private Tesoros tesoro = new Tesoros
    {
        Id = Guid.NewGuid(),
        Fecha_t = DateTime.Today
    };
    private Coordenadas coord = new Coordenadas
    {
        Id = Guid.NewGuid()
    };

    private async Task HandleSubmit()
    {
        tesoro.Cordenadas = coord;
        var status = await TS.SetTreasure(tesoro);
        if (status)
        {
            tesoro = new Tesoros
            {
                Id = Guid.NewGuid(),
                Fecha_t = DateTime.Today
            };
            coord = new Coordenadas
            {
                Id = Guid.NewGuid()
            };
            StateHasChanged();
        }
        Console.WriteLine(status);

    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            if (Uid != null)
            {
                coord.Tid = tesoro.Id;
                coord.Uid = Uid;
                tesoro.Uid = Uid;
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ITesoroService TS { get; set; }
    }
}
#pragma warning restore 1591