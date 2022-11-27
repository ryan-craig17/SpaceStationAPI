using SpaceStationAPI.Models.Domain;
using SpaceStationAPI.Models.View;

namespace SpaceStationAPI.Transforms
{
    public static class StarWarsTransformer
    {
        public static StarWarsFilmView DomainToView(StarWarsFilm starWarsFilm)
        {
            var result = new StarWarsFilmView
            {
                IsErrorResponse = starWarsFilm.IsErrorResponse,
                ErrorMessage = starWarsFilm.ErrorMessage,
                StatusCode = starWarsFilm.StatusCode,

                StarWarsFilm = GetFilmItem(starWarsFilm)
            };

            return result;
        }

        public static StarWarsFilmListView DomainToView(StarWarsFilmList starWarsFilms)
        {
            var filmView = new StarWarsFilmListView
            {
                Count = starWarsFilms.count,
                Next = starWarsFilms.next,
                Previous = starWarsFilms.previous,
                ErrorMessage = starWarsFilms.ErrorMessage,
                IsErrorResponse = starWarsFilms.IsErrorResponse,
                StatusCode = starWarsFilms.StatusCode,
            };

            foreach(var item in starWarsFilms.results ?? Enumerable.Empty<StarWarsFilm>())
                filmView.StarWarsFilms.Add(GetFilmItem(item));

            return filmView;
        }

        public static StarWarsPersonView DomainToView(StarWarsPerson starWarsPerson)
        {
            var result = new StarWarsPersonView
            {
                IsErrorResponse = starWarsPerson.IsErrorResponse,
                ErrorMessage = starWarsPerson.ErrorMessage,
                StatusCode = starWarsPerson.StatusCode,

                StarWarsPerson = GetPersonItem(starWarsPerson)
            };

            return result;
        }

        public static StarWarsPersonListView DomainToView(StarWarsPersonList starWarsPeople)
        {
            var peopleView = new StarWarsPersonListView
            {
                Count = starWarsPeople.count,
                Next = starWarsPeople.next,
                Previous = starWarsPeople.previous,
                ErrorMessage = starWarsPeople.ErrorMessage,
                IsErrorResponse = starWarsPeople.IsErrorResponse,
                StatusCode = starWarsPeople.StatusCode
            };

            foreach (var item in starWarsPeople.results ?? Enumerable.Empty<StarWarsPerson>())
                peopleView.StarWarsPeople.Add(GetPersonItem(item));

            return peopleView;
        }





        private static int GetIdFromURL(string url)
        {
            var id = new string((url ?? "0").Where(char.IsDigit).ToArray());

            return Convert.ToInt32(id);
        }

        private static StarWarsFilmItem GetFilmItem(StarWarsFilm starWarsFilm)
        {
            var filmItem = new StarWarsFilmItem
            {
                Id = GetIdFromURL(starWarsFilm.url),
                Created = starWarsFilm.created,
                Director = starWarsFilm.director,
                Edited = starWarsFilm.edited,
                EpisodeId = starWarsFilm.episode_id,
                OpeningCrawl = starWarsFilm.opening_crawl,
                Producer = starWarsFilm.producer,
                ReleaseDate = DateTime.TryParse(starWarsFilm.release_date, out var dateRelease) ? dateRelease : null,
                Title = starWarsFilm.title,
                Url = Uri.TryCreate(starWarsFilm.url, UriKind.Absolute, out var filmURL) ? filmURL : null
            };

            foreach (var url in starWarsFilm.characters ?? Enumerable.Empty<string>())
                filmItem.Characters.Add(GetIdFromURL(url));

            foreach (var url in starWarsFilm.planets ?? Enumerable.Empty<string>())
                filmItem.Planets.Add(GetIdFromURL(url));

            foreach (var url in starWarsFilm.species ?? Enumerable.Empty<string>())
                filmItem.Species.Add(GetIdFromURL(url));

            foreach (var url in starWarsFilm.starships ?? Enumerable.Empty<string>())
                filmItem.Starships.Add(GetIdFromURL(url));

            foreach (var url in starWarsFilm.vehicles ?? Enumerable.Empty<string>())
                filmItem.Vehicles.Add(GetIdFromURL(url));

            return filmItem;
        }

        private static StarWarsPersonItem GetPersonItem(StarWarsPerson starWarsPerson)
        {
            var personItem = new StarWarsPersonItem
            {
                Id = GetIdFromURL(starWarsPerson.url),
                Name = starWarsPerson.name,
                Gender = starWarsPerson.gender,
                BirthYear = starWarsPerson.birth_year,
                HomeWorldId = GetIdFromURL(starWarsPerson.homeworld),
                Height_cm = double.TryParse(starWarsPerson.height, out var personHeight) ? personHeight : 0,
                Mass_kg = double.TryParse(starWarsPerson.mass, out var personMass) ? personMass : 0,
                HairColor = starWarsPerson.hair_color,
                SkinColor = starWarsPerson.skin_color,
                EyeColor = starWarsPerson.eye_color,
                Created = starWarsPerson.created,
                Edited = starWarsPerson.edited,
                Url = Uri.TryCreate(starWarsPerson.url, UriKind.Absolute, out var personURL) ? personURL : null
            };

            foreach (var url in starWarsPerson.films ?? Enumerable.Empty<string>())
                personItem.Films.Add(GetIdFromURL(url));

            foreach (var url in starWarsPerson.species ?? Enumerable.Empty<string>())
                personItem.Species.Add(GetIdFromURL(url));

            foreach (var url in starWarsPerson.starships ?? Enumerable.Empty<string>())
                personItem.Starships.Add(GetIdFromURL(url));

            foreach (var url in starWarsPerson.vehicles ?? Enumerable.Empty<string>())
                personItem.Vehicles.Add(GetIdFromURL(url));

            return personItem;
        }
    }
}
