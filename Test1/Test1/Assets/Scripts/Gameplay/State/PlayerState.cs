using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ShipSystems;
public class PlayerState : MonoBehaviour, IHealth, ISpeed
{
    [SerializeField]
    private float _maxStreinght = 100;

    public float MaxStreinght => _maxStreinght;

    
    private float _currentStreinght;

    private WeaponSystem _weaponSystem;


    public float CurrentStreinght => _currentStreinght;


    private void Start()
    {
        _weaponSystem = GetComponent<WeaponSystem>();
        _currentStreinght = _maxStreinght;
        EventManager.Instance.EventPlayerTakeDamage.AddListener(TakeDamage);
        EventManager.Instance.EventPlayerHealthUpdate.Invoke(_currentStreinght);
    }

    public void ApplyHealth(float healthAmount)
    {
        if ((_currentStreinght + healthAmount) > _maxStreinght)
        {
            _currentStreinght = _maxStreinght;
        }
        else
        {
            _currentStreinght += healthAmount;
        }

        EventManager.Instance.EventPlayerHealthUpdate.Invoke(_currentStreinght);
    }
    public void TakeDamage(float amount)
    {

        _currentStreinght -= amount;
        EventManager.Instance.EventPlayerHealthUpdate.Invoke(_currentStreinght);

        if (_currentStreinght <= 0)
        {
            EventManager.Instance.EventPlayerDeath.Invoke();
        }
    }

    public void SpeedUpdate(float _speedUpdate)
    {
        _weaponSystem.UpdateSpeedFire(_speedUpdate);
    }
}
