# GenericEnvironment.GetEnvironmentVariable

## Description
Generic [Environment.GetEnvironmentVariable](https://learn.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable?view=net-7.0)

## Signature
```cs
TType GetEnvironmentVariable<TType>(string name)
```

## Use cases
* Throw `ArgumentNullException` when `name` is null.
* Throw `InvalidOperationException` when cannot find environment variable by `name`.
* Throw `InvalidCastException` when `TType` is nullable.
* Throw `FormatException` when cannot convert environment variable to `TType`.
* Throw `SecurityException` when a security error is detected.
* Throw `OverflowException` when an arithmetic, casting, or conversion operation in a checked context results in an overflow.

## Type Parameters
`TType` - Type of environment variable value.

## Parameters
`name` - Name of environment variable.

## Returns
`TType` value.

## Code examples
``` cs
// Setup (or get from launchSettings.json)
Environment.SetEnvironmentVariable("YourIntVariable", "12345");
Environment.SetEnvironmentVariable("YourBoolVariable", "true");
Environment.SetEnvironmentVariable("YourStringVariable", "YourStringVariable");

// Valid results
int yourIntVariable = GenericEnvironment.GetEnvironmentVariable<int>("YourIntVariable"); // 12345
bool yourBoolVariable = GenericEnvironment.GetEnvironmentVariable<bool>("YourBoolVariable"); // true
string yourStringVariable = GenericEnvironment.GetEnvironmentVariable<string>("YourStringVariable"); // "YourStringVariable"

// Exceptions
GenericEnvironment.GetEnvironmentVariable<bool>(null); // ArgumentNullException because name parameter is null.
GenericEnvironment.GetEnvironmentVariable<bool>("InvalidName"); // InvalidOperationException because variable not found by name.
GenericEnvironment.GetEnvironmentVariable<bool?>("YourBoolVariable"); // InvalidCastException because type is nullable (bool?)
GenericEnvironment.GetEnvironmentVariable<bool>("YourIntVariable"); // FormatException because cannot convert variable to type (bool -> int)
```

# GenericEnvironment.TryGetEnvironmentVariable

## Description
Try get environment variable (generic [Environment.GetEnvironmentVariable](https://learn.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable?view=net-7.0)).
## Signature
```cs
bool TryGetEnvironmentVariable<TType>(string name, out TType value)
```
## Use cases
* [true, value=TType] when environment variable was found.
* [false, value=default(TType)] when `name` is null.
* [false, value=default(TType)] when environment variable wasn't found.
* [false, value=default(TType)] when cannot convert environment variable to `TType`.
* [false, value=default(TType)] when a security error is detected.
* [false, value=default(TType)] when an arithmetic, casting, or conversion operation in a checked context results in an overflow.

## Type Parameters
`TType` - Type of environment variable value.
## Parameters
`name` - Name of environment variable
`value` - Environment variable value
## Returns
true if environment variable was gotten by `name`; otherwise, false.

## Code examples
```cs
// Setup
Environment.SetEnvironmentVariable("IntEnvironmentVariable", "12345"); // or from launchSettings.json

// Code
bool firstResult = GenericEnvironment.TryGetEnvironmentVariable("IntEnvironmentVariable", out int firstValue);
bool secondResult =  GenericEnvironment.TryGetEnvironmentVariable("InvalidEnvironmentVariableName", out int secondValue);

// Output
// [firstResult, firstValue] = [true, 12345]
// [secondResult, secondValue] = [false, 0]
```
