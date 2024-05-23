using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
    public string name; //이름
    public EnemyGrade grade; //등급
    public EnemyType type; // 타입
    public float hp; //체력
    public float speed; //속도
    public int price; //가격
    public Sprite sprite; //스프라이트
    public float spawnDelay; //스폰딜레이
}
