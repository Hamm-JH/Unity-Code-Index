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
        //debugText.text = DeviceModel;
        
        // 장치 이름 확인
        debugText.text = DeviceName;

        //SystemInfo.deviceType;
        //UnityEngine.DeviceType.Unknown;
        //UnityEngine.DeviceType.Handheld;
        //UnityEngine.DeviceType.Console;
        //UnityEngine.DeviceType.Desktop;

    }

    /// <summary>
    /// 장비 모델명을 확인한다
    /// PC : 메인보드 칩셋 확인
    /// </summary>
    public string DeviceModel
    {
        get => SystemInfo.deviceModel;
    }

    /// <summary>
    /// 장비 이름을 확인한다.
    /// Win10 : 장비 인식코드 출력 (기본값 6-6 문자, 숫자 결합 코드)
    /// </summary>
    public string DeviceName
    {
        get => SystemInfo.deviceName;
    }

    /// <summary>
    /// 장비 형태를 확인한다. (Enum Code)
    /// 0 : 
    /// </summary>
    public string DeviceType
    {
        get => SystemInfo.deviceType.ToString();
    }
}
