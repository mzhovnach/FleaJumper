using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    public Camera Camera;
    public Material Material;
    private float _curOffset;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void Update () {
        float offset = Camera.transform.position.x / 20.0f;
        Material.mainTextureOffset = new Vector2(offset, 0);
    }
}
