using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // Random spawning of monsters

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            // Creates a copy of a game object
            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0) // Left side
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10); // Go to right (positive)
            }
            else // Right side
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10); // Go to left (positive)

                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); // Flip
            }
        }
    }
}
