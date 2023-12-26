namespace VideoGameDependencyExample
{
    internal class Sword : IWeapon
    {
        public string SwordName { get; set; }

        public void AttackWithMe()
        {
            Console.WriteLine(SwordName + " clices through the air, devestating all enemies");
        }
    }
}
