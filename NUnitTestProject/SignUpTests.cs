using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NUnitTestProject
{
    public class SignUpTests
    {
        Entry Firstname = new Entry();
        Entry Lastname = new Entry();
        Entry Username = new Entry();
        Entry Password = new Entry();
        Entry ConfirmPassword = new Entry();
        String customerOrWorker;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckEmptyAccount()
        {

            Firstname.Text = "";
            Lastname.Text = "";
            Username.Text = "";
            Password.Text = "";
            ConfirmPassword.Text = "";
            customerOrWorker = "";


            if (String.IsNullOrEmpty(Firstname.Text) || String.IsNullOrEmpty(Lastname.Text) || String.IsNullOrEmpty(Username.Text)
               || String.IsNullOrEmpty(Password.Text) || String.IsNullOrEmpty(customerOrWorker))
            {
                Assert.IsEmpty(Firstname.Text);
                Assert.IsEmpty(Lastname.Text);
                Assert.Pass();
            }

            // validate password and confirm password fields are same
            if (Convert.ToString(Password.Text) != Convert.ToString(ConfirmPassword.Text))
            {
                Assert.AreNotEqual(Password.Text, ConfirmPassword.Text, "Passwords are not equal.");
                Assert.Fail();
            }

            Assert.IsEmpty(Firstname.Text);
            Assert.Fail();

        }

        [Test]
        public void CheckNoUsername()
        {

            Firstname.Text = "Thomas";
            Lastname.Text = "Beck";
            Username.Text = "";
            Password.Text = "gmailpassword";
            ConfirmPassword.Text = "gmailpassword";
            customerOrWorker = "Customer";


            if (String.IsNullOrEmpty(Firstname.Text) || String.IsNullOrEmpty(Lastname.Text) || String.IsNullOrEmpty(Username.Text)
               || String.IsNullOrEmpty(Password.Text) || String.IsNullOrEmpty(customerOrWorker))
            {
                Assert.Pass();
            }

            // validate password and confirm password fields are same
            if (Convert.ToString(Password.Text) != Convert.ToString(ConfirmPassword.Text))
            {
                Assert.AreNotEqual(Password.Text, ConfirmPassword.Text, "Passwords are not equal.");
                Assert.Fail();
            }

            Assert.Fail();

        }

        [Test]
        public void CheckDifferentPassword()
        {

            Firstname.Text = "Tomar";
            Lastname.Text = "Azure";
            Username.Text = "Tomar1732";
            Password.Text = "gmailpassword";
            ConfirmPassword.Text = "gmail.password";
            customerOrWorker = "Worker";


            if (String.IsNullOrEmpty(Firstname.Text) || String.IsNullOrEmpty(Lastname.Text) || String.IsNullOrEmpty(Username.Text)
               || String.IsNullOrEmpty(Password.Text) || String.IsNullOrEmpty(customerOrWorker))
            {
                Assert.Fail();
            }

            // validate password and confirm password fields are same
            if (Convert.ToString(Password.Text) != Convert.ToString(ConfirmPassword.Text))
            {
                Assert.AreNotEqual(Password.Text, ConfirmPassword.Text, "Passwords are not equal.");
                Assert.Pass();
            }
        }

    }
}