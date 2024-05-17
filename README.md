﻿![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/BudgetExecution.png)

## An open source data analysis tool for Analysts in the US EPA developed in C# and released under the MIT license.

## Features

- Mutliple providers including SQLite, MS Access, SQL CE, and SQL Server Express Edition.
- Charting and reporting.
- Its own internal web browser [Baby Browser](https://github.com/KarmaScripter/Baby/blob/main/README.md)
- Pre-defined schema for 100 actively used data tables.
- SQL Editors for SQLite, SQL Compact Edition, MS Access,
- Excel User Interface over real databases.
- Map functionality for congressional projects (earmarks) and pollution sites.
- Easy access to environmental program project descriptions of statutory authority.
- Quick budget and accouting calculations via calaculator control bound to data
- Easily add agency/region/division-specific branding, buttons or hotkeys
- View online & offline web data/gaes specifically targeted to reasearching .gov domains with Baby

## Providers

- SQLite is a C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine. [Learn more here](https://sqlite.org/index.html) 
- SQL CE is a discontinued but still useful relational database produced by Microsoft for applications that run on mobile devices and desktops. [Learn more here](https://www.microsoft.com/en-us/download/details.aspx?id=30709)
- SQL Server Express Edition is a scaled down, free edition of SQL Server, which includes the core database engine. [Learn more here](https://www.microsoft.com/en-us/download/details.aspx?id=101064)
- MS Access is a database management system (DBMS) from Microsoft that combines the relational Access Database Engine (ACE) with a graphical user interface and software-development tools. 


## System requirements

- You need [VC++ 2019 Runtime](https://aka.ms/vs/17/release/vc_redist.x64.exe) 32-bit and 64-bit versions

- You will need .NET 6.

- You need to install the version of VC++ Runtime that CEFSharp needs. Since we are using CefSharp 106, according to [this](https://github.com/cefsharp/CefSharp/#release-branches) we need the above versions


## Getting started

- See the [Compilation Guide](Resources/Github/Compilation.md) for steps to get started.


## Documentation

- [User Guide](Resources/Github/Users.md)
- [Compilation Guide](Resources/Github/Compilation.md)
- [Configuration Guide](Resources/Github/Configuration.md)
- [Distribution Guide](Resources/Github/Distribution.md)


## Code

- BudgetExecution uses CefSharp 106 for Baby and is built on NET 6
- BudgetExecution supports AnyCPU as well as x86/x64 specific builds
- `Controls`  - main UI layer and associated controls and related functionality
- `Enumerations`  - various enumerations used for budgetary accounting
- `Extensions`  - useful extension methods for budget analysis by type
- `Clients`  - other tools used and available
- `bin` - Binaries are included in the `bin` folder due to the complex Baby setup required. Don't empty this folder.

## Credits

## Screenshots

### Datagrids to query financial data

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Datagrid.PNG)

### Excel-like UI over a relational database

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/ExcelUserInterface.PNG)

### Maps for congressional projects (earmarks) and pollution sites

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Map.PNG)

### Baby Browser

![](https://github.com/KarmaScripter/Baby/blob/main/Properties/Images/2.png)

### Quick budget and accouting calculations on bound data

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Calculator.PNG)

### Fiscal Year Utility

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/FiscalYear.PNG)

### Environmental Program Definitions

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/EnvironmentalPrograms.PNG)

### Data Visualization

![](https://github.com/KarmaScripter/BudgetExecution/blob/main/Resources/Assets/GitHubImages/Charts.PNG)
