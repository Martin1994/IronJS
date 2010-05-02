﻿namespace IronJS.Compiler

open IronJS
open IronJS.Aliases
open IronJS.Tools
open IronJS.Tools.Dlr
open IronJS.Compiler
open IronJS.Compiler.Types

module Assign =
  
  let build (ctx:Context) (left:Ast.Node) (right:Ast.Node)  =
    match left with
    | Ast.Global(name, _) -> 
      let value   = ctx.Build right
      let target  = Wrap.static' ctx.Internal.Globals

      if value.Type <> typeof<Runtime.Box> then 
        ctx.TemporaryTypes.AddOrUpdate(name, value.Type, fun _ _ -> value.Type) |> ignore

      Object.setProperty ctx  name target value

    | Ast.Property(target, name) ->
      let value = ctx.Build right
      let target = ctx.Build target
      Object.setProperty ctx name target value
