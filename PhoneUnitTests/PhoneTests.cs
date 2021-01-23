using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace PhoneUnitTests
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            string o = "Mateusz";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            Assert.AreEqual(p.Owner, o);
            Assert.AreEqual(p.PhoneNumber, pn);          
        }

        [TestMethod]
        public void PhoneOwnerTest()
        {
            string o = "Mateusz";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            Assert.AreEqual(p.Owner, o);
        }
        
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void PhoneOwnerOwnerNameExceptionTest()
        {
            string o = "";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            string owner = p.Owner;
        }

        [TestMethod]
        public void PhoneNumberTest()
        {
            string o = "Mateusz";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            Assert.AreEqual(p.PhoneNumber, pn);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void PhoneNumberPhoneNumberIsEmptyExceptionTest()
        {
            string o = "Mateusz";
            string pn = "";
            Phone p = new Phone(o, pn);

            string phoneNumber = p.PhoneNumber;
        }
        
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void PhoneNumberInvalidPhoneNumberExceptionTest()
        {
            string o = "Mateusz";
            string pn = "23";
            Phone p = new Phone(o, pn);

            string phoneNumber = p.PhoneNumber;
        }
        
        [TestMethod]
        public void PhoneBookCountTest()
        {
            string o = "Mateusz";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            Assert.AreEqual(p.Count, 0);
        }
        
        [TestMethod]
        public void PhoneBookAddContactTest()
        {
            string o = "Mateusz";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            string co = "Sw Marcellina";
            string cpn = "777777777";

            p.AddContact(co, cpn);

            Assert.AreEqual(p.Count, 1);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void PhoneBookAddContactPhoneBookFullExceptionTest()
        {
            string o = "Mateusz";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            for (int i = 0; i < 102; i++)
            {
                string co = "Sw Marcellina" + i;
                string cpn = (100000000 + i).ToString();

                p.AddContact(co, cpn);
            }
        }

        [TestMethod]
        public void PhoneCallTest()
        {
            string o = "Mateusz";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            string co = "Sw Marcellina";
            string cpn = "777777777";

            p.AddContact(co, cpn);

            string callMessage = p.Call(co);

            Assert.IsTrue(callMessage.Contains(co));
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void PhoneCallNotAddedPersonToPhoneBookExceptionTest()
        {
            string o = "Mateusz";
            string pn = "123321231";
            Phone p = new Phone(o, pn);

            string co = "Sw Marcellina";
            string cpn = "777777777";

            string callMessage = p.Call(co);
        }
    }
}
