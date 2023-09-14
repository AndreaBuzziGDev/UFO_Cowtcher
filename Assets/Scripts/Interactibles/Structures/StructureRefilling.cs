using UnityEngine;

public class StructureRefilling : StructureAbstract
{
    //DATA
    private float remainingQuantity;
    private int RemainingQuantityAsInt { get { return (int) remainingQuantity; } }

    private float refillingSpeed;

    //CONSTRUCTOR
    public StructureRefilling(StructureRefillingSO templateSO) : base(templateSO)
    {
        remainingQuantity = templateSO.RefillingQuantity;
        refillingSpeed = templateSO.RefillingSpeed;
    }

    //METHODS

    ///STRUCTURE FUNCTIONALITIES
    public override void DoBehaviour(InteractibleStructure wrappingStructure)
    {
        //DO SOMETHING...
        if (activationSource == eActivationSource.UFO)
        {
            float transactionSpeed = refillingSpeed * Time.deltaTime;

            float transactionQuantity;
            if (transactionSpeed < remainingQuantity) transactionQuantity = transactionSpeed;
            else transactionQuantity = remainingQuantity;

            GameController.Instance.FindUFOAnywhere().ChangeFuel(transactionQuantity);

            //GENERATE PARTICLES
            if ((int) (remainingQuantity - transactionQuantity) < RemainingQuantityAsInt)
            {
                wrappingStructure.ParticleGen.CreateFuelParticles();
            }

            //DRAW FUEL FROM POOL
            remainingQuantity -= transactionQuantity;

            if (remainingQuantity <= 0) wrappingStructure.HasBeenDepleted = true;

            //TODO: FIRE AN EVENT WHENEVER A NEW UNIT OF FUEL HAS BEEN FULLY DEPLETED
            //      COROUTINE ON THE STRUCTURE WILL HANDLE THE REST

        }

    }

}
