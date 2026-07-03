# GenerateUnrealEngineServerTool

## Overview

GenerateUnrealEngineServerToolは、Unreal Engineプロジェクトのサーバーを簡単に起動するためのツールです。
このアプリケーションを使用することで、Unreal Editorのパスやプロジェクトファイルを指定し、簡単にバッチファイルを生成・実行できます。

GenerateUnrealEngineServerTool is a tool designed to simplify the process of launching a server for Unreal Engine projects.
With this application, you can specify the Unreal Editor path and project file to easily generate and execute batch files.

## Requirement

- Windows OS
- .NET Framework 4.7.2 以上 / .NET Framework 4.7.2 or later
- Unreal Engine 4.26 以降 / Unreal Engine 4.26 or later

## Installation

[GitHub Releases](../../releases) から最新の `.msi` インストーラーをダウンロードして実行してください。
.NET ランタイムは同梱されているため、別途インストールは不要です（インストール先: `C:\Program Files`、管理者権限が必要）。

Download the latest `.msi` installer from [GitHub Releases](../../releases) and run it.
The .NET runtime is bundled, so no separate installation is required (installs to `C:\Program Files`; administrator privileges required).

## Release (for maintainers)

`v*` 形式のタグを push すると、GitHub Actions が self-contained な `.msi` を自動生成し Release に添付します。
Pushing a `v*` tag triggers GitHub Actions to build the self-contained `.msi` and attach it to a Release.

```bash
git tag v1.2.0
git push origin v1.2.0
```

ワークフロー: [.github/workflows/release.yml](.github/workflows/release.yml) / インストーラー定義: [installer/](installer/)

## Usage

1. アプリケーションを起動します。
   Launch the application.
2. Unreal Engineのバージョンをドロップダウンリストから選択するか、カスタムパスを有効化して手動で指定してください。
   Select the Unreal Engine version from the dropdown list or enable the custom path option to specify it manually.
3. プロジェクトファイル（.uproject）を指定します。
   Specify the project file (.uproject).
4. "Generate Batch"ボタンをクリックすると、バッチファイルが生成されます。
   Click the "Generate Batch" button to create a batch file.
   - ファイル名は`プロジェクト名_RunServer.bat`形式になります。
     The file will be named in the format `ProjectName_RunServer.bat`.
5. 生成されたバッチファイルを使用して、サーバーを起動できます。
   Use the generated batch file to launch the server.

## Note

本アプリを利用してのファイル損失やシステムの障害等、いかなる理由があっても一切の補償ができません。
同意の上ご利用ください。

This application does not provide any warranty or compensation for file loss, system issues, or any other problems caused by its use. Use it at your own risk.

## Author

- Namiton
- SingleClickCompany
- namitonShere@gmail.com

## License

"GenerateUnrealEngineServerTool" is under [MIT license](https://en.wikipedia.org/wiki/MIT_License).

