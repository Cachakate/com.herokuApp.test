using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace com.PSL.PageObject
{
    public class AppointmentErrorView
    {
        //constructor
        public AppointmentErrorView(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "text-danger")]
        private IWebElement errorMessage { get; set; }

        [FindsBy(How = How.ClassName, Using = "panel-body")]
        private IWebElement successMessage { get; set; }

        public string errorCatcher()
        {
           return errorMessage.Text;
        }

        public string successCatcher()
        {
            return successMessage.Text;
        }
      
    }
}
