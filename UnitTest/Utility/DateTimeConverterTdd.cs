using System;
using System.Collections.Generic;
using NUnit.Framework;
using Utility;

namespace UnitTest.Utility
{
    [TestFixture]
    public class DateTimeConverterTdd
    {
        [Test]
        public void FirstDay_DateTime()
        {
            DateTime date = new DateTime(2019,01,15);
            DateTime firstDay = new DateTime(2019,01,1);

            DateTime result = date.FirstDay();
            Assert.That(result==firstDay);
        }
        [Test]
        public void LastDay_DateTime()
        {
            DateTime date = new DateTime(2019, 01, 15);
            DateTime lastDay = new DateTime(2019, 01, 31);

            DateTime result = date.LastDay();
            Assert.That(result == lastDay);
        }
    }
}
