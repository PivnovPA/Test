using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public Events.EventReturnInt EventOnScoreUpdate;
    public Events.EventReturnfloat EventPlayerTakeDamage;
    public Events.EventReturnfloat EventPlayerHealthUpdate;
    public Events.EventReturnTypeVoid EventPlayerDeath;
}
