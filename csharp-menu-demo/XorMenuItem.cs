namespace CSharp.Console.Menu.Example
{
    internal class XorMenuItem : MenuItem
    {
        public XorMenuItem() : base("XOR operation")
        {
            AddOption(new BoolMenuOption("b1", "b1"));
            AddOption(new BoolMenuOption("b2", "b2"));
        }

        public override void Handler(MenuCallValues values)
        {
            var b1 = values.GetValue("b1", false, typeof(bool));
            var b2 = values.GetValue("b2", false, typeof(bool));
            System.Console.WriteLine(b1 ^ b2);
        }
    }
}