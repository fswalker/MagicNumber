open Arguments

[<EntryPoint>]
let main argv = 

    let arguments = getArguments None

    let magicNumber = arguments |> getMagicNumber

    printfn "magic number:\t%i" magicNumber

    0
