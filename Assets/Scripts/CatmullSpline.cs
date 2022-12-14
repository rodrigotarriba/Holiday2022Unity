//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CatmullSpline : MonoBehaviour
//{

//			// Create the 4 points 
//			Vector3 point1 = new Vector3(-1f, -1f, -1f);
//			Vector3 point2 = new Vector3(-1f, 1f, 1f);
//			Vector3 point3 = new Vector3(1f, -1f, 1f);
//			Vector3 point4 = new Vector3(1f, 1f, -1f);

//    private void Start()
//    {
//		// Create the LineRenderer component
//		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

//		// Set the number of points in the line
//		lineRenderer.positionCount = 20;

//		// Set the width of the line
//		lineRenderer.startWidth = 0.1f;
//		lineRenderer.endWidth = 0.1f;

//		// Set the color of the line
//		lineRenderer.startColor = Color.red;
//		lineRenderer.endColor = Color.yellow;

//		// Create a Catmull-Rom spline through these 4 points
//		for (int i = 0; i < lineRenderer.positionCount; i++)
//		{
//			float t = i / (lineRenderer.positionCount - 1f);
//			Vector3 position = GetCatmullRomPosition(t, point1, point2, point3, point4);
//			lineRenderer.SetPosition(i, position);
//		}
//	}
    

//		// Helper functions
//		Vector3 GetCatmullRomPosition(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
//		{
//			// The coefficients of the cubic polynomial (except the 0.5f * which I added later for performance)
//			Vector3 a = 2f * p1;
//			Vector3 b = p2 - p0;
//			Vector3 c = 2f * p0 - 5f * p1 + 4f * p2 - p3;
//			Vector3 d = -p0 + 3f * p1 - 3f * p2 + p3;

//			// The cubic polynomial: a + b * t + c * t^2 + d * t^3
//			Vector3 pos = 0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t));

//			return pos;
//		}
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatmullSpline : MonoBehaviour
{

	// Create 25 random points 
	Vector3[] points = new Vector3[25];


private void Start()
{
		for (int i = 0; i < points.Length; i++)
		{
			points[i] = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		}



		// Create the LineRenderer component
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

	// Set the number of points in the line
	lineRenderer.positionCount = 25;

	// Set the width of the line
	lineRenderer.startWidth = 0.1f;
	lineRenderer.endWidth = 0.1f;

	// Set the color of the line
	lineRenderer.startColor = Color.red;
	lineRenderer.endColor = Color.yellow;

	// Create a Catmull-Rom spline through these 25 points
	for (int i = 0; i < lineRenderer.positionCount; i++)
	{
		float t = i / (lineRenderer.positionCount - 1f);
		Vector3 position = GetCatmullRomPosition(t, points);
		lineRenderer.SetPosition(i, position);
	}
}


// Helper functions
Vector3 GetCatmullRomPosition(float t, Vector3[] points)
{
	// Calculate the coefficients of the cubic polynomial 
	Vector3 a = 2f * points[1];
	Vector3 b = points[2] - points[0];
	Vector3 c = 2f * points[0] - 5f * points[1] + 4f * points[2] - points[3];
	Vector3 d = -points[0] + 3f * points[1] - 3f * points[2] + points[3];

	// The cubic polynomial: a + b * t + c * t^2 + d * t^3
	Vector3 pos = 0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t));

	return pos;
}
}
