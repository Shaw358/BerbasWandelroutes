using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LucasDebug : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI gui;
    void Update()
    {
        gui.text = player.transform.position.ToString();
    }
}
