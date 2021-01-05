using UnityEngine;
using System;

namespace Tools
{
    [Serializable]
    public class Record
    {
        public String saveTime{get; private set;}
        public float recordTime{get; private set;}
        public bool m_IsNewest{get; private set;}
        public Record(DateTime saveTime, float recordTime)
        {
            this.saveTime = saveTime.ToString();
            this.recordTime = recordTime;
            m_IsNewest = true;
        }

        public void SetNewest(bool value)
        {
            m_IsNewest = value;
        }
    }
}
