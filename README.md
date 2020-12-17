# Test Automation Challenge 🔄

## Description

AUT : http://computer-database.gatling.io/computers

Automating the functional test cases to be included in a regression test set. 

Functional test cases : https://github.com/saritacutinha/ComputerDataBase_RegressionTests/blob/master/FunctionalTestCases_ComputerDatabaseApplication.xlsx

Time Taken : 7 hours

## Test Strategy :
Testing Framework : 
1. Modular Framework Approach using POM
2. Automated the Highest Priority Test Cases First.

## Test Environment : 
Editor Used : Visual Studio 2019 Community Edition
Packages used for Browser Automation : 
1. Selenium.Support 3.141.0
2. Selenium WebDriver 3.141.0
3. Selenium.WebDriver.ChromeDriver 87.0.4280.8800

Framework used for Tests :
1. Nunit 3.12.0

Test Data and Configuration Management 
1. Microsoft.Extensions.Configuration 5.0.0

## Details

### 👣 Steps for running the test project.
1. Clone repository.
2. Build the Project 
3. Run Tests
4. Extent Report Will be available in the current working directory.

### 🏗 Structure:
-->CommonLibs Class Library Project holds:
1. Implementation Folder.
    1. Driver Set Up used in the Entire Solution
    2. Common Actions performed by the driver on IWebElements.
2. Utility Folder.
    1. Reporting Utility.
-->PageObject Class Library Project holds all the modules of the Application.

-->Regression Tests : Hold the Tests.

### 🏆 Additional Improvements to be considered:
1. Refactoring code for waits, test data organisation
2. Adding additional browser support
3. BDD Framework Integration.
4. Parallel testing





