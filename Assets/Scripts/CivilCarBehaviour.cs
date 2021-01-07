using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilCarBehaviour : MonoBehaviour
{
    public float crashDamage = 20f;
    public float civilCarSpeed = 5f;
    public int direction = -1;
    [HideInInspector] public int pointsPerCar;
    
    private Vector3 civilCarPosition;

    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, direction, 0) * civilCarSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<PlayerCarMovement>().durability -= crashDamage / 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            PointsManager.points -= pointsPerCar;
            obj.gameObject.GetComponent<PlayerCarMovement>().durability -= crashDamage;
            Debug.Log("Gracz w nas wjechał");
            Destroy(this.gameObject);
        } 
        else if (obj.gameObject.tag == "EndOfTheRoad")
        {
            PointsManager.points += pointsPerCar;
            Destroy(this.gameObject);
        }
    }
}
