using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SimpleGoogleSearch.StepDefinitions
{
    [Binding]
    public class SearchGoogleStepDefinitions
    {
		IWebDriver driver;
		string _workflowName;

		[Given(@"i navigate to google\.com")]
        public void GivenINavigateToGoogle_Com()
        {
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--window-size=1920,1080");

			driver = new ChromeDriver(options);
			driver.Url = "http://google.co.uk";
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/span/div/div/div/div[3]/div[1]/button[2]/div")).Click();  
		}

        [Given(@"I search for BBC")]
        public void GivenISearchForBBC()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("BBC website");

		}

        [Given(@"I click search")]
        public void GivenIClickSearch()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]")).Click();

		}

        [Then(@"Search results show")]
        public void ThenSearchResultsShow()
        {
            Console.WriteLine("thats good enough for me");
        }

		[Then(@"I close browser")]
		public void ThenICloseBrowser()
		{
            driver.Close();
		}

	}
}
