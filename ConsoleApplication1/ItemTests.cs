using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Moq;

namespace ConsoleApplication1
{
    [TestFixture]
    public class ItemTests
    {
        public static DateTime date = DateTime.Now.AddYears(-30);
        public User userValid = new User("mail@mail.fr", "firstname", "lastname", date, "testPasseword123");
        public User userNotValid = new User("mail@mail.fr", "", "lastname", date, "testPasseword123");
        public ToDoList plainTodolist = new ToDoList();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
    
            var randomString = new char[length];
    
            for (int i = 0; i < length; i++)
            {
                randomString[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomString);
        }
        
        [TestCase(ExpectedResult = true)]
        public bool isOkAddToToDoList()
        {
            var mock =  new Mock<IEmailSenderService>();
            mock.Setup(x => x.sendEmail(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
            IEmailSenderService emailSenderService = mock.Object;
            
            plainTodolist.user = userValid;
            var interval = 0;
            for (int i = 0; i < 10; i++)
            {
                Item item = new Item();
                item.name = "item" + i;
                item.content = "content" + i;
                item.dateTime = DateTime.Now.AddMinutes(interval);
                plainTodolist.addItemToToDoList(item, emailSenderService);
                interval += 30;
            }

            return true;
        }

        [TestCase(ExpectedResult = false)]
        public bool addMore10ItemsInTodoList()
        {
            var mock =  new Mock<IEmailSenderService>();
            mock.Setup(x => x.sendEmail(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
            IEmailSenderService emailSenderService = mock.Object;
            
            plainTodolist.user = userValid;
            var interval = 0;
            for (int i = 0; i < 10; i++)
            {
                Item item = new Item();
                item.name = "item" + i;
                item.content = "content" + i;
                item.dateTime = DateTime.Now.AddMinutes(interval);
                plainTodolist.addItemToToDoList(item, emailSenderService);
                interval += 30;
            }
            
            Item item2 = new Item();
            item2.name = "item11";
            item2.content = "content11";
            item2.dateTime = DateTime.Now.AddMinutes(500);
            
            return plainTodolist.addItemToToDoList(item2, emailSenderService);
        }
        
        [TestCase(ExpectedResult = false)]
        public bool addSameNameItem()
        {
            var mock =  new Mock<IEmailSenderService>();
            mock.Setup(x => x.sendEmail(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
            IEmailSenderService emailSenderService = mock.Object;
            
            plainTodolist.user = userValid;
            
            Item item = new Item();
            item.name = "item";
            item.content = "content";
            item.dateTime = DateTime.Now.AddMinutes(30);
            
            plainTodolist.addItemToToDoList(item, emailSenderService);
            
            Item item2 = item;
            item2.dateTime = DateTime.Now.AddMinutes(60);
            
            return plainTodolist.addItemToToDoList(item2, emailSenderService);
        }
        
        [TestCase(ExpectedResult = false)]
        public bool addContentMore1000Char()
        {
            var mock =  new Mock<IEmailSenderService>();
            mock.Setup(x => x.sendEmail(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
            IEmailSenderService emailSenderService = mock.Object;
            
            plainTodolist.user = userValid;
            
            Item item = new Item();
            item.name = "item";
            item.content = GenerateRandomString(1001);
            item.dateTime = DateTime.Now.AddMinutes(30);
            
            return plainTodolist.addItemToToDoList(item, emailSenderService);
        }
        
        [TestCase(ExpectedResult = false)]
        public bool addItemWithNoInterval()
        {
            var mock =  new Mock<IEmailSenderService>();
            mock.Setup(x => x.sendEmail(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
            IEmailSenderService emailSenderService = mock.Object;
            
            plainTodolist.user = userValid;
            
            Item item = new Item();
            item.name = "item";
            item.content = GenerateRandomString(500);
            item.dateTime = DateTime.Now;
            
            plainTodolist.addItemToToDoList(item, emailSenderService);
            
            Item item2 = item;
            item2.name = "test2";
            return plainTodolist.addItemToToDoList(item2, emailSenderService);
        }
    }
    
}