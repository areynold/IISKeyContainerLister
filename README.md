# IIS Key Container Lister

## Summary

When [encrypting portions of web.config](<https://msdn.microsoft.com/en-us/library/53tyfkaw.aspx>) to protect sensitive data such as API keys, `aspnet_regiis` makes it easy to add new RSA keys, but not so easy to see what keys you've installed on your system.

This is a command line tool to list available RSA key containers used by IIS Express.

The meat of the functional code comes from [LamonteCristo's answer](<https://security.stackexchange.com/questions/1771/how-can-i-enumerate-all-the-saved-rsa-keys-in-the-microsoft-csp/1772#1772>) on this StackOverflow thread.

## Installation & Use

### Run Once

1. Open solution file in Visual Studio.
2. Click **Debug > Start without debugging**.

### Install On System

1. Open solution file in Visual Studio.
2. Set build configuration to **Release**.
3. Click **Build > Publish**.
4. Choose an output directory for the Windows Installer (`setup.exe`).
5. Choose installation method.
6. Choose update strategy.
7. Click **Finish**.
8. Open output directory defined in step 4.
9. Run `setup.exe`.

### Run Installed

1. Open a command prompt.
2. Type `RsaKeyContainerLister` and press Enter.