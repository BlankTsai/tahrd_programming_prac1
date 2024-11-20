using System.Collections;
using UnityEngine.Networking;
using System.Text;
using UnityEngine;
using TMPro;

namespace BLANK
{
    /// <summary>
    /// modelmanager
    /// </summary>

    public class modelmanager : MonoBehaviour
    {
        private string url = "https://g.ubitus.ai/v1/chat/completions";
        private string key = "AIzaSyARpxd_UXdIXA9i8uFjqVHl66yr5AYve-Y";

        private TMP_InputField inputField;
        private string prompt;
        private string role = "你是一個俏皮的幽靈";
        //喚醒事件 遊戲撥放後會執行一次
        private void Awake()
        {
            //尋找場景上名稱維輸入欄位得物件放進inputField變數內
            inputField = GameObject.Find("輸入欄位").GetComponent<TMP_InputField>();
            //當玩家結束編輯輸入欄位時會執行PlayerInput方法
            inputField.onEndEdit.AddListener(PlayerInput);
        }

        private void PlayerInput(string input)
        {
            print($"<color=#3f3>{input}</color>");
            prompt = input;

            StartCoroutine(GetResult());
        }

        private IEnumerator GetResult()
        {
            var data = new
            {
                model = "llama-3.1-70b",
                messages = new
                {
                    name = "user",
                    content = prompt,
                    role = this.role
                },
                stop = new string[] {"<|eot_id|>", "<|end_of_text|>"},
            frequency_penalty = 0,
            max_tokens = 2000,
            temperature = 0.2,
            top_p = 0.5,
            top_k = 20,
            stream = false
        };
            //將資料傳為json以及上傳的byte[] 格式
            string json = JsonUtility.ToJson(data);
            byte[] postData = Encoding.UTF8.GetBytes(json);
            //透過POST將資料傳遞到模型伺服器並設定標題
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + key);

            yield return request.SendWebRequest();

            print(request.result);
        }
    }
}