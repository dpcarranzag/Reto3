using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerInventory : MonoBehaviour
{
    public int NumberofDiamondsAir { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondAirCollected;

    public void DiamondCollectedAir() {
        NumberofDiamondsAir++;
        OnDiamondAirCollected.Invoke(this);

    }

}
