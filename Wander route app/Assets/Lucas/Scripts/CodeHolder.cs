using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeHolder : MonoSingleton<CodeHolder>
{
    public bool unlockNext;

    [SerializeField] string serializedCode;
    char[] code = { '0', '0', '0', '0' };
    List<char> unlockedPartOfCode = new List<char>();

    int currentUnlocked = 0;

    [SerializeField] TextMeshProUGUI gui;
    [SerializeField] TextMeshProUGUI playerHintsText;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += FindTextmeshOnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= FindTextmeshOnSceneLoaded;
    }

    private void Awake()
    {
        for (int i = 0; i < serializedCode.Length; i++)
        {
            code[i] = serializedCode[i];
        }

        for (int i = 0; i < 4; i++)
        {
            unlockedPartOfCode.Add('_');
        }
    }

    private void Update()
    {
        //testing purposes
        if (unlockNext)
        {
            UnlockNextPiece();
            UpdateOnScreenVal();
            unlockNext = false;
        }
    }

    public void UnlockNextPiece()
    {
        if (currentUnlocked <= 3)
        {
            unlockedPartOfCode[currentUnlocked] = code[currentUnlocked];
            currentUnlocked++;
        }
        else if (currentUnlocked == 4)
        {
            playerHintsText.text = "Je hebt de hele code!";
        }
    }

    public void FindTextmeshOnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "map")
        {
            if (currentUnlocked <= 3)
            {
                gui = GameObject.Find("SecretCodeText").GetComponent<TextMeshProUGUI>();
                UnlockNextPiece();
                UpdateOnScreenVal();
            }
        }
    }

    public void UpdateOnScreenVal()
    {
        gui.text = "Geheime code: ";
        for (int i = 0; i < unlockedPartOfCode.Count; i++)
        {
            gui.text += unlockedPartOfCode[i] + " ";
        }
    }
}