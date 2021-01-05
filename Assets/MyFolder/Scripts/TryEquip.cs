using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryEquip : MonoBehaviour
{
    public int index;
    Equip equip;
    void Start()
    {
        equip = GetComponentInParent<Equip>();
    }
    // Start is called before the first frame update
    public void TryParticleSystem()
    {
        equip.EnableParticleSystem(index);
    }

    public void TryHat()
    {
        equip.EnableHats(index);
    }
}
