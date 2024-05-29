using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적의 이동 경로. 0 = Up으로 시작해서 시계방향으로 돌음
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
    GameMode,
    GameOver
}

/// <summary>
/// 적 타입 Enum
/// </summary>
public enum EnemyType
{
    Normal,
    Fast,
    Small,
    Tank,
    Guard
}

/// <summary>
/// 적 등급
/// Common : 흔히 나오는 잡몹입니다.
/// Uncommon : Common과 마찬가지로 수 채우기용 잡몹이나, Common보다 이점을 가지고 있습니다.
/// Special : 특수한 기믹을 가진 적입니다. EnemySpawner에 의해 종류가 제한되고 웨이브에 포함되지 않을 수 있습니다.
/// Boss : 보스 적입니다.
/// </summary>
public enum EnemyGrade
{
    Common,
    Uncommon,
    Special,
    Boss
}
