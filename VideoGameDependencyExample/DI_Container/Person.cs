using System.Security.Cryptography.X509Certificates;

namespace DI_Container
{
    internal class Person : IMovement
    {
        internal string Name { get; set; }
        internal IGlad Glad { get; set; }

        public void MoveToTheVisibilityZone()
        {
            Console.WriteLine($" {Name} came into the room and the pet saw him...");
            Glad.ToShowJoy(Name);
        }
    }
}
