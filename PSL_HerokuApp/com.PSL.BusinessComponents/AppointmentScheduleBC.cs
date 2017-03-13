using System;
//Added selenium libs
using OpenQA.Selenium;
using com.PSL.PageObject;

namespace com.PSL.BusinessComponents
{
    public static class AppointmentScheduleBC
    {
        public static IWebDriver driver { get; set; }

        public static void openHome()
        {
            HomeView homeView = new HomeView(driver);
            driver.Url = "http://automatizacion.herokuapp.com/acastaneda/";
            driver.Manage().Window.Maximize();
        }

        public static Boolean AppointmentScheduleProcess(string sDate, string patientID, string doctorID,
            string observations)
        {
            HomeView homeView = new HomeView(driver);
            AppointmentSchedulingView appointmentSchedulingView = new AppointmentSchedulingView(driver);

            homeView.AccesToAppointmentSchedule();
            appointmentSchedulingView.FillformDate(sDate, patientID, doctorID, observations);

        return true;
    }


    }
}
