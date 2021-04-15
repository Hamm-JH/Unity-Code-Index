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
        // ��ġ �� Ȯ��
        //debugText.text = DeviceModel;
        
        // ��ġ �̸� Ȯ��
        //debugText.text = DeviceName;

        // ��ġ ���� Ȯ��
        debugText.text = DeviceType;

        //SystemInfo.deviceType;
        //UnityEngine.DeviceType.Unknown;
        //UnityEngine.DeviceType.Handheld;
        //UnityEngine.DeviceType.Console;
        //UnityEngine.DeviceType.Desktop;

    }

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
}
