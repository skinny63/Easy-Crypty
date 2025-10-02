# 🔐 Easy-Crypty: Hash'n'Crypt Made Simple

The easiest way to hash'n'crypt your data with C# and C.

[![Version](https://img.shields.io/badge/version-8.0.0-blue)](https://github.com/skinny63/Easy-Crypty)
[![License](https://img.shields.io/badge/license-MIT%20License-green)](LICENSE.md)
![Stars](https://img.shields.io/github/stars/skinny63/Easy-Crypty?style=social)
![Forks](https://img.shields.io/github/forks/skinny63/Easy-Crypty?style=social)

## 🚀 Overview

Welcome to your next hash and crypt experience!

``` csharp
using Easy_Crypty.HashExtension;

// Hash string never been so easy
var hash = "Hello world!"
    .HashWith<Sha256>()
    .ToString();
```

You are using a custom hashing algorithm? No problem!
It just needs to implement the `HashAlgorithm` class provided by Microsoft.
``` csharp
using System.Security.Cryptography;

var hash = "Hello world!"
    .HashWith<YourCustomAlgorithm>()
    .ToString();
```

## ✨ Features

*   ⚡️ **Effortless Hashing:** Quickly generate cryptographic hashes for various data types and algorithms (MD5, SHA256, SHA512).
*   🔒 **Secure Cryptography:** Designed to integrate robust encryption and decryption routines with ease (future scope).
*   🚀 **Cross-Platform Compatibility:** Built primarily with C#, ensuring broad system support across different operating systems.
*   🧩 **Extensible Architecture:** Designed for easy integration of new hashing and encryption algorithms as the project evolves.
*   📖 **Developer-Friendly API:** Provides a simple, intuitive API for rapid development and seamless integration into your .NET applications.

## 🚀 Installation

### Prerequisites

Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed on your system (version 6.0 or higher recommended).

### 📦 As a Project Reference

You can integrate Easy-Crypty into your .NET project by adding it as a project reference.

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/skinny63/Easy-Crypty.git
    cd Easy-Crypty
    ```

2.  **Add the project reference to your solution:**
    If you have an existing solution, navigate to its directory and run:
    ```bash
    dotnet sln add Easy-Crypty.HashExtension/Easy-Crypty.HashExtension.csproj
    dotnet add [YourProjectName].csproj reference Easy-Crypty.HashExtension/Easy-Crypty.HashExtension.csproj
    ```
    Replace `[YourProjectName]` with the actual name of your project's `.csproj` file.

3.  **Build your solution:**
    ```bash
    dotnet build Easy-Crypty.sln
    ```

### 🛠️ Manual Build

If you prefer to build the project manually, follow these steps:

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/skinny63/Easy-Crypty.git
    cd Easy-Crypty
    ```

2.  **Restore dependencies and build the solution:**
    ```bash
    dotnet restore Easy-Crypty.sln
    dotnet build Easy-Crypty.sln --configuration Release
    ```
    The compiled binaries will be located in the `Easy-Crypty.HashExtension/bin/Release` directory.

##