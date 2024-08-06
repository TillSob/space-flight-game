using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackSpeed;
    private int attackDamage;

    private GameObject bulletPrefab;
    private GameObject bullet;

    Vector3 offset = new Vector3(0, 0, .5f);
    Vector3 forceOffset = new Vector3(0,1,1);

    Rigidbody rb;

    enum Bullets
    {
        YELLOW,
        ORANGE,
        RED,
        BLUE,
        PURPLE
    }

    private void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Bullets/yellow");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        bullet = Instantiate(bulletPrefab, transform.position + offset, bulletPrefab.transform.rotation);
        rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.position.normalized * 5, ForceMode.Impulse);
    }

}
