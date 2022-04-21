using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When an Enemy object reaches this object, it will decrease the health of the player, once health it's 0, the game will end.
public class EnemyGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Enemy reached out Goal
            if(GameValues.health>0){
                GameValues.health--;
            }            
            other.gameObject.SetActive(false);
        }
    }
}
