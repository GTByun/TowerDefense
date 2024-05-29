using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
    public string name; //�̸�
    public EnemyGrade grade; //���
    public EnemyType type; // Ÿ��
    public float hp; //ü��
    public float speed; //�ӵ�
    public int price; //����
    public Sprite sprite; //��������Ʈ
    public float spawnDelay; //����������
}
