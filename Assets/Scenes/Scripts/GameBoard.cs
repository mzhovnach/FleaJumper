using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    public SmoothCamera2D CameraFollower;
    public BackgroundScroller BackgroundScroller;
    public Dog DogHost;
    public GameObject DogPrefab;
    public GameObject DogContainer;

	// Use this for initialization
	void Start () {

        //create first dog

	}
	
	// Update is called once per frame
	void Update () {

	}

    private Dog SpawnDog(GameObject prefab)
    {
        GameObject newDogObj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        Dog dogObj = newDogObj.GetComponent<Dog>();
        return dogObj;
    }

    public void SetNewHost(Dog newHostDog)
    {
        if (newHostDog != DogHost)
        {
            DogHost = newHostDog;
            BackgroundScroller.SetScrollSpeed(DogHost.GetDogSpeed() / 2.0f);
            CameraFollower.target = DogHost.transform;
        }
    }
}
