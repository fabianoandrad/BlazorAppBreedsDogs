using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppBreedsDogs.Components.Layout
{
    public partial class MainLayout
    {
        //private MudTheme _theme = new();
        private bool _isDarkMode { get; set; }
        private MudThemeProvider? _mudThemeProvider;

        // Customize theme colors if you want rather than defaults.
        // https://mudblazor.com/customization/overview#custom-themes        

        MudTheme _theme = new MudTheme()
        {
            //PaletteLight = new PaletteLight()
            //{
            //    Primary = MudBlazor.Colors.Blue.Default,
            //    Secondary = MudBlazor.Colors.Pink.Accent2,
            //    Background = "#F5F5F5",
            //    Surface = "#FFFFFF",
            //    AppbarBackground = "#1976D2",
            //    TextPrimary = "#212121",
            //    DrawerBackground = "#EEEEEE"
            //},
            //PaletteDark = new PaletteDark()
            //{
            //    Primary = MudBlazor.Colors.Blue.Lighten1,
            //    Secondary = MudBlazor.Colors.Pink.Lighten2,
            //    Background = "#121212",
            //    Surface = "#1E1E1E",
            //    AppbarBackground = "#1C1C1C", // Menu superior
            //    TextPrimary = "#CCCCCC",
            //    DrawerBackground = "#1C1C1C", // Menu lateral
            //    //LinesInputs = "#e307eb"
            //    //InputBackground = "#2A2A2A",
            //    //InputText = "#FFFFFF",
            //    //InputPlaceholder = "rgba(255,255,255,0.5)"
            //}

            //LayoutProperties = new LayoutProperties()
            //{
            //    DrawerWidthLeft = "260px",
            //    DrawerWidthRight = "300px"
            //}
        };

        bool _drawerOpen = true;

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Caso queira iniciar com modo dark
                //_isDarkMode = await _mudThemeProvider.GetSystemDarkModeAsync();
                //StateHasChanged();
            }
        }

        protected override async Task OnInitializedAsync()
        {

        }

        public string DarkLightModeButtonIcon => _isDarkMode switch
        {
            true => Icons.Material.Rounded.LightMode,
            false => Icons.Material.Outlined.DarkMode,
        };

        private async Task DarkModeToggle()
        {
            _isDarkMode = !_isDarkMode;
        }
    }
}
