using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaCows : MonoBehaviour
{
    //TODO: THIS IS NOT A CowSpecialScript. SHOULD USE SOMETHING ELSE INSTEAD

    //DATA
    [SerializeField] List<ItemPickup> Gifts;

    ///TECHNICAL DATA
    // Update is called once per frame
    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded)
            return;
        else
        {
            int randomInt = Random.Range(0, Gifts.Count);
            int randomChance = Random.Range(0, 100);
            if (randomChance < 33)
            {
                Vector3 ufoPos = GameController.Instance.FindUFOAnywhere().GetPositionXZ();
                Instantiate(
                    Gifts[randomInt].gameObject,
                    ufoPos + UtilsRadius.RandomPositionOnCircleRadius(4),
                    Quaternion.identity
                    );
            }
        }
    }
}
