using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    private float _speed;
    public Material Material;

	// Use this for initialization
	void Start () {
        _speed = 10.5f;
	}

    // minus speed means scroll in opposite direction
    public void SetScrollSpeed(float speed)
    {
        float offset = Time.time * _speed;
        Material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
	
	// Update is called once per frame
	public void Update () {
		
	}
}
