using CNPM;
using CNPM.Controler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCNPM
{
    [TestClass]
    public class UnitTestDangNhap
    {
        [TestMethod]
        public void TestLogin()
        {
            string username = "khanhdinh141";
            string password = "123456aA@";
            AuthenControler controler = new AuthenControler();
            bool completelogin = controler.Dangnhap(username,password);
            Assert.IsTrue(completelogin);
        }
        [TestMethod]
        public void TestLoginWrong()
        {
            string username = "abcxyz123";
            string password = "123456aA@";
            AuthenControler controler = new AuthenControler();
            bool completelogin = controler.Dangnhap(username, password);
            Assert.IsTrue(!completelogin);
        }

    }
}
