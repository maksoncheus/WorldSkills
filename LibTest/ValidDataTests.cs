using SF2022UserLyubaLib;

namespace LibTest
{
    [TestClass]
    public class ValidDataTests
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
        #region SecondTest - Insufficient time at start of day
        string[] secondTestOutput = new string[]
        {
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
        TimeSpan[] secondTestStartTimes = new TimeSpan[]
        {
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(11),
            TimeSpan.FromHours(15),
            TimeSpan.FromHours(15.5d),
            TimeSpan.FromMinutes(16*60 + 50)
        };
        int[] secondTestDurations = new int[]
        {
            180,
            30,
            10,
            10,
            40
        };
        TimeSpan secondTestBeginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan secondTestEndWorkingTime = TimeSpan.FromHours(18);
        int secondTestConsultationTime = 30;
        #endregion
        #region ThirdTest - Insufficient time at end of day
        string[] thirdTestOutput = new string[]
        {
            "11:30-12:00",
            "12:00-12:30",
            "12:30-13:00",
            "13:00-13:30",
            "13:30-14:00",
            "14:00-14:30",
            "14:30-15:00"
        };
        TimeSpan[] thirdTestStartTimes = new TimeSpan[]
        {
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(11),
            TimeSpan.FromHours(15),
            TimeSpan.FromHours(15.5d),
            TimeSpan.FromHours(16)
        };
        int[] thirdTestDurations = new int[]
        {
            180,
            30,
            10,
            10,
            120
        };
        TimeSpan thirdTestBeginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan thirdTestEndWorkingTime = TimeSpan.FromHours(18);
        int thirdTestConsultationTime = 30;
        #endregion
        #region FourthTest - Insufficient time at all
        string[] fourthTestOutput = new string[]
        {
        };
        TimeSpan[] fourthTestStartTimes = new TimeSpan[]
        {
            TimeSpan.FromHours(8)
        };
        int[] fourthTestDurations = new int[]
        {
            240
        };
        TimeSpan fourthTestBeginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan fourthTestEndWorkingTime = TimeSpan.FromHours(12);
        int fourthTestConsultationTime = 30;
        #endregion
        #region FifthTest - Other consultation time
        string[] fifthTestOutput = new string[]
        {
            "10:10-11:00",
            "11:00-11:50"
        };
        TimeSpan[] fifthTestStartTimes = new TimeSpan[]
        {
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(10)
        };
        int[] fifthTestDurations = new int[]
        {
            120,
            10
        };
        TimeSpan fifthTestBeginWorkingTime = TimeSpan.FromHours(8);
        TimeSpan fifthTestEndWorkingTime = TimeSpan.FromHours(12);
        int fifthTestConsultationTime = 50;
        #endregion
        #region Valid data tests
        [TestMethod]
        public void WorldSkillsData()
        {
            CollectionAssert.AreEqual(firstTestOutput, calc.AvailablePeriods(firstTestStartTimes, firstTestDurations, firstTestBeginWorkingTime, firstTestEndWorkingTime, firstTestConsultationTime));
        }
        [TestMethod]
        public void InsufficientTimeAtStartOfDay()
        {
            CollectionAssert.AreEqual(secondTestOutput, calc.AvailablePeriods(secondTestStartTimes, secondTestDurations, secondTestBeginWorkingTime, secondTestEndWorkingTime, secondTestConsultationTime));
        }
        [TestMethod]
        public void InsufficientTimeAtEndOfDay()
        {
            CollectionAssert.AreEqual(thirdTestOutput, calc.AvailablePeriods(thirdTestStartTimes, thirdTestDurations, thirdTestBeginWorkingTime, thirdTestEndWorkingTime, thirdTestConsultationTime));
        }
        [TestMethod]
        public void InsufficientTime()
        {
            CollectionAssert.AreEqual(fourthTestOutput, calc.AvailablePeriods(fourthTestStartTimes, fourthTestDurations, fourthTestBeginWorkingTime, fourthTestEndWorkingTime, fourthTestConsultationTime));
        }
        [TestMethod]
        public void OtherConsultationTime()
        {
            CollectionAssert.AreEqual(fifthTestOutput, calc.AvailablePeriods(fifthTestStartTimes, fifthTestDurations, fifthTestBeginWorkingTime, fifthTestEndWorkingTime, fifthTestConsultationTime));
        }
        #endregion
    }
}