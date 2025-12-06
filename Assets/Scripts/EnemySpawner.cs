using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ObjectPool enemyPooling;

    void Start()
    {
        enemyPooling = GetComponent<ObjectPool>();
        StartCoroutine(nameof(SpawnEnemy));
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            GameObject enemy = enemyPooling.GetPooledObject();
            if (enemy == null)
            {
                continue;
            }
            enemy.transform.position = new Vector3(2, 3, -24);
            enemy.transform.SetParent(gameObject.transform, false);
            enemy.SetActive(true);
        }
    }
}
