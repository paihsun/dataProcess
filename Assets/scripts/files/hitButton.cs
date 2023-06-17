using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class hitButton : MonoBehaviour
{
    public int hitCount;
    public TextMeshProUGUI tt;
    public TextMeshProUGUI info;
    //FileCreate fc;
    private string sFilePath;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // sFilePath = Path.Combine(Application.persistentDataPath, "SaveSkins.json");
            sFilePath= Path.Combine(Application.persistentDataPath, "androidtt.txt");
            info.text = sFilePath;
            if (!File.Exists(sFilePath))
            {
                File.WriteAllText(sFilePath, "Android open\n");
            }
        }
        else {

            sFilePath = Application.streamingAssetsPath + "/chatLog/" + "chat" + ".txt";
            Directory.CreateDirectory(Application.streamingAssetsPath + "/chatLog/");
            info.text = Application.streamingAssetsPath;
        }
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tt.text = "hit: "+hitCount.ToString();
    }
    public void hitBu()
    {
        hitCount++;
        CreateTextFile();
    }

    public void CreateTextFile()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            File.AppendAllText(sFilePath, tt.text + "\n");

        }
        else
        {
            if (tt.text == "") { return; }

            
            if (!File.Exists(sFilePath))
            {
                File.WriteAllText(sFilePath, "test open\n");
                //File.WriteAllBytes(txtDocumentName, "chat");
            }

            File.AppendAllText(sFilePath, tt.text + "\n");
            //tt.text = "";
        }

    }

    public void loadTxt()
    {
        info.text = File.ReadAllText(sFilePath);
    }
    public void clearTxt()
    {
        File.WriteAllText(sFilePath, "");
        info.text = File.ReadAllText(sFilePath);
        info.text += "clear OK";

    }

    /// <summary>
    /// ===================https://forum.unity.com/threads/cant-use-json-file-from-streamingassets-on-android-and-ios.472164/
    /// </summary>
    /// <returns></returns>



}
