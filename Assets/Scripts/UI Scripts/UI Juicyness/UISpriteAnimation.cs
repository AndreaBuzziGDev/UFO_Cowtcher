using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteAnimation : MonoBehaviour
{
    //DATA
    [SerializeField] private Image m_Image;
    [SerializeField] private Sprite[] m_SpriteArray;

    [SerializeField] private float m_Speed = .02f;
    [SerializeField] private bool isLooping;

    private int m_IndexSprite;
    private Coroutine m_CorotineAnim;

    private bool isDone;


    //METHODS

    public void Func_PlayUIAnim()
    {
        isDone = false;
        StartCoroutine(Func_PlayAnimUI());
    }

    public void Func_StopUIAnim()
    {
        isDone = true;
        StopCoroutine(Func_PlayAnimUI());
    }


    //COROUTINE

    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length)
        {
            if (isLooping)
                m_IndexSprite = 0;
            else
                isDone = true;
        }

        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        m_IndexSprite += 1;

        if (isDone == false)
            m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
    }
}