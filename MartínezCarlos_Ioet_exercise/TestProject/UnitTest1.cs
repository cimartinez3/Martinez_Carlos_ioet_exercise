using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetData()
        {           
            string[] expected = {"RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00",
                                    "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00",
                                    "CHARLIE=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00,MO15:00-21:00"};
             
            Assert.AreEqual(expected[0], MartínezCarlos_Ioet_exercise.data_layer.Data.getData()[0]);
            Assert.AreEqual(expected[1], MartínezCarlos_Ioet_exercise.data_layer.Data.getData()[1]);
            Assert.AreEqual(expected[2], MartínezCarlos_Ioet_exercise.data_layer.Data.getData()[2]);
            
        }

        [TestMethod]

        public void TestCalculatePayment()
        {
            Assert.AreEqual(30, MartínezCarlos_Ioet_exercise.business_layer.Operation.calculatePayment(TimeSpan.Parse("10:00"), TimeSpan.Parse("12:00"), "09:01-18:00", "MO"));
            Assert.AreEqual(25, MartínezCarlos_Ioet_exercise.business_layer.Operation.calculatePayment(TimeSpan.Parse("20:00"), TimeSpan.Parse("21:00"), "18:01-23:59", "SU"));
            Assert.AreEqual(105, MartínezCarlos_Ioet_exercise.business_layer.Operation.calculatePayment(TimeSpan.Parse("15:00"), TimeSpan.Parse("21:00"), "09:01-18:00", "MO"));
        }
    }
}
