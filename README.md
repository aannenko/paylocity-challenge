# paylocity-challenge

This is a solution to the take-home challenge by Paylocity.

### Problem

Implement a backend solution where a user, an employee, has their paychecks calculated for a year based on the following requirements.

### Conditions
- An employee may only have 1 spouse or domestic partner (not both)
- An employee may have an unlimited number of children

### Requirements
- The app should allow to view employees and their dependents
- The app should be able to calculate paychecks for each employee given these rules:
    - 26 paychecks per year with deductions spread as evenly as possible on each paycheck
    - base benefits costs of $1,000 gets deducted from the employee's salary each month
    - per-dependent benefits costs of $600 gets deducted from the employee's salary each month
    - employees that make more than $80,000 per year incur deduction of additional 2% of their yearly salary as benefits costs
    - dependents that are over 50 years old will incur an additional $200 per month

### Solution details
1. The solution is a .NET Web API with the following technical characteristics
    - A minimal API template is used in order to simplify API routing and passing parameters
    - Can be easily containerized (not ready in scope of this task but can be achieved by spending additional hour or two)
    - Architecturally split into areas Database, Calculations and Endpoints which contain the corresponding functionality
    - Focuses on execution performance and a small memory footprint
    - Uses source generation to create JSON response serializers in order to boost performance even further
    - With some additional work, may be turned into a trimmable or AOT-compiled application (not fully implemented in scope of this task)
2. Endpoints return standardized responses with correct status codes and, if problems occur, return industry-accepted problem details
    - Performant forward-only paging for Employees and Dependents that prioritizes response time over the ability to go to a previous page
    - Basic filtering for Employees and Dependents in the paged endpoints
    - Paychecks endpoint provides details about each deduction applied to the employee's salary for each paycheck
    - OpenAPI and Swagger support
    - Paychecks.Api.http file is available to test the endpoints from an IDE
3. Database interaction is arranged as a duo of EF Core and an in-memory SQLite DB for the purpose of this challenge
    - DB queries are already asynchronous and are kept as universal as possible for an easy switch to a different database
    - Performant forward-only paging, leveraged by the endpoints, uses indexed columns to go from one page to the next
4. Paycheck calculation is arranged as a set of policies applied on top of the employee's salary
    - The policies are .NET classes which act upon the information about the employee and their dependents
    - The values which these classes operate upon (e.g. age of a dependent that incurs additional deductions) are stored in the DB
    - New policies can be easily added to the application by adding a new class for the policy that implements ICalculationPolicy and then adding applicability and operation values for it to the DB
    - The result of applying policies to an employee's salary is a set of objects, each of which represents a paycheck information with the details for each deduction
5. The provided unit test project is used to test the functionality of the application
    - Minor modifications are made to the expected values for employees and dependents
    - Additional test class was added to cover the paychecks endpoint
    - Per-service tests can be quickly added (not implemented in scope of this challenge)

### How to run and test

Open in Visual Studio, F5 and run all tests

### Potential areas for the future development
- Caching
- Logging
- Better error handling
- Request validation (e.g. using Mini Validator)
- Auth
- Refactoring into multiple projects
- Switch to a different database
- Docker support
