using İdentityCardİnformation.Database.Base;
using System.ComponentModel.DataAnnotations;

namespace İdentityCardİnformation.Database.Models
{
    public class User : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string IdentityNumber { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
    }
    public class UserViewModel
    {
        public UserViewModel(string firstName, string lastName, string fatherName, string birthPlace, string birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            BirthPlace = birthPlace;
            BirthDate = birthDate;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public class UserRegister
        {
            public UserRegister(string firstName, string lastName, string identityNumber, string fatherName, string birthPlace, string birthDate)
            {
                FirstName = firstName;
                LastName = lastName;
                IdentityNumber = identityNumber;
                FatherName = fatherName;
                BirthPlace = birthPlace;
                BirthDate = birthDate;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string IdentityNumber { get; set; }
            public string FatherName { get; set; }
            public string BirthPlace { get; set; }
            public string BirthDate { get; set; }
        }
    }
}
