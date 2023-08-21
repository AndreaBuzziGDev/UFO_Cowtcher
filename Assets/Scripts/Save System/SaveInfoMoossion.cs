using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfoMoossion
{
    //DATA
    private int index = 0;
    private int progress = 0;
    private int target = 0;

    ///DATA GETTERS
    public int Index { get { return index; } }
    public int Progress { get { return progress; } }
    public int Target { get { return target; } }



    //CONSTRUCTOR
    private SaveInfoMoossion()
    {
        //PRIVATE EMPTY CONSTRUCTOR TO AVOID INSTANCIATION

    }

    public SaveInfoMoossion(int index, int progress, int target)
    {
        this.index = index;
        this.progress = progress;
        this.target = target;
    }



}
