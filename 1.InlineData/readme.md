# 1. Commands to run:
```
dotnet new sln -n CalculatorApp
dotnet new classlib -n CalculatorApp.Domain
dotnet new xunit -n CalculatorApp.Domain.Test
dotnet sln CalculatorApp.sln add CalculatorApp.Domain CalculatorApp.Domain.Test
dotnet add CalculatorApp.Domain.Test/CalculatorApp.Domain.Test.csproj reference CalculatorApp.Domain/CalculatorApp.Domain.csproj
```

# 2. Write code + unit tests for this story:
 We want to implement a calculator. We want to be able to add two integer values.
 These are some cases we'd like to see:
   * 1 + 1 = 2
   * 2 + 3 = 5
   * 10 + 30 = 40
   * -5 + 5 = 0

# 3. Parametrize the unit tests
 Use the ```[Theory]``` and ```[InlineData]``` attribute to pass variables and expected result for each test.

# 4. Add a unit test
 Write a unit test for:
   * 1073741024 + 1073742624 = 2147483648
 
 Notice that our test will fail. The max value for an int (2147483647) is exceeded, so it will be overflowed.
 Write a new test, where we expect an overflow exception to be thrown when this happens.
 Hint: use the ```checked``` keyword to automatically throw an overflow exception.