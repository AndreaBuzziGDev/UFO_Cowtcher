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

    ///FUEL GAIN MULTIPLIER
    private float fuelGainMultiplier = 1.0f;



    ///FUEL BOTTOM DELAY MANAGEMENT
    [SerializeField] [Range(0.0f, 100.0f)] private float fuelEmergencyThreshold = 20.0f;
    [SerializeField] private float fuelEmergencyExtensionFactor = 2.0f;


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
        if (((fuelAmount/maxFuelAmount) * 100) <= fuelEmergencyThreshold)
        {
            extensionMultiplier = fuelEmergencyExtensionFactor;
        }
        fuelAmount -= Time.deltaTime * (1/extensionMultiplier);

        //GUI UPDATE
        UIController.Instance.IGPanel.PlayerFuelBar.UpdateFuelBar(this);

        //IS THE GAME OVER?
        if (fuelAmount <= 0)
        {
            if(!GameController.Instance.IsGameOver) GameController.Instance.SetState(GameController.EGameState.GameOver);
        }

    }


    //CURRENT FUEL SETTER
    public void ChangeFuelCapture(CowSO cowTemplate)
    {
        //CHANGE FUEL SUMMONING THE HELPER
        ChangeFuel(UFOFuelHelper.HandleFuelRecoveryAmount(cowTemplate));

        //INCREASE CAPTURED COW COUNT ON DIFFICULTY MANAGER
        DifficultyManager.Instance.CountCapturedCow(cowTemplate.UID);

    }

    public void ChangeFuel(float delta) 
    {
        fuelAmount += delta * fuelGainMultiplier;
        if (fuelAmount > MaxFuelAmount) fuelAmount = maxFuelAmount;

        //TODO: USE EVENT INSTEAD?
        UIController.Instance.IGPanel.PlayerFuelBar.SetShaking();
    }


    //CURRENT SCORE SETTER
    ///LEGACY
    //NB: IT'S USING FLOAT INSTEAD OF INT
    //public void ChangeScore(float delta) => scoreAmount += delta;

    public void ChangeScore(int delta)
    {
        UIController.Instance.IGPanel.HighScoreBar.AddScore(delta);
    }

    public void ChangeFuelBoostMultiplier(float newMultiplier)
    {
        fuelGainMultiplier = newMultiplier;
    }



    //UTILITIES
    public Vector3 GetPositionXZ()
    {
        return new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }




}
