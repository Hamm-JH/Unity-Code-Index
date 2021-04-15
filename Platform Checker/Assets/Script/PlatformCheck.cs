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
        //debugText.text = DeviceName;

        // 장치 형태 확인
        //debugText.text = DeviceType;

        // 장치 고유식별자 확인
        //debugText.text = DeviceUniqueIdentifier;

        // 장치 그래픽 ID 반환
        //debugText.text = GraphicsDeviceID.ToString();

        // 장치 그래픽 라이브러리 버전 확인
        debugText.text = GraphicsDeviceVersion;
    }

    #region Device

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
    /// 0 : Unknown
    /// 1 : Handheld
    /// 2 : Console
    /// 3 : Desktop
    /// </summary>
    public string DeviceType
    {
        get => SystemInfo.deviceType.ToString();
    }

    /// <summary>
    /// 장비만의 고유 식별자를 확인한다.
    /// [PC] 고유 헤쉬코드 반환
    /// </summary>
    public string DeviceUniqueIdentifier
    {
        get => SystemInfo.deviceUniqueIdentifier;
    }

    #endregion

    #region Graphics

    /// <summary>
    /// 그래픽 장치의 ID 반환코드
    /// [PC] 확인필요, 4자리 숫자 반환값(7942)나옴
    /// </summary>
    public int GraphicsDeviceID
    {
        get => SystemInfo.graphicsDeviceID;
    }

    /// <summary>
    /// 그래픽 장치의 그래픽 라이브러리 버전을 반환한다.
    /// [PC] Direct3D 11.0
    /// </summary>
    public string GraphicsDeviceVersion
    {
        get => SystemInfo.graphicsDeviceVersion;
    }

    #endregion
}
