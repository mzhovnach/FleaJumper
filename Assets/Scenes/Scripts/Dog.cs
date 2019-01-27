using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _rigidbody;
    public float _speed = 1.0f;
    public SpriteRenderer Renderer;
    public float fury = 0;
    private float milliseconds;
    private float starttime = 0;

    bool _couldUpdateTimer;

    public Action OnFleaDroppedFromDog;

    // Use this for initialization
    void Start () {
        _rigidbody.velocity = new Vector2(_speed, 0.0f);
        Vector3 scale = transform.localScale;
        scale.x = _rigidbody.velocity.x < 0 ? 1.0f : -1.0f;
        transform.localScale = scale;
        _couldUpdateTimer = true;
    }

    public void UpdateSortingOrder()
    {
        Renderer.sortingOrder = -(int)((transform.position.y) * 100.0f);
    }

    private void SetSpeed(float speed)
    {
        _speed = speed;
        _rigidbody.velocity = new Vector2(_speed, 0.0f);
    }

    //direction should be -1 or 1
    public void SetRandomSpeed(float direction)
    {
        SetSpeed(UnityEngine.Random.Range(2.0f, 4.0f) * direction);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_couldUpdateTimer)
        {
            starttime += Time.deltaTime;
            // milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;
            fury = starttime / 30;

            if (fury >= 100.0f)
            {
                OnFleaDroppedFromDog();
                _couldUpdateTimer = false;
            }
        }
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
