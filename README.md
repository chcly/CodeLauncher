# CodeLauncher

Is a program to control the extension and user directories for vs-code with
environment variables.  

It's meant to be a quick hack / work around to prevent Code from using valuable space on a windows partition.

> VSCODE_PATH

Should point to a specific vs-code zip. download.

```.txt
Z:\foo\VSCode-win32-x64-1.76.1\
```

> VSCODE_EXTENSIONS

Should point to the desired storage location for extensions.

```.txt
Z:\foo\VSCodeData\ext\
```

> VSCODE_USER

Should point to the desired storage location for user data.

```.txt
Z:\foo\VSCodeData\user\
```

## Notes

+ To transparently funnel through it, change the output type to `Windows Application`.
+ I set it to load `Code1.exe` to assert that the desired executable is being invoked.

## Google Search Reference

If you use vscode from the shell, then the paths outlined here need to be changed to the CodeLauncher installation directory.

+ <https://stackoverflow.com/questions/64461301/open-folder-in-vs-code-from-windows-explorer>
+ <https://stackoverflow.com/questions/40080793/is-there-a-way-to-change-the-extensions-folder-location-for-visual-studio-code>

### Entries

```.txt
Computer\HKEY_CLASSES_ROOT\Directory\Background\shell\vscode
```

| Name      | Type   | Data                                     |
| --------- | ------ | ---------------------------------------- |
| (Default) | REG_SZ | Open as Code Project                     |
| Icon      | REG_SZ | "Z:\foo\CodeLauncher\CodeLauncher.exe",0 |

```.txt
Computer\HKEY_CLASSES_ROOT\Directory\Background\shell\vscode\command
```

| Name      | Type   | Data                                       |
| --------- | ------ | ------------------------------------------ |
| (Default) | REG_SZ | "Z:\foo\CodeLauncher\CodeLauncher.exe" "." |

```.txt
Computer\HKEY_CLASSES_ROOT\Directory\shell\vscode
```

| Name      | Type   | Data                                     |
| --------- | ------ | ---------------------------------------- |
| (Default) | REG_SZ | Open as Code Project                     |
| Icon      | REG_SZ | "Z:\foo\CodeLauncher\CodeLauncher.exe",0 |

```.txt
Computer\HKEY_CLASSES_ROOT\Directory\shell\vscode\command
```

| Name      | Type   | Data                                        |
| --------- | ------ | ------------------------------------------- |
| (Default) | REG_SZ | "Z:\foo\CodeLauncher\CodeLauncher.exe" "%1" |

```.txt
Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shell\vscode
```

| Name      | Type   | Data                                     |
| --------- | ------ | ---------------------------------------- |
| (Default) | REG_SZ | Open with VS Code                        |
| Icon      | REG_SZ | "Z:\foo\CodeLauncher\CodeLauncher.exe",0 |

```.txt
Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shell\vscode\command
```

| Name      | Type   | Data                                        |
| --------- | ------ | ------------------------------------------- |
| (Default) | REG_SZ | "Z:\foo\CodeLauncher\CodeLauncher.exe" "%1" |
