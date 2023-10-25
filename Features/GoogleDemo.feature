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
| searchText | searchResult | title |
| C#            | C# docs - get started, tutorials, reference.                      | C# docs - get started, tutorials, reference. \| Microsoft Learn                                      |
| Report Portal | ReportPortal test automation analytics platform and real-time ... | ReportPortal test automation analytics platform and real-time reporting, powered by Machine Learning |
| Selenium      | Selenium                                                          | Selenium                                                                                             |

