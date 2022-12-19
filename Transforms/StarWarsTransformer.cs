using SpaceStationAPI.Extensions;
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

            foreach(var item in starWarsFilms.results.EmptyIfNull())
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

            foreach (var item in starWarsPeople.results.EmptyIfNull())
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
                Url = starWarsFilm.url.ToUriOrNull()
            };

            foreach (var url in starWarsFilm.characters.EmptyIfNull())
                filmItem.Characters.Add(GetIdFromURL(url));

            foreach (var url in starWarsFilm.planets.EmptyIfNull())
                filmItem.Planets.Add(GetIdFromURL(url));

            foreach (var url in starWarsFilm.species.EmptyIfNull())
                filmItem.Species.Add(GetIdFromURL(url));

            foreach (var url in starWarsFilm.starships.EmptyIfNull())
                filmItem.Starships.Add(GetIdFromURL(url));

            foreach (var url in starWarsFilm.vehicles.EmptyIfNull())
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
                Height_cm = starWarsPerson.height.ToDoubleOrZero(),
                Mass_kg = starWarsPerson.mass.ToDoubleOrZero(),
                HairColor = starWarsPerson.hair_color,
                SkinColor = starWarsPerson.skin_color,
                EyeColor = starWarsPerson.eye_color,
                Created = starWarsPerson.created,
                Edited = starWarsPerson.edited,
                Url = starWarsPerson.url.ToUriOrNull()
            };

            foreach (var url in starWarsPerson.films.EmptyIfNull())
                personItem.Films.Add(GetIdFromURL(url));

            foreach (var url in starWarsPerson.species.EmptyIfNull())
                personItem.Species.Add(GetIdFromURL(url));

            foreach (var url in starWarsPerson.starships.EmptyIfNull())
                personItem.Starships.Add(GetIdFromURL(url));

            foreach (var url in starWarsPerson.vehicles.EmptyIfNull())
                personItem.Vehicles.Add(GetIdFromURL(url));

            return personItem;
        }
    }
}
