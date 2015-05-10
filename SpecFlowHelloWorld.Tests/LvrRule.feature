Feature: LVR Calculation
	User story goes here

Background: 
	Given a LVR coefficient of 1.3234

@Rule
@FeatureAcceptanceTest
Scenario Outline: LVR calculation
	Given a property price of <PropertyPrice>
		And a property value of <PropertyValue>
		And a loan amount of <LoanAmount>
	When we calculate the LVR score
	Then the result is <LvrScore>

	Examples:
		| PropertyPrice	| PropertyValue | LoanAmount	| LvrScore							|
		| 100000.00		| 98000.00		| 90000.00		| 1.2153673469387755102040816327	|
		| 100000.00		| 103000.00		| 90000.00		| 1.19106							|
