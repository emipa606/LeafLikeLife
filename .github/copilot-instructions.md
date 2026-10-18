# Leaf Like Life (Continued) - GitHub Copilot Instructions

## Mod Overview and Purpose

**Leaf Like Life (Continued)** is a RimWorld mod that updates the original mod by Neceros to provide a more immersive experience with the in-game smokeleaf drug. The mod rebalances smokeleaf's effects to align them more closely with real life, making it slightly less addictive and significantly reducing the likelihood of cancer. The mod's settings are also highly customizable, allowing players to tune the effects to their preferences.

## Key Features and Systems

The mod introduces several key features and changes:
- The consciousness penalty inflicted by smokeleaf is reduced from 30% to 15%.
- Movement, sleepiness, and hunger penalties are customizable via the settings menu.
- Smokeleaf is now half as addictive as in the base game.
- The probability of developing asthma is halved.
- The likelihood of contracting carcinoma is reduced by three-quarters.
- Withdrawal mood penalty is lowered from -22 to -8.

These changes are aimed at enhancing gameplay immersion by simulating effects more akin to real-life scenarios.

## Coding Patterns and Conventions

- **C# Naming Conventions**: The mod employs PascalCase for class names (`LLLMod`, `LLLModSettings`) and method names (`ExposeData`, `DoSettingsWindowContents`). CamelCase is used for local variables and method parameters.
- **Code Layout**: Methods related to settings and initialization (`ExposeData`, `ResetSettings`, `WriteSettings`) are organized within their respective C# files to maintain a clean and logical structure.
- **Modular Architecture**: Each C# file encapsulates a specific component of the mod (e.g., startup logic, mod settings).

## XML Integration

- **About.xml**: This file contains meta information about the mod, including the name, author, package ID, and other pertinent data.
- **Patch Files**: `Patch_ImmersiveSmokeleaf.xml` is used for defining XML patches that modify the game's data directly, allowing for the rebalance of smokeleaf properties.

### Harmony Patching

While there is no specific Harmony patching mentioned, if you plan to introduce any Harmony patches in the future, ensure you:

1. **Create a Harmony Instance**: Initialize Harmony with a unique identifier to avoid conflicts.
   csharp
   var harmony = new Harmony("com.modname.patch");
   

2. **Patch Methods**: Use `harmony.Patch` to apply your prefix, postfix, or transpiler methods to the target game methods.

3. **Organize Patch Logic**: Keep patch logic organized in a separate class to maintain clarity.

## Suggestions for Copilot

- **Automate XML Definitions**: Use Copilot to generate additional XML-related content, such as new XML def files, if you intend to extend the mod's functionality.
- **Streamline Code Updates**: Copilot can assist in automating repetitive coding patterns, such as initializing settings and writing UI components.
- **Implement Logging**: Enhance debugging with logging capabilities, and Copilot can suggest logging integration points for better error tracking.
- **Optimize Performance**: Copilot can help identify performance bottlenecks in the code and suggest potential optimizations.

These instructions provide a comprehensive guide for using GitHub Copilot to assist in the ongoing development and maintenance of the Leaf Like Life mod for RimWorld. Keep these best practices in mind to ensure a robust and feature-rich mod experience.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

