using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//It will replace the object that was clicked that show up the pop up (like other towers), but not "SpawnPoint" objects because those are part of the map.
public class SpawnTower : MonoBehaviour
{
    [SerializeField]
    GameObject towerToSpawn;
    [SerializeField]
    int cost;

    public void Spawn(){
        if(GameValues.ObjectToReplace!=null){
            if(cost<=GameValues.currency){
                GameObject newTower = Instantiate (towerToSpawn);
                Vector3 position = GameValues.ObjectToReplace.transform.position;
                newTower.transform.position= position;
                GameValues.showPopUpUpgrade=false;
                GameValues.currency-=cost;
                if(!GameValues.ObjectToReplace.name.Contains("SpawnPoint")){
                    Destroy(GameValues.ObjectToReplace);
                }                
            }
        }
    }
}
