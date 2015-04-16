using System;
using System.CodeDom;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using CoDelivery.Core.Infra.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoDelivery.IntegrationTests
{
    /// <summary>
    /// Summary description for GitIntergrationTest
    /// </summary>
    [TestClass]
    public class GitIntergrationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new PowerShellClient();

            var response = client.ExecuteCommand("git --version");

            Assert.AreEqual(response, "git version 1.9.4.msysgit.2");
        }
    }
}
