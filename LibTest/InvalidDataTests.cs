using SF2022UserLyubaLib;
namespace LibTest
{
    [TestClass]
    public class InvalidDataTests
    {
        Calculations calc = new();
        #region FirstTest - Provided by WorldSkills
        string[] firstTestOutput = new string[]
        {
            "08:00-08:30",
            "08:30-09:00",
            "09:00-09:30",
            "09:30-10:00",
            "11:30-12:00",
            "12:00-12:30",
            "12:30-13:00",
            "13:00-13:30",
            "13:30-14:00",
            "14:00-14:30",
            "14:30-15:00",
            "15:40-16:10",
            "16:10-16:40",
            "17:30-18:00"
        };
        TimeSpan[] firstTestStartTimes = new TimeSpan[]
        {
            TimeSpan.FromHours(10),
            TimeSpan.FromHours(11),
            TimeSpan.FromHours(15),
            TimeSpan.FromHours(15.5d),
            TimeSpan.FromMinutes(16*60 + 50)
        };
        int[] firstTestDurations = new int[]
        {
            60,
            30,
            10,
            10,
            40
        };
        TimeSpan firstTestBeginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan firstTestEndWorkingTime = TimeSpan.FromHours(18);
        int firstTestConsultationTime = 30;
        #endregion
        #region Different array lengths;
        string[] sixthTestOutput = new string[]
        {
            "10:10-11:00",
            "11:00-11:50"
        };
        TimeSpan[] sixthTestStartTimes = new TimeSpan[]
        {
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(10)
        };
        int[] sixthTestDuradions = new int[]
        {
            120
        };
        TimeSpan sixthTestBeginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan sixthTestEndWorkingTime = TimeSpan.FromHours(12);
        int sixthTestConsultationTime = 50;
        #endregion
        
        #region Throwed exception test
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DifferentArrayLength()
        {
            CollectionAssert.AreEqual(sixthTestOutput, calc.AvailablePeriods(sixthTestStartTimes, sixthTestDuradions, sixthTestBeginWorkingTime, sixthTestEndWorkingTime, sixthTestConsultationTime));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroOrLessThanZero()
        {
            CollectionAssert.AreEqual(firstTestOutput, calc.AvailablePeriods(firstTestStartTimes, firstTestDurations, firstTestBeginWorkingTime, firstTestEndWorkingTime, -1));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StartTimeBiggerThanEnd()
        {
            CollectionAssert.AreEqual(firstTestOutput, calc.AvailablePeriods(firstTestStartTimes, firstTestDurations, firstTestEndWorkingTime, firstTestBeginWorkingTime, firstTestConsultationTime));
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullPointer()
        {
            CollectionAssert.AreEqual(firstTestOutput, calc.AvailablePeriods(null, firstTestDurations, firstTestBeginWorkingTime, firstTestEndWorkingTime, firstTestConsultationTime));
            CollectionAssert.AreEqual(firstTestOutput, calc.AvailablePeriods(firstTestStartTimes, null, firstTestBeginWorkingTime, firstTestEndWorkingTime, firstTestConsultationTime));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeBusyWhileNOTatWork()
        {
            CollectionAssert.AreEqual(new string[] { }, calc.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(6) }, new int[] { 240 }, TimeSpan.FromHours(8), TimeSpan.FromHours(10), firstTestConsultationTime));
        }
        #endregion
    }
}
