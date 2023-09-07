using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowdexGUI : MonoBehaviour
{
    //ENUMS


    //DATA
    ///SIMPLE DATA
    private int pageIndex;
    public int PageIndex { get { return pageIndex; } }


    ///COMPLEX DATA
    private List<CowdexPage> CowdexPages = new();

    public int NumberOfPages { get { return CowdexPages.Count; } }



    ///GUI REFERENCES
    [SerializeField] private CowdexPageGUI myCowdexPageGUI;




    //METHODS
    //...

    void OnEnable()
    {
        //DEFAULT-KNOWN BLACK AND WHITE COWS
        if (SaveSystem.LoadCowProgress(CowSO.UniqueID.C000_BlackCow).KnowledgeValue == 0)
        {
            SaveSystem.SaveCowProgress(CowSO.UniqueID.C000_BlackCow, SaveInfoCow.Knowledge.Known);
        }

        if (SaveSystem.LoadCowProgress(CowSO.UniqueID.C001_WhiteCow).KnowledgeValue == 0)
        {
            SaveSystem.SaveCowProgress(CowSO.UniqueID.C001_WhiteCow, SaveInfoCow.Knowledge.Known);
        }

        if (CowdexPages.Count > 0) GoToPage(0);
    }


    //FUNCTIONALITIES
    ///INITIALIZATION
    public void Initialization()
    {
        pageIndex = 0;
        List<IndexedCow> allCows = Cowdex.Instance.GetAllIndexedActualCows();
        foreach(IndexedCow c in allCows)
        {
            CowdexPage cp = new CowdexPage(c);
            CowdexPages.Add(cp);
        }

        Debug.Log("CowdexGUI - CowdexPages size: " + CowdexPages.Count);

        myCowdexPageGUI.Initialization(this);
        GoToPage(0);
    }



    //TODO: EVALUATE IF CODE SHOULD BE MOVED INSIDE CowdexPageGUI

    ///PAGE-RELATED FUNCTIONALITIES
    public void NextPage()
    {
        GoToPage(pageIndex + 1);
        Debug.Log("CowdexGUI - pageIndex: " + pageIndex);
    }

    public void PreviousPage()
    {
        GoToPage(pageIndex - 1);
        Debug.Log("CowdexGUI - pageIndex: " + pageIndex);
    }

    public void GoToPage(int targetIndexPage)
    {
        //GRANT INDEX IS WITHIN BOUNDARY
        if (targetIndexPage < 0) pageIndex = 0;
        else if (pageIndex >= NumberOfPages) pageIndex = CowdexPages.Count - 1;
        else pageIndex = targetIndexPage;

        //UPDATE THE COWDEXPAGE
        myCowdexPageGUI.SetPage(CowdexPages[pageIndex]);

    }

    public CowdexPage GetCurrentPage() => CowdexPages[pageIndex];

}
