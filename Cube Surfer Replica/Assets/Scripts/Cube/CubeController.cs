using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{

    [SerializeField] private HeroStackController heroStackController;

    private Vector3 direction = Vector3.back; 

    private bool isStack = false; //Stack the cube only 1 times, avoiding for stacking more cubes than a cube.
    
    private RaycastHit hit;
    
    void Start()
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCubeRaycast();
    }

    private void SetCubeRaycast()
    {
        if(Physics.Raycast(transform.position, direction, out hit, 1f)) //Cube to player
        {
            if (!isStack)
            {
                isStack = true;
                heroStackController.StackCubes(gameObject);
                SetDirection();
            }

            if (hit.transform.name == "ObstacleCube") //Cube to Obstacle Cube
            {
                heroStackController.UnstackCubes(gameObject);
            }
        }
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
