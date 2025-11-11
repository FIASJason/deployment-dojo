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

## Full episode list and where to watch

- Full Season 1 episodes: <https://robmensching.com/deployment-dojo/episodes/s1/>
- YouTube playlist (Season 1): <https://www.youtube.com/playlist?list=PLDlzbQXIs18slmqmdlS10_de_Cps-QRg6>
