using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MIS
{
    public abstract class InputDevice<Mod> : MonoBehaviour where Mod : InputDevice<Mod>
    {
        #region Module
        private static InputDevice<Mod> module;

        public static InputDevice<Mod> Module
        {
            get
            {
                if(module == null)
                {
                    module = FindObjectOfType<InputDevice<Mod>>() as InputDevice<Mod>;
                    if(module == null)
                    {
                        GameObject obj = new GameObject(typeof(Mod).Name);
                        InputDevice<Mod> mod = obj.AddComponent<Mod>();
                        module = mod;
                        obj.transform.SetParent(InputManager.Instance.transform);
                    }
                }
                return module;
            }
        }

        public void Init() { }
        #endregion
    }
}
