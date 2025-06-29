# MacroAttributes — Inspector Attributes for Unity
[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=for-the-badge&logo=unity)](https://unity.com)
[![License: CC BY-ND 4.0](https://img.shields.io/badge/license-CC%20BY--ND%204.0%20International-lightgrey.svg?style=for-the-badge&logo=creativecommons)](https://creativecommons.org/licenses/by-nd/4.0/)
[![Latest Release](https://img.shields.io/github/v/release/Macrobyte/MacroAttributes?style=for-the-badge)](https://github.com/macrobyte/MacroAttributes/releases)

A lightweight kit that enhances readability, structure, and workflow in Unity’s Inspector using custom attributes.
Ideal for reusing across your Unity games and tools, with clear and simple integration.

## Current Attributes

- **ReadOnly**
- **Divider**
- **SectionHeader**
- **Foldout**

## How to use

1. **Drop** the `MacroAttributes` folder into your project.  
2. **Decorate** your exposed properties:

```csharp
public class GameSettings : MonoBehaviour
{
    
    [SectionHeader("Gameplay Settings", TextAnchor.MiddleCenter, 20)]
    [Divider]
    [ReadOnly] public int maxPlayers = 4;
    
    [Foldout("Graphics Settings")] public bool enableShadows = true;
    [Foldout("Graphics Settings")] public int textureQuality = 2;
    
    [SectionHeader("Audio Settings", TextAnchor.MiddleCenter)]
    [Divider("#FF9384")]
    public float masterVolume = 0.5f;
}
```

## Constructor Overloads

| Attribute       | Constructor Call                                       | Description                                       |
| --------------- | ------------------------------------------------------ | ------------------------------------------------- |
| `SectionHeader` | `[SectionHeader("Title")]`                             | Default alignment = `UpperLeft`, font size = `16` |
| `SectionHeader` | `[SectionHeader("Title", TextAnchor.MiddleCenter)]`    | Custom alignment                                  |
| `SectionHeader` | `[SectionHeader("Title", TextAnchor.MiddleRight, 18)]` | Custom alignment + font size                      |
| `Divider`       | `[Divider]`                                            | Default height (`5f`) & grey color (`#808080FF`)  |
| `Divider`       | `[Divider(10f)]`                                       | Custom height & default color                     |
| `Divider`       | `[Divider(10f, "#FF0000")]`                            | Custom height & custom hex color (red)            |
  
