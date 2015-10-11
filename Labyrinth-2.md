1. Redesigned the project structure: Team Labyrinth-2
 - Renamed project files
 - Extracted methods in separate files
2. Reformatted the source code:
 - introduced core of the game functionality and game platform via console
 - separeted namespace for every logical aspect
3. StyleCop and HQC good practices for naming, positioning, tabulations etc
 - Formatted the curly braces { and } according to the best practices for the C# language.
 - Put { and } after all conditionals and loops (when missing).
 - Character casing: variables and fields made camelCase; types and methods made PascalCase.
 - Formatted all other elements of the source code according to the best practices introduced in the course “High-Quality Programming Code”.
 - renamed variables
4. Introduced classes for constants
 - in namespace Common
5. Implemented Factory design pattern for commands functunality
 - in namespace CommandFactory
 - in namespace Commands
6. Higher abstraction for all game components
 - ICell
 - IDirection
 - Iplayer
 - IPlayField
 - IPlayFieldRenderer
 - IResult
 - IScoreLadder
 - more...
7. Implemented Memento design pattern
 - in namespace Helpers.Contracts
