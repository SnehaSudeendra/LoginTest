/*using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

public class KendoDropdownHelper
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public KendoDropdownHelper(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public List<string> GetDropdownValues(string formControllerName)
    {
        // Locate the Kendo dropdown element
        IWebElement dropdownElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector($"[data-role='dropdownlist'][name='{formControllerName}']")));

        // Click the dropdown to open it
        dropdownElement.Click();

        // Wait for the dropdown list to be visible
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".k-list-container.k-popup")));

        // Find all option elements
        var options = driver.FindElements(By.CssSelector(".k-list-container.k-popup .k-item"));

        // Extract text from each option
        List<string> dropdownValues = options.Select(option => option.Text).ToList();

        // Close the dropdown
        dropdownElement.Click();

        return dropdownValues;
    }
}*/