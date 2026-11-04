# Contributing to Megacity East
This will mostly be some guidelines and then some words for some gotchas developers might face.

# Guidelines
## 1. No AI/LLM generated/assisted code
We extend a brief olive branch when a developer looks something up, and gets an AI summary and uses part of it, because that's forced onto the developer.

Similarly if a developers IDE is forcing AI code suggestions, its acceptable (an example being JetBrains Rider's autocomplete);
but if you're just using Codex, Claude Code, Copilot or similar, **We don't want your LLMs code.**

## 2. No redistributing [Airframe Ultra's](https://store.steampowered.com/app/2522120/Airframe_Ultra/) assets (such as textures or models)
This is largely because I've been unable to get permission from Akupara or Videocult to do this.

If this ends up happening without explicit written permission, It puts the entire project as risk for a cease and desist and I cant afford lawyers.

Please do not contact anybody at AG or VC about this on the projects behalf.

# Gotchas
This is mostly just things I've learned and or decided on that might make learning the codebase tricky.

The biggest gotcha would be the sloppily put together `ToQNative` proxy generator.
That things job is essentially, to turn all of the `ProxyTypes` into the Quantum versions, but code generation tends to be really janky with LSP's.

Its code quality is also *really bad* (at least at the time of writing this).

The `ProxyTypes` might also be kinda confusing, early on I decided I wanted `MCEEditor` to not depend on anything but things available in base unity.
so we have a system to make JSON serializable versions of every type in the game.

The whole project is supposed to be architected to where `MCEEditor` has the most responsibility, and `MCELoader` basically just follows its instructions.

