Feature: Journey Planner for TFL 

Background: User launches the TFL Journey Planner application
    Given User launches the TFL Journey Planner application
    
Scenario Outline:Validate a valid journey can be planned
    When User enters the "<From>" and "<To>" locations
    Then validate that journey results page is displayed
       
Examples:
    | From      | To     |
    | Leicester | Covent |
    
Scenario Outline: Amend a journey to select least walking route and update the journey
    When User enters the "<From>" and "<To>" locations  
    When User clicks on EditPreferences Link
    And User selects the route with least walking option
    And User clicks on Update Journey button
    Then User validates that the journey results page is displayed with least walking route
    
Examples:
    | From      | To     |
    | Leicester | Covent |
    
Scenario Outline: Validate complete access information at Covent Garden Station
    When User enters the "<From>" and "<To>" locations  
    When User clicks on EditPreferences Link
    And User selects the route with least walking option
    And User clicks on Update Journey button
    And User clicks on View Details button
    Then User validates complete access information is displayed for Covent Garden Station
    
Examples:
    | From      | To     |
    | Leicester | Covent |
    
Scenario Outline: Validate an invalid journey cannot be planned
    When User enters invalid "<From>" and "<To>" locations
    Then validate that an error message is displayed
    
Examples:
    | From  | To        |
    | Milan | Bengaluru |
    

Scenario Outline: Validate user is unable to plan a journey with no locations entered
    When User clicks on Plan My Journey button
    Then User validates the apprpriate error messages are displayed on the widget