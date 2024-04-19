using UnityEngine;

public class BreathTower : Tower
{
    float fireAngle;
    int shell;

    protected override void Start()
    {
        shell = 7;
        fireAngle = 90f;
        range = 1f;
        speed = 3f;
        damage = 20f;
        penetrate = 20;
        reloadDelay = 0.5f;
        base.Start();
    }

    protected override void Fire()
    {
        float angleOffset = fireAngle / (shell - 1);
        float startAngle = -fireAngle / 2f;
        float rotZ = startAngle;

        for (int i = 0; i < shell; i++)
        {
            GameObject bObject = Instantiate(bulletObject);
            Fire bullet = bObject.GetComponent<Fire>();
            bullet.init(speed, damage, penetrate);
            Vector3 rot = transform.rotation.eulerAngles;
            rot.z = rot.z + rotZ;
            bullet.setTransform(transform.position, rot);
            rotZ += angleOffset;
            bObject.SetActive(true);
        }
    }
}
