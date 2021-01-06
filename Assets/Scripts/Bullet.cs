using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    [HideInInspector] public int direction;
    public float bulletSpeed;

    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(direction, 0, 0) * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<PlayerCarMovement>().durability -= bulletDamage;
            Destroy(this.gameObject);
        }
        else if (obj.gameObject.tag == "Shield" || obj.gameObject.tag == "Barrier" || obj.gameObject.tag == "PoliceCar")
        {
            Destroy(this.gameObject);
        }
    }
}
