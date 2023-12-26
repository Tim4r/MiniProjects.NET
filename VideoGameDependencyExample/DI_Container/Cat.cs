namespace DI_Container
{
    internal class Cat : IGlad
    {
        internal string Name { get; set; }

        public void ToShowJoy(string namePerson)
        {
            Console.WriteLine($" {Name} noticed the {namePerson} and lazily wandered towards him, purring");
        }
    }
}
