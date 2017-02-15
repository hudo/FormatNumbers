namespace HumanNumbers
{
    internal class Helpers
    {
        public static string Pluralize(long count, string text, string plural = "s")
        {
            return count == 1 ? text : text + plural;
        }
    } 
}