
using UnityEngine;

public class ProductivityUnit : Unit
{

    private ResourcePile currentPile = null;

    private float productionMultiplier = 2f;

    protected override void BuildingInRange()
    {
        if (currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                currentPile = pile;
                currentPile.ProductionSpeed *= productionMultiplier;
            }
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 pos)
    {
        ResetProductivity();
        base.GoTo(pos);
    }

    private void ResetProductivity()
    {
        if (currentPile != null)
        {
            currentPile.ProductionSpeed /= productionMultiplier;
            currentPile = null;
        }
    }
}
