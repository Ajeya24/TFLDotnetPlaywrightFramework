A repository to automate the TFL Plan my journey functionality using .NET and Playwright.

Design Decisions
------------------------------------------------------------------------------------------------
The Framework is built using the Page Object Model Design Pattern where the test cases logic are separated from the 
functionality and locators. All the page level classes have their relevant locators and the respective functions.
The configuration and drivers functionality is being isolated and called upon when required thus keeping each component
separate for reusability and maintainabilty of code.The framework is modular in nature and scalable.
The test cases are written in Gherkin syntax and Step definitions navigate to different Page level classes to 
invoke relevant functions.


IDE and Setup
-------------------------------------------------------------------------------------------------
The project is built using .NET 8 and Rider IDE.The tests are run using Test Explorer.



