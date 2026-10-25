# Adventure Rabbit

A 2D pixel-art platformer made with Unity. Guide the rabbit through six levels, dodge enemies, ride moving platforms, and reach the finish point to unlock the next stage.

## Features

- 6 hand-built levels plus a main menu with level select
- Level progression saved with `PlayerPrefs` (finishing a level unlocks the next one)
- Checkpoints and respawn zones
- Moving platforms that carry the player
- Pause menu (resume, restart, return home) and game-over screen
- 8-bit soundtrack, one track per level

## Controls

| Action     | Key                     |
|------------|-------------------------|
| Move       | `A` / `D` or `←` / `→`  |
| Jump       | `Space`                 |
| Pause      | On-screen pause button  |

## Requirements

- Unity **2023.1.0f1** (other 2023.x versions should work, but may upgrade the project)
- Universal Render Pipeline 15 (installed automatically through the Package Manager)

## Getting started

1. Clone the repository:
   ```bash
   git clone https://github.com/youngboi03/Adventure-Rabbit.git
   ```
2. Open the folder in Unity Hub (**Add project from disk**) and open it with Unity 2023.1.
3. Open `Assets/Scenes/Main Menu.unity` and press **Play**.

To build, use **File → Build Settings**. The scene order is already configured: `Main Menu`, `lv1` … `lv6`.

## Project structure

```
Assets/
├── Scenes/            Main Menu and levels lv1–lv6
├── Script/            Gameplay C# scripts
├── animation/         Player and enemy animations
├── Canvas/, Graphics/ UI and sprites
├── SunnyLand Artwork/ Environment and character art
├── Simple 2D Platformer BE2/
└── 8Bit Music - 062022/  Background music
```

### Main scripts

| Script                    | Responsibility                                        |
|---------------------------|-------------------------------------------------------|
| `PlayerController`        | Player movement, jumping, animation                   |
| `PlayerManager`           | Spawn position, game-over screen, replay              |
| `PlayerCollision`         | Kills the player on contact with enemies              |
| `Checkpoint` / `checkpointscript` / `RespawnScript` | Checkpoints and respawning  |
| `Flatform`                | Moving platform between two points                    |
| `FinishPoint`             | Unlocks the next level and loads it                   |
| `SceneController`         | Persistent scene loader                               |
| `LevelMenu`, `Main_Menu`, `PauseMenu` | Menus                                     |

## Credits

- Art: *Sunny Land* by Ansimuz, *Simple 2D Platformer BE2* (Unity Asset Store)
- Music: *8Bit Music - 062022* by GWriterStudio

Third-party assets remain the property of their respective authors and are subject to their own licenses.

## Author

**youngboi03** — [github.com/youngboi03](https://github.com/youngboi03)

## License

The source code in this repository is released under the [MIT License](LICENSE).
