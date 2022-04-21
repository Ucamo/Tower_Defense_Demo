using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if an Enemy it's hit by a Bullet tag, decrease it's health, and add Currency to player once defeated.
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int HP;
    [SerializeField]
    private int MaxHP;
    [SerializeField]
    private int currencyToEarn;

    void Update()
    {
        if(HP<=0){
            this.gameObject.SetActive(false);
            this.gameObject.GetComponent<FollowPath>().ResetTarget();
            HP=MaxHP;
            GameValues.currency+=currencyToEarn;
            GameValues.score+=currencyToEarn;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //Start shooting
            other.gameObject.GetComponent<BulletController>().SetTarget(null);
            int damage = other.gameObject.GetComponent<BulletController>().GetDamage();
            DecreaseHealth(damage,other.gameObject);
        }
    }

    private void DecreaseHealth(int value, GameObject other){
        if(HP>=1){
            HP--;
        }else{
            other.SetActive(false);
        }
    }
}
