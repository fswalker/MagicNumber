module Arguments

open Argu

type Arguments =
    | Magic_Number of id:int
    with
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Magic_Number _ -> "This is magic number"

let getArguments path = 
    let parser = ArgumentParser.Create<Arguments> ()
    match path with
    | Some path -> 
        let ireader = ConfigurationReader.FromAppSettingsFile (path)
        parser.ParseConfiguration (ireader)
    | None ->
        parser.Parse ([||])
        
let getMagicNumber (arguments: ParseResults<Arguments>) =
    arguments.GetResult <@ Magic_Number @>
