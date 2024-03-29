﻿# DBAccessor 
## A decorator to make ADO.NET more accessable

nuget page https://lnkd.in/eUpwfVCj

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)
DBAccesor is an easy way to use ADO.NET using a Fluent API

## Features

- Understandable  Syntax
- Easy Setup
  
- ## Example
  
- The Connect variable is the container for the Connection String.
This can either be set using the AppSettings.json at runtime or at compile time.

One can choose one of the following ways to write the access stament.

### To connect to  the database we can use the following which returns an SqlConnection

```C#
var connection = DBAccess.Connect.ConnectToDB();

```

### For an async operation

```C#
var connection = await DBAccess.Connect.ConnectToDBAsync();

```

### Or using the fluent api

```C#

 DBAccess.Connect.ConnectToDB().ComposeCommand("SQL SCRIPT")

```

### Then we can also add vaibles that need to be passed to the DB like this. This returns SqlCommand Variable.

```C#

WithParam("@PARAMETER NAME", <DATA TYPE>, <Value to be passed>);

```

### The full action equates to the following

```C#
DBAccess.Connect.ConnectToDB().ComposeCommand("SQL SCRIPT").WithParam("@PARAMETER NAME", <DATA TYPE>, <Value to be passed>).Result.ExecuteReaderAsync();

```

### This can be wrappend in a using as well

```C#
using( var temp = DBAccess.Connect.ConnectToDB())


```
We can chain multiple Paramaters inputs if desired.
```C#
DBAccess.Connect.ConnectToDB().ComposeCommand("SQL SCRIPT").WithParam("@PARAMETER NAME", <DATA TYPE>, <Value to be passed>)
.WithParam("@PARAMETER NAME", <DATA TYPE>, <Value to be passed>)
.WithParam("@PARAMETER NAME", <DATA TYPE>, <Value to be passed>)
.Result.ExecuteReaderAsync();

```

## Tech

Uses ADO.NET as the library to access the DataBase
