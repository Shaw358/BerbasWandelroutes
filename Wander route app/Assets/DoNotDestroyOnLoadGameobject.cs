using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoadGameobject : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}