namespace FormUI
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ FirstName } { LastName } ({ EmailAddress })";
            }
        }
    }
}
