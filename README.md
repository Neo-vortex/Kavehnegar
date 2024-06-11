
# Kavehnegar SMS and Call SDK

## Overview

Kavehnegar SMS and Call (https://kavenegar.com) SDK is a .NET library designed to interact with the Kavehnegar SMS and Call center services. This redesigned version improves upon the original by providing a cleaner codebase, utilizing built-in .NET utilities, supporting advanced lookup functionalities, and enhancing performance.

official SDK :https://github.com/kavenegar/Kavenegar.Core
## Features

- Clean and readable C# code
- Minimal custom implementation by leveraging built-in .NET utilities
- Supports 'tokens' with spaces for lookup functionality
- Improved performance by omitting unnecessary fields in requests
- Strongly-typed wrapper around the API to minimize mistakes
- A lot of client side validation to minimize round-trip

## Installation
**dotnet 8 or later is needed**.

To install the SDK, you can use the NuGet package manager:

```bash
dotnet add package Neovortex.KavehNegar --version 0.0.1
```

## Usage

Here's an example of how to use the Kavehnegar SMS and Call SDK:

```csharp
using Neovortex.KavehNegar;
using Neovortex.KavehNegar.Model;

var kavehnegar = new KavehnegarClient("API_KEY");

// send a simple text message
await kavehnegar.Send(new KavenegarSmsMessage
{
    Receptors = ["+989121111111"],
    Message = """
              بهرین کیفیت محصولات رو از ما بخواهید
              شماره تماس 0210000000
              """
});

// send a simple text to voice message
await kavehnegar.TTS(new KavehnegarTtsRequest
{
    Receptor = "+989121111111",
    Message = "کد فعال سازی شما 112 می باشد"
});

// send a lookup (aka OTP) message
await kavehnegar.LookUp(new KavehnegarLookupRequest
{
    Receptor = "+989121111111",
    Tokens =
    [
        "شرکت بین المللی خزر افتاب شرق",
        "2545"
    ],
    TemplateName = "auth"
});

```


## API Reference

For a detailed API reference, please refer to the [official documentation](https://kavenegar.com/rest.html).

## Contributing

We welcome contributions to enhance the functionality and efficiency of this SDK. Please fork the repository and submit pull requests with your improvements.

## License

This project is licensed under the MIT License.

## Contact

For any questions or support, please open an issue on the [GitHub repository](https://github.com/Neo-vortex/Kavehnegar).

---

Thank you for using!

## Planned Enhancements

### 1. Add Support for Config API

The next step is to add support for the Config API, which will allow users to configure various settings and parameters directly through the SDK.



### 2. Add Strongly Typed Exceptions for Better Exception Management

To improve exception management, the SDK will be updated to use strongly typed exceptions. This will help users to handle errors more effectively and understand the issues more clearly.


### 3. Add Cancelation Token Support Accross the SDK
### 4. Add Unit Tests for SDK
After all  softwares must have tests right?! :)
