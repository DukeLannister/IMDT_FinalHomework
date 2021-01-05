using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInfoManager : MonoBehaviour
{
    public static UserInfoManager instance;
    public string infoFileName = "userinfo";
    public UserInfo info{get; private set;}
    void Awake()
    {
        if(instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        info = SaveSystem.LoadUserInfo(infoFileName);
    }

    public void SaveInfo()
    {
        Debug.Log("save INFO to DISK");
        SaveSystem.SaveUserInfo(info, infoFileName);
    }

    public void Buy(string name, int price)
    {
        info.SetKeyNumber(info.keyNumber - price);
        Unequip(name);
    }

    public void Equip(string name)
    {
        if(name.StartsWith("Trail"))
        {
            string[] ss = name.Split('-');
            int index = int.Parse(ss[1]);
            info.SetTrailType(index, 1);
        }
        else if(name.StartsWith("Sparkle"))
        {
            string[] ss = name.Split('-');
            int index = int.Parse(ss[1]);
            info.SetParticleType(index, 1);
        }
        else if(name.StartsWith("Hat"))
        {
            string[] ss = name.Split('-');
            int index = int.Parse(ss[1]);
            info.SetHatType(index, 1);
        }
        else
        {
            Debug.LogWarning("Item Name is wrong");
        }
    }

    public void Unequip(string name)
    {
        if(name.StartsWith("Trail"))
        {
            string[] ss = name.Split('-');
            int index = int.Parse(ss[1]);
            info.SetTrailType(index, 2);
        }
        else if(name.StartsWith("Sparkle"))
        {
            string[] ss = name.Split('-');
            int index = int.Parse(ss[1]);
            info.SetParticleType(index, 2);
        }
        else if(name.StartsWith("Hat"))
        {
            string[] ss = name.Split('-');
            int index = int.Parse(ss[1]);
            info.SetHatType(index, 2);
        }
        else
        {
            Debug.LogWarning("Item Name is wrong");
        }
    }

    public int GetStatus(string name)
    {
        string[] ss = name.Split('-');
        int index = int.Parse(ss[1]);
        if(name.StartsWith("Trail"))
        {
            Debug.Log("Trail"+index + " : " + info.ownedTrails[index]);
            return info.ownedTrails[index];
        }
        else if(name.StartsWith("Sparkle"))
        {
            Debug.Log("Sparkle"+index + " : " + info.ownedParticles[index]);
            return info.ownedParticles[index];
        }
        else if(name.StartsWith("Hat"))
        {
            Debug.Log("Hat"+index + " : " + info.ownedHats[index]);
            return info.ownedHats[index];
        }
        else
        {
            Debug.LogWarning("Item Name is wrong");
            return -1;
        }
    }

}
