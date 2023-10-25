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

# Type Parameters
`TType` - Type of environment variable value.

# Parameters
`name` - Name of environment variable.

# Returns
`TType` value.

# Code examples
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