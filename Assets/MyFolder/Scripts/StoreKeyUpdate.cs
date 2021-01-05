using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreKeyUpdate : MonoBehaviour
{
    TMP_Text keysText;
    int m_KeyNums;
    // Start is called before the first frame update
    void Awake()
    {
        keysText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        m_KeyNums = UserInfoManager.instance.info.keyNumber;
        UpdateBowling(m_KeyNums); 
    }

    // Update is called once per frame
    public void UpdateBowling(int keysNum)
    {
        m_KeyNums = keysNum;
        if(m_KeyNums < 10) keysText.text = "00" + m_KeyNums;
        else if(m_KeyNums < 100) keysText.text = "0" + m_KeyNums;
        else keysText.text = m_KeyNums.ToString(); 
    }

}
