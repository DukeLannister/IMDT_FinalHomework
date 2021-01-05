using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankListBowling : MonoBehaviour
{
    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }


    void OnEnable()
    {
        int n = UISystem.instance.GetKeyNumber();
        text.text = "Bowlings:"+n.ToString();
    }

}
