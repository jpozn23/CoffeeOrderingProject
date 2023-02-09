using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject
{
    public class SignUpTests
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string custOrWorker { get; set; }

        public string firstname2 { get; set; }
        public string lastname2 { get; set; }
        public string username2 { get; set; }
        public string password2 { get; set; }
        public string confirmPassword2 { get; set; }
        public string custOrWorker2 { get; set; }

        public string firstname3 { get; set; }
        public string lastname3 { get; set; }
        public string username3 { get; set; }
        public string password3 { get; set; }
        public string confirmPassword3 { get; set; }
        public string custOrWorker3 { get; set; }



        [SetUp]
        public void Setup()
        {
            firstname = "Joe";
            lastname = "Smith";
            username = "uss2";
            password = "pw2";
            confirmPassword = "pw2";
            custOrWorker = "Worker";

            firstname2 = "";
            lastname2 = "Smith";
            username2 = "uss2";
            password2 = "";
            confirmPassword2 = "pw2";
            custOrWorker2 = "Worker";

            firstname3 = "Joe";
            lastname3 = "Smith";
            username3 = "uss2";
            password3 = "pw2";
            confirmPassword3 = "pw222";
            custOrWorker3 = "Worker";
        }

        [Test]
        public void VerifySignUpValid_Test()
        {
            int errorMsg = 0;
            
            if (String.IsNullOrEmpty(firstname) || String.IsNullOrEmpty(lastname) || String.IsNullOrEmpty(username)
                || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(custOrWorker))
            {
                errorMsg = 1;
            } else if (Convert.ToString(password) != Convert.ToString(confirmPassword))
            {
                errorMsg = 2;
                
            } else
            {
                errorMsg = 0;
            }

            Assert.AreEqual(0, errorMsg);
            
        }

        [Test]
        public void VerifySignUpNotValid_Test()
        {
            int errorMsg = 0;

            if (String.IsNullOrEmpty(firstname2) || String.IsNullOrEmpty(lastname2) || String.IsNullOrEmpty(username2)
                || String.IsNullOrEmpty(password2) || String.IsNullOrEmpty(custOrWorker2))
            {
                errorMsg = 1;
            }
            else if (Convert.ToString(password2) != Convert.ToString(confirmPassword2))
            {
                errorMsg = 2;

            }
            else
            {
                errorMsg = 0;
            }

            Assert.AreEqual(1, errorMsg);
        }

        [Test]
        public void VerifySignUpNotValid2_Test()
        {
            int errorMsg = 0;

            if (String.IsNullOrEmpty(firstname3) || String.IsNullOrEmpty(lastname3) || String.IsNullOrEmpty(username3)
                || String.IsNullOrEmpty(password3) || String.IsNullOrEmpty(custOrWorker3))
            {
                errorMsg = 1;
            }
            else if (Convert.ToString(password3) != Convert.ToString(confirmPassword3))
            {
                errorMsg = 2;

            }
            else
            {
                errorMsg = 0;
            }

            Assert.AreEqual(2, errorMsg);
        }

    }
}