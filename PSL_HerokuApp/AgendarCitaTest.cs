using com.PSL.BusinessComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace PSL_HerokuApp
{
    [TestClass]
    public class AgendarCitaTest
    {

        //ID del doctor existente   123456
        //ID del paciente existente 654321

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNotExistingDoctor_1()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "654321", "1", "Fake appoint");
            Assert.IsTrue(makeAppointment,"When trying to make an appointment when the doctor does not exist the application, " +
                                          "is no presenting a message indicating that.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNotExistingPatient_2()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "1", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the patient does not exist the application, " +
                             "is no presenting a message indicating that.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentBeforeDate_3()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2016", "654321", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the date is before actual the application, " +
                                           "is no presenting a message indicating that.");
        }

        [TestCategory("Positve")]
        [TestMethod]
        public void WhenMakingAppointmentCurrentDate_4()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "654321", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the date is after the actual the application, " +
                "is no presenting a message indicating that.");
        }

        [TestCategory("Positve")]
        [TestMethod]
        public void WhenMakingAppointmentPosDate_5()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2018", "654321", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the date is after actual the application, " +
                "is no presenting a message indicating that.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNotNumberPatientID_6()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "AAA", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the patient does not contain a valid value the application, " +
                 "is no presenting a message indicating that.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNotNumberDoctorID_7()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "654321", "BBB", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the doctor does not contain a valid value the application, " +
                "is no presenting a message indicating that.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNoPatientID_8()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/122017", "", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the patient has no value the application, " +
                "is no presenting a message indicating that.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNoDoctorID_9()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "654321", "", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the doctor has no value the application, " +
                "is no presenting a message indicating that.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNoDate_10()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("", "654321", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the date has no value the application, " +
                "is no presenting a message indicating that.");
        }

    }
}
