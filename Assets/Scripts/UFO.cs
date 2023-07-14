using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    //DATA
    [Min(0f)]public float FuelAmount;
    public float ScoreAmount;
    [SerializeField] private float maxFuelAmount;
    public float MaxFuelAmount {get { return maxFuelAmount; }}

    //METHODS

    private void Awake()
    {
        FuelAmount = maxFuelAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FuelAmount -= Time.deltaTime;

        if (FuelAmount <= 0)
        {
            Debug.Log("Player has no fuel, GAME OVER");
        }
    }
}
