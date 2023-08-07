using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowdexGUI : MonoBehaviour
{
    //ENUMS


    //DATA
    private int pageIndex;
    public int PageIndex { get { return pageIndex; } }





    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        pageIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES

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




}
