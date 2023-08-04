using UnityEngine;

public class StructureRefilling : StructureAbstract
{
    //DATA
    private float remainingQuantity;
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
            Debug.Log("StructureRefilling - transactionSpeed: " + transactionSpeed);

            float transactionQuantity;
            if (transactionSpeed < remainingQuantity)
            {
                transactionQuantity = transactionSpeed;
            }
            else
            {
                transactionQuantity = remainingQuantity;
            }
            Debug.Log("StructureRefilling - remainingQuantity: " + remainingQuantity);
            Debug.Log("StructureRefilling - transactionQuantity: " + transactionQuantity);

            GameController.Instance.FindUFOAnywhere().ChangeFuel(transactionQuantity);

            //DRAW FUEL FROM POOL
            remainingQuantity -= transactionQuantity;
            if (remainingQuantity <= 0)
            {
                wrappingStructure.HasBeenDepleted = true;
            }

        }

    }

}
