using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;


namespace SeleniumTemplate
{
    [Binding]
    public class StepDefinition
    {
        private PageObject _pageObject;
        public PageObject PageObject => _pageObject ?? (_pageObject = new PageObject());
        public static IWebDriver Driver;
        public class Browser

        {
            public IWebDriver Chrome;

            public Browser()
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                Chrome = new ChromeDriver(options);
            }
        }

        public StepDefinition(Browser browser)
        {
            Driver = browser.Chrome;
            PageFactory.InitElements(Driver, PageObject);
        }

        [Given(@"I navigate to claims")]
        public void GivenINavigateToClaims()
        {
            Driver.Url = "https://claim.skycop.com";
        }

        [Then(@"I set Kaunas as departure airport")]
        public void ThenISetKaunasAsDepartureAirport()
        {
            Thread.Sleep(2000);
            var departureAirportField = Driver.FindElement(By.XPath("(//input[@class='Select-input'])[1]"));
            departureAirportField.SendKeys("Kaunas");
            Thread.Sleep(2000);
            var kaunasSelection = Driver.FindElement(By.XPath("//div[@title='Kaunas International Airport']"));
            kaunasSelection.Click();
        }

        [Then(@"I set Gatwick as arrival airport")]
        public void ThenISetGatwickAsArrivalAirport()
        {
            Thread.Sleep(2000);
            var arrivalAirportField = Driver.FindElement(By.XPath("(//input[@class='Select-input'])[2]"));
            arrivalAirportField.SendKeys("Gatwick");
            Thread.Sleep(2000);
            var gatwickSelection = Driver.FindElement(By.XPath("//div[@title='London Gatwick Airport']"));
            gatwickSelection.Click();
        }

        [Then(@"I set airlines")]
        public void ThenISetAirlines()
        {
            Thread.Sleep(2000);
            var airlinesField = Driver.FindElement(By.XPath("(//input[@class='Select-input'])[3]"));
            airlinesField.SendKeys("Ryanair");
            Thread.Sleep(2000);
            var airlineSelection = Driver.FindElement(By.XPath("//div[@title='Ryanair']"));
            airlineSelection.Click();
        }

        [Then(@"I enter flight number")]
        public void ThenIEnterFlightNumber()
        {
            Thread.Sleep(2000);
            var flightNumberField = Driver.FindElement(By.XPath("//input[@name='failedFlightNumberDigits']"));
            flightNumberField.SendKeys("1234");
        }

        [Then(@"I choose flight date")]
        public void ThenIChooseFlightDate()
        {
            Thread.Sleep(2000);
            var flightDateField = Driver.FindElement(By.XPath("//input[@name='failedFlightDate']"));
            flightDateField.Click();
            Thread.Sleep(2000);
            var DaySelection = Driver.FindElement(By.XPath("//td[@data-value='1']"));
            DaySelection.Click();
        }

        [Then(@"I answer questions about flight")]
        public void ThenIAnswerQuestionsAboutFlight()
        {
            Thread.Sleep(2000);
            var ProblemSelection = Driver.FindElement(By.XPath("//span[text()='Denied boarding']"));
            ProblemSelection.Click();
            Thread.Sleep(2000);
            var DelaySelection = Driver.FindElement(By.XPath("//span[text()='Never arrived']"));
            DelaySelection.Click();
            Thread.Sleep(2000);
            var VolunteerSelection = Driver.FindElement(By.XPath("//span[text()='Yes']"));
            VolunteerSelection.Click();
        }
        
        [Then(@"I choose where I heard about Skycop")]
        public void ThenIChooseWhereIHeardAboutSkycop()
        {
        
            Thread.Sleep(2000);
            var heardSelection = Driver.FindElement(By.XPath("//span[@id='react-select-6--value']"));
            heardSelection.Click();
            Thread.Sleep(2000);
            var GoogleSelection = Driver.FindElement(By.XPath("//div[@id='react-select-6--option-0']"));
            GoogleSelection.Click();
        }


        [Then(@"I choose next step")]
        public void ThenIChooseNextStep()
        {

            Thread.Sleep(2000);
            var nextStepSelection = Driver.FindElement(By.XPath("//button[@type='submit']"));
            nextStepSelection.Click();
        }
    }
}

