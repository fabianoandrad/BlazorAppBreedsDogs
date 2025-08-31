using BlazorAppBreedsDogs.Models;
using BlazorAppBreedsDogs.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Color = MudBlazor.Color;



namespace BlazorAppBreedsDogs.Components.Pages
{
    public partial class BreedsDogs : ComponentBase
    {
        private BreedCard BreedCardRef;

        [Inject]
        public BreedsDogsServices BreedsDogsServices { get; set; }

        public bool isVisible { get; set; } = true;
        public bool loading { get; set; }
        public string? selectedBreedName { get; set; }

        private int selectedBreedId { get; set; }

        List<BreedDog> allBreedsDogs { get; set; } = new List<BreedDog>();
        List<BreedsNames> breedsNames { get; set; } = new List<BreedsNames>();

      
        protected override async Task OnInitializedAsync()
        {
            loading = true;
            allBreedsDogs = await BreedsDogsServices.GetAllBreeedsDogs();
            if (allBreedsDogs != null && allBreedsDogs.Count() != 0)
            {
                //TODO: enviar aqui a lista allBreedsDogs pro componente BreedCard

                breedsNames = allBreedsDogs.Select(b => new BreedsNames { Id = b.Id, BreedName = b.BreedName }).ToList();

                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            loading = false;
        }

        public async Task onChangeBreedName(string breedName)
        {
            if (breedName == null)
            {
                selectedBreedId = 0;
                selectedBreedName = "";
                await BreedCardRef.GetAllBreeds();
                return;
            }

            BreedsNames selectedBreed = breedsNames.Where(n => n.BreedName == breedName).FirstOrDefault();

            selectedBreedId = selectedBreed.Id;
            selectedBreedName = selectedBreed.BreedName;
            await BreedCardRef.GetBreedFiltered(selectedBreedId);
        }

        private async Task<IEnumerable<string>> Search(string value, CancellationToken token)
        {
            if (string.IsNullOrEmpty(value)) return breedsNames.Select(v => v.BreedName);
            var selectedBreed = breedsNames.Where(v => v.BreedName.Contains(value, StringComparison.InvariantCultureIgnoreCase));
            return selectedBreed.Select(v => v.BreedName);
        }
    }
}
 