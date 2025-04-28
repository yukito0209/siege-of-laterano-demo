# Siege of Laterano Demo

## 简介 (Introduction)

这是一个基于 Unity 引擎开发的二次元风格第一人称射击 (FPS) 游戏 Demo。项目灵感来源于游戏《明日方舟》，旨在探索在 Unity 中实现特定美术风格和 FPS 核心玩法的可能性。

This is an anime-style First-Person Shooter (FPS) game demo developed with the Unity engine. Inspired by the game "Arknights", this project aims to explore the implementation of specific art styles and core FPS gameplay mechanics within Unity.

**主题 (Theme):** 萨科塔 (Sankta) 抵御萨卡兹 (Sarkaz) 对拉特兰圣城 (Laterano) 的入侵。
*(Sankta defending the holy city of Laterano against Sarkaz invasion.)*

## 当前功能 (Current Features)

*   **基础玩家控制 (Basic Player Control):**
    *   使用 WASD 键进行移动 (Movement using WASD keys)。
    *   使用鼠标控制视角 (Camera look controlled by mouse)。
    *   基于 Character Controller 的移动和重力 (Character Controller based movement and gravity)。
*   **基础射击机制 (Basic Shooting Mechanics):**
    *   鼠标左键发射射线进行射击 (Left mouse button fires a raycast)。
    *   可射击目标 (Target) 能够承受伤害并在生命值耗尽时被销毁 (Shootable targets (Target) can take damage and are destroyed when health reaches zero)。
    *   在击中点生成简单的粒子特效作为视觉反馈 (Instantiates a simple particle effect at the hit point for visual feedback)。
    *   在控制台输出击中和伤害信息 (Logs hit and damage information to the console)。

## 如何运行 (How to Run)

1.  确保已安装 [Git](https://git-scm.com/downloads) 和 [Unity Hub](https://unity.com/download)。
2.  通过 Unity Hub 安装 Unity 编辑器版本 **2022.3.57f1c1 LTS** (或兼容的 2022.3.x 版本)。确保安装了 Windows/Mac Build Support 模块。
3.  克隆此仓库到本地: `git clone https://github.com/yukito0209/siege-of-laterano-demo.git`
4.  使用 Unity Hub 打开克隆到本地的项目文件夹。
5.  在 Unity 编辑器中，打开 `Assets/Scenes/SampleScene` (或其他主场景)。
6.  点击编辑器顶部的 Play (▶️) 按钮运行 Demo。

## 使用的引擎版本 (Engine Version)

*   Unity **2022.3.57f1c1 LTS**

## 开发环境 (Development Environment)

*   **代码编辑器 (IDE):** Visual Studio Code
*   **渲染管线 (Render Pipeline):** Universal Render Pipeline (URP)

## 未来计划 (Roadmap)

*   [x] 实现目标伤害与销毁 (Implement target damage & destruction)
*   [ ] 添加基础武器模型和开火动画 (Add basic weapon model and firing animation)
*   [ ] 添加射击特效 (枪口火焰、弹道、**完成: 击中效果**) (Add shooting VFX: muzzle flash, tracer, **Done: impact effect**)
*   [ ] 实现简单的敌人 AI (Implement simple enemy AI)
*   [ ] 探索二次元风格着色器 (Explore anime-style shaders)
*   [ ] 构建基础关卡环境 (Build basic level environment)

---

*这个 Demo 是在 Gemini 的指导下创建的。*
*(This demo was created with guidance from Gemini.)*
