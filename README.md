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
- Multiple subdirectory levels can be specified using backslashes, e.g. `Subdirectory="Subfolder\Subsubfolder"`.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e13/last-minute-changes-directories/>

### S1:E14 — Last Minute Changes. This Time: Properties in WiX v4

- Demonstrates how to specify properties at build time and at install time.
- Property values are referenced using square brackets: [PROPERTYNAME]
- Properties don't need to be defined in the WiX source files to be used at install time, but it's good practice to define them using `<Property>` elements.
- Default values can be specified using the `Value` attribute on the `<Property>` element, e.g. `<Property Id="FOO" Value="Bar" />`.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e14/last-minute-changes-this-time-properties-in-wix-v4/>

### S1:E15 — What's a WXL?

- Introduces WiX localization files (`.wxl`), which are XML files used to store localized strings for WiX installers.
- Localized strings are stored in separate `.wxl` files, allowing for easy translation and localization of installer text.
- Name localization files with a language code suffix, e.g. `Strings.en-US.wxl` for US English.
- Id attributes must match across localisation files; only the Value attribute changes.
- Specify localization variables in a `.wxl` file using the `<String>` element, e.g. `<String Id="WelcomeMessage">Welcome to the Setup Wizard</String>`.
- Reference localized strings using `!(loc.VariableName)`, e.g. `<Property Id="WELCOME_MSG" Value="!(loc.WelcomeMessage)" />`.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e15/whats-a-wxl/>

### S1:E16 Let us revisit libraries in WiX v4 - Our first introduction was too short

- Explores the concept of libraries in WiX v4, providing a deeper understanding of how to create and use libraries for reusable installer components.
- Validation of the MSI was disabled in the `.wixproj` file. This can be done by adding the following property inside a `<PropertyGroup>`:
  ```xml
  <DisableMsiValidation>true</DisableMsiValidation>
  ```
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e16/let-us-revisit-libraries-in-wix-v4---our-first-introduction-was-too-short/>

### S1:E17 — The Latest WiX Build Variables: Bind Variables

- Demonstrates the use of bind variables in WiX v4, which allow for dynamic values to be bound at build time.
- We'll create two installers, both of which use the same Wix Library.
- The installers will set a registry key to a different value, depending on the bind variable
- The Wix Library uses a property variable to set a registry key value using the tag `<RegistryValue Value="[DojoType]" />`.
- The `DojoType` property is set in each installer project using a property tag in the `Package.wxs` file:
  ```xml
  <Property Id="DojoType" Value="Community" />
  ```
  ```xml
  <Property Id="DojoType" Value="Enterprise" />
  ```
- If the properties are not set in the installer project, the variable is not set, and the default value will be used.
- If the variable needs to be defined, use Binding properties.
- Use `<WixVariable>` to define bind variables in the `.wxs` file, e.g.:
  ```xml
  <WixVariable Id="DojoType" Value="Community" />
  ```
  Reference the bind variable in the library using the syntax `!(wix.DojoType)`, e.g.:
  ```xml
  <RegistryValue Value="!(wix.DojoType)" />
  ```
- If bound properties are not specified, the build will fail with an error indicating that the bind variable is not set.
  ```
      Error WIX0197: The bind variable !(wix.DojoType) is unknown. Please ensure the variable is declared on the command line for wix.exe, via a WixVariable element, or inline using the syntax !(wix.DojoType=some value which doesn't contain parentheses).
  ```
- Default values can be specified when referencing the bound variable, e.g.:
  ```xml
  <RegistryValue Value="!(wix.DojoType=DefaultValue)" />
  ```
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e17/the-latest-wix-build-variables-bind-variables/>

### S1:E18 Variables End to End - Putting it all together in WiX v4

- Links everything we've learned in the last 17 episodes into one project.
- We start with a console app that we want to install using an MSI.
- Our build team has provided a `.cmd` file to build the application and specify the version.
- Create a WiX Library project to build and install the ConsoleApp1 application and associated registry keys.
- Create a WiX Installer project to build the MSI using the WiX Library (Community Edition).
- Set the Version number using a preprocessor variable passed from the command line.
- Add localisation support (English US, Danish).
- Clone the project for Enterprise Edition, changing only the necessary values (replace `Community` with `Enterprise`).
- Specify bind variables to set the edition type in the registry.
- Specify customer variable at install time. Variable must be UPPERCASE in the code, but when specified at the command line the capitalisation does not matter.
- When installing via the command line, use `msiexec /i [Edition]Package.msi CUSTOMERNAME="My Customer"` to set the customer name.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e18/variables-end-to-end---putting-it-all-together-in-wix-v4/>

## S1 E19: Introducing GitHub to the Deployment Dojo

- Introduces using GitHub for version control and collaboration in the Deployment Dojo projects.
- The first section walks the user through creating a free GitHub Organisation and adds a repository for the Deployment Dojo Episode 19 samples.
- We copy the Episode 18 samples into the new repository, and commit the changes.
- Set up a GitHub Action by creating the file `.GitHub/workflows/buildl.yml`. This file contains a set of instructions to checkout the code, run the `build.cmd`, and then save the compiled MSI packages as artifacts.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e19/introducing-github-to-the-deployment-dojo/>

## S1E20: The New Dojo Development Flow: WiX Toolset + GitHub

- Demonstrates more advanced GitHub methods for working with repositories.
- Introduces using branches to manage code changes and creating pull requests to merge the branch back into the main branch.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e20/the-new-dojo-development-flow-wix-toolset-github/>

## S1E21: Enhancing the Environment with WiX v4

- Moving forward, episodes will be linked to a branch and update the BeltTest project.
- Version numbers of installers will be updated to match the episode number.
- Demonstrates how to set and update Environment Variables using WiX v4.
- Updates the `PATH` variable to include the install folder.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e21/enhancing-the-environment-with-wix-v4/>

## S1E22: Taking a Shortcut using WiX v4

- Creating shortcuts for installed applications using WiX v4.
- In this episode, we create a new Winforms application to display the Edition and Customer name.
- Link: <https://robmensching.com/deployment-dojo/episodes/s1/e22/taking-a-shortcut-using-wix-v4/>

## Full episode list and where to watch

- Full Season 1 episodes: <https://robmensching.com/deployment-dojo/episodes/s1/>
- YouTube playlist (Season 1): <https://www.youtube.com/playlist?list=PLDlzbQXIs18slmqmdlS10_de_Cps-QRg6>
