using Microsoft.Maui.Storage;
using System.Text.Json;


namespace BlazorAppBreedsDogs.Services
{
    public class FavoriteBreedsService
    {
        private const string StorageKey = "favoriteBreeds";

        public List<int> GetFavorites()
        {
            var json = Preferences.Default.Get(StorageKey, "[]");
            return JsonSerializer.Deserialize<List<int>>(json) ?? new List<int>();
        }

        public void AddFavorite(int breedId)
        {
            var favorites = GetFavorites();
            if (!favorites.Contains(breedId))
            {
                favorites.Add(breedId);
                SaveFavorites(favorites);
            }
        }

        public void SaveFavorites(List<int> breedIds)
        {
            var distinctList = breedIds.Distinct().ToList();
            var json = JsonSerializer.Serialize(distinctList);
            Preferences.Default.Set(StorageKey, json);
        }

        public void RemoveFavorite(int breedId)
        {
            var favorites = GetFavorites();
            if (favorites.Contains(breedId))
            {
                favorites.Remove(breedId);
                SaveFavorites(favorites);
            }
        }

        public bool IsFavorite(int breedId)
        {
            return GetFavorites().Contains(breedId);
        }

        public void ClearFavorites()
        {
            Preferences.Default.Remove(StorageKey);
        }

    }
}
