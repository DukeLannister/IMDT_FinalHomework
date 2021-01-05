using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTransmitter : MonoBehaviour
{
    public GameObject[] buttonsArray;
    
    public void ResetOtherEquipStatus(int highlight)
    {
        for(int b = 0; b<buttonsArray.Length; b++)
        {
            if( b == highlight ) continue;
            StoreButtonControl sbc = buttonsArray[b].GetComponent<StoreButtonControl>();
            if(sbc.GetButtonStatus() != 0) sbc.SetEquipButtonOutlook();
        }
    }
}
