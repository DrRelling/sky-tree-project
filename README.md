# sky-tree-project

## C#/.NET

You will need .NET v7.0 installed.

To run the program from the command line, run `dotnet run [args]` from the `dotnet/TreeParser/program` folder.

To run the unit tests, run `dotnet run test` from the `dotnet/TreeParser/tests` folder.

To build the program as an executable, you can use `dotnet publish`. The exact arguments needed vary by platform, but for Windows this should work:

`dotnet publish -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:UseAppHost=true`

This will build TreeParser.exe in `program\bin\Debug\net7.0\win-x64`.

## TypeScript/NodeJS

You will need NodeJS v20.12.2 installed. All commands should be run from the `node` folder.

To run the program from the command line, run `npm start [args]`.

To run the tests, run `npm run test`.

## Arguments

Both programs will accept either comma-separated values (1,2,3) or multiple arguments with one value each (1 2 3).

Currently, both programs will only accept integers, but the tree code itself is type-agnostic.

## Possible improvements

* Make the tree building/parsing recursive.
* Improve the configuration for import handling in the node program.
* Convert programs to use generics rather than accept any input.
* It might be possible to skip the entire tree generation and just return the correct output with some clever maths on the input indices.
