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

        public UnityEvent newInput = default(UnityEvent);

        public UnityEvents inputEvents;
        

        //public DeviceDictionary<InputDevice<T>> deviceList;

        // Start is called before the first frame update
        void Start()
        {
            ImportModule();

            inputEvents = new UnityEvents();
            inputEvents.Add("t1", new UnityEvent());
            inputEvents.Add("t20", new UnityEvent());

            //srDic = new SrDictionary<int, string>();
            //srDic.Add(0, "Hello");
        }

        public void ImportModule()
        {
            //InputDevice<Mouse>.Module.Init();
            Def.DeviceParams param = new Def.DeviceParams();
            param.Init(Def.Platform.MOBILE, Def.Device.TOUCHSCREEN);
            InputDevice<TouchScreen>.Module.Init(param);
        }
    }
}
