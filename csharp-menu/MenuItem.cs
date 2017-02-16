using System.Collections.Generic;

namespace CSharp.Console.Menu
{
    public abstract class MenuItem
    {
        protected MenuItem(string title)
        {
            Title = title;
            Options = new LinkedList<MenuOption>();
        }

        public void AddOption(MenuOption option)
        {
            Options.AddLast(option);
        }

        public abstract void Handler(MenuCallValues values);

        public LinkedList<MenuOption> Options { get; }

        public string Title { get; }
    }
}