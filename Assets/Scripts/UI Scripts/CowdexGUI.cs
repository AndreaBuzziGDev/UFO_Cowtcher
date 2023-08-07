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
    public void Initialize()
    {
        pageIndex = 0;
        List<Cow> allCows = Cowdex.Instance.GetAllCows();
        foreach(Cow c in allCows)
        {
            CowdexPage cp = new CowdexPage(c);
            CowdexPages.Add(cp);
            CowdexPagesDictionary.Add(c.CowTemplate.UID, cp);
        }

        Debug.Log("CowdexGUI - CowdexPages size: " + CowdexPages.Count);
        Debug.Log("CowdexGUI - CowdexPagesDictionary size: " + CowdexPagesDictionary.Count);

    }


    //TODO: A "CowdexPage" CLASS COULD HANDLE THESE?
    ///PAGE-RELATED FUNCTIONALITIES
    public void NextPage()
    {
        //CHECK IF PAGE INDEX IS NOT MAXED OUT...
        pageIndex++;
        Debug.Log("CowdexGUI - pageIndex: " + pageIndex);

    }

    public void PreviousPage()
    {
        if (pageIndex > 0) pageIndex--;
        Debug.Log("CowdexGUI - pageIndex: " + pageIndex);
    }

    public void GoToPage(int targetIndexPage)
    {
        if (targetIndexPage < 0) pageIndex = 0;
        else pageIndex = targetIndexPage;


        //TODO: SET TARGET WITHIN MAXIMUM
        Debug.Log("CowdexGUI - pageIndex: " + pageIndex);
    }

    public CowdexPage GetCurrentPage() => CowdexPages[pageIndex];




}
