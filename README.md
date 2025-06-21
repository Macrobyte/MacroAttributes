# 📦 MacroAttributes — Inspector Attributes for Unity
<p align="center">
  <img src="https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=for-the-badge&logo=unity" alt="Made with Unity" />
  <img src="https://img.shields.io/badge/license-CC%20BY--ND%204.0%20International-lightgrey.svg?style=for-the-badge&logo=creativecommons" alt="License: CC BY-ND 4.0" />
  <img src="https://img.shields.io/github/v/release/macrobyte/MacroAttributes?style=for-the-badge" alt="Latest Release" />
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
