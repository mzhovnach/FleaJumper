using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpawner : MonoBehaviour {
    public GameObject DogPrefab;

    private Dog SpawnDog(GameObject prefab)
    {
        GameObject newDogObj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        newDogObj.transform.SetParent(transform, true);
        Dog dogObj = newDogObj.GetComponent<Dog>();
        dogObj.SetRandomSpeed(Random.Range(0, 2) == 1 ? 1.0f : -1.0f);
        return dogObj;
    }

    public Dog SpawnRandomDog()
    {
        return SpawnDog(DogPrefab);
    }
}
