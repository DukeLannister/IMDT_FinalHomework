using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject StoreMenu;
    Equip equip;
    void Start()
    {
        equip = GetComponentInParent<Equip>();
    }
    
    public void BackToMainMenu()
    {
        equip.DisableAll();
        StoreMenu.SetActive(false);
        MainMenu.SetActive(true);
        UserInfoManager.instance.SaveInfo();
    }
}
