# 🍜 NoodleCV

![GitHub last commit](https://img.shields.io/github/last-commit/BartShoot/NoodleCV?style=flat-square)
![GitHub License](https://img.shields.io/github/license/BartShoot/NoodleCV?style=flat-square)
[![Libraries.io dependency status for GitHub repo](https://img.shields.io/librariesio/github/bartshoot/noodlecv?style=flat-square&logo=librariesdotio)](https://libraries.io/github/BartShoot/NoodleCV)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/BartShoot/NoodleCV?style=flat-square)
![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/BartShoot/NoodleCV/total?style=flat-square)


Multiplatform desktop application for image processing.
Project is inspired by Blender, Unreal Engine, Substance Designer and other node-based editors.

User will be able to add blocks representing operations and pass the inputs with connections creating series of
functions like you could do in code but with no programming knowledge required.

Software should be good enough for demonstrating quick prototypes of image processing workflows.
Ideally preview should update on user input for quick feedback.

First priority is getting simple functions like blur to work.
Types of data other than images are planned for future developement.

# 🚀 Running the app

To try the application you can head over to download newest [release](https://github.com/BartShoot/NoodleCV/releases)
for your device.
For now the application is mostly made up of mock interface and functionality will come at later date.

If you wish to build the app yourself clone the repo and in repo root directory
run `dotnet run --project NoodleCV.App.Desktop`

For the lazy:

```shell
git clone https://github.com/BartShoot/NoodleCV.git
cd NoodleCV
dotnet run --project NoodleCV.App.Desktop
```

If you wish to package it like in releases check out
my [Buddy pipelines](https://github.com/BartShoot/NoodleCV/blob/main/.buddy/buddy.yml) where I use `dotnet publish` with
trimming and single file portable output.

# 🧰 Stack

Application is developed in C# with AvaloniaUI targeting desktop platforms (Windows, Linux and MacOS).
Operations will be implemented from OpenCV.