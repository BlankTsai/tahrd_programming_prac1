using UnityEngine;

namespace BLANK
{
    /// <summary>
    /// NPC 控制器
    /// </summary>
    public class NPCController : MonoBehaviour 
    {
        //序列化欄位，將私人變數顯示於面板
        [SerializeField, Header("NPC 資料")]        
        private DataNPC dataNPC;

        //Unity 的動畫控制系統
        private Animator ani;

        //喚醒事件:播放遊戲時會執行一次
        private void Awake()
        {
            //獲取角色身上的動畫控制器
            ani = GetComponent<Animator>();
        }
    }
}