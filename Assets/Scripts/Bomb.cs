using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int bombDamage;
    public float bombSpeed;
    [HideInInspector] public int pointsPerBomb;

    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * bombSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            PointsManager.points -= pointsPerBomb;
            obj.gameObject.GetComponent<PlayerCarMovement>().durability -= bombDamage;
            Destroy(this.gameObject);
        } 
        else if (obj.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
        }
        else if (obj.gameObject.tag == "EndOfTheRoad")
        {
            PointsManager.points += pointsPerBomb;
            Destroy(this.gameObject);
        }
    }
}
