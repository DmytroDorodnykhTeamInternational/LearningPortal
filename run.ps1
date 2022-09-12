docker-compose up -d 2>$null
$scriptpath = $MyInvocation.MyCommand.Path
$dir = Split-Path $scriptpath
cd "$dir\Portal_Perfomance_Employes"
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:EmployeeDbString" "Server=localhost,1433;Database=LearningPortal;User ID=sa;Password=Password123!;"
dotnet tool install --global dotnet-ef 2>$null
dotnet ef database update