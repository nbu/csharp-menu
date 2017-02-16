namespace CSharp.Console.Menu
{
    public abstract class MenuOption
    {
        protected MenuOption(string title, string shortForm)
        {
            Title = title;
            ShortForm = shortForm;
        }

        public string Title { get; }

        public string ShortForm { get; }

        public abstract object AsObject(string str);
    }
}