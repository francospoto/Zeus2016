Feature: Login
	In order to access the website
	As a website user
	I want to login into the website


@mytag
Scenario: valid credentials
	Given I am on the login page
	When I fill in the form with
	| field    | value |
	| Email  |  gertamayo@gmail.com  |
	| Password | 123456789  |

	
	And I click "Ingresar"
	Then I should see "Logueado" 
