# CreditSuisse IT DEV RISK

# Q1
run console application with `dotnet run` and input the datas.

# Q2
Follow these steps to solve the problem:

Implement a new bool property IsPoliticallyExposed for my class with the ITrade interface.
Add another method in the TradeService class to check if the trade is PEP with `bool IsTradePEP(bool isPoliticallyExposed)`.
Implement the IsTradePEP() method as the first validation in `TradeService.CreateResult()` and check if it returns true or false.
If true: return the trade with the PEP category in the `TradeService.CreateResult()` method.
If false: perform the other validations already implemented in the code.

