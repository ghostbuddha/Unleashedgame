﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player, Enemies (Mob, Add, Boss), Destructible Walls
// Items (Health, 1-Up, Ammo, Karma), Stage (Doors, Trapdoors)
// NPCs (Friendly, Unfriendly), Signs
// Menus (Main, Pause, Dialogue, Game Over)
// Scenes (Intro, Inactive Start Menu, Cutscene)

public interface IPlayable {

    void HandleStates();

    void HandleMovement();

    void HandleAttack();
    
}

public interface IFightable
{
    
    void Behavior();

    void Attack();
    
}

public interface IKillable
{
    float MaxHealth { get; set; }

    float CurrentHealth { get; set; }

    void TakeDamage();

    int Lives { get; set; }

    int CurrentLives { get; set; }
       
    void Die();

}


public interface IUsable
{
    void Spawn();

    void OnPickup();

}

public interface IShootable
{
    void Behavior();

    void OnHit();

    void Proc();

    void Pop();

}

public interface ICutscene
{

}