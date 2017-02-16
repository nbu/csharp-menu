namespace CSharp.Console.Menu
{
    public class IntegerMenuOption : MenuOption
    {
        public IntegerMenuOption(string title, string shortForm) : base(title, shortForm)
        {
        }

        public override object AsObject(string str)
        {
            int res;
            var valid = int.TryParse(str, out res);
            if (!valid) throw new InvalidMenuOptionValueException($"{str} is invalid integer value");

            int? nullableRes = res;
            return nullableRes;
        }
    }
}