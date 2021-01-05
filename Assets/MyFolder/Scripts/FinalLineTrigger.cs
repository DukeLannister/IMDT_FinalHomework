using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLineTrigger : MonoBehaviour
{
    bool reachEnd;
    ParticleSystem[] celebrateParticle;
    public GameObject RecordDisplayCanvas;
    public bool straightTrack;

    void Start()
    {
        reachEnd = straightTrack;
        celebrateParticle = GetComponentsInChildren<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
       
        if(other.tag == "Player") 
        {
            if(reachEnd)
            {
                RecordDisplayCanvas.SetActive(true);
                RecordDisplayer.instance.AddPlayerData();
                UserInfoManager.instance.SaveInfo();
                foreach(ParticleSystem instance in celebrateParticle)
                {
                    instance.Play();
                }
            }
            
            else reachEnd = true;
        }
    }
}
