using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{

    [SerializeField] private Button targetButton;

    public void ChangeButton()
    {
        if (this.enabled)
        {
            targetButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}
