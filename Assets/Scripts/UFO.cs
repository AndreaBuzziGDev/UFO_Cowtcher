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

    ///FUEL BOTTOM DELAY MANAGEMENT
    [SerializeField] private float fuelBottomThreshold = 10.0f;
    [SerializeField] private float fuelExtensionFactor = 2.0f;


    ///SCORE
    private float scoreAmount;
    public float ScoreAmount { get { return scoreAmount; } }







    //METHODS

    private void Awake()
    {
        fuelAmount = maxFuelAmount;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleFuelLogic();
        
    }

    //FUNCTIONALITIES
    public void HandleFuelLogic() {

        Mathf.Clamp(fuelAmount, 0, maxFuelAmount);

        //FUEL CHANGES
        float extensionMultiplier = 1;
        if (fuelAmount/maxFuelAmount <= fuelBottomThreshold/maxFuelAmount)
        {
            extensionMultiplier = fuelExtensionFactor;
        }
        fuelAmount -= Time.deltaTime * (1/extensionMultiplier);

        //GUI UPDATE
        UIController.Instance.IGPanel.PlayerFuelBar.UpdateFuelBar(this);

        //IS THE GAME OVER?
        if (fuelAmount <= 0)
        {
            GameController.Instance.SetState(GameController.EGameState.GameOver);
        }

    }


    //CURRENT FUEL SETTER
    public void ChangeFuel(float delta) => fuelAmount += delta;


    //CURRENT SCORE SETTER
    ///LEGACY
    //NB: IT'S USING FLOAT INSTEAD OF INT
    //public void ChangeScore(float delta) => scoreAmount += delta;

    public void ChangeScore(int delta)
    {
        UIController.Instance.IGPanel.HighScoreBar.AddScore(delta);
    }

}
