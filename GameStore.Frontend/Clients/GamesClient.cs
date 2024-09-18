using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GamesClient
    {
        private readonly HttpClient _httpClient;
        public GamesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //private readonly List<GameSummary> _gameSummaries =
        //    [
        //        new GameSummary
        //        {
        //            Id = 1,
        //            Name = "Street Fighter II",
        //            Genre = "Fighting",
        //            Price = 19.99M,
        //            ReleaseDate = new DateOnly(1992, 7, 15)
        //        },
        //        new GameSummary
        //        {
        //            Id = 2,
        //            Name = "Final Fantasy XIV",
        //            Genre = "Roleplaying",
        //            Price = 59.99M,
        //            ReleaseDate = new DateOnly(2010, 9, 30)
        //        },
        //        new GameSummary
        //        {
        //            Id = 3,
        //            Name = "FIFA 23",
        //            Genre = "Sports",
        //            Price = 69.99M,
        //            ReleaseDate = new DateOnly(2022, 9, 27)
        //        }
        //    ];

        //private readonly Genre[] _genres = new GenresClient(httpClient).GetGenres();

        public async Task<GameSummary[]> GetGamesAsync()
        {
            return await _httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
        }

        public async Task AddGameAsync(GameDetails gameDetails)
        {
            //Genre genre = GetGenreById(gameDetails.GenreId);

            //_gameSummaries.Add(new GameSummary
            //{
            //    Id = _gameSummaries.Count + 1,
            //    Name = gameDetails.Name,
            //    Genre = genre.Name,
            //    Price = gameDetails.Price,
            //    ReleaseDate = gameDetails.ReleaseDate
            //});

            await _httpClient.PostAsJsonAsync("games", gameDetails);
        }

        public async Task<GameDetails> GetGameAsync(int id)
        {
            //GameSummary gameSummary = GetGameSummaryById(id);

            //var genre = _genres.Single(genre => string.Equals(genre.Name, gameSummary.Genre, StringComparison.OrdinalIgnoreCase));

            //return new GameDetails
            //{
            //    Id = gameSummary.Id,
            //    Name = gameSummary.Name,
            //    GenreId = genre.Id.ToString(),
            //    Price = gameSummary.Price,
            //    ReleaseDate = gameSummary.ReleaseDate
            //};

            return await _httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ??
                throw new Exception("Could not find game!");
        }

        public async Task UpdateGameAsync(GameDetails gameDetails)
        {
            //Genre genre = GetGenreById(gameDetails.GenreId);
            //GameSummary existingGameSummary = GetGameSummaryById(gameDetails.Id);

            //existingGameSummary.Name = gameDetails.Name;
            //existingGameSummary.Genre = genre.Name;
            //existingGameSummary.Price = gameDetails.Price;
            //existingGameSummary.ReleaseDate = gameDetails.ReleaseDate;

            await _httpClient.PutAsJsonAsync($"games/{gameDetails.Id}", gameDetails);
        }

        public async Task DeleteGameAsync(int id)
        {
            //GameSummary existingGameSummary = GetGameSummaryById(id);
            //_gameSummaries.Remove(existingGameSummary);

            await _httpClient.DeleteAsync($"games/{id}");
        }

        //private GameSummary GetGameSummaryById(int id)
        //{
        //    GameSummary? gameSummary = _gameSummaries.Find(gameSummary => gameSummary.Id == id);
        //    ArgumentNullException.ThrowIfNull(gameSummary);
        //    return gameSummary;
        //}

        //private Genre GetGenreById(string? id)
        //{
        //    ArgumentException.ThrowIfNullOrWhiteSpace(id);
        //    return _genres.Single(genre => genre.Id == int.Parse(id));
        //}
    }
}
