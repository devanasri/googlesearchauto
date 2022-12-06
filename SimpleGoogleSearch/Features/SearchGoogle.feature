Feature: SearchGoogle

@mytag
Scenario: Google search bbc.co.uk
	Given i navigate to google.com
	And I search for BBC
	And I click search
	Then Search results show
	Then I close browser