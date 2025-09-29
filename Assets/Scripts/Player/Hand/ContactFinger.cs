using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactFinger : MonoBehaviour
{
    [SerializeField] private bool _isPressed = false;

    public bool IsPressed { get => _isPressed; set => _isPressed = value; }

}
