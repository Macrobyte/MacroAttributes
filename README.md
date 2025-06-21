# 📦 MacroAttributes — Inspector Attributes for Unity
<p align="center">
  <img src="https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge" alt="License: MIT" />
  <img src="https://img.shields.io/badge/Unity-2023.1.0f1-blue.svg?style=for-the-badge" alt="Unity Version" />
  <img src="https://img.shields.io/badge/Platform-Windows%20%7C%20macOS%20%7C%20Linux-lightgrey.svg?style=for-the-badge" alt="Supported Platforms" />
</p>
A lightweight, open-source toolkit by Macrobyte (Vasco Almeida) that enhances readability, structure, and workflow in Unity’s Inspector using custom attributes.
Instantly improve inspector clarity and polish.
Ideal for reusing across your Unity games and tools, with clear and simple integration.

---

## 🔍 Features

- **ReadOnly**, **Divider**, **Category** – built-in attributes for cleaner and more organized inspectors.
- Sticker-style visuals for inspector decoration—ideal for quick layout improvements.
- Clean, modular code with a distinct namespace (`MacroAttributes`) to avoid conflicts.

---

## 🛠 Getting Started

1. **Drop** the `MacroAttributes` folder into your project.  
2. **Decorate** your serialized fields like this:

    ```csharp
    [ReadOnly]
    [Divider]
    [Category("Gameplay Settings", TextAnchor.MiddleCenter)]
    ```

3. **Enjoy** a more structured and readable inspector—instantly!

---
[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=for-the-badge&logo=unity)](https://unity.com)

[![License: MIT](https://img.shields.io/badge/license-MIT-green.svg?style=for-the-badge)](./LICENSE)

[![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/yourusername/MacroAttributes?style=for-the-badge)](https://github.com/yourusername/MacroAttributes/releases)
