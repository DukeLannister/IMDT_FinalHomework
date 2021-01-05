using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public GameObject Storemenu;
    public void ShowStoreMenu()
    {
        Mainmenu.SetActive(false);
        Storemenu.SetActive(true);
        }
}
