using UnityEngine;
using System;
[Serializable]
public class UserInfo
{
    public int keyNumber{get; private set;}
    public int[] ownedTrails{get; private set;} //trailType三种：0=FireTrail, 1=LaserTrail, 2=RainbowTrail; //每一位上为0则代表未购买，1代表购买已装备，2代表购买未装备
    public int[] ownedParticles{get; private set;} //particleType三种：0=BlueParticle, 1=GreenParticle, 2=PurpleParticle
    public int[] ownedHats{get; private set;} //hatType三种：0=partyhat, 1=WizardHat, 2=TopHat


    public UserInfo()
    {
        keyNumber = 0;
        ownedTrails = new int[] {0, 0, 0};
        ownedParticles = new int[] {0, 0, 0};
        ownedHats = new int[] {0, 0, 0};   
    }

    public void SetKeyNumber(int keyNumber)
    {
        this.keyNumber = keyNumber;
    }

    public void SetTrailType(int index, int value)
    {
        ownedTrails[index] = value;
    }

    public void SetParticleType(int index, int value)
    {
        ownedParticles[index] = value;
    }

    public void SetHatType(int index, int value)
    {
        ownedHats[index] = value;
    }

}
