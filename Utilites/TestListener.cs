using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTests.Utilites
{
    public class TestListener : ITestListener
    {
        public void SendMessage(TestMessage message)
        {

        }

        public void TestFinished(ITestResult result)
        {

        }

        public void TestOutput(TestOutput output)
        {

        }

        public void TestStarted(ITest test)
        {

        }
    }
}
