using System;
using UnityEngine;

public interface IInput
{
    Vector3 Direction { get; }
    event Action<Vector3> OnDirectionChanged;
}