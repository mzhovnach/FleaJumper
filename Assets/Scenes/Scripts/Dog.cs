using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start () {
        _rigidbody.velocity = new Vector2(1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetDogSpeed()
    {
        return _rigidbody.velocity.x;
    }
}
