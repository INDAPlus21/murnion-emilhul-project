using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMetrics {
    public const float outerRadius = 10f;
	// Magic number is sqr(3)/2
    public const float innerRadius = outerRadius * 0.8660254038f; 

    public static Vector3[] corners = {
		new Vector3(0f, outerRadius, 0f),
		new Vector3(innerRadius, 0.5f * outerRadius, 0f),
		new Vector3(innerRadius, -0.5f * outerRadius, 0f),
		new Vector3(0f, -outerRadius, 0f),
		new Vector3(-innerRadius, -0.5f * outerRadius, 0f),
		new Vector3(-innerRadius, 0.5f * outerRadius, 0f),
		new Vector3(0f, outerRadius, 0f)
	};
}
