namespace VideoGameDependencyExample
{
    internal class HeroThatCanUseAnyWeapon : IHero
    {
        public string Name { get; set; }
        public IWeapon MyWeapon { get; set; }

        //public HeroThatCanUseAnyWeapon(IWeapon myWeapon)             --------- with using constructor
        //{
        //    this.MyWeapon = myWeapon;
        //}

        //public void Attack(IWeapon MyWeapon)                         --------- with using method
        //{
        //    Console.WriteLine(Name + " prepares to attack");
        //    MyWeapon.AttackWithMe();
        //}   

        public void Attack()
        {
            Console.WriteLine(Name + " prepares to attack");
            MyWeapon.AttackWithMe();
        }
    }
}
