using System.Windows.Forms.VisualStyles;
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
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "654321", "1", "Fake appointment");
            Assert.IsTrue(makeAppointment,"When trying to make an appointment when the doctor does not exist the application, " +
                                          "is no presenting a message indicating that.");
            Assert.AreEqual("*El campo 'Documento de identidad' no se encuentra entre nuestros doctores.",
                AppointmentScheduleBC.AppointmentScheduleError(), "The Application is not presenting the error expected when the doctor does not exist.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNotExistingPatient_2()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "1", "123456", "Fake appointment");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the patient does not exist the application, " +
                             "is no presenting a message indicating that.");
            Assert.AreEqual("*El campo 'Documento de identidad' no se encuentra entre nuestros pacientes registrados.",
               AppointmentScheduleBC.AppointmentScheduleError(), "The Application is not presenting the error expected when the patient does not exist");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentBeforeDate_3()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2016", "654321", "123456", "Fake appointment");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the date is before actual the application, " +
                                           "is no presenting a message indicating that.");
            Assert.AreEqual("*El campo 'Fecha' se encuentra fuera del rango permitido.",
               AppointmentScheduleBC.AppointmentScheduleError(), "The Application is not presenting the error expected when the date is before than the actual.");
        }

        [TestCategory("Positve")]
        [TestMethod]
        public void WhenMakingAppointmentCurrentDate_4()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "654321", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the date, doctor ID and patient ID are correct, " +
                "and error is displayed by the app.");
            StringAssert.Contains("Datos guardados correctamente.",
              AppointmentScheduleBC.AppointmentScheduleSucess(), "The Application is not presenting the suscess message expected.");

        }

        [TestCategory("Positve")]
        [TestMethod]
        public void WhenMakingAppointmentPosDate_5()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2018", "654321", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the date, doctor ID and patient ID are correct, " +
                "and error is displayed by the app.");
            StringAssert.Contains("Datos guardados correctamente.",
              AppointmentScheduleBC.AppointmentScheduleSucess(), "The Application is not presenting the suscess message expected.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNotNumberPatientID_6()
        { 
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "AAA", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the value of the patient is not a number the application, " +
                                            "is no presenting a message indicating that.");
            StringAssert.Contains("*El campo 'Documento de identidad' no permite ingreso de datos diferentes a numeros.",
               AppointmentScheduleBC.AppointmentScheduleError(), "The Application is not presenting the error expected when the patient id is not a number.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNotNumberDoctorID_7()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "654321", "BBB", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the value of the doctor is not a number the application, " +
                                            "is no presenting a message indicating that.");
            StringAssert.Contains("*El campo 'Documento de identidad' no permite ingreso de datos diferentes a numeros.",
               AppointmentScheduleBC.AppointmentScheduleError(), "The Application is not presenting the error expected when the doctor id is not a number.");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNoPatientID_8()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/122017", "", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the value of the patient is empty the application, " +
                                           "is no presenting a message indicating that.");
            StringAssert.Contains("*El campo 'Documento de identidad' es requerido.",
               AppointmentScheduleBC.AppointmentScheduleError(), "The Application is not presenting the error expected when the patient id is empty.");

        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNoDoctorID_9()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("03/12/2017", "654321", "", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the value of the doctor is empty the application, " +
                                          "is no presenting a message indicating that.");
            StringAssert.Contains("*El campo 'Documento de identidad' es requerido.",
               AppointmentScheduleBC.AppointmentScheduleError(), "The Application is not presenting the error expected when the doctor id is empty");
        }

        [TestCategory("Negative")]
        [TestMethod]
        public void WhenMakingAppointmentNoDate_10()
        {
            bool makeAppointment = false;
            AppointmentScheduleBC.driver = new ChromeDriver();
            AppointmentScheduleBC.openHome();
            makeAppointment = AppointmentScheduleBC.AppointmentScheduleProcess("", "654321", "123456", "Fake appoint");
            Assert.IsTrue(makeAppointment, "When trying to make an appointment when the value of the date is empty the application, " +
                                          "is no presenting a message indicating that.");
            StringAssert.Contains("*El campo 'Fecha' es requerido.",
               AppointmentScheduleBC.AppointmentScheduleError(), "The Application is not presenting the error expected when the date field is empty.");
        }

    }
}
