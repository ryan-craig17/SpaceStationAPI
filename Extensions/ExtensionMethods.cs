
namespace SpaceStationAPI.Extensions
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static double ToDoubleOrZero(this string possibleDouble)
        {
            return double.TryParse(possibleDouble, out double result) ? result : 0;
        }

        public static Uri ToUriOrNull(this string possibleUri)
        {
            return Uri.TryCreate(possibleUri, UriKind.Absolute, out Uri result) ? result : null;
        }
    }
}
