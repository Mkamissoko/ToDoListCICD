using System;
using NUnit.Framework;

namespace ConsoleApplication1
{
    [TestFixture]
    public class UserTests
    {
        [TestCase("mail@mail.fr", "firstname", "lastname", "01/01/2009","testPasseword123" , ExpectedResult = true)]
        [TestCase("mail@mail.fr", "", "lastname", "01/01/2010", "testPasseword123", ExpectedResult = false)]
        [TestCase("mail@mail.fr", "firstname", "", "01/01/2010", "testPasseword123",ExpectedResult = false)]
        [TestCase("mail@mail.fr", "firstname", "lastname", "01/01/2010", "testPasseword",ExpectedResult = false)]
        [TestCase("mail@mail.fr", "firstname", "lastname", "01/01/2010", "testpasseword123",ExpectedResult = false)]
        public bool TestIsValid(string mail, string firstname, string lastname, DateTime birthdate, String password)
        {
            User user = new User(mail, firstname, lastname, birthdate, password);
            return user.isValid();
        }

        [TestCase(ExpectedResult = false)]
        public bool TestBirthDate()
        {
            DateTime date = DateTime.Now.AddYears(-12);
            User user = new User("mail@mail.fr", "firstname", "lastname", date,"testPasseword123");
            return user.isValid();
        }
        
        
    }
}