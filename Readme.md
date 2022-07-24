# SaaS Products Import

## Summary
We update our inventory of SaaS products from several sources.  Each source provides its content to us in a different format.  Write a command line tool in C# to import the products.

## Installation
### Cloning the project and running on local

- For cloning the project, use the [Link](https://github.com/ayushbansal433/SaasInventory.git) and use command `git clone link-address`.
- Before running the project, make sure .net 6 is installed. 
- Open the solution in Visual Studio, clean and build the solution.
- Restore the required dependencies.

### Creating .nupkg file
- For creating the nupkg file, open command line in solution folder and write `dotnet pack` in cmd.
- It will create a nupkg file.
- To install the nupkg file globally and access it in cmd, use `dotnet tool install --global --add-source ./SaasInventory/nupkg SaasInventory` command. This will install the nupkg file.
- To uninstall the file, use `dotnet tool uninstall SaasInventory -g`

### Running CLI tool

- Open command prompt and write `import <FileName> <Path(with file-type)>` and click enter.
