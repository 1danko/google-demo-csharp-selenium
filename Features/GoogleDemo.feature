Feature: Google Search
        As a User,
        User can find information from Google search page

Background: User navigate to google search page
	Given user navigates to "baseUrl" url
	And user select "English (United States)" language
	And user accept all cookies

@GoogleTest
Scenario Outline: Google Search - Examples	
	When user search for "<searchText>"
	And user select "<searchResult>" in the search results
	Then title of the page is "<title>"

Examples: 
| searchText         | searchResult                                            | title                                         |
| .net framework 6   | Download .NET 6.0 (Linux, macOS, and Windows) - Dot.net | Download .NET 6.0 (Linux, macOS, and Windows) |
| allure report docs | Allure Report Docs — Overview                           | Allure Report Docs — Overview                 |
| Selenium           | Selenium                                                | Selenium                                      |

