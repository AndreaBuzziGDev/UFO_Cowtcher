using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioIfUFONearby : MonoBehaviour
{
    //DATA
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private float maxHearingDistance = 20f;


    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        if ((this.transform.position - GameController.Instance.FindUFOAnywhere().GetPositionXZ()).magnitude < maxHearingDistance)
        {
            myAudioSource.Play();
        }
    }

}
