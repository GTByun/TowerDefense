using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumScript
{
}

/// <summary>
/// 적의 이동 경로
/// </summary>
public enum EnemyMove
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3
}

/// <summary>
/// 현재 게임의 상태
/// </summary>
public enum GameState
{
    None,
    SelectReward,
    EditMode,
    GamePlay
}
