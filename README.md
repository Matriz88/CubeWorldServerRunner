# Cube World Server Runner

![](https://github.com/Matriz88/CubeWorldServerRunner_source/workflows/CI/badge.svg)

Runner for Cube World Server.

Allows you to set a seed when you run the server. No need to edit your server.cfg manually 😉.

## 🛠️ How to build it:

Visual Studio 2022 or similar ide is mandatory to build the executable.

1. Open the project solution with Visual Studio 2022.
2. Right click on the project in the solution explorer sidebar and click **publish**.
3. Now you have the executable file ready to use in `/publish` folder.
4. Copy the file `CubeWorldServerRunner.exe` and follow the next steps.

## 🚀 How it works:

Copy `CubeWorldServerRunner.exe` in your Cube World installation folder. (Default: `C:\Program Files (x86)\Cube World`).

Run `CubeWorldServerRunner.exe`.

You'll be asked for a server seed. If you don't want to change the current seed, specified in brackets, leave it blank and just press `enter`.

If you insert a new seed, it will be saved in your server configuration.

Then server starts.

![example](/assets/img.gif)

## 💡 Tips

### Setup server

If you're new about Cube World server remember to run Cube World at least once, otherwise you won't have `Server.exe` in your installation folder. It will be generated after the first start of the game.

### Server port

The server runs on port `12345` and this cannot be changed. Be sure to add this port in your port forward settings on your modem/router.
