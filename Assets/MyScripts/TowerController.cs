using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The class will start shooting at collision with a Enemy and will stop shooting when the enemy is out of range.
public class TowerController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.activeSelf)
        {
            //Start shooting
            this.gameObject.GetComponent<SpawnController>().SetTarget(other.gameObject);
            this.gameObject.GetComponent<SpawnController>().SetCanContinue(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.gameObject.GetComponent<SpawnController>().SetCanContinue(false);
        }
    }
}
