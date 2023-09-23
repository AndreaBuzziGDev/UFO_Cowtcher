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
            if (this.gameObject.name.Equals("AudioButton"))
            {
                PlayerPrefs.SetInt("Volume", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Volume", 1);
            }
            targetButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
        Debug.Log(PlayerPrefs.GetInt("Volume"));

    }

}
