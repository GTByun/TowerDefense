using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumScript
{
}

//���⿡ enum�� �־��ּ���

/// <summary>
/// �� ������Ʈ�� ��� �������� �̵��ؾ� �ϴ����� ������
/// </summary>
public enum EnemyMove
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3
}

/// <summary>
/// ���� ������ State
/// </summary>
public enum GameState
{
    SelectReward,
    EditMode,
    GamePlay
}
