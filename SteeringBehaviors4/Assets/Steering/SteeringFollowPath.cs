﻿using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : MonoBehaviour {

	Move move;
	SteeringSeek seek;
    BGCcMath mathPath;
    Vector3 closestPoint;
    public GameObject path;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		seek = GetComponent<SteeringSeek>();



        // TODO 1: Calculate the closest point in the range [0,1] from this gameobject to the path

        mathPath = path.GetComponent<BGCcMath>();
        closestPoint = mathPath.CalcPositionByClosestPoint(transform.position);

        seek.Steer(closestPoint);
    }
	
	// Update is called once per frame
	void Update () 
	{
		// TODO 2: Check if the tank is close enough to the desired point
		// If so, create a new point further ahead in the path

        
	}

	void OnDrawGizmosSelected() 
	{

		if(isActiveAndEnabled)
		{
			// Display the explosion radius when selected
			Gizmos.color = Color.green;
			// Useful if you draw a sphere on the closest point to the path
		}

	}
}
