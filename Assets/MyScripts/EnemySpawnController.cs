using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will activate/deactivate the Spawners of each type of Enemies according to the score of the player, higher the score, higher the difficulty of the enemies.
public class EnemySpawnController : MonoBehaviour
{
    [SerializeField]
    GameObject spawner_Weak;
    [SerializeField]
    GameObject spawner_Normal;
    [SerializeField]
    GameObject spawner_Hard;
    
    void Update()
    {
        int currentScore = GameValues.score;

        if(currentScore>=0 && currentScore<=500){
            spawner_Weak.SetActive(true);
        }else{
            spawner_Weak.GetComponent<SpawnController>().StopSpawns();
            spawner_Weak.SetActive(false);
        }

        if(currentScore>500 && currentScore<=1000){
            spawner_Normal.SetActive(true);
        }else{
            spawner_Normal.GetComponent<SpawnController>().StopSpawns();
            spawner_Normal.SetActive(false);
        }

        if(currentScore>1000){
            spawner_Hard.SetActive(true);
        }else{
            spawner_Hard.GetComponent<SpawnController>().StopSpawns();
            spawner_Hard.SetActive(false);
        }
    }
}
