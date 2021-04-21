using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MIS
{
    #region Serialization class
    [System.Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [System.Serializable]
        public struct serializer
        {
            [SerializeField]
            TKey key;
            [SerializeField]
            TValue value;

            public void add(TKey _key, TValue _value)
            {
                key = _key;
                value = _value;
            }
        }

        [SerializeField]
        private List<serializer> serial = new List<serializer>();

        [SerializeField]
        private List<TKey> keys = new List<TKey>();
        [SerializeField]
        private List<TValue> values = new List<TValue>();

        // save the dictionary to lists
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            serial.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                serializer s1 = new serializer();
                s1.add(pair.Key, pair.Value);
                serial.Add(s1);
                //keys.Add(pair.Key); values.Add(pair.Value);
            }
        }

        // load dictionary from lists
        public void OnAfterDeserialize()
        {
            this.Clear();
            if(keys.Count != values.Count)
            {
                throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));
                for (int i = 0; i < keys.Count; i++)
                {
                    this.Add(keys[i], values[i]);
                }
            }
        }
    }

    [System.Serializable]
    public class UnityEvents : SerializableDictionary<string, UnityEvent> { }
    #endregion

    public class InputManager : MonoBehaviour
    {
        #region Instance 
        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<InputManager>() as InputManager;
                    if(instance == null)
                    {
                        GameObject obj = new GameObject("InputManager");
                        InputManager manager = obj.AddComponent<InputManager>();
                        instance = manager;

                        DontDestroyOnLoad(obj);
                    }
                }
                return instance;
            }
        }

        public void Init() { }
        #endregion

        #region Events
        public UnityEvent<Vector3> OnClick;

        public UnityEvent<Vector3> OnDrag;

        public UnityEvent<float> OnZoom;
        #endregion

        private void Awake()
        {
            ImportModule();

            OnClick = new UnityEvent<Vector3>();
            OnDrag = new UnityEvent<Vector3>();
            OnZoom = new UnityEvent<float>();
        }

        public void ImportModule()
        {
            Def.Platform runtimePlatform = RuntimePlatform();

            Def.DeviceParams param = new Def.DeviceParams();
            if (runtimePlatform == Def.Platform.PC)
            {
                param.Init(runtimePlatform, Def.Device.MOUSE);
                InputDevice<Mouse>.Module.Init(param);
            }
            else if(runtimePlatform == Def.Platform.MOBILE)
            {
                param.Init(runtimePlatform, Def.Device.TOUCHSCREEN);
                InputDevice<TouchScreen>.Module.Init(param);
            }
        }

        /// <summary>
        /// 플랫폼 코드는 차후 static library로 이전 고려필요
        /// </summary>
        /// <returns></returns>
        private Def.Platform RuntimePlatform()
        {
            Def.Platform platform = Def.Platform.NULL;

            if(Application.platform == UnityEngine.RuntimePlatform.WebGLPlayer)
            {
                if(Application.isMobilePlatform)
                {
                    platform = Def.Platform.MOBILE;
                }
                else
                {
                    platform = Def.Platform.PC;
                }
            }
            else if(Application.platform == UnityEngine.RuntimePlatform.WindowsEditor)
            {
                platform = Def.Platform.PC;
            }
            else if(Application.platform == UnityEngine.RuntimePlatform.WindowsPlayer)
            {
                platform = Def.Platform.PC;
            }
            else if(Application.platform == UnityEngine.RuntimePlatform.Android)
            {
                platform = Def.Platform.MOBILE;
            }
            else if(Application.platform == UnityEngine.RuntimePlatform.IPhonePlayer)
            {
                platform = Def.Platform.MOBILE;
            }

            return platform;
        }
    }
}
