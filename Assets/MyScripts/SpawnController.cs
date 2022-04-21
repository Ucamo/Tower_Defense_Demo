using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use Object Pooling to reuse objects, can be used for spawners or Bullets, it will spawn objects based on the spawnFrecuency. If it's a Bullet, it will check if it already has a target.
public class SpawnController : MonoBehaviour
{
    [SerializeField]
    float spawnFrequency;
    Vector3 position;

    [SerializeField]
    GameObject objectToSpawn;
    [SerializeField]
    int poolSize;

    [SerializeField]
    GameObject target;

    List<GameObject> objectPool;

    [SerializeField]
    bool canContinue = true;
    [SerializeField]
    bool isBullet=false;
    
    void Start()
    {
        //Initialize your properties
        objectPool = new List<GameObject>();
        position = new Vector3 (gameObject.transform.localPosition .x, gameObject.transform.localPosition .y, gameObject.transform.localPosition.z);

        //Create a pool and fill it with inactive GameObjects.
        for (int i = 0; i < poolSize; i++) {
            GameObject newGameObject = Instantiate (objectToSpawn);
            newGameObject.SetActive(false);
            objectPool.Add(newGameObject);
        }
        
        //start spawning objects.
        InvokeRepeating ("SpawnObject", 0, spawnFrequency);
    }

    void SpawnObject(){       
            GameObject spawnObject = GetObjectFromPool();
            if(spawnObject!=null){
                spawnObject.transform.position=position;
                if(canContinue){
                    spawnObject.SetActive(true);
                    if(target!=null){
                        spawnObject.GetComponent<BulletController>().SetTarget(target);
                    }
                    if(isBullet && target!=null){
                        if(!target.activeSelf){
                        canContinue=false;
                        spawnObject.SetActive(false);
                        }
                    }
                }                
            }             
    }

    public void StopSpawns(){
        CancelInvoke();
    }

    public GameObject GetObjectFromPool(){
         //Get object from the pool
        foreach(GameObject objInPool in objectPool){
            //check if the object is inactive
            if(!objInPool.activeInHierarchy && objInPool.name.Contains(objectToSpawn.name)){
                return objInPool;
            }
        }
        //No inactive objects found, instantiate a new one and add it to the pool.
        GameObject newGameObject = Instantiate (objectToSpawn);
        newGameObject.SetActive(false);
        objectPool.Add(newGameObject);
        return GetObjectFromPool();
    }

    public void SetTarget(GameObject _target){
        target=_target;
    }

    public GameObject GetTarget(){
        return target;
    }

    public void SetCanContinue(bool _canContinue){
        canContinue=_canContinue;
    }

}