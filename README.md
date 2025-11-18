# Deployment Dojo Projects

This repository includes customised sample projects from the [Deployment Dojo](https://robmensching.com/deployment-dojo/) video series by Rob Mensching. The Deployment Dojo is a set of short, practical lessons focused on the WiX Toolset, installers, and related build/harvesting techniques. Season 1 contains 54 episodes (S1:E1 through S1:E54).

I created these samples so that I could follow along with the episodes, and have something to refer back to and see how the installer progresses with each episode.

While Season 1 uses the WiX 4 toolset, my projects were built and compiled using the WiX 6 version.

## Windows Sandbox

When testing MSIs, it's best practice to use a VM or the Windows Sandbox.

Windows Sandbox generates a minimal virtual machine which can be used for testing software installations and other applications. See <https://learn.microsoft.com/en-us/windows/security/application-security/application-isolation/windows-sandbox/> for more information.

> [!WARNING] Windows Sandbox is not available home Home editions of Windows.

- Windows sandbox configuration files are formatted as XML and use the `.wsb` extension.
- Your computer must have support for Hypervisor enabled. Most machines should support this, however it may need to be enabled in the BIOS.

## Notes on Windows Installer

- MSI only takes the first 3 segments of a version into account. If your MSI has version `1.1.1.0`, and you release version `1.1.1.1`, MSI will happily install the new version and overwrite any files in the old version, but you'll have two listings for your application in the `Add/Remove Programs` applet. Best practice is to update your new release to version `1.1.2.0` instead.

## Quick overview

- Series: The Deployment Dojo
- Host: Rob Mensching (FireGiant / WiX Toolset)
- Focus: WiX Toolset v4, installer authoring, harvesting, build tooling, testing/sandboxing, and practical setup patterns.
- Season 1: 54 weekly episodes (practical demos and katas)

## Highlights (selected episodes)

### S1:E1 — Introducing WiX v4 to the Deployment Dojo

- A kick-off episode that introduces WiX v4 and the goals for the series: learn-by-doing, katas, and real-world installer scenarios.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e1/introducing-wix-v4-to-the-deployment-dojo/>

### S1:E2 — Refining WiX v4 Kata 0

- Early kata-based exercises to get comfortable with WiX v4 syntax and project structure; iterative improvements and patterns for beginners.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e2/refining-wix-v4-kata-0/>

### S1:E3 — Building a sandbox in the Deployment Dojo

- Shows how to create an isolated sandbox environment for safely testing installers and observing installer behaviour without impacting a host system.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e3/building-a-sandbox-in-the-deployment-dojo/>

### S1:E4 — Upgrades and downgrades

- Shows how to install an updated version of your MSI, and what can happen if you don't prevent downgrades.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e4/out-with-the-old-in-with-the-new/>

### S1:E5 — The problem with Same Version Upgrades

- Discusses the pitfalls and solutions that may be encountered during upgrades.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e5/the-problem-with-same-version-upgrades/>

### S1:E6 — The Real Problem with Same Version Upgrades in WiX

- Discusses some solutions for working with same-version upgrades, namely the fact that you can install older revisions on top of newer ones.
- Discusses how to prevent older versions from being installed.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e6/the-real-problem-with-same-version-upgrades-in-wix-v4-copy/>

### S1:E7 — Moving beyond Upgrades to Groups and files

- Installing multiple files, using Component Groups
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e7/moving-beyond-upgrades-to-groups-and-files/>

### S1:E8 — Moving beyond Upgrades to Groups and files

- Using WiX and `msbuild` (or `dotnet msbuild`) together using `.wixproj` files
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e8/a-perfect-match-wix-and-msbuild/>

### S1:E9 — Let's install something real

- Installing a compiled application from source code
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e9/lets-install-something-real/>

### S1:E10 — The path from WiX v3 to WiX v4

- Highlights the differences between WiX v3 and WiX v4
- Code samples are not included as WiX v3 is deprecated and unlikely to be used any more
- Use `wix convert filename.wxs` to convert a WiX v3 file to WiX v4.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e10/the-path-from-wix-v3-to-wix-v4/>

### S1:E11 — HeatWave! The New Hotness for WiX v4

- Focuses on using Visual Studio to create installers
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e11/heatwave-the-new-hotness-for-wix-v4/>

### S1:E12 — All the Ways to Change. Variables and Variables. Directories and Properties

- Demonstrates how to define and use variables and properties in WiX installers
- Set preprocessor variables in the `.wixproj` file or in the properties GUI.
- Specify properties at the command line: `dotnet build -p:WixVersion=12.0.0.0 -p:Platform=x86` where `WixVersion` is your preprocessor variable.
- Or using wix: `wix build *.wxs *.wxl -d Version=12.0.0.0 -o out\ep12.msi`
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e12/all-the-ways-to-change-variables-and-variables-directories-and-properties/>

### S1:E13 — Last Minute Changes: Directories

- Demonstrates how to specify installation directories at build time and at install time.
- Build-time directory structure is specified using the `*.wxs` files.
- Install-time directory structure can be specified using properties passed to `msiexec`, e.g `msiexec /i myapp.msi INSTALLFOLDER="C:\My Custom Folder\"`
- Variables specified at install time override those specified at build time.
- Variables specified at install time **must** be in UPPERCASE in your installer project (e.g. `<Directory Id="BINFOLDER">`. Any variables in lowercase (e.g. `<Directory Id="BinFolder">`) will be ignored.
- Variables specified at install time are not case-sensitive. `BINFOLDER=123` is the same as `binfolder=123` and `BinFolder=123`.
- Components can be installed to subdirectories by specifying a `Subdirectory` attribute on the `Component` element, e.g. `<Component Id="MyComponent" Subdirectory="Subfolder">`.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e13/last-minute-changes-directories/>

## Full episode list and where to watch

- Full Season 1 episodes: <https://robmensching.com/deployment-dojo/episodes/s1/>
- YouTube playlist (Season 1): <https://www.youtube.com/playlist?list=PLDlzbQXIs18slmqmdlS10_de_Cps-QRg6>
