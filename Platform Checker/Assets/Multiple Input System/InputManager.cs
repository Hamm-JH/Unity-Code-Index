using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MIS
{
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

        // Start is called before the first frame update
        void Start()
        {
            ImportModule();
        }

        public void ImportModule()
        {
            InputDevice<Mouse>.Module.Init();
            //InputDevice<TouchScreen>.Module.Init();
            //Mouse.Module.Init();
        }
    }
}
