using System;

//Added selenium libs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace com.PSL.PageObject
{
    public class AppointmentSchedulingView
    {
        IWebDriver webDriver = null;

        //constructor
        public AppointmentSchedulingView(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Día de la cita element
        [FindsBy(How = How.Id, Using = "datepicker")]
        private IWebElement AppointmentDate { get; set; }

        //ID paciente
        [FindsBy(How = How.XPath, Using = "//*[@id='page-wrapper']/div/div[3]/div/div[2]/input")]
        private IWebElement PatientID { get; set; }

        // ID Doctor
        [FindsBy(How = How.XPath, Using = "//*[@id='page-wrapper']/div/div[3]/div/div[3]/input")]
        private IWebElement DoctorId { get; set; }

        //Observaciones Field
        [FindsBy(How = How.XPath, Using = "//*[@id='page-wrapper']/div/div[3]/div/div[4]/textarea")]
        private IWebElement Observaciones { get; set; }

        //guardar buton
        [FindsBy(How = How.XPath, Using = "//*[@id='page-wrapper']/div/div[3]/div/a")]
        private IWebElement GuardarBTN { get; set; }

        //Metodo para interactuar
        public Boolean FillformDate(string sDate, string patientID, string doctorID, string observations)
        {
            AppointmentDate.SendKeys(sDate);
            PatientID.SendKeys(patientID);
            DoctorId.SendKeys(doctorID);
            Observaciones.SendKeys(observations);
            GuardarBTN.Click();
            
            return true;
        }
    }
}
