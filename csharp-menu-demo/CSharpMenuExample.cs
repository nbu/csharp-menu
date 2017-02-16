namespace CSharp.Console.Menu.Example
{
    internal class CSharpMenuExample
    {
        public static void Main(string[] args)
        {
            var menu = new Menu("Calculator", "Do simple arythmetic");
            menu.AddMenuItem(new SumMenuItem());
            menu.AddMenuItem(new StringLengthMenuItem());
            menu.AddMenuItem(new XorMenuItem());
            menu.Start();
        }
    }
}
