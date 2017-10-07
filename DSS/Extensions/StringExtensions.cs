namespace DSS.Extensions
{
    public static class StringExtensions
    {
        public static string UpperCaseFirstLetter(this string @this)
        {
            if (string.IsNullOrEmpty(@this))
            {
                return string.Empty;
            }

            return char.ToUpper(@this[0]) + @this.Substring(1);
        }
    }
}