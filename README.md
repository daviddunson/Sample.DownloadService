Service registration:

* [sc.exe create](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/sc-create)
* [sc.exe config](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/sc-config)
* [sc.exe start](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/start)
* [sc.exe delete](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/sc-delete)


Produces UnauthorizedAccessException:

```
sc create "Sample Service" binPath= "C:\Sample.DownloadService\Sample.DownloadService\bin\Debug\net6.0\win-x64\Sample.DownloadService.exe" 
```
