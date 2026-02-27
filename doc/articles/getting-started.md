# Getting Started

This guide shows how to quickly install and use the **Resultify** NuGet package in your .NET project.

## 1. Install via NuGet

You can install the package using the **.NET CLI**:

```bash
dotnet add package Resultify --version 0.1.0
```

Or via Visual Studio:

1. Right-click on your project → Manage NuGet Packages…

2. Search for Resultify

3. Click Install

## 2. Add a Using Statement

In your C# code, add:

```c#
using Resultify.Core.Models;
using Resultify.Core.ValueObjects;
```

## 3. Example Usage

Here’s a simple example of how to use the package:

```c#
using Resultify.Core.Models;
using Resultify.Core.ValueObjects;

Result result = Result.Success();

if (result.IsSuccess)
    Console.WriteLine("result success");
```
## 4. Learn More

- Check the API reference in this documentation.

- Browse tutorials and examples to see how to integrate the package into real projects.

- If you encounter issues, refer to the FAQ or open an issue on GitHub.