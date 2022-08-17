docker-compose up -d
$scriptpath = $MyInvocation.MyCommand.Path
$dir = Split-Path $scriptpath
cd "$dir\Portal_Perfomance_Employes"
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:EmployeeDbString" "Server=localhost,1433;Database=master;User ID=sa;Password=Password123!;"
Start-Sleep -Seconds 2
dotnet ef database update