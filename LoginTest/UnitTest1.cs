using OpenQA.Selenium;  
using OpenQA.Selenium.Chrome;    
using OpenQA.Selenium.Support.UI;
using loginPage.BaseClass ;
using AventStack.ExtentReports;
using loginPage.BaseClass;
using NUnit.Framework.Interfaces;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.DevTools.V124.DOM;
using System.Security.Policy;
using OpenQA.Selenium.Interactions;

namespace LoginTest
{
    [TestFixture]
    public class LoginTest1 : BaseTest
    {
        [Test, Order(1)]
        public void TestMethodEnterEmail()
        {
            IWebElement emailTextField = driver.FindElement(By.Id("userName"));
            emailTextField.SendKeys("sygnaltestuser@sygnal.tech");
            Thread.Sleep(2000);
        }

        [Test, Order(2)]
        public void TestMethodPassword()
        {
            IWebElement passwordTextField = driver.FindElement(By.Id("password"));
            passwordTextField.SendKeys("pass#word1");
            Thread.Sleep(4000);
        }

        [Test, Order(3)]
        public void TestMethodLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.Id("btn_login"));
            loginButton.Click();
            Thread.Sleep(5000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement elementOnNextPage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("page-content")));
            Thread.Sleep(5000);
        }

        [Test, Order(4)]
        public void SelectOrganisation()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement selectDev = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/block-ui/auth/multi-tenant-login/mat-sidenav-container/mat-sidenav-content/div/div[2]/div[1]/mat-card[1]")));
            selectDev.Click();
            IWebElement elementOnNextPage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("page-content")));
        }

        [Test, Order(5)]
        public void ClientModule()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement client = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/block-ui/app-dashboard/mat-sidenav-container/mat-sidenav-content/kendo-menu/ul/li[2]")));
            client.Click();
            Thread.Sleep(5000);
        }

        [Test, Order(6)]
        public void CreateClientModule()
        {
            IWebElement createButton = driver.FindElement(By.XPath("/html/body/app-root/block-ui/app-dashboard/mat-sidenav-container/mat-sidenav-content/div/ng-component/client-landing/div/div[2]/div[2]/div"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(createButton));
            createButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("page-content")));
            Thread.Sleep(10000);
        }

        [Test, Order(7)]
        public void AgedCareFirstName()
        {
            IWebElement FirstName = driver.FindElement(By.CssSelector("input[formcontrolname='firstName']"));
            FirstName.SendKeys("test1");
            Thread.Sleep(2000);
        }

        [Test, Order(8)]
        public void AgedCareLastName()
        {
            IWebElement FirstName = driver.FindElement(By.CssSelector("input[formcontrolname='lastName']"));
            FirstName.SendKeys("abc");
            Thread.Sleep(2000);
        }

        [Test, Order(9)]
        public void AgedCareDOB()
        {
            IWebElement DateField = driver.FindElement(By.CssSelector("input.k-input-inner"));
            DateField.Clear();
            DateTime DateToEnter = new DateTime(2000, 11, 04);
            string formattedDate = DateToEnter.ToString("dd/MM/yyyy");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value = arguments[1];", DateField, formattedDate);           
            string fieldValue = DateField.GetAttribute("value");
            DateTime enteredDate = DateTime.Parse(fieldValue);
            string enteredFormattedDate = enteredDate.ToString("dd/MM/yyyy");
            Assert.AreEqual(formattedDate, enteredFormattedDate);
        }

        [Test, Order(10)]
        public void AgeCareEmail()
        {
            IWebElement Email = driver.FindElement(By.XPath("//input[contains(@placeholder, 'Email ID')]"));
            Email.SendKeys("test@gmail.com");
            Thread.Sleep(5000);
        }

        [Test, Order(11)]
        public void AgeCareMobileNumber()
        {
            IWebElement MobileNumber = driver.FindElement(By.CssSelector("input[formcontrolname='mobile']"));
            MobileNumber.SendKeys("8618323398");
            Thread.Sleep(5000);
        }

        [Test, Order(12)]
        public void TestMethodSelectGender()
        {
            try
            {
                Console.WriteLine("Attempting to locate the dropdown with text '----- Select Gender -----'");
                IWebElement genderDropDown = driver.FindElement(By.XPath("//span[contains(text(), '----- Select Gender -----')]"));
                Thread.Sleep(5000);
                genderDropDown.Click();
                Console.WriteLine("Dropdown clicked. Waiting for options to be visible...");
                Thread.Sleep(5000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownOptionsContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".k-list-md .k-list-ul")));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string htmlContent = (string)js.ExecuteScript("return arguments[0].innerHTML;", dropdownOptionsContainer);
                Console.WriteLine("Dropdown options container HTML:");
                Console.WriteLine(htmlContent);
                var options = dropdownOptionsContainer.FindElements(By.CssSelector("li.k-list-item"));
                Console.WriteLine($"Number of options found: {options.Count}");
                if (options.Count < 2)
                {
                    throw new Exception("Not enough options in the dropdown to select the second one.");
                }
                IWebElement secondOption = options[1];
                Console.WriteLine("Attempting to select the second option: " + secondOption.Text);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", secondOption);
                Thread.Sleep(5000);
                secondOption.Click();
                Console.WriteLine("Second option selected.");
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }      

        [Test, Order(13)]
        public void MaritalStatus()
        {
            try
            {
                Console.WriteLine("Attempting to locate the dropdown with text '----- Select Marital status -----'");
                IWebElement genderDropDown = driver.FindElement(By.XPath("//span[contains(text(), '----- Select Marital Status -----')]"));
                Thread.Sleep(5000);
                genderDropDown.Click();
                Console.WriteLine("Dropdown clicked. Waiting for options to be visible...");
                Thread.Sleep(5000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownOptionsContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".k-list-md .k-list-ul")));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string htmlContent = (string)js.ExecuteScript("return arguments[0].innerHTML;", dropdownOptionsContainer);
                Console.WriteLine("Dropdown options container HTML:");
                Console.WriteLine(htmlContent);
                var options = dropdownOptionsContainer.FindElements(By.CssSelector("li.k-list-item"));
                Console.WriteLine($"Number of options found: {options.Count}");
                if (options.Count < 2)
                {
                    throw new Exception("Not enough options in the dropdown to select the second one.");
                }
                IWebElement secondOption = options[1];
                Console.WriteLine("Attempting to select the second option: " + secondOption.Text);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", secondOption);
                Thread.Sleep(5000);
                secondOption.Click();
                Console.WriteLine("Second option selected.");
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }          

        [Test, Order(14)]
        public void TestMethodEnterCDCNumber()
        {
            IWebElement cdcNumberInputField = driver.FindElement(By.CssSelector("input[formcontrolname='cdcNumber']"));
            cdcNumberInputField.Clear();
            cdcNumberInputField.SendKeys("4568365535");
            Thread.Sleep(3000);
        }

        [Test, Order(15)]
        public void SelectionOfSubsidary()
        {
            try
            {
                Console.WriteLine("Attempting to locate the dropdown with text '----- Select Subsidiary -----'");
                IWebElement genderDropDown = driver.FindElement(By.XPath("//span[contains(text(),'----- Select Subsidiary -----')]"));
                Thread.Sleep(5000);
                genderDropDown.Click();
                Console.WriteLine("Dropdown clicked. Waiting for options to be visible...");
                Thread.Sleep(5000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownOptionsContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".k-list-md .k-list-ul")));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string htmlContent = (string)js.ExecuteScript("return arguments[0].innerHTML;", dropdownOptionsContainer);
                Console.WriteLine("Dropdown options container HTML:");
                Console.WriteLine(htmlContent);
                var options = dropdownOptionsContainer.FindElements(By.CssSelector("li.k-list-item"));
                Console.WriteLine($"Number of options found: {options.Count}");
                if (options.Count < 2)
                {
                    throw new Exception("Not enough options in the dropdown to select the second one.");
                }
                IWebElement secondOption = options[1];
                Console.WriteLine("Attempting to select the second option: " + secondOption.Text);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", secondOption);
                Thread.Sleep(5000);
                secondOption.Click();
                Console.WriteLine("Second option selected.");
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        [Test, Order(16)]
        public void SelectCaseManager()
        {
            IWebElement caseManagerButton = driver.FindElement(By.CssSelector("input[formcontrolname='caseManager']"));
            caseManagerButton.SendKeys("Sygnal Admin");
            Thread.Sleep(3000);
        }

        [Test, Order(17)]
        public void GoverntmentFunds()
        {
            IWebElement governmentFundsInputField = driver.FindElement(By.CssSelector("input[formcontrolname='governmentFunds']"));
            governmentFundsInputField.Clear();
            governmentFundsInputField.SendKeys("5000");
            Thread.Sleep(3000);
        }

        [Test, Order(18)]
        public void ProviderFunds()
        {
            IWebElement providerFundsInputField = driver.FindElement(By.CssSelector("input[formcontrolname='providerFunds']"));
            providerFundsInputField.Clear();
            providerFundsInputField.SendKeys("1000");
            Thread.Sleep(3000);
        }

        [Test, Order(19)]
        public void ManagementFee()
        {
            IWebElement managementFeeInputField = driver.FindElement(By.CssSelector("input[formcontrolname='managementFee']"));
            managementFeeInputField.Clear();
            managementFeeInputField.SendKeys("500");
            Thread.Sleep(3000);
        }

        [Test, Order(20)]
        public void ManagementFeeSystemEffectiveDate()
        {
            IWebElement ManagementFeeEffectiveDateButton = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[1]/div[2]/div[4]/div/kendo-datepicker"));
            ManagementFeeEffectiveDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }
        [Test, Order(21)]
        public void ITFDeductions()
        {
            IWebElement ITFDeductionInputField = driver.FindElement(By.CssSelector("input[formcontrolname='itfDeductions']"));
            ITFDeductionInputField.Clear();
            ITFDeductionInputField.SendKeys("500");
            Thread.Sleep(3000);
        }

        [Test, Order(22)]
        public void ITFDeductionsSystemEffectiveDate()
        {
            IWebElement ITFSystemEffectiveDateButton = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[1]/div[2]/div[5]/div/kendo-datepicker"));
            ITFSystemEffectiveDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }
        [Test,Order(23)]
        public void SubsidaryReduction()
        {
            IWebElement ITFDeductionInputField = driver.FindElement(By.CssSelector("input[formcontrolname='subsidyReduction']"));
            ITFDeductionInputField.Clear();
            ITFDeductionInputField.SendKeys("1.03");
            Thread.Sleep(3000);
        }

        [Test, Order(24)]
        public void SubsidaryReductionsEffectiveDate()
        {
            IWebElement SubsidaryReductionEffectiveDateButton = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[1]/div[2]/div[6]/div/kendo-datepicker"));
            SubsidaryReductionEffectiveDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }
        [Test,Order(25)]
        public void ITFReduction()
        {
            IWebElement ITFDeductionInputField = driver.FindElement(By.CssSelector("input[formcontrolname='itfReduction']"));
            ITFDeductionInputField.Clear();
            ITFDeductionInputField.SendKeys("0.03");
            Thread.Sleep(3000);
        }

        [Test, Order(26)]
        public void ITFReductionEffectiveDate()
        {
            IWebElement ITFReductionEffectiveDateButton = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[1]/div[2]/div[7]/div/kendo-datepicker"));
            ITFReductionEffectiveDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }
        
        [Test, Order(27)]
        public void NextButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement NextButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[1]/div[4]/button[2]")));
            NextButton.Click();
            IWebElement elementOnNextPage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("page-content")));
        }
        
        [Test, Order(28)]
        public void SubsidaryLevel()
        {
            try
            {
                Console.WriteLine("Attempting to locate the dropdown with text '----- Select Subsidiary Level -----'");
                IWebElement genderDropDown = driver.FindElement(By.XPath("//span[contains(text(), '----- Select Subsidy Level -----')]"));
                Thread.Sleep(5000);
                genderDropDown.Click();
                Console.WriteLine("Dropdown clicked. Waiting for options to be visible...");
                Thread.Sleep(5000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownOptionsContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".k-list-md .k-list-ul")));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string htmlContent = (string)js.ExecuteScript("return arguments[0].innerHTML;", dropdownOptionsContainer);
                Console.WriteLine("Dropdown options container HTML:");
                Console.WriteLine(htmlContent);
                var options = dropdownOptionsContainer.FindElements(By.CssSelector("li.k-list-item"));
                Console.WriteLine($"Number of options found: {options.Count}");
                if (options.Count < 2)
                {
                    throw new Exception("Not enough options in the dropdown to select the second one.");
                }
                IWebElement secondOption = options[1];
                Console.WriteLine("Attempting to select the second option: " + secondOption.Text);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", secondOption);
                Thread.Sleep(5000);
                secondOption.Click();
                Console.WriteLine("Second option selected.");
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        [Test, Order(29)]
        public void HomeCareSubsidarySystemEffectiveDate()
        {
            IWebElement HomeCareSystemEffectiveDateButton = driver.FindElement(By.CssSelector("kendo-datepicker[formcontrolname='clientLevelEffectiveDate'] button"));
            HomeCareSystemEffectiveDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }
         
        [Test,Order(30)]
        public void DementiaCognitionVeteranCheckBox()
        {
            IWebElement HomeCarecheckboxLabel = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[2]/div[1]/div[2]/div[2]/mat-checkbox/div/div/div[3]"));
            HomeCarecheckboxLabel.Click();
            IWebElement checkboxInput = driver.FindElement(By.Id("mat-checkbox-1-input"));
            Assert.IsTrue(checkboxInput.Selected, "Checkbox is not checked");
            Thread.Sleep(3000);
        }

        [Test, Order(31)]
        public void HomeCareSupplementLevelDate()
        {
            IWebElement HomeCareDateButton = driver.FindElement(By.CssSelector("kendo-datepicker[formcontrolname='dcvSupplementEffectiveDate'] button"));
            HomeCareDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }

        [Test, Order(32)]
        public void EACHDLevelCheckbox()
        {
            IWebElement EACHDCheckbox = driver.FindElement(By.CssSelector("input[id='mat-mdc-checkbox-2-input']"));
            EACHDCheckbox.Click();
            Assert.IsTrue(EACHDCheckbox.Selected, "Checkbox is not checked");
            Thread.Sleep(3000);
        }

        [Test, Order(33)]
        public void TestEACHDEffectiveDate()
        {
            IWebElement TestEACHDDateButton = driver.FindElement(By.CssSelector("kendo-datepicker[formcontrolname='eachadEffectiveDate'] button"));
            TestEACHDDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }

        [Test, Order(34)]
        public void OxygenSupplimentsCheckbox()
        {
            IWebElement OxygenSupplimentcheckbox = driver.FindElement(By.CssSelector("input[id='mat-mdc-checkbox-3-input']"));
            OxygenSupplimentcheckbox.Click();
            Assert.IsTrue(OxygenSupplimentcheckbox.Selected, "Checkbox is not checked");
            Thread.Sleep(3000);
        }

        [Test, Order(35)]
        public void FeedingSupplimentsDate()
        {
            IWebElement FeedingSupplimentsDateButton = driver.FindElement(By.CssSelector("kendo-datepicker[formcontrolname='oaefSupplementsEffectiveDate'] button"));
            FeedingSupplimentsDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }

        [Test, Order(36)]
        public void MMMClassification()
        {
            try
            {
                Console.WriteLine("Attempting to locate the dropdown with text '----- MMM Classification -----'");
                IWebElement genderDropDown = driver.FindElement(By.XPath("//span[contains(text(),'----- Select MMM Classification -----')]"));
                Thread.Sleep(5000);
                genderDropDown.Click();
                Console.WriteLine("Dropdown clicked. Waiting for options to be visible...");
                Thread.Sleep(5000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownOptionsContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".k-list-md .k-list-ul")));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string htmlContent = (string)js.ExecuteScript("return arguments[0].innerHTML;", dropdownOptionsContainer);
                Console.WriteLine("Dropdown options container HTML:");
                Console.WriteLine(htmlContent);
                var options = dropdownOptionsContainer.FindElements(By.CssSelector("li.k-list-item"));
                Console.WriteLine($"Number of options found: {options.Count}");
                if (options.Count < 2)
                {
                    throw new Exception("Not enough options in the dropdown to select the second one.");
                }
                IWebElement secondOption = options[1];
                Console.WriteLine("Attempting to select the second option: " + secondOption.Text);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", secondOption);
                Thread.Sleep(5000);
                secondOption.Click();
                Console.WriteLine("Second option selected.");
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        [Test, Order(37)]
        public void MMMClassificationSupplementsDate()
        {
            IWebElement MMMClassificationSupplimentsDateButton = driver.FindElement(By.CssSelector("kendo-datepicker[formcontrolname='mmmClassificationEffectiveDate'] button"));
            MMMClassificationSupplimentsDateButton.Click();
            Thread.Sleep(3000);
            IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
            currentDate.Click();
            Thread.Sleep(3000);
        }

        [Test, Order(38)]
        public void ARIARates()
        {
            try
            {
                Console.WriteLine("Attempting to locate the dropdown with text '----- ARIA Score -----'");
                IWebElement genderDropDown = driver.FindElement(By.XPath("//span[contains(text(),'----- Select ARIA Score -----')]"));
                Thread.Sleep(5000);
                genderDropDown.Click();
                Console.WriteLine("Dropdown clicked. Waiting for options to be visible...");
                Thread.Sleep(5000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownOptionsContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".k-list-md .k-list-ul")));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string htmlContent = (string)js.ExecuteScript("return arguments[0].innerHTML;", dropdownOptionsContainer);
                Console.WriteLine("Dropdown options container HTML:");
                Console.WriteLine(htmlContent);
                var options = dropdownOptionsContainer.FindElements(By.CssSelector("li.k-list-item"));
                Console.WriteLine($"Number of options found: {options.Count}");
                if (options.Count < 2)
                {
                    throw new Exception("Not enough options in the dropdown to select the second one.");
                }
                IWebElement secondOption = options[1];
                Console.WriteLine("Attempting to select the second option: " + secondOption.Text);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", secondOption);
                Thread.Sleep(5000);
                secondOption.Click();
                Console.WriteLine("Second option selected.");
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        [Test, Order(39)]
        public void ARIARatesDate() 
        {
        IWebElement MMMClassificationSupplimentsDateButton = driver.FindElement(By.CssSelector("kendo-datepicker[formcontrolname='ariaRatesEffectiveDate'] button"));
        MMMClassificationSupplimentsDateButton.Click();
        Thread.Sleep(3000);
        IWebElement currentDate = driver.FindElement(By.CssSelector(".k-calendar .k-today"));
        currentDate.Click();
        Thread.Sleep(3000);
        }

        [Test, Order(40)]
        public void NextButton2()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement NextButton2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[2]/div[2]/button[2]")));
            NextButton2.Click();
            IWebElement elementOnNextPage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("page-content")));
        }

        [Test, Order(41)]
        public void Question1()
        {
            IWebElement Question1Field = driver.FindElement(By.CssSelector("input[placeholder='Question 1 Req']"));
            Question1Field.Clear();
            Question1Field.SendKeys("abc");
            Thread.Sleep(3000);
        }

        [Test, Order(42)]
        public void Question2()
        {
            IWebElement Question2Field = driver.FindElement(By.CssSelector("input[placeholder='Q2 Not Req']"));
            Question2Field.Clear();
            Question2Field.SendKeys("xyx");
            Thread.Sleep(3000);
        }

        [Test, Order(43)]
        public void Question3()
        {
            IWebElement Question3Field = driver.FindElement(By.CssSelector("input[placeholder='Q3 Req']"));
            Question3Field.Clear();
            Question3Field.SendKeys("xyx");
            Thread.Sleep(3000);
        }

        [Test, Order(44)]
        public void SingleChoice()
        {
            try
            {
                Console.WriteLine("Attempting to locate the dropdown with text '----- Single Choice -----'");
                IWebElement genderDropDown = driver.FindElement(By.CssSelector("#cdk-accordion-child-2 > div > div > div > div:nth-child(4) > div > choice-single-selection-directive > div > mat-form-field > div.mat-mdc-text-field-wrapper.mdc-text-field.ng-tns-c1205077789-106.mdc-text-field--outlined > div > div.mdc-notched-outline.ng-tns-c1205077789-106.mdc-notched-outline--upgraded.ng-star-inserted"));
                Thread.Sleep(5000);
                genderDropDown.Click();
                Console.WriteLine("Dropdown clicked. Waiting for options to be visible...");
                Thread.Sleep(5000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownOptionsContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".k-list-md .k-list-ul")));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string htmlContent = (string)js.ExecuteScript("return arguments[0].innerHTML;", dropdownOptionsContainer);
                Console.WriteLine("Dropdown options container HTML:");
                Console.WriteLine(htmlContent);
                var options = dropdownOptionsContainer.FindElements(By.CssSelector("li.k-list-item"));
                Console.WriteLine($"Number of options found: {options.Count}");
                if (options.Count < 2)
                {
                    throw new Exception("Not enough options in the dropdown to select the second one.");
                }
                IWebElement secondOption = options[1];
                Console.WriteLine("Attempting to select the second option: " + secondOption.Text);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", secondOption);
                Thread.Sleep(5000);
                secondOption.Click();
                Console.WriteLine("Second option selected.");
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        [Test, Order(45)]
        public void ArrowDownClick()
        {
            IWebElement ArrowDown = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]"));
            ArrowDown.Click();
            Thread.Sleep(5000);
        }

        [Test, Order(46)]
        public void TestingText()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement inputElement = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[1]/div/text-directive/div/mat-form-field/div[1]/div/div[2]/input"));
                inputElement.SendKeys("Hello");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element not found: " + e.Message);
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Element not found within the time limit: " + e.Message);
            }
        }

        [Test, Order(47)]
        public void TestingTextArea()
        {
            IWebElement TestingTextArea = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[2]/div/text-area-directive/div/mat-form-field/div[1]/div/div[2]/textarea"));
            TestingTextArea.SendKeys("abcdefg");
            Thread.Sleep(3000);
        }      

        [Test, Order(48)]
        public void TestingSingleSignature()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[3]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[5]/div/choice-single-selection-directive/div/mat-form-field/div[1]/div/div[1]")));
                dropdown.Click();
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("mat-option")));
                var options = driver.FindElements(By.CssSelector("mat-option"));
                if (options.Any())
                {
                    var firstOption = options.First();
                    string firstValue = firstOption.GetAttribute("value");
                    string firstText = firstOption.Text;
                    Console.WriteLine($"First dropdown value: {firstValue}");
                    Console.WriteLine($"First dropdown text: {firstText}");
                }
                else
                {
                    Console.WriteLine("No options found in the dropdown.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        [Test, Order(49)]
        public void TestingMultiSignature()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement multiSelectElement = wait.Until(d => d.FindElement(By.CssSelector("kendo-multiselect")));
            Console.WriteLine("Clicking on the multiselect dropdown");
            multiSelectElement.Click();
            Console.WriteLine("Waiting for the dropdown options to be visible");
            IWebElement dropdown = wait.Until(d => d.FindElement(By.CssSelector(".k-list-container ul")));
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Fetching the first option");
            IWebElement firstOption = dropdown.FindElement(By.CssSelector(".k-list-item"));
            string firstOptionText = firstOption.Text;
            Console.WriteLine("First option text: " + firstOptionText);
            firstOption.Click();
        }

        [Test,Order(50)]
        public void AddNewGrid()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(50000);
            IWebElement AddNewGridButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[8]/div/grid-directive/div/kendo-grid/kendo-grid-toolbar/button")));
            AddNewGridButton.Click();
            IWebElement elementOnNextPage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("page-content")));
        }

        [Test, Order(51)]
        public void SearchAddressButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement SearchButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[9]/div/address-directive/div/div[1]/button")));
            SearchButton.Click();
        }

        [Test,Order(52)]
        public void SearchAddressInput()
        {
            IWebElement AddressInput = driver.FindElement(By.CssSelector("input[placeholder='Search Address']"));
            AddressInput.SendKeys("Airport Drive, Brisbane Airport QLD, Australia");
            Thread.Sleep(2000);
        }

        [Test,Order(53)]
        public void AddAddressButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement AddAddressButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[4]/div[4]/div/mat-dialog-container/div/div/address-search-dialog/div/mat-dialog-content/div[2]/div[2]/button")));
            AddAddressButton.Click();
        }

        /*[Test,Order(51)]
        public void TestingAddress()
        {
            IWebElement TestingAddress = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[9]/div/address-directive/div/div[2]/div[1]/mat-form-field"));
            TestingAddress.SendKeys("abcdefg");
            Thread.Sleep(3000);
        }

        [Test, Order(52)]
        public void PostalCode()
        {
            IWebElement PostalField = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[9]/div/address-directive/div/div[2]/div[2]/mat-form-field"));
            PostalField.SendKeys("572104");
            Thread.Sleep(3000);
        }

        [Test,Order(53)]
        public void StateField()
        {
            IWebElement StateField = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[9]/div/address-directive/div/div[2]/div[4]/mat-form-field"));
            StateField.SendKeys("abcdefghi");
            Thread.Sleep(3000);
        }

        [Test, Order(54)]
        public void SuburbField()
        {
            IWebElement SuburbField = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[1]/form-view-directive/div/div[2]/mat-accordion/div[2]/mat-expansion-panel/div/div/div/div/div[9]/div/address-directive/div/div[2]/div[5]/mat-form-field"));
            SuburbField.SendKeys("abcdefghi");
            Thread.Sleep(3000);
        }

        [Test,Order(55)]
        public void TestBirthDate()
        {
            IWebElement DateField = driver.FindElement(By.CssSelector("#cdk-accordion-child-1 > div > div > div > div:nth-child(11) > div > birth-date-picker-directive > div > div > kendo-datepicker"));
            DateField.Clear();
            DateTime DateToEnter = new DateTime(2019, 11, 04);

            string formattedDate = DateToEnter.ToString("dd/MM/yyyy");

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value = arguments[1];", DateField, formattedDate);
            string fieldValue = DateField.GetAttribute("value");
            DateTime enteredDate = DateTime.Parse(fieldValue);
            string enteredFormattedDate = enteredDate.ToString("dd/MM/yyyy");

            Assert.AreEqual(formattedDate, enteredFormattedDate);
        }*/

        [Test, Order(54)]
        public void SaveButton()
        {
            IWebElement SaveButton = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/div/div/app-client-create-and-edit/div/mat-dialog-content/mat-tab-group/div/mat-tab-body[1]/div/app-client-aged-care-form/div/mat-stepper/div/div[2]/div[3]/div[2]/button"));
            SaveButton.Click();
            Thread.Sleep(3000);
        }

    }

    
}



