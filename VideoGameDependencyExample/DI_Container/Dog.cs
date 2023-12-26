namespace DI_Container
{
    internal class Dog : IGlad
    {
        internal string Name { get; set; }

        public void ToShowJoy(string namePerson)
        {
            Console.WriteLine($" {Name} noticed the {namePerson} and ran towards him, wagging his tail");
        }
    }
}
