using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Event : ScriptableObject
{
    private Action<Vector3> action;

    public void AddListener(Action<Vector3> action)
    {
        this.action += action;
    }

    public void RemoveListener(Action<Vector3> action)
    {
        this.action -= action;
    }

    public void Raise(Vector3 value)
    {
        this.action?.Invoke(value);
    }
}
