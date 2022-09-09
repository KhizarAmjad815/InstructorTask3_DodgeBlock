using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    private float spawnXInterval = -16.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2f;
    private float spawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFourBlocks", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnFourBlocks()
    {
        // spawning all prefabs blocks and then setting any random of them to not be active
        
        for (int i = 0; i < blockPrefabs.Length; i++)
        {
            Vector3 spawnPos = new Vector3(spawnXInterval, 0, spawnPosZ);

            Instantiate(blockPrefabs[i], spawnPos, blockPrefabs[i].transform.rotation);
            blockPrefabs[i].SetActive(true);

            spawnXInterval += 8;      // For next block, x position, to be instantiated
        }

        int randomBlockPos = Random.Range(0, blockPrefabs.Length);
        blockPrefabs[randomBlockPos].SetActive(false);
        spawnXInterval = -16;
        Debug.Log("Not Active: Block# " + (randomBlockPos + 1));
    }
}
