using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] public Transform parent;
        public List<Enemy> enemyPrefabs = new List<Enemy>();
        public List<DestroyedEnemy> destroyedEnemies = new List<DestroyedEnemy>();
        public List<Enemy> currentEnemies = new List<Enemy>();
        
        void Awake()
        {
            if (!parent)
            {
                parent = this.transform;
            }
        }

        public void Reset()
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                parent.transform.GetChild(i).gameObject.SetActive(false);
                Destroy(parent.transform.GetChild(i).gameObject);
            }

            currentEnemies.Clear();
        }

        public void SpawnDestroyedEnemy(Enemy enemy)
        {
            var prefab = destroyedEnemies.FirstOrDefault(p => p.type == enemy.type);

            if (prefab != null)
            {
                var e = Instantiate(prefab, enemy.transform.position, Quaternion.identity, parent);
            }
        }

        public void UpdateBehaviour() => 
            currentEnemies.ForEach((e) => { if (e.gameObject.activeInHierarchy) e.UpdateBehaviour(); });        

        public void FreezeAll() =>
            currentEnemies.ForEach((e) => { if(e.gameObject.activeInHierarchy) e.Freeze(); });

        public bool AllEnemiesAreDead() => currentEnemies.All(e => !e.gameObject.activeInHierarchy);
      

        public void SpawnWave()
        {
            currentEnemies.ForEach(e => Destroy(e));
            currentEnemies.Clear();

            var attackers = CalcAttackers();

            for (int i = 0; i < attackers.Length; i++)
            {
                for (int j = 0; j < attackers[i]; j++)
                {
                    var position2d = Random.insideUnitCircle.normalized * GameManager.Instance.GameSettings.spawnRange;
                    Vector3 pos = new Vector3(position2d.x, 0, position2d.y);

                    var go = Instantiate(enemyPrefabs[i].gameObject, pos, Quaternion.LookRotation(Vector3.zero - pos, Vector3.up), parent);
                    var e = go.GetComponent<Enemy>();
                    e.Spawn();
                    currentEnemies.Add(e);
                }
            }
        }

        private int[] CalcAttackers()
        {
            int[] results = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int remaining = GameManager.Instance.GameData.wave;

            while (remaining > 0)
            {
                var pick = remaining > 9 ? 9 : remaining;

                var calc = Mathf.CeilToInt(Random.value * pick);

                if (calc == 0) calc = 1; // If we manage to somehow roll a perfect 1;

                results[calc - 1]++;
                remaining -= calc;
            }

            return results;
        }


    }
}