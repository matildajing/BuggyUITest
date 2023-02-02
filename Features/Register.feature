Feature: Register

Scenario Outline: Register flow work properly
	Given I am on the base page of buggy
	When I click Register button
	Then I should see the page contain Register with Buggy Cars Rating
	Then I could not click Register button as no info is filled
	When I fill fields Login: <login>, First Name: <firstName>, Last Name: <lastName>, Password: <password>
	Then I could click Register button
	When I click Register submit button
	Then I should get success message: Registration is successful
	When I login with just username and <password>
	Then I should login properly

Examples:
	| login		| firstName | lastName | password | 
	|auto_test_	| k_first	| k_last   | 1234Qwe!  |
	|!\”#123_	| k_first	| k_last   | 1234Qwe!a  |
	|auto_test_	| k_first_dskfjlskdfjskldfjdsklfjdsklfjdsklfjdsklfjdsklfjdkslfjldsfjdsklfj	| k_last   | 1234Qwe!D"  |



Scenario Outline: Cancel Registration working properly
	Given I am on the register page
	When I fill fields Login: <login>, First Name: <firstName>, Last Name: <lastName>, Password: <password>
	When I click Cancel button
	Then I should be directed to home page
	When I login with just username and <password>
	Then I should get error message in home page: Invalid username/password

Examples:
	| login		| firstName | lastName | password | 
	|auto_test_	| k_first	| k_last   | 1234Qwe!  |


Scenario Outline: As a new user, I want to register with not not proper password (password minimum 8 characters - 1 Uppercase + 1 lowercase + 1 special character)
	Given I am on the register page
	When I fill all fields except with improper password requirement, length: <length>, hasUpper: <hasUpper>, hasLower: <hasLower>, hasSpecial: <hasSpecial>
	When I click Register submit button
	Then I should get error message: <errormessage>

Examples:
	| length	| hasUpper	| hasLower	| hasSpecial	| errormessage |
	| 8			| false		| true		| true			| InvalidPasswordException: Password did not conform with policy: Password must have uppercase characters |