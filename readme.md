# Shape Battle Demo Project

A simple battle demonstrating a gameplay mechanic implemented with godot. The player takes control of 3 characters:
- Square: mage like, has **icewall (ground target)** and **firewall (single target)**
- Circle: healer like, has **heal (single target)** and **swap position (single target)**
- Triangle: warrior like, has **dash slash (single target)** and **double slash (single target)**

You will be fighting a boss (let's call it diamond) that has the following attacks:
- Meteor (ground target, large area)
- Spikes (no target, random spikes appear on the ground)
- Lazer (ground target, reaches from the boss to the end of the screen)

Gameplay will be a combination of real-time and menu-based battle systems. The objective is to kill the diamond before it kills your party members.

Note: everyone (party members and boss) will have **move** and **attack** commands alongside their mentioned moveset, which will work this way:
- Move lets you move your character inside a set area (boss' move covers the entire map)
- Attack is the simplest form of damage dealing, you move next to the target and strike it
