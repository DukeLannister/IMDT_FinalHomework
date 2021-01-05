using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    public GameObject[] particleSystems;
    public GameObject[] hats;


    public void EnableParticleSystem(int index)
    {
        for(int i=0; i<particleSystems.Length; i++)
        {
            if(i == index)
            particleSystems[i].SetActive(true);
            else particleSystems[i].SetActive(false);
        }
    }

    public void EnableHats(int index)
    {
        for(int i=0; i<particleSystems.Length; i++)
        {
            if(i == index)
            hats[i].SetActive(true);
            else hats[i].SetActive(false);
        }
    }

    public void DisableAll()
    {
        foreach(GameObject particleSystem in particleSystems)
        {
            particleSystem.SetActive(false);
        }
        foreach(GameObject hat in hats)
        {
            hat.SetActive(false);
        }
    }
}
