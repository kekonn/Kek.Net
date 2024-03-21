function Get-Versions {
    $versionFiles = Get-Item -Path src/**/version.yaml | Select-Object -ExpandProperty FullName
    Write-Debug "Found the following version files:"
    $versionFiles | ForEach-Object { $_ | Write-Debug }

    $packageVersions = @{}
    $versionFiles | ForEach-Object {
        Write-Debug "Reading version file $_"
        $packageName = Split-Path $_ -Parent | Split-Path -Leaf
        $yamlVersion = (Get-Content $_ | ConvertFrom-Yaml).version
        $semver = '{0}.{1}.{2}' -f $yamlVersion.major, $yamlVersion.minor, $yamlVersion.patch
        $assemblyVersion = $semver + ".0"
        
        $packageVersions[$packageName] = @{ 'SemVer' = $semver; 'AssemblyVersion' = $assemblyVersion; 'Root' = $(Split-Path $_ -Parent)}
    }
    
    $packageVersions | ConvertTo-Json | Write-Output
}

function Get-LockFiles {
    $lockFiles = Get-Item -Path src/**/packages.lock.json | Select-Object -ExpandProperty FullName
    Write-Debug "Found the following lock files:"
    $lockFiles | ForEach-Object { Write-Debug "\t- $_" }

    $lockFiles | Write-Output
}

Install-Module -Name powershell-yaml -Force -AcceptLicense
Export-ModuleMember -Function Get-Versions
Export-ModuleMember -Function Get-LockFiles