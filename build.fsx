#r @"packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.Testing


// PATHS
let buildDir = "./build/"


// REFERENCES

let appReferences = 
    !! "MagicNumber.sln"


// TARGET VARS
let Clean = "Clean"
let ``Build App`` = "Build App"
let ``Run Integration Tests`` = "Run Integration Tests"
let Default = "Default"


// TARGETS
Target Clean (fun _ ->
    CleanDirs [ buildDir ]
)

Target ``Build App`` (fun _ ->
    appReferences
    |> MSBuildRelease buildDir "Build"
    |> Log "AppBuild-Output: "
)

Target ``Run Integration Tests`` (fun _ ->
    !! (buildDir @@ "MagicNumber.Tests.*.dll")
    |> xUnit2 (fun p ->
        { p with 
            ToolPath =  "packages/xunit.runner.console/tools" @@ "xunit.console.exe"
        }
    )
)

Target Default DoNothing


// DEPENDENCIES
Clean
    ==> ``Build App``
    ==> ``Run Integration Tests``
    ==> Default 

RunTargetOrDefault Default
