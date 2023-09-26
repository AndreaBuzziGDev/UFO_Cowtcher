using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureExplosion : MonoBehaviour
{
    //DATA

    //GAMEOBJECT REFERENCES
    ///BIG EXPLOSION
    [SerializeField] private Transform bigExplosionTransform;

    ///SMALL EXPLOSIONS
    [SerializeField] private List<Transform> smallExplosionTransforms = new();


    //PARTICLE PREFABS
    [SerializeField] private GameObject bigExplosionPS;
    [SerializeField] private GameObject smallExplosionPs;


    ///AUDIO SOURCE
    [SerializeField] private GameObject turretExplosionSoundCarryingPrefab;



    //METHODS
    //...

    // Start is called before the first frame update
    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) 
            return;
        else
        {
            //DO BIG EXPLOSION
            DoBigExplosion();

            //DO SMALL EXPLOSIONS
            DoSmallExplosion();

            //PLAY SOUND
            GameObject soundExplosion = Instantiate(turretExplosionSoundCarryingPrefab, this.transform.position, Quaternion.identity);
            Destroy(soundExplosion, 4);
        }
    }

    
    //FUNCTIONALITIES
    public void DoBigExplosion()
    {
        GameObject instance = Instantiate(bigExplosionPS.gameObject, bigExplosionTransform.position, Quaternion.identity);
        Destroy(instance.gameObject, 5);
    }

    public void DoSmallExplosion()
    {
        int randomInt = Random.Range(1, 3);

        for(int i = 0; i<smallExplosionTransforms.Count; i++)
        {
            if (i % 2 == 0 && randomInt % 2 == 0)
            {
                //EVEN INDEX AND EVEN RANDOM
                Vector3 position = smallExplosionTransforms[i].position;
                GameObject instance = Instantiate(smallExplosionPs.gameObject, position, Quaternion.identity);
                Destroy(instance, 5);
            }
            else if(i % 2 != 0 && randomInt % 2 != 0)
            {
                //UNEVEN INDEX AND UNEVEN RANDOM
                Vector3 position = smallExplosionTransforms[i].position;
                GameObject instance = Instantiate(smallExplosionPs.gameObject, position, Quaternion.identity);
                Destroy(instance, 5);
            }
        }
    }

}
