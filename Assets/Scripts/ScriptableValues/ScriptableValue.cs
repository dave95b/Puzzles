using System;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableValue<T> : ScriptableObject {

    [SerializeField]
    protected T value;

    public event Action<T> OnValueChanged;

#if UNITY_EDITOR
    public T Value {
        get { return keepPlaymodeChanges ? value : savedValue; }
        set {
            T oldValue;
            if (keepPlaymodeChanges)
            {
                oldValue = this.value;
                this.value = value;
            }
            else
            {
                oldValue = savedValue;
                savedValue = value;
            }

            if (OnValueChanged != null && !oldValue.Equals(value))
                OnValueChanged.Invoke(value);
        }
    }

    [SerializeField]
    private bool keepPlaymodeChanges;

    [SerializeField, HideInInspector]
    protected T savedValue;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
        savedValue = value;
    }

#else
    public T Value {
        get { return value; }
        set {
            T oldValue = this.value;
            this.value = value;

            if (OnValueChanged != null && !oldValue.Equals(value))
                OnValueChanged.Invoke(value);
        }
    }

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
#endif
}