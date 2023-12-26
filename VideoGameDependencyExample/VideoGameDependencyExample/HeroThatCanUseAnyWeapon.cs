namespace VideoGameDependencyExample
{
    internal class HeroThatCanUseAnyWeapon : IHero
    {
        public string Name { get; set; }
        public IWeapon MyWeapon { get; set; }

        //public HeroThatCanUseAnyWeapon(IWeapon myWeapon)
        //{
        //    this.MyWeapon = myWeapon;
        //}

        public void Attack()
        {
            Console.WriteLine(Name + " prepares to attack");
            MyWeapon.AttackWithMe();
        }
    }
}
