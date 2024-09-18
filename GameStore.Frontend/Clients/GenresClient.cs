using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GenresClient
    {
        private readonly HttpClient _httpClient;
        public GenresClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //private readonly Genre[] _genres =
        //    [
        //        new Genre
        //        {
        //            Id = 1,
        //            Name = "Fighting",
        //        },
        //        new Genre
        //        {
        //            Id = 2,
        //            Name = "Roleplaying",
        //        },
        //        new Genre
        //        {
        //            Id = 2,
        //            Name = "Sports",
        //        },
        //        new Genre
        //        {
        //            Id = 4,
        //            Name = "Racing",
        //        },
        //        new Genre
        //        {
        //            Id = 5,
        //            Name = "Kids and Family",
        //        }
        //    ];

        public async Task<Genre[]> GetGenresAsync()
        {
            return await _httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
        }
    }
}
