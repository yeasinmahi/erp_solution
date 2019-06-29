using System.Collections.Generic;
using NUnit.Framework;
using Utility;

namespace UnitTest.Utility
{
    [TestFixture]
    public class CommonTdd
    {
        [Test]
        public void ToStringWithDelimiter_string()
        {
            List<int> ids = new List<int>()
            {
                5,6,7
            };

            string result= ids.ToStringWithDelimiter(",");
            Assert.That(result=="5,6,7");
        }
    }
}
