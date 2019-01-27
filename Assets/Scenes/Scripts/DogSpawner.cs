using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpawner : MonoBehaviour {

    private const float DOG_SIZE = 500.0f;
    public GameObject DogPrefab;
    public Camera Camera;

    private Dog SpawnDog(GameObject prefab)
    {
        GameObject newDogObj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        newDogObj.transform.SetParent(transform, true);
        Dog dogObj = newDogObj.GetComponent<Dog>();
        float side = Random.Range(0, 2) == 1 ? 1.0f : -1.0f;
        Vector3 pos = Vector3.zero;
        pos.x = -side * (Screen.width / 2.0f + DOG_SIZE);
        pos.y = Random.Range(Screen.height / 2.5f, 0.0f) * (Random.Range(0, 2) == 1 ? 1.0f : -1.0f);
        pos /= 100.0f;
        pos += Camera.transform.position;
        dogObj.transform.position = pos;
        dogObj.SetRandomSpeed(side);
        dogObj.UpdateSortingOrder();
        return dogObj;
    }

    public Dog SpawnRandomDog()
    {
        return SpawnDog(DogPrefab);
    }
}
