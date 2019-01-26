using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _rigidbody;
    public float _speed = 1.0f;
    public SpriteRenderer Renderer;

    // Use this for initialization
    void Start () {
        _rigidbody.velocity = new Vector2(_speed, 0.0f);
        Renderer.sortingOrder = -(int)(transform.position.y * 100.0f);
        Vector3 scale = transform.localScale;
        scale.x = _rigidbody.velocity.x < 0 ? 1.0f : -1.0f;
        transform.localScale = scale;
	}

    private void SetSpeed(float speed)
    {
        _speed = speed;
        _rigidbody.velocity = new Vector2(_speed, 0.0f);
    }

    //direction should be -1 or 1
    public void SetRandomSpeed(float direction)
    {
        SetSpeed(Random.Range(1.0f, 2.0f) * direction);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSpeedMultiplier(float speedMult)
    {
        SetSpeed(_speed * speedMult);
    }

    public float GetDogSpeed()
    {
        return _speed;
    }
}
