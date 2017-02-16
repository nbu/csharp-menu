using System;

namespace CSharp.Console.Menu
{
    public class ExitMenuItem : MenuItem
    {
        public ExitMenuItem() : base("Exit")
        {
        }

        public override void Handler(MenuCallValues values)
        {
            Environment.Exit(0);
        }
    }
}