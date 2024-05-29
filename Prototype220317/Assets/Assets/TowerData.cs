using UnityEngine;

[CreateAssetMenu(fileName = "Tower Data", menuName = "Scriptable Object/Tower Data", order = 2)]
public class TowerData : ScriptableObject
{
    public float range;
    public float speed;
    public float damage;
    public float reloadSpeed;
    public int penetrate;
}