using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use this class to show up the Tower upgrade pop up, also will keep track of the position that the tower will be set to.
public class UpgradeTower : MonoBehaviour
{
    void OnMouseDown()
    {
        GameValues.showPopUpUpgrade=true; 
        GameValues.ObjectToReplace=this.gameObject; 
    }

}
