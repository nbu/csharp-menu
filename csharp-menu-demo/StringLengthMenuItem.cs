namespace CSharp.Console.Menu.Example
{
    internal class StringLengthMenuItem : MenuItem
    {
        public StringLengthMenuItem() : base("String length")
        {
            AddOption(new StringMenuOption("some string", "str"));
        }

        public override void Handler(MenuCallValues values)
        {
            var str = values.GetValue("str", (string) null, typeof(string));
            System.Console.WriteLine(str.Length);
        }
    }
}