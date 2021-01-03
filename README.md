# Coffeemachine
Prevents idle, sleeping and locking by sending mouse move events.

## How It Works

Every minute it sends the mouse move event using the [SendInput API](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput) with relative<br>
coordinates - this means the mouse will not jump anywhere and the movement is not noticable.

## Dependencies
Vanara.PInvoke.User32 (via NuGet)<br>
Costura.Fody (via NuGet)