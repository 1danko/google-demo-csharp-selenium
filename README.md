# Test Automation Framework for web application

This is a test automation framework that uses C#, Selenium, Specflow, Allure and AzureDevOps to run UI tests on a web application.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Framework Structure](#framework-structure)
- [Adding and Automating Tests](#adding-and-automating-tests)
- [Test data](#test-data)
- [Reporting](#report)

## Prerequisites

- Visual Studio 2022 or later
- .NET Core 6.0 SDK or later
- SpecFlow extension for Visual Studio
- Install allure to your pc - [Installing the allure report](https://allurereport.org/docs/gettingstarted/installation/) 

## Getting Started

1. Clone or download this repository to your local machine.
2. Open the solution file (**QA.GoogleDemo.sln**) in Visual Studio.
3. Restore the NuGet packages for the solution.
5. Build the solution in Visual Studio.
6. Run the tests using Test Explorer or dotnet test command.

## Framework Structure

The framework consists of the following folders and files:

- **Factories** folder: contains the factory class that create and manage web driver instances
- **Features** folder: contains the feature files that define the test scenarios using Gherkin language
- **PageObjects** folder: contains the page object classes that encapsulate the web elements and actions for each page of the web application
- **Pipelines** folder: defines the Azure DevOps pipelines for building and running the tests
- **Resources** folder: contains the configuration files and test data files
- **StepDefinitions** folder: contains the step definition classes that implement the logic for each step of the test scenarios
- **Support** folder: contains the helper classes and hooks for test initialization and cleanup
- **.gitignore** file: specifies the files and folders to be ignored by Git
- **ImplicitUsings.cs** file: enables global usings for C# 
- **README.md** file: provides an overview of the framework and instructions for usage

## Adding and Automating Tests

To add a new test, create a new feature file in the `Features` directory. Write your test scenarios using the Gherkin language. Here's an example:

```gherkin
Feature: Login Feature
Scenario: Successful Login with Valid Credentials
Given User is at the Login Page
When User enters valid credentials
And Clicks on the Login button
Then User should be redirected to the Home Page
```

Then, create a PageObject file related to the test, for example LoginPage.cs, in the `PageObjects` directory. 
Write and develop methods and elements that related to this page.  
Next, create the step definitions in the `StepDefinitions` directory, for example LoginSteps. 
Make sure to match the steps with the ones defined in your feature file. 

## Test Data 

All Test data storing in the `Resources` directory that containing various configuration files and additional test data necessary for running automated tests. 

**CONTENTS**

1. **.settings.json files:**
   - The `.settings.json` files contain credentials and additional test data specific to different environments. These files are used to store sensitive information like usernames, passwords, test data, API keys, etc., required for test execution.

2. **ExecEnv.json:**
   - The `ExecEnv.json` file enables the user to choose the desired browser and test execution environment:
     - **Browser:** The browser in which the tests will be executed (Chrome only right now).
     - **Execution Environment:** The target execution environment (e.g., local, selenoid).
     - 

## Reporting

This framework use the Allure report for reporting. To view report, after running the tests run this command:
```
allure generate allure-results && allure open
```

