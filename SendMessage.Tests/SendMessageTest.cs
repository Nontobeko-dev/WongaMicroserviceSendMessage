using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SendMessage.Tests
{
    class SendMessageTest
    {
        [Test]
        public void TestSendMessagConsole()
        {
            // Arrange
            var expected = new StringWriter();
            Console.SetOut(expected);

            // Act
            var actual = new StringReader("xPerson");
            Console.SetIn(actual);

            // Assert
            Program.Main(new string[] { });

            Assert.That(expected.ToString(), Is.EqualTo(string.Format("Input the sender's name: {0}Hello my name is, xPerson{0}", Environment.NewLine)));
        }
    }
}
