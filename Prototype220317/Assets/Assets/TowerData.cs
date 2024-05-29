using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Data", menuName = "Scriptable Object/Tower Data", order = 2)]
public class TowerData : ScriptableObject
{
    public float range; //��Ÿ�
    public float bulletSpeed; //�Ѿ��� �ӵ�
    public float damage; //�Ѿ��� ������
    public float reloadSpeed; // ���� �ӵ� (�ð� > 1f / reloadSpeed)
    public int penetrate; //����� (������)

    public Sprite towerIcon;
    public string towerName;
    [TextArea(3,5)]
    public string towerDescription;
    public TowerType towerType;
}