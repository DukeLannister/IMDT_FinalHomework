using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreButtonControl : MonoBehaviour
{
    Button buttonControl;
    TMP_Text buttonText;
    ColorBlock m_BuyColorBlock;
    ColorBlock m_EquipColorBlock;
    ColorBlock m_UnequipColorBlock;
    int m_ButtonStatus;  //0为按钮状态为buy，1为Equip，2为Unequip
    public int price = 1;
    public GameObject tipsCanvas;
    public string itemString;
    public int buttonIndex;
    ControlTransmitter m_ControlTransmitter;
    // Start is called before the first frame update
    void Start()
    {
        buttonControl = GetComponent<Button>();
        buttonText = GetComponentInChildren<TMP_Text>();
        m_BuyColorBlock = m_EquipColorBlock = m_UnequipColorBlock = buttonControl.colors;
        m_EquipColorBlock.normalColor = new Color(6, 179, 255, 255);
        m_EquipColorBlock.highlightedColor = m_EquipColorBlock.selectedColor = new Color(0, 72, 159, 255);
        m_UnequipColorBlock.normalColor = new Color(193, 229, 245, 255);
        m_UnequipColorBlock.highlightedColor = m_UnequipColorBlock.selectedColor = new Color(148, 187, 205, 255);
        m_ButtonStatus = 0;
        m_ControlTransmitter = GetComponentInParent<ControlTransmitter>();
        switch(UserInfoManager.instance.GetStatus(itemString))
        {
            case 0:
                Debug.Log("Buy Button, don't change.");
                break;
            case 1:
                SetUnequipButtonOutlook();
                break;
            case 2:
                SetEquipButtonOutlook();
                break;
            default:
                Debug.LogWarning("Unexpected button status returned.");
                break;
        }
    }

    // Update is called once per frame
    public void Clicked()
    {
        switch(m_ButtonStatus)
        {
            case 0:
                if(UserInfoManager.instance.info.keyNumber < price)
                tipsCanvas.SetActive(true);
                else
                {
                    UserInfoManager.instance.Buy(itemString, price);
                    SetEquipButtonOutlook();
                }
                break;
            case 1:
                SetUnequipButtonOutlook();
                m_ControlTransmitter.ResetOtherEquipStatus(buttonIndex);
                break;
            case 2:
                SetEquipButtonOutlook();
                break;
            default:
                Debug.LogWarning("Swtich runs in defalut branch!");
                break;
        }
    }

    void SetBuyButtonOutlook()
    {
        buttonText.text = "Buy";
        buttonControl.colors = m_BuyColorBlock;
        m_ButtonStatus = 0;
    }

    public void SetEquipButtonOutlook()
    {
        UserInfoManager.instance.Unequip(itemString);
        buttonText.text = "Equip";
        buttonControl.colors = m_EquipColorBlock;
        m_ButtonStatus = 1;
    }

    public void SetUnequipButtonOutlook()
    {
        UserInfoManager.instance.Equip(itemString);
        buttonText.text = "Unequip";
        buttonControl.colors = m_UnequipColorBlock;
        m_ButtonStatus = 2;
    }

    public int GetButtonStatus()
    {
        return m_ButtonStatus;
    }
}
