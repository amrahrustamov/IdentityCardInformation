namespace İdentityCardİnformation.Database.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
    }
    public class UserIdentityNumber
    {
        public string IdentityNumber { get; set; }
    }
}
