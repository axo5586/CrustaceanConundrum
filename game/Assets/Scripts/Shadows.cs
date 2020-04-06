using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour {
    // https://www.reddit.com/r/Unity2D/comments/8267zv/2d_drop_shadows_in_unity_using_shader_tutorial/

    public GameObject shadow;
    public Vector3 shadowOffset = new Vector3(-0.1f, -0.1f);

    public Material shadowMaterial;

	// Use this for initialization
	void Start () {
        shadow = new GameObject("Shadow");
        //shadowMaterial = Resources.Load("/Materials/Shadow", typeof(Material)) as Material;
        //shadowMaterial = Resources.Load<Material>("Shadow");
        shadow.transform.parent = this.transform;

        shadow.transform.localPosition = shadowOffset;
        shadow.transform.localRotation = Quaternion.identity;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material = shadowMaterial;
	}
	
	// Update is called once per frame
	void Update () {
        shadow.transform.localPosition = shadowOffset;
	}
}
