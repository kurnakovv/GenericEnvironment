 [![Build/Test](https://github.com/KurnakovMaksim/GenericEnvironment/actions/workflows/dotnet.yml/badge.svg)](https://github.com/KurnakovMaksim/GenericEnvironment/actions/workflows/dotnet.yml)


# Description

GenericEnvironment is generic System.Environment class library.

# How is it work

Environment variables
``` json
...

"environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development",
    "YourIntVariable": "12345",
    "YourBoolVariable": "true",
    "YourStringVariable": "YourStringVariable"
    ...
}

...
```

Get variables with strict types
``` cs
int yourIntVariable = GenericEnvironment.GetEnvironmentVariable<int>("YourIntVariable");
bool yourBoolVariable = GenericEnvironment.GetEnvironmentVariable<bool>("YourBoolVariable");
string yourStringVariable = GenericEnvironment.GetEnvironmentVariable<string>("YourStringVariable");

// Output
// yourIntVariable - 12345
// yourBoolVariable - true
// yourStringVariable - "YourStringVariable"
```

Exceptions
``` cs
GenericEnvironment.GetEnvironmentVariable<bool>(null); // ArgumentNullException because name parameter is null.
GenericEnvironment.GetEnvironmentVariable<bool>("InvalidName"); // InvalidOperationException because variable not found by name.
GenericEnvironment.GetEnvironmentVariable<bool?>("YourBoolVariable"); // InvalidCastException because type is nullable (bool?)
GenericEnvironment.GetEnvironmentVariable<bool>("YourIntVariable"); // FormatException because cannot convert variable to type (bool -> int)
```

# Reason
C# is a strictly typed language and I want to work environment variables as strictly typed variables. This library solves this problem.

# Give a star ⭐
I hope this library is useful for you, if so please give a star for this repository, thank you :)