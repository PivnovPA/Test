using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;


        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private EnemyState _enemyState;

        private PlayerState _playerState;

        #region ReferenceVFX
        public GameObject destructionVFX;

        #endregion

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);

            if (_battleIdentity == UnitBattleIdentity.Enemy)
            {
                _enemyState = GetComponent<EnemyState>();
                if (_enemyState == null)
                {
                    return;
                }
            }

            else if (_battleIdentity == UnitBattleIdentity.Ally)
            {
                _playerState = GetComponent<PlayerState>();
                if (_playerState == null)
                {
                    return;
                }
            }
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {

            if (_battleIdentity == UnitBattleIdentity.Enemy)
            {
                EventManager.Instance.EventOnScoreUpdate.Invoke(_enemyState.RewardKill);
                _enemyState._killReward.InstanceBonus();
                Instantiate(destructionVFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            else if (_battleIdentity == UnitBattleIdentity.Ally)
            {
                EventManager.Instance.EventPlayerTakeDamage.Invoke(damageDealer.Damage);  
            }
        }

    }
}
