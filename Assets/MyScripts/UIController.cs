using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Link up all the labels on the UI to show up the values that are usefull to the player.
public class UIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI lblCurrency;
    [SerializeField]
    TextMeshProUGUI lblScore;

    [SerializeField]
    TextMeshProUGUI lblPhase;

    [SerializeField]
    TextMeshProUGUI lblHealth;
    [SerializeField]
    GameObject UpgradePanel;

    [SerializeField]
    GameObject PanelWin;

    [SerializeField]
    GameObject PanelLose;

    string currentPhase;

    
    void Update()
    {
        lblCurrency.text=GameValues.currency.ToString();
        lblScore.text=GameValues.score.ToString()+"/"+GameValues.maxScore.ToString();

        int score = GameValues.score;

        if(score>=0 && score<=500){
            currentPhase="Wave 1";
        }

        if(score>500 && score<1000){
            currentPhase="Wave 2";
        }

        
        if(score>=1000){
            currentPhase="Final Wave";
        }

        lblPhase.text=currentPhase;

        string health=GameValues.health+"/"+GameValues.maxHealth;
        lblHealth.text=health;

        if(GameValues.health<=0){
            PanelLose.SetActive(true);
        }

        if(GameValues.score>=GameValues.maxScore){
            PanelWin.SetActive(true);
        }


        if(GameValues.showPopUpUpgrade){
            UpgradePanel.SetActive(true);
        }else{
            UpgradePanel.SetActive(false);
        }
    }

    public void ClosePopUp(){
        GameValues.showPopUpUpgrade=false;  
    }
}
