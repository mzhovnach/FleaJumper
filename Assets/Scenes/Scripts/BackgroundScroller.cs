using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    private float _speed;
    public Material Material;
    private float _curOffset;

	// Use this for initialization
	void Start () {
        _speed = 0.05f;
	}

    // minus speed means scroll in opposite direction
    public void SetScrollSpeed(float speed)
    {
        Debug.Log(speed);
        _speed = speed;
    }
	
	// Update is called once per frame
	public void Update () {
        float offset = Time.time * _speed;
        Material.mainTextureOffset = new Vector2(offset, 0);
    }
}
