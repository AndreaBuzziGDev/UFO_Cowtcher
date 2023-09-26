using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    //DATA
    [SerializeField] private MainMenuController.eMainMenuCanvas myTargetCanvas;
    [SerializeField] private GameObject dark;

    //METHODS
    public void GoToCanvas()
    {
        MainMenuController.Instance.SetTargetCanvas(myTargetCanvas);
       
        
        //questo if viene usato in caso di rientro nel main menu
        //siccome la dashboard diventa sempre più scura per mostrare meglio i bottoni interagibili, in caso si vada in una qualche opzione e si torna indietro, la dasboard rimarrebbe scura
        //in questa maniera, resettiamo la "scurezza" al valore di defaul per ricominciare da capo il ciclo
        if(myTargetCanvas.ToString() == "Main")
        {
            Color c = new Color(0, 0, 0, 0.4f);
            dark.GetComponent<Obscure>().c = c;  
        }
    }


}
