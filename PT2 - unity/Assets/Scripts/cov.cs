using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using Pathfinding;

public class cov : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aipath;
    public SpriteRenderer render;

    // Update is called once per frame
    void Update()
    {
        if(aipath.desiredVelocity.x >= 0.01f){
            render.flipX = false;
        }else if(aipath.desiredVelocity.x <= -0.01f){
            render.flipX = true;
        }
    }
}
