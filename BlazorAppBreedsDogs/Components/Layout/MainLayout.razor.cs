using BlazorAppBreedsDogs.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Colors = MudBlazor.Colors;

namespace BlazorAppBreedsDogs.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        public StateContainer StateContainer { get; set; }
        private bool _isDarkMode { get; set; } = false;
        private MudThemeProvider? _mudThemeProvider;

        // Customize theme colors if you want rather than defaults.
        // https://mudblazor.com/customization/overview#custom-themes        

        MudTheme _theme = new MudTheme()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = Colors.Blue.Lighten2,
                PrimaryContrastText = Colors.Orange.Accent3,
                Background = Colors.Shades.White,
                TextPrimary = Colors.Gray.Darken3,
                AppbarBackground = Colors.Blue.Lighten2,
                AppbarText = Colors.Gray.Darken2,
                DrawerText = Colors.Gray.Darken3,
                DrawerBackground = Colors.Shades.White,
            },
            PaletteDark = new PaletteDark()
            {
                Primary = Colors.Blue.Lighten2,
                PrimaryContrastText = Colors.LightGreen.Accent4,
                Background = Colors.Gray.Darken3,
                AppbarText = Colors.Gray.Darken1
            },
            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            }
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
            StateContainer.IsDarkMode = _isDarkMode;
        }

        public string DarkLightModeButtonIcon => _isDarkMode switch
        {
            true => Icons.Material.Rounded.LightMode,
            false => Icons.Material.Outlined.DarkMode,
        };

        private async Task DarkModeToggle()
        {
            _isDarkMode = !_isDarkMode;
            StateContainer.IsDarkMode = _isDarkMode;
        }
    }
}
