using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject
{
    public class LogInTests
    {
        string username { get; set; }
        string password { get; set; }
        string username2 { get; set; }
        string password2 { get; set; }

        [SetUp]
        public void Setup()
        {
            username = "shfjff";
            password = "hjfhjf";
            username2 = "";
            password2 = "";
        }

        [Test]
        public void VerifyLoginValid_Test()
        {
            bool isValid = false;

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            Assert.AreEqual(true, isValid);
        }

        [Test]
        public void VerifyLoginNotValid_Test()
        {
            bool isValid = false;

            if (String.IsNullOrEmpty(username2) || String.IsNullOrEmpty(password2))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            Assert.AreEqual(false, isValid);

        }
    }
}