using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform[] Points; // Array of waypoints for the enemy to follow
    [SerializeField] GameObject Slime, FastSlime; // The enemy prefab to spawn
    [SerializeField] float MinSpeed, MaxSpeed;
    [SerializeField] int MaxHealth;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        // NextWave();
        GlobalData.NextWave = NextWave;
    }

    private void NextWave()
    {
        // Calculate the number of enemies for the wave
        int enemyCount = GlobalData.wave <= 10 ? (10 * GlobalData.wave) : Mathf.RoundToInt(10 * Mathf.Pow(2, GlobalData.wave));
        
        StartCoroutine(SpawnEnemies(enemyCount));
    }

    IEnumerator SpawnEnemies(int EnemyCount)
    {
        GlobalData.AliveSlimes++;
        while (EnemyCount > 0)
        {
            float threshold = 1f / GlobalData.wave + 0.05f; // Calculate threshold based on wave
            float speed = Random.Range(0f, 1f) > threshold ? MaxSpeed : MinSpeed;
            GameObject newEnemy = Instantiate(speed == MaxSpeed ? FastSlime : Slime, Points[0].position, Quaternion.identity);

            newEnemy.GetComponent<EnemyScript>().Points = Points;

            // Use the threshold to determine speed and health
            newEnemy.GetComponent<EnemyScript>().speed = speed;
            newEnemy.GetComponent<EnemyScript>().HealthPoint = (int)(
                Random.Range(0f, 1f) > threshold ? Random.Range(MaxHealth/2, MaxHealth) : Random.Range(1, MaxHealth/2));

            EnemyCount--;
            yield return new WaitForSeconds(3);
        }
        GlobalData.AliveSlimes--;
    }
}
