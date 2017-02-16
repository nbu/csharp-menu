namespace CSharp.Console.Menu
{
    public class BoolMenuOption : MenuOption
    {
        public BoolMenuOption(string title, string shortForm) : base(title, shortForm)
        {
        }

        public override object AsObject(string str)
        {
            bool res;
            var valid = bool.TryParse(str, out res);
            if (!valid) throw new InvalidMenuOptionValueException($"{str} is invalid boolean value");

            bool? nullableRes = res;
            return nullableRes;
        }
    }
}