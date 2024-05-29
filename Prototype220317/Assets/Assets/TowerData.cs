using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Data", menuName = "Scriptable Object/Tower Data", order = 2)]
public class TowerData : ScriptableObject
{
    public float range; //사거리
    public float bulletSpeed; //총알의 속도
    public float damage; //총알의 데미지
    public float reloadSpeed; // 장전 속도 (시간 > 1f / reloadSpeed)
    public int penetrate; //관통력 (사용안함)

    public Sprite towerIcon;
    public string towerName;
    [TextArea(3,5)]
    public string towerDescription;
    public TowerType towerType;
}