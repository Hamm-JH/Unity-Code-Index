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
        //debugText.text = DeviceType;

        // ��ġ �����ĺ��� Ȯ��
        //debugText.text = DeviceUniqueIdentifier;

        // ��ġ �׷��� ID ��ȯ
        //debugText.text = GraphicsDeviceID.ToString();

        // ��ġ �׷��� ���̺귯�� ���� Ȯ��
        debugText.text = GraphicsDeviceVersion;
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
