"Installing Git hooks";

Get-ChildItem "$PSScriptRoot/git/hooks" | Foreach-Object {
    $hookname = $_.Basename;
    "  Linking hook $hookname";
    cmd /c mklink "$PSScriptRoot/../.git/hooks/$hookname" "$_";
}
