@echo off

echo ==========================================
echo Running Buys Computer
echo ==========================================
dotnet run "Buys_Computer_Train.csv" "Buys_Computer_Test.csv"

echo.

echo ==========================================
echo Running Disease Diagnosis
echo ==========================================
dotnet run "Disease_Diagnosis_Train.csv" "Disease_Diagnosis_Test.csv"

echo.

echo ==========================================
echo Running Job Promotion
echo ==========================================
dotnet run "Job_Promotion_Train.csv" "Job_Promotion_Test.csv"

echo.

echo ==========================================
echo Running Loan Approval Requires Laplace
echo ==========================================
dotnet run "Loan_Approval_Requires_Laplace_Train.csv" "Loan_Approval_Requires_Laplace_Test.csv"

echo.

echo ==========================================
echo Running Play Tennis
echo ==========================================
dotnet run "Play_Tennis_Train.csv" "Play_Tennis_Test.csv"

echo.

echo ==========================================
echo All tests finished.
echo ==========================================

pause