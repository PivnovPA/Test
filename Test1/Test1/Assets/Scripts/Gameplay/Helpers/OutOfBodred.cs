using System.Collections;
using System.Collections.Generic;
using Gameplay.Helpers;
using UnityEngine;

public class OutOfBodred : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _representation;

    void Update()
    {
        CheckBorders();
    }

    private void CheckBorders()
    {
        if (!GameAreaHelper.Instance.IsInGameplayArea(transform, _representation.bounds))
        {
            Destroy(gameObject);
        }
    }
}
