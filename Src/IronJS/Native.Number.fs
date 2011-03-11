﻿namespace IronJS.Native

open System
open IronJS
open IronJS.Support.Aliases
open IronJS.DescriptorAttrs

module Number =

  //----------------------------------------------------------------------------
  let internal constructor' (ctor:FunctionObject) (this:CommonObject) (value:BoxedValue) =
    match this with
    | null -> 
      let value = 
        match value.Tag with
        | TypeTags.Undefined -> 0.0
        | _ -> value |> TC.ToNumber

      ctor.Env.NewNumber(value) |> BV.Box

    | _ -> value |> TC.ToNumber |> BV.Box
    
  //----------------------------------------------------------------------------
  let private nanToString number =
    if number <> number then "NaN"
    elif number = NegInf then "-Infinity"
    elif number = PosInf then "Infinity"
    else failwith "Number is not NaN, Infinity or -Infinity"

  let internal toString (f:FunctionObject) (this:CommonObject) (radix:double) =
    this.CheckType<NO>()
    let number = (this |> ValueObject.GetValue).Number

    if FSKit.Utils.isNaNOrInf number then nanToString number
    else
      match radix with
      | 0.0 | 10.0 -> TypeConverter.ToString(number)
      | 2.0 -> Convert.ToString(int64 number, 2)
      | 8.0 -> Convert.ToString(int64 number, 8)
      | 16.0 -> Convert.ToString(int64 number, 16)
      | _ -> "Radix must be 0, 2, 8, 10 or 16"
      
  //----------------------------------------------------------------------------
  let internal toLocaleString (f:FunctionObject) (this:CommonObject) = 
    toString f this 10.0
    
  //----------------------------------------------------------------------------
  let internal valueOf (f:FunctionObject) (this:CommonObject) =
    this.CheckType<NO>()
    this |> ValueObject.GetValue

  //----------------------------------------------------------------------------
  // This implementation is a C# to F# adaption of the Jint sources
  let private verifyFractions (env:Environment) fractions = 
    if fractions < 0 || fractions > 20 then
      env.RaiseRangeError("fractions must be between 0 and 20")

  let internal toFixed (f:FunctionObject) (this:CommonObject) (fractions:double) =
    this.CheckType<NO>()

    let number = (this |> ValueObject.GetValue).Number
    let fractions = fractions |> TypeConverter.ToInt32

    if number |> FSKit.Utils.isNaNOrInf then nanToString number
    else
      verifyFractions f.Env fractions
      number.ToString("f" + string fractions, invariantCulture)

  //----------------------------------------------------------------------------
  // This implementation is a C# to F# adaption of the Jint sources
  let internal toExponential (f:FunctionObject) (this:CommonObject) (fractions:BoxedValue) =
    this.CheckType<NO>()
    
    let number = (this |> ValueObject.GetValue).Number

    if fractions.IsUndefined then 
      toString f this 10.0

    elif number |> FSKit.Utils.isNaNOrInf then 
      nanToString number

    else
      let fractions = 
        if fractions.IsUndefined
          then 16 
          else fractions |> TypeConverter.ToInt32

      verifyFractions f.Env fractions
      let format = String.Concat("#.", new String('0', fractions), "e+0");
      number.ToString(format, invariantCulture)
    
  //----------------------------------------------------------------------------
  // This implementation is a C# to F# adaption of the Jint sources
  let internal toPrecision (f:FunctionObject) (this:CommonObject) (precision:BoxedValue) =
    this.CheckType<NO>()
    
    let number = (this |> ValueObject.GetValue).Number

    if precision.IsUndefined then 
      toString f this 10.0

    elif number |> FSKit.Utils.isNaNOrInf then 
      nanToString number

    else
      let precision = precision |> TypeConverter.ToInt32

      if precision < 1 || precision > 21 then
        f.Env.RaiseRangeError("precision must be between 1 and 21")

      let str = number.ToString("e23", invariantCulture);
      let decimals = str.IndexOfAny([|'.'; 'e'|]);
      let decimals = if decimals = -1 then str.Length else decimals

      let precision = precision - decimals
      let precision = if precision < 1 then 1 else precision

      number.ToString("f" + string precision, invariantCulture)
      
  //----------------------------------------------------------------------------
  let createPrototype (env:Environment) objPrototype =
    let prototype = env.NewNumber()
    prototype.Prototype <- objPrototype
    prototype
    
  //----------------------------------------------------------------------------
  let setupConstructor (env:Environment) =
    let ctor = new Func<FunctionObject, CommonObject, BoxedValue, BoxedValue>(constructor')
    let ctor = Utils.createHostFunction env ctor

    ctor.ConstructorMode <- ConstructorModes.Host
    ctor.Put("prototype", env.Prototypes.Number, Immutable) 
    ctor.Put("MAX_VALUE", Double.MaxValue, Immutable) 
    ctor.Put("MIN_VALUE", Double.Epsilon, Immutable) 
    ctor.Put("NaN", Double.NaN, Immutable) 
    ctor.Put("NEGATIVE_INFINITY", NegInf, Immutable) 
    ctor.Put("POSITIVE_INFINITY", PosInf, Immutable) 

    env.Globals.Put("Number", ctor)
    env.Constructors <- {env.Constructors with Number=ctor}
    
  //----------------------------------------------------------------------------
  let setupPrototype (env:Environment) =
    let proto = env.Prototypes.Number;

    proto.Put("constructor", env.Constructors.Number, DontEnum)

    let toString = new Func<FunctionObject, CommonObject, double, string>(toString)
    let toString = Utils.createHostFunction env toString
    proto.Put("toString", toString, DontEnum)

    let toLocaleString = new Func<FunctionObject, CommonObject, string>(toLocaleString)
    let toLocaleString = Utils.createHostFunction env toLocaleString
    proto.Put("toLocaleString", toLocaleString, DontEnum)

    let valueOf = new Func<FunctionObject, CommonObject, BoxedValue>(valueOf)
    let valueOf = Utils.createHostFunction env valueOf
    proto.Put("valueOf", valueOf, DontEnum)

    let toFixed = new Func<FunctionObject, CommonObject, double, string>(toFixed)
    let toFixed = Utils.createHostFunction env toFixed
    proto.Put("toFixed", toFixed, DontEnum)
    
    let toExponential = new Func<FunctionObject, CommonObject, BoxedValue, string>(toExponential)
    let toExponential = Utils.createHostFunction env toExponential
    proto.Put("toExponential", toExponential, DontEnum)
    
    let toPrecision = new Func<FunctionObject, CommonObject, BoxedValue, string>(toPrecision)
    let toPrecision = Utils.createHostFunction env toPrecision
    proto.Put("toPrecision", toPrecision, DontEnum)
    
