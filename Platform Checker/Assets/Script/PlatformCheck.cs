using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformCheck : MonoBehaviour
{
    public TextMeshProUGUI debugText;

    // Start is called before the first frame update
    void Start()
    {
        // 장치 모델 확인
        debugText.text = DeviceModel;
        //SystemInfo.deviceName
    }

    /// <summary>
    /// 장비 모델명을 확인한다
    /// PC : 메인보드 칩셋 확인
    /// </summary>
    public string DeviceModel
    {
        get => SystemInfo.deviceModel;
    }

    
    public string DeviceName
    {
        get => SystemInfo.deviceName;
    }
}
