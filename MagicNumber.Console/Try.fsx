#r "../packages/Argu/lib/net40/Argu.dll"

#load "../MagicNumber.Core/Arguments.fs"

open System
open Argu

open Arguments

let path = sprintf "%s\%s" __SOURCE_DIRECTORY__ "App.config"

let arguments = getArguments <| Some path

let magicNumber = arguments |> getMagicNumber
