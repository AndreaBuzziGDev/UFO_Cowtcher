using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowParticles : MonoBehaviour
{
    //DATA
    [SerializeField] private ParticleSystem Slow;
    [SerializeField] private ParticleSystem Terror;


    // Start is called before the first frame update
    void Start()
    {
        Slow.gameObject.SetActive(false);
        Terror.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Slow.gameObject.SetActive(CowManager.Instance.IsGloballySlowed);
        Terror.gameObject.SetActive(CowManager.Instance.IsGlobalTerrify);
    }
}
