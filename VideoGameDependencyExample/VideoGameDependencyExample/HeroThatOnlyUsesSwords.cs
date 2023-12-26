namespace VideoGameDependencyExample
{
    internal class HeroThatOnlyUsesSwords : IHero
    {
        public string Name { get; set; }

        public void Attack()
        {
            Sword sword = new Sword() { SwordName = "Excalibur" };
            Console.WriteLine(Name + " prepares himself for the battle");
            sword.AttackWithMe();
        }
    }
}
