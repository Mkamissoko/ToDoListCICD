using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Moq;

namespace ConsoleApplication1
{
    public class User
    {
        public String email { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public DateTime birthdate { get; set; }
        public String password { get; set; }
        public List<ToDoList> todolists { get; set; }
        
        public User(String email, String firstname, String lastname, DateTime birthdate, String password)
        {
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthdate = birthdate;
            this.password = password;
            this.todolists= new List<ToDoList>();
        }
        
        public void createToDoList()
        {
            todolists.Add(new ToDoList());
        }
        public Boolean isValid()
        {
            Regex regexMail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            //creer une regex pour le password qui doit contenir entre 8 et 40 caracteres, une majuscule, une minuscule et un chiffre
            Regex regexPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,40}$");
            if (email == null || firstname == null || lastname == null || birthdate == null || password == null)
                return false;
            if (email.Length == 0 || firstname.Length == 0 || lastname.Length == 0)
                return false;
            if (birthdate >= DateTime.Now.AddYears(-13))
                return false;
            if (!regexMail.IsMatch(email))
                return false;
            if(!regexPassword.IsMatch(password))
                return false;
            return true;
        }
    }
    
}