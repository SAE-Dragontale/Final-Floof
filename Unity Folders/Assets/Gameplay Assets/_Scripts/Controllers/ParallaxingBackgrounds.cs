using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxingBackgrounds : MonoBehaviour {

    public float howFastTheBackGroundMove = 0.01f;

    public MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2(Time.time * howFastTheBackGroundMove, 0);

        mr.GetComponent<MeshRenderer>().material.mainTextureOffset = offset;
        //TODO reset once reached size
    }
}
