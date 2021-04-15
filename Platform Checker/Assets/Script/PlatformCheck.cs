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
        {
            // 장치 모델 확인
            //debugText.text = DeviceModel;

            // 장치 이름 확인
            //debugText.text = DeviceName;

            // 장치 형태 확인
            //debugText.text = DeviceType;

            // 장치 고유식별자 확인
            //debugText.text = DeviceUniqueIdentifier;
        } // Device

        {
            // 현재 실행중인 플랫폼 확인
            //debugText.text = runtimePlatform.ToString();

            // 현재 에디터에서 실행중인지 확인
            //if (IsEditor) debugText.text = "plays in editor";
            //else debugText.text = "not plays in editor";

            // 현재 모바일에서 실행중인지 확인
            //if (IsMobilePlatform) debugText.text = "plays in mobile platform";
            //else debugText.text = "not plays in mobile platform";
        } // Platform

        {
            // 장치 그래픽 ID 반환
            //debugText.text = GraphicsDeviceID.ToString();

            // 장치 그래픽 라이브러리 버전 확인
            //debugText.text = GraphicsDeviceVersion;

            // 애플리케이션 이름 확인
            //debugText.text = Application.productName;
        } // Graphics

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

    #region Platform

    /// <summary>
    /// 현재 플레이중인 장비의 플랫폼을 확인한다.
    /// </summary>
    public RuntimePlatform runtimePlatform
    {
        get
        {
            //RuntimePlatform.OSXEditor;            : 0 / Mac OS X 유니티 에디터 플레이어
            //RuntimePlatform.OSXPlayer;            : 1 / Mac OS X 플레이어
            //RuntimePlatform.WindowsPlayer;        : 2 / Windows 플레이어
            //RuntimePlatform.OSXWebPlayer;         : 3 / Mac OS X 웹 플레이어
            //RuntimePlatform.OSXDashboardPlayer;   : 4 / Mac OS X Dashboard widget
            //RuntimePlatform.OSXDashboardPlayer;   : 4 / Dep.
            //RuntimePlatform.WindowsWebPlayer;     : 5 / Dep. Windows 웹 플레이어
            // 공백
            //RuntimePlatform.WindowsEditor;        : 7 / Windows 유니티 에디터
            //RuntimePlatform.IPhonePlayer;         : 8 / iPhone 플레이어
            //RuntimePlatform.PS3;                  : 9 / Dep.
            //RuntimePlatform.XBOX360;              : 10 / Dep.
            //RuntimePlatform.Android;              : 11 / Android Player
            //RuntimePlatform.NaCl;                 : 12 / Dep.
            //RuntimePlatform.LinuxPlayer;          : 13 / Linux 플레이어
            //RuntimePlatform.FlashPlayer;          : 15 / Dep.
            //RuntimePlatform.LinuxEditor;          : 16 / Linux 에디터
            //RuntimePlatform.WebGLPlayer;          : 17 / WebGL 플레이어
            //RuntimePlatform.MetroPlayerX86;       : 18 / Dep.
            //RuntimePlatform.WSAPlayerX86;         : 18 / CPU 아키텍쳐가 x86인 윈도우스토어 앱플레이어
            //RuntimePlatform.MetroPlayerX64;       : 19 / Dep.
            //RuntimePlatform.WSAPlayerX64;         : 19 / CPU 아키텍쳐가 x64인 윈도우스토어 앱플레이어
            //RuntimePlatform.MetroPlayerARM;       : 20 / Dep.
            //RuntimePlatform.WSAPlayerARM;         : 20 / CPU 아키텍쳐가 ARM인 윈도우스토어 앱플레이어
            //RuntimePlatform.WP8Player;            : 21 / Dep.
            //RuntimePlatform.BlackBerryPlayer;     : 22 / Dep.
            //RuntimePlatform.TizenPlayer;          : 23 / Dep.
            //RuntimePlatform.PSP2;                 : 24 / Dep,
            //RuntimePlatform.PS4;                  : 25 / Playstation 4 플레이어
            //RuntimePlatform.PSM;                  : 26 / Dep.
            //RuntimePlatform.XboxOne;              : 27 / Xbox One 플레이어
            //RuntimePlatform.SamsungTVPlayer;      : 28 / Dep.
            //RuntimePlatform.WiiU;                 : 30 / Dep.
            //RuntimePlatform.tvOS;                 : 31 / ? apple tv 플레이어
            //RuntimePlatform.Switch;               : 32 / Switch 플레이어
            //RuntimePlatform.Lumin;                : 33 / Lumin 플레이어
            //RuntimePlatform.Stadia;               : 34 / Google Stadia 플레이어
            //RuntimePlatform.CloudRendering;       : 35 / 클라우드 렌더링
            //RuntimePlatform.GameCoreScarlett;     : 36 / ?
            //RuntimePlatform.GameCoreXboxSeries;   : 36 / ?
            //RuntimePlatform.GameCoreXboxOne;      : 37 / Xbox One Core
            //RuntimePlatform.PS5;                  : 38 / Playstation 5 플레이어

            return Application.platform;
        }
    }

    /// <summary>
    /// Editor에서 플레이한 것인지 확인
    /// </summary>
    public bool IsEditor
    {
        get => Application.isEditor;
    }
    
    /// <summary>
    /// mobile platform에서 플레이중인지 확인
    /// </summary> 
    public bool IsMobilePlatform
    {
        get => Application.isMobilePlatform;
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
