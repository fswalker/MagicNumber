module ArgumentsTests

open Xunit
open Swensen.Unquote
open Arguments

[<Fact>]
let ``Get Magic Number argument`` () =

    let arguments = getArguments None
    let magicNumber = arguments |> getMagicNumber

    test <@ 123 = magicNumber @>
