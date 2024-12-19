using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public struct Spawning
    {
        public GameObject spawnObject;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public Spawning[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawner), Random.Range(minSpawnRate, maxSpawnRate));
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawner()
    {
        float chance = Random.value;
        foreach (var obj in objects)
        {
            if (chance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.spawnObject);
                obstacle.transform.position += transform.position;
                break;
            }
            chance -= obj.spawnChance;
        }
        Invoke(nameof(Spawner),Random.Range(minSpawnRate,maxSpawnRate));
    }
}
