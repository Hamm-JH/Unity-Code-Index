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
        debugText.text = DeviceModel;
        //SystemInfo.deviceName
    }

    /// <summary>
    /// ��� �𵨸��� Ȯ���Ѵ�
    /// PC : ���κ��� Ĩ�� Ȯ��
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
