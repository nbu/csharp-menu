namespace CSharp.Console.Menu.Example
{
    internal class SumMenuItem : MenuItem
    {
        public SumMenuItem() : base("Sum a + b")
        {
            AddOption(new IntegerMenuOption("a", "a"));
            AddOption(new IntegerMenuOption("b", "b"));
        }

        public override void Handler(MenuCallValues values)
        {
            var a = values.GetValue("a", 0, typeof(int));
            var b = values.GetValue("b", 0, typeof(int));
            System.Console.WriteLine(a + b);
        }
    }
}