using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public int token;

    void Start()
    {
        // Load token từ PlayerPrefs khi bắt đầu
        token = PlayerPrefs.GetInt("Token", 0);
    }
}
