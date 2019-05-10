namespace Demo.Characters
{
    public abstract class BibleCharacter : IBibleCharacter
    {
        public string Name { get; set; }

        public virtual string WhatsYourName()
        {
            return $"Hello, my name is {Name}";
        }
    }
}
