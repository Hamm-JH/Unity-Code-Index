using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MIS
{
    [System.Serializable]
    public class SrDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TKey> keys = new List<TKey>();
        [SerializeField]
        private List<TValue> values = new List<TValue>();

        // save the dictionary to lists
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key); values.Add(pair.Value);
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
    public class srDicString : SrDictionary<string, string>
    {

    }

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

        public SrDictionary<int, string> srDic;
        // Start is called before the first frame update
        void Start()
        {
            ImportModule();

            srDic = new SrDictionary<int, string>();
            srDic.Add(0, "Hello");
        }

        public void ImportModule()
        {
            //InputDevice<Mouse>.Module.Init();
            InputDevice<TouchScreen>.Module.Init();
            //Mouse.Module.Init();
        }
    }
}
