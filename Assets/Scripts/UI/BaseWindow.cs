using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWindow : MonoBehaviour
{
    [SerializeField] private Windows window;

    public Windows WindowType => window;
}