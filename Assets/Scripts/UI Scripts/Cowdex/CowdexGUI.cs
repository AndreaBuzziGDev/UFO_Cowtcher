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
    private Dictionary<CowSO.UniqueID, CowdexPage> CowdexPagesDictionary = new();

    public int NumberOfPages { get { return CowdexPages.Count; } }



    ///GUI REFERENCES
    [SerializeField] private CowdexPageGUI myCowdexPageGUI;




    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
    ///INITIALIZATION
    public void Initialization()
    {
        pageIndex = 0;
        List<IndexedCow> allCows = Cowdex.Instance.GetAllIndexedCows();
        foreach(IndexedCow c in allCows)
        {
            CowdexPage cp = new CowdexPage(c);
            CowdexPages.Add(cp);
            CowdexPagesDictionary.Add(c.ReferenceTemplate.UID, cp);
        }

        Debug.Log("CowdexGUI - CowdexPages size: " + CowdexPages.Count);
        Debug.Log("CowdexGUI - CowdexPagesDictionary size: " + CowdexPagesDictionary.Count);

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
