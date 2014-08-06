﻿namespace FsUno

open System
open Deck
open Game

type EventHandler() =
    let mutable turnCount = 0

    let setColor card =
        let color = 
            match card with
            | Digit(_, c) -> Some c
            | KickBack c -> Some c
            |> function
               | Some Red -> ConsoleColor.Red
               | Some Green -> ConsoleColor.Green
               | Some Blue -> ConsoleColor.Blue
               | Some Yellow -> ConsoleColor.Yellow
               | None -> ConsoleColor.White
        Console.ForegroundColor <- color
    
    member this.Handle =
        function
        | GameStarted event ->
            printfn "Game %d started with %d players" event.GameId event.PlayerCount
            setColor event.FirstCard
            printfn "First card: %A" event.FirstCard

        | CardPlayed event ->
            turnCount <- turnCount + 1
            setColor event.Card
            printfn "[%d] Player %d played %A" turnCount event.Player event.Card

