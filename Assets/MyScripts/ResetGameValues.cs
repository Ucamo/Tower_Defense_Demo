using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Make sure that all the values are reseted while reseting the scene or moving to another level.
public class ResetGameValues : MonoBehaviour
{
    public void ResetValues(){
        GameValues.health=GameValues.maxHealth;
        GameValues.score=0;
        GameValues.currency=500;
        GameValues.showPopUpUpgrade=false;
        GameValues.ObjectToReplace=null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
