# AR Furniture (Yuda) 🛋️

An Augmented Reality (AR) application to visualize and place furniture in the real world using Unity ARFoundation technology.

## 📋 Table of Contents
- [Project Description](#project-description)
- [Key Features](#key-features)
- [Technologies Used](#technologies-used)
- [System Requirements](#system-requirements)
- [Installation & Setup](#installation--setup)
- [Project Structure](#project-structure)
- [How to Use](#how-to-use)

---

## 🎯 Project Description

AR Furniture is a mobile AR application that allows users to:
- **Visualize furniture in the real world** before purchasing
- **Place furniture objects** on flat surfaces detected by AR
- **Rotate furniture** interactively
- **Delete unwanted furniture** from the scene

This project is designed to help users make better purchase decisions by seeing how furniture will look in their space.

---

## ✨ Key Features

### 1. **Flat Surface Detection (Plane Detection)**
   - Uses ARFoundation to detect horizontal and vertical surfaces
   - Displays an interactive placement indicator

### 2. **Furniture Spawning & Placement**
   - Tap to place furniture on detected surfaces
   - Real-time preview before confirming placement
   - Support for multiple furniture items in one scene

### 3. **User Interaction**
   - **Tap & Drag**: Move furniture to a new location
   - **Manual Rotation**: Buttons to rotate furniture clockwise/counterclockwise
   - **Delete**: Remove unwanted furniture

### 4. **UI Controls**
   - Furniture buttons to select models to spawn
   - Left/right rotation buttons
   - Delete button to remove last object
   - Finish button to confirm placement

---

## 🛠️ Technologies Used

### Core Framework
- **Unity 2022+** - Game Engine
- **ARFoundation 5.x** - Cross-platform AR framework
- **ARKit (iOS)** / **ARCore (Android)** - Platform-specific backend

### Additional Assets & Libraries
- **Quick Outline** - For visual feedback when furniture is selected
- **XR Interaction Toolkit** - For advanced AR interactions
- **TextMesh Pro** - UI text rendering

### Programming Language
- **C#** - Script logic

---

## 💻 System Requirements

### For Development
- **Unity 2022 LTS** or newer
- **Visual Studio 2022** or compatible C# editor
- **Git** for version control

### For Runtime
- **Android 7.0+** (Device with ARCore support)
- Internet connection (for cloud assets if needed)

---

## 🚀 Installation & Setup

### 1. Clone Repository
```bash
git clone https://github.com/Yuda531/AR-Furniture-Yuda-.git
cd AR-Furniture-Yuda-
```

### 2. Setup Unity Project
- Open Unity Hub
- Select **Add project from disk**
- Navigate to the project folder
- Ensure you are using Unity 2022 LTS or newer

### 3. Import Dependencies
Unity will automatically import the required packages:
- ARFoundation
- ARKit XR Plugin (for iOS)
- Google ARCore XR Plugin (for Android)
- XR Interaction Toolkit

### 4. Configure Project Settings
```
Edit > Project Settings > Player:
- Set Bundle Identifier: com.yuda.arfurniture
- Set Minimum API Level: Android 7.0+
- Enable ARKit/ARCore support
```

---

## 📁 Project Structure

```
AR Furniture (Yuda)/
├── Assets/
│   ├── AR Furniture/                # Main AR furniture assets
│   │   ├── Screen Space Ray Interactor.prefab
│   │   └── ...
│   │
│   ├── Scenes/                      # Scene files
│   │   ├── AR Furniture Scene.unity  # Main AR scene
│   │   ├── ARInteractionManager.cs   # Manager for AR interactions
│   │   ├── PlaceOnIndicator.cs       # Furniture placement script
│   │   └── ...
│   │
│   ├── Resources/                   # Furniture prefabs & assets
│   │   └── [Furniture Prefabs]
│   │
│   ├── Samples/                     # Samples from packages
│   ├── XR/                          # XR-related assets
│   ├── XRI/                         # XR Interaction Toolkit assets
│   ├── Settings/                    # Project configuration
│   └── TextMesh Pro/                # TMP assets
│
├── Packages/                        # Package dependencies
├── ProjectSettings/                 # Unity project configuration
└── README.md                        # This file
```

---

## 🎮 How to Use

### For End Users (Runtime)

1. **Launch Application**
   - Open the app on iOS/Android device
   - Grant camera permissions

2. **Select Furniture**
   - Tap one of the furniture buttons in the UI
   - Move your camera to detect a flat surface
   - Placement indicator will appear when a surface is detected

3. **Rotate Furniture**
   - Use the **Rotate Left** ⬅️ button to rotate counterclockwise
   - Use the **Rotate Right** ➡️ button to rotate clockwise

4. **Place Furniture**
   - Tap finish button on the screen to place furniture at the location shown by the indicator

5. **Delete Furniture**
   - Tap the **Delete** button to remove it

---

## 🔧 Main Scripts Explanation

### ARInteractionManager.cs
Main manager for handling AR interactions:
- **SetObjectToSpawn()** - Set the furniture to be spawned
- **UpdatePlacementPose()** - Update placement indicator position
- **SelectObject()** / **DeselectObject()** - Manage object selection
- **DeleteActiveObject()** - Delete the selected object

### PlaceOnIndicator.cs
Script for furniture placement and rotation:
- **SelectObjectToPlace()** - Preview furniture before placement
- **RotateLeft()** / **RotateRight()** - Rotate furniture
- **ConfirmPlacement()** - Confirm final placement
- **DeleteLastObject()** - Delete last placed furniture

---

## 🐛 Troubleshooting

### Plane not detected
- Ensure sufficient lighting
- Move camera slowly over the surface
- Ensure the surface has clear texture/pattern

### Furniture appears too small/large
- Adjust scale on the furniture prefab
- Modify initial spawn scale in the `SpawnObject()` script

### Performance issues
- Reduce the number of furniture spawned simultaneously
- Optimize mesh on furniture prefabs

---

## 📚 Resources & Documentation

- [Unity ARFoundation Documentation](https://docs.unity.com/arfoundation/latest/index.html)
- [ARKit Plugin](https://docs.unity.com/arkit/latest/manual/index.html)
- [Google ARCore Plugin](https://developers.google.com/ar/develop/unity-arf)
- [XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest)

---

## 👨‍💼 About Project

**Developer:** Agung Yuda Pratama  
**Repository:** [AR-Furniture-Yuda-](https://github.com/Yuda531/AR-Furniture-Yuda-)  
**Status:** Active Development 🚀

---

## 📞 Contact & Support

For questions or support:
- 📧 Email: [yudaagung70@gmail.com]
- 🐙 GitHub Issues: [Issue Tracker](https://github.com/Yuda531/AR-Furniture-Yuda-/issues)

---

## 🎓 Development Notes

### Latest Versions
- **v1.0** - Initial release with basic features
- **v0.3** - UI and performance improvements
- **v0.2** - Beta testing phase
- **v0.1** - Alpha release

### Known Issues 🚨
- Plane detection requires proper lighting

---

**Happy AR Furniture Shopping! 🎉**

*Last updated: November 2025*
