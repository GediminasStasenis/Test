Feature: SkycopSteps

Scenario: Open Skycop claims page
	Given I navigate to claims
	Then I set Kaunas as departure airport
	And I set Gatwick as arrival airport
	And I set airlines
	And I enter flight number
	And I choose flight date
	And I answer questions about flight
	And I choose where I heard about Skycop
	And I choose next step
