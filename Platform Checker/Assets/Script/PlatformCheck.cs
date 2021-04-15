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
            // ��ġ �� Ȯ��
            //debugText.text = DeviceModel;

            // ��ġ �̸� Ȯ��
            //debugText.text = DeviceName;

            // ��ġ ���� Ȯ��
            //debugText.text = DeviceType;

            // ��ġ �����ĺ��� Ȯ��
            //debugText.text = DeviceUniqueIdentifier;
        } // Device

        {
            // ���� �������� �÷��� Ȯ��
            //debugText.text = runtimePlatform.ToString();

            // ���� �����Ϳ��� ���������� Ȯ��
            //if (IsEditor) debugText.text = "plays in editor";
            //else debugText.text = "not plays in editor";

            // ���� ����Ͽ��� ���������� Ȯ��
            //if (IsMobilePlatform) debugText.text = "plays in mobile platform";
            //else debugText.text = "not plays in mobile platform";
        } // Platform

        {
            // ��ġ �׷��� ID ��ȯ
            //debugText.text = GraphicsDeviceID.ToString();

            // ��ġ �׷��� ���̺귯�� ���� Ȯ��
            //debugText.text = GraphicsDeviceVersion;

            // ���ø����̼� �̸� Ȯ��
            //debugText.text = Application.productName;
        } // Graphics

    }

    #region Device

    /// <summary>
    /// ��� �𵨸��� Ȯ���Ѵ�
    /// PC : ���κ��� Ĩ�� Ȯ��
    /// </summary>
    public string DeviceModel
    {
        get => SystemInfo.deviceModel;
    }

    /// <summary>
    /// ��� �̸��� Ȯ���Ѵ�.
    /// Win10 : ��� �ν��ڵ� ��� (�⺻�� 6-6 ����, ���� ���� �ڵ�)
    /// </summary>
    public string DeviceName
    {
        get => SystemInfo.deviceName;
    }

    /// <summary>
    /// ��� ���¸� Ȯ���Ѵ�. (Enum Code)
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
    /// ����� ���� �ĺ��ڸ� Ȯ���Ѵ�.
    /// [PC] ���� �콬�ڵ� ��ȯ
    /// </summary>
    public string DeviceUniqueIdentifier
    {
        get => SystemInfo.deviceUniqueIdentifier;
    }

    #endregion

    #region Platform

    /// <summary>
    /// ���� �÷������� ����� �÷����� Ȯ���Ѵ�.
    /// </summary>
    public RuntimePlatform runtimePlatform
    {
        get
        {
            //RuntimePlatform.OSXEditor;            : 0 / Mac OS X ����Ƽ ������ �÷��̾�
            //RuntimePlatform.OSXPlayer;            : 1 / Mac OS X �÷��̾�
            //RuntimePlatform.WindowsPlayer;        : 2 / Windows �÷��̾�
            //RuntimePlatform.OSXWebPlayer;         : 3 / Mac OS X �� �÷��̾�
            //RuntimePlatform.OSXDashboardPlayer;   : 4 / Mac OS X Dashboard widget
            //RuntimePlatform.OSXDashboardPlayer;   : 4 / Dep.
            //RuntimePlatform.WindowsWebPlayer;     : 5 / Dep. Windows �� �÷��̾�
            // ����
            //RuntimePlatform.WindowsEditor;        : 7 / Windows ����Ƽ ������
            //RuntimePlatform.IPhonePlayer;         : 8 / iPhone �÷��̾�
            //RuntimePlatform.PS3;                  : 9 / Dep.
            //RuntimePlatform.XBOX360;              : 10 / Dep.
            //RuntimePlatform.Android;              : 11 / Android Player
            //RuntimePlatform.NaCl;                 : 12 / Dep.
            //RuntimePlatform.LinuxPlayer;          : 13 / Linux �÷��̾�
            //RuntimePlatform.FlashPlayer;          : 15 / Dep.
            //RuntimePlatform.LinuxEditor;          : 16 / Linux ������
            //RuntimePlatform.WebGLPlayer;          : 17 / WebGL �÷��̾�
            //RuntimePlatform.MetroPlayerX86;       : 18 / Dep.
            //RuntimePlatform.WSAPlayerX86;         : 18 / CPU ��Ű���İ� x86�� �����콺��� ���÷��̾�
            //RuntimePlatform.MetroPlayerX64;       : 19 / Dep.
            //RuntimePlatform.WSAPlayerX64;         : 19 / CPU ��Ű���İ� x64�� �����콺��� ���÷��̾�
            //RuntimePlatform.MetroPlayerARM;       : 20 / Dep.
            //RuntimePlatform.WSAPlayerARM;         : 20 / CPU ��Ű���İ� ARM�� �����콺��� ���÷��̾�
            //RuntimePlatform.WP8Player;            : 21 / Dep.
            //RuntimePlatform.BlackBerryPlayer;     : 22 / Dep.
            //RuntimePlatform.TizenPlayer;          : 23 / Dep.
            //RuntimePlatform.PSP2;                 : 24 / Dep,
            //RuntimePlatform.PS4;                  : 25 / Playstation 4 �÷��̾�
            //RuntimePlatform.PSM;                  : 26 / Dep.
            //RuntimePlatform.XboxOne;              : 27 / Xbox One �÷��̾�
            //RuntimePlatform.SamsungTVPlayer;      : 28 / Dep.
            //RuntimePlatform.WiiU;                 : 30 / Dep.
            //RuntimePlatform.tvOS;                 : 31 / ? apple tv �÷��̾�
            //RuntimePlatform.Switch;               : 32 / Switch �÷��̾�
            //RuntimePlatform.Lumin;                : 33 / Lumin �÷��̾�
            //RuntimePlatform.Stadia;               : 34 / Google Stadia �÷��̾�
            //RuntimePlatform.CloudRendering;       : 35 / Ŭ���� ������
            //RuntimePlatform.GameCoreScarlett;     : 36 / ?
            //RuntimePlatform.GameCoreXboxSeries;   : 36 / ?
            //RuntimePlatform.GameCoreXboxOne;      : 37 / Xbox One Core
            //RuntimePlatform.PS5;                  : 38 / Playstation 5 �÷��̾�

            return Application.platform;
        }
    }

    /// <summary>
    /// Editor���� �÷����� ������ Ȯ��
    /// </summary>
    public bool IsEditor
    {
        get => Application.isEditor;
    }
    
    /// <summary>
    /// mobile platform���� �÷��������� Ȯ��
    /// </summary> 
    public bool IsMobilePlatform
    {
        get => Application.isMobilePlatform;
    }


    #endregion

    #region Graphics

    /// <summary>
    /// �׷��� ��ġ�� ID ��ȯ�ڵ�
    /// [PC] Ȯ���ʿ�, 4�ڸ� ���� ��ȯ��(7942)����
    /// </summary>
    public int GraphicsDeviceID
    {
        get => SystemInfo.graphicsDeviceID;
    }

    /// <summary>
    /// �׷��� ��ġ�� �׷��� ���̺귯�� ������ ��ȯ�Ѵ�.
    /// [PC] Direct3D 11.0
    /// </summary>
    public string GraphicsDeviceVersion
    {
        get => SystemInfo.graphicsDeviceVersion;
    }

    #endregion
}
