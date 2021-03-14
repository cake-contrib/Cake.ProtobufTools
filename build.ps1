$ErrorActionPreference = 'Stop'

$SCRIPT_NAME = "recipe.cake"

Write-Host "Restoring .NET Core tools"
dotnet tool restore
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
    [string[]]$ScriptArgs
Write-Host "Bootstrapping Cake"
dotnet cake $SCRIPT_NAME --bootstrap
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
        return $null
Write-Host "Running Build"
dotnet cake $SCRIPT_NAME @args
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }Invoke-Expression "& `"$CAKE_EXE`" `"$Script`" -target=`"$Target`" -configuration=`"$Configuration`" -verbosity=`"$Verbosity`" $UseMono $UseDryRun $UseExperimental $ScriptArgs"
exit $LASTEXITCODE