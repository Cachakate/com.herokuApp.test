using System;

//Added selenium libs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace com.PSL.PageObject
{
    public class HomeView
    {
        IWebDriver webDriver = null;

        //constructor
        public HomeView(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void OpenAppointSchedule(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.webDriver.Url = "http://automatizacion.herokuapp.com/acastaneda/";
        }

        //Seleccionar agendar cita
        [FindsBy(How = How.XPath , Using = "//*[@id='page-wrapper']/div/div[2]/div/div/div/div/div[1]/div/a[6]")]
        private IWebElement agendarCitaLink { get; set; }

        //
        [FindsBy(How = How.ClassName, Using = "list-group")]
        private IWebElement FirstLink { get; set; }
        
        
        //Metodo para interactuar
        public Boolean AccesToAppointmentSchedule()
        {
            //FirstLink.Click();
            agendarCitaLink.Click();
            return true;
        }
    }
}
