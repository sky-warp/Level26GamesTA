using _Project.Scripts.Configs;
using _Project.Scripts.Enemies;
using UnityEngine;

namespace _Project.Scripts.Factories
{
    public class EnemyFactory : BaseMonoFactory
    {
        private EnemyConfig _enemyConf;
        private VisualEffectFactory _visualEffectsFactory;
        private Vector3 _spawnPoint;
        private Vector3 _destination;

        public EnemyFactory(EnemyConfig config,
            VisualEffectFactory visualEffectsFactory) : base(config.Prefab)
        {
            _enemyConf = config;
            _visualEffectsFactory = visualEffectsFactory;
            _spawnPoint = config.SpawnPoint;
            _destination = -(_spawnPoint);
        }

        public override GameObject Create()
        {
            var instance = GameObject.Instantiate(Prefab, _spawnPoint, Quaternion.Euler(0, 180, 0));

            instance.GetComponent<Enemy>().Init(_enemyConf.Speed, _enemyConf.Health, _visualEffectsFactory,_destination);
            
            return instance;
        }
    }
}