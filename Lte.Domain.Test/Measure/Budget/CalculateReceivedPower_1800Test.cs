﻿using Lte.Domain.Measure;
using Lte.Domain.Test.Broadcast;
using Lte.Domain.TypeDefs;
using Moq;
using NUnit.Framework;

namespace Lte.Domain.Test.Measure.Budget
{
    [TestFixture]
    public class CalculateReceivedPower_1800Test
    {
        private readonly Mock<IBroadcastModel> model = new Mock<IBroadcastModel>();
        private readonly Mock<ILinkBudget<double>> budget = new Mock<ILinkBudget<double>>();
        const double eps = 1E-6;

        [SetUp]
        public void TestInitialize()
        {
            model.MockFrequencyType(FrequencyBandType.Downlink1800);
            model.MockUrbanTypeAndKValues(UrbanType.Dense);
            budget.SetupGet(x => x.Model).Returns(model.Object);
            budget.SetupGet(x => x.TransmitPower).Returns(15.2);
            budget.SetupGet(x => x.AntennaGain).Returns(18);
        }

        [Test]
        public void Test_10mDistance()
        {
            double p = budget.Object.CalculateReceivedPower(0.01, 40);
            Assert.AreEqual(p, -19.549633, eps);
        }

        [Test]
        public void Test_20mDistance()
        {
            double p = budget.Object.CalculateReceivedPower(0.02, 40);
            Assert.AreEqual(p, -34.452577, eps);
        }

        [Test]
        public void Test_50mDistance()
        {
            double p = budget.Object.CalculateReceivedPower(0.05, 40);
            Assert.AreEqual(p, -54.153197, eps);
        }

        [Test]
        public void Test_100mDistance()
        {
            double p = budget.Object.CalculateReceivedPower(0.1, 40);
            Assert.AreEqual(p, -69.05614, eps);
        }

        [Test]
        public void Test_200mDistance()
        {
            double p = budget.Object.CalculateReceivedPower(0.2, 40);
            Assert.AreEqual(p, -83.959084, eps);
        }

        [Test]
        public void Test_500mDistance()
        {
            double p = budget.Object.CalculateReceivedPower(0.5, 40);
            Assert.AreEqual(p, -103.659704, eps);
        }
    }
}
