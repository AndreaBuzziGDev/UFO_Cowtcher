using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    //DATA
    ///CURRENT FUEL
    [Min(0f)] private float fuelAmount;
    public float FuelAmount { get { return fuelAmount; } }

    ///MAX FUEL
    [SerializeField] private float maxFuelAmount;
    public float MaxFuelAmount { get { return maxFuelAmount; } }

    ///SCORE
    private float scoreAmount;
    public float ScoreAmount { get { return scoreAmount; } }


    //GUI LINKS
    FuelBar fBar;



    //METHODS

    private void Awake()
    {
        fuelAmount = maxFuelAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        fBar = FindAnyObjectByType<FuelBar>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleFuelLogic();
        
    }

    //FUNCTIONALITIES
    public void HandleFuelLogic() {
        fuelAmount -= Time.deltaTime;

        if (fuelAmount <= 0)
        {
            Debug.Log("Player has no fuel, GAME OVER");
        }

        if (fBar != null) fBar.UpdateFuelBar(this);

    }


    //CURRENT FUEL SETTER
    public void ChangeFuel(float delta) => fuelAmount += delta;


    //CURRENT SCORE SETTER
    public void ChangeScore(float delta) => scoreAmount += delta;



}
