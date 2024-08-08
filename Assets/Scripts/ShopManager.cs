using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject Pack1;
    public GameObject Pack2;
    public GameObject Pack3;
    public GameObject Pack4;

    // Hàm này sẽ được gọi khi người dùng nhấn vào Button 1
    public void OnButton1Clicked()
    {
        // Bật pack 1 và tắt các pack còn lại
        Pack1.SetActive(true);
        Pack2.SetActive(false);
        Pack3.SetActive(false);
        Pack4.SetActive(false);
    }

    // Tương tự, bạn có thể tạo các hàm tương ứng cho các button khác
    public void OnButton2Clicked()
    {
        Pack1.SetActive(false);
        Pack2.SetActive(true);
        Pack3.SetActive(false);
        Pack4.SetActive(false);
    }

    public void OnButton3Clicked()
    {
        Pack1.SetActive(false);
        Pack2.SetActive(false);
        Pack3.SetActive(true);
        Pack4.SetActive(false);
    }

    public void OnButton4Clicked()
    {
        Pack1.SetActive(false);
        Pack2.SetActive(false);
        Pack3.SetActive(false);
        Pack4.SetActive(true);
    }
}
