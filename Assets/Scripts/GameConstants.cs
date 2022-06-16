using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConstants
{
    //Player
    public static readonly int SwordSliceAttackTrigger = Animator.StringToHash("Attack");
    public static readonly int SwordSliceAttack_PrepareAttack = Animator.StringToHash("PrepareAttack");
    public static readonly int PlayerRun = Animator.StringToHash("Run");

    //Cube
    public static readonly int CubeDestroy = Animator.StringToHash("Destroy");

    //Zombie
    public static readonly int ZombieAttack = Animator.StringToHash("Attack");
    public static readonly int ZombieFallback = Animator.StringToHash("Fallback");
    public static readonly int ZombieWalking = Animator.StringToHash("IsWalking");
    public static readonly int ZombieRunning = Animator.StringToHash("IsRunning");
    public static readonly int ZombieRoaming = Animator.StringToHash("IsRoaming");
}

public class GameplayConstants
{
}

public class Tags
{
    public static readonly string GameController = "GameController";
    public static readonly string Player = "Player";
    public static readonly string Enemy = "Enemy";
    public static readonly string DamageDealingObject = "DamageDealingObject";
    public static readonly string WallrunObject = "WallrunObject";
}

public class Other
{
    public static readonly string MainMenuName = "MainMenu";
}