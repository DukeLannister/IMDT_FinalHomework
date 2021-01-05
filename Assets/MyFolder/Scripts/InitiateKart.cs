using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateKart : MonoBehaviour
{
    public GameObject[] trails;
    public GameObject[] sparkles;
    public GameObject[] hats;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<UserInfoManager.instance.info.ownedTrails.Length; i++)
        {
            if(UserInfoManager.instance.info.ownedTrails[i] == 1) 
            {
                trails[i].SetActive(true);
                
            }
            else trails[i].SetActive(false);
        }
        for(int i = 0; i<UserInfoManager.instance.info.ownedParticles.Length; i++)
        {
            if(UserInfoManager.instance.info.ownedParticles[i] == 1) sparkles[i].SetActive(true);
            else sparkles[i].SetActive(false);
        }
        for(int i = 0; i<UserInfoManager.instance.info.ownedHats.Length; i++)
        {
            if(UserInfoManager.instance.info.ownedHats[i] == 1) hats[i].SetActive(true);
            else hats[i].SetActive(false);
        }
    }

    // Update is called once per frame
}
