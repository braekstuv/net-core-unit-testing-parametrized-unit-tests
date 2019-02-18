# 1. Commands to run:
```
dotnet new sln -n StudentApp
dotnet new classlib -n StudentApp.Domain
dotnet new xunit -n StudentApp.Domain.Test
dotnet sln StudentApp.sln add StudentApp.Domain StudentApp.Domain.Test
dotnet add StudentApp.Domain.Test/StudentApp.Domain.Test.csproj reference StudentApp.Domain/StudentApp.Domain.csproj
```

# 2. The User story:
 For an application in a school, we'd like to have a ranking of each student in a class. 
 This is the information that we store of each student:
 * First name
 * Last name
 * Date of birth
 * Grades

 A grade is represented by a fraction, e.g.: 15/20 
 We'd like to sort the students based on these criteria:
 1. Amount of grades (as in: one student has 5 grades, another one has 3,...) (highest first)
 2. Average of grades (highest first)
 3. Date of birth
 4. Full Name (starting with Last Name) 

 Write the code + tests for this userstory. Use ```[ClassData]``` to pass the parameters.
 
 Hint: There are several ways to test this. Here are some things to consider:
 1. We could create one test, that tests the totality of the sorting method 
 (i.e.: create an expected result list where all sorting criteria cases are represented by one student, scramble this list into a new list, sort it; the students in the sorted list should be in the same order as the expected list)
 The benefit of this test is that we are certain that the total sorting is correct. 
 The downside is that we cannot pinpoint a mistake when we implement our sort incorrectly.
 2. We could create several tests, where we assert the order of each element respectively to its successor
 (i.e.: use the same list as step 1, but for each element in the list, we generate a test: Student A should be before Student B, because the student's grades are higher, etc...)