using UnityEngine;
using UnityEngine.Events;
using System;


public class Events
{
    [System.Serializable] public class EventReturnInt : UnityEvent<int> { };
    [System.Serializable] public class EventReturnfloat : UnityEvent<float> { };

    [System.Serializable] public class EventReturnTypeVoid : UnityEvent { };
    [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { };


}
