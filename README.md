# epi-utility-tcpproxy

[![Essentials-v2](https://img.shields.io/badge/Essentials-v2-teal.svg)](https://github.com/PepperDash/Essentials)

## License

Provided under MIT license

## Overview

This plugin acts as a TCP proxy, forwarding connections from a local server port to a configured remote client address and port. It supports both Essentials v1.x (3-series) and Essentials v2.x (4-series).

## Dependencies

The [Essentials](https://github.com/PepperDash/Essentials) libraries are required. They are referenced via NuGet.

- **4-series (Essentials v2.x):** Uses `PepperDashEssentials` v2.28.1 via `PackageReference` in the SDK-style csproj.
- **3-series (Essentials v1.x):** Uses `PepperDashEssentials` v1.x via `packages.config` (maintained on the `maintenance/1x` branch).

## Device Configuration

Example device configuration JSON:

```json
{
  "key": "tcpProxy-1",
  "name": "TCP Proxy",
  "type": "TcpProxy",
  "properties": {
    "clientAddress": "192.168.1.100",
    "clientPort": 23,
    "serverPort": 8023
  }
}
```

### Configuration Properties

| Property        | Type   | Description                              |
|-----------------|--------|------------------------------------------|
| `clientAddress` | string | Remote IP address to forward traffic to  |
| `clientPort`    | int    | Remote port to connect to                |
| `serverPort`    | int    | Local port to listen on                  |

## Building

### 4-series (Essentials v2.x)

Open `epi-utility-tcpproxy.4Series.sln` and build. Output (`.cplz` and `.nupkg`) is placed in the `output/` folder.

### 3-series (Essentials v1.x)

Switch to the `maintenance/1x` branch and open `epi-utility-tcpproxy.3Series.sln`. Run `GetPackages.bat` to restore NuGet packages, then build.
