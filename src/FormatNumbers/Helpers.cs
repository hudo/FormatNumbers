namespace FormatNumbers
{
    internal class Helpers
    {
        public static string Pluralize(int count, string text, string plural = "s")
        {
            return count == 1 ? text : text + plural;
        }
    } 
}