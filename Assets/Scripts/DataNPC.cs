//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


namespace BLANK
{

    /// <summary>
    /// NPC資料
    /// </summary>
    [CreateAssetMenu(menuName = "BLANK/NPC")]
    public class DataNPC : ScriptableObject 
    {
        [Header("NPC AI 要分析的句子")]
        public string[] sentences;
    }

}