# only need to commit assembly info changes when build is NOT for a pull-request
if ($env:appveyor_pull_request_number)
{
    'Skip committing assembly info changes as this is a PR build...' | Write-Host -ForegroundColor White
}
else
{
    # updated assembly info files
    git add "source\Properties\AssemblyInfo.cs"
    git commit -m "Update assembly info file for v$env:GitVersion_NuGetVersionV2"
    # need to wrap the git command bellow so it doesn't throw an error because of redirecting the output to stderr
    "$(git push origin)"


    # clone nf-interpreter repo (only a shallow clone with last commit)
    git clone https://github.com/nanoframework/nf-interpreter -b develop --depth 1 -q
    cd nf-interpreter

    # new branch name
    $newBranch = "nfbot/$env:APPVEYOR_REPO_BRANCH/update-version/$env:GitVersion_NuGetVersionV2" 
    
    # create branch to perform updates
    git checkout -b $newBranch develop -q
    
    # replace version in assembly declaration
    $newVersion = $env:GitVersion_AssemblySemFileVer -replace "\." , ", "
    $newVersion = "{ $newVersion }"
    
    $versionRegex = "\{\s*\d+\,\s*\d+\,\s*\d+\,\s*\d+\s*}"
    $assemblyFiles = (Get-ChildItem ".\src\CLR\Runtime.Events\nf_rt_events_native.cpp" -Recurse)

    foreach($file in $assemblyFiles)
    {
        $filecontent = Get-Content($file)
        attrib $file -r
        $filecontent -replace $versionRegex, $newVersion | Out-File $file -Encoding utf8
    }

    $commitMessage = "Update nanoFramework.Runtime.Events version to $env:GitVersion_AssemblySemFileVer"

    # commit changes
    git add -A 2>&1
    git commit -m $commitMessage -q
    git push --set-upstream origin $newBranch
    git push origin -q
 
    # start PR
    $prRequestBody = "{ ""title"": ""$commitMessage"", ""body"": ""$commitMessage"", ""head"": ""$newBranch"", ""base"": ""develop"" }"
    $githubApiEndpoint = "https://api.github.com/repos/$env:APPVEYOR_REPO_NAME/pulls"
    $webClient = New-Object System.Net.WebClient
    $webClient.Headers.add('User-Agent', "User-Agent: Mozilla/4.0 (compatible; MSIE 7.0;)") 
    $webClient.Headers.add('Authorization', "Basic $env:GitHubToken")
    $webClient.Headers.add('Content', "application/json")
    $webClient.UploadString($githubApiEndpoint, 'POST', $prRequestBody)

    # move back to home folder
    cd ..
}
