using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexagonMesh : MonoBehaviour {

	private Vector3 center;
	private int width = 1;
	private Vector3[] corners = new Vector3[6];
	private int[] triangles = new int[12];
	private Mesh mesh;

	// Use this for initialization
	void Start () {
		GetComponent<MeshFilter> ().mesh = mesh = new Mesh ();
		center = transform.position;
		this.Create ();
		this.gameObject.AddComponent <MeshCollider>();
	}

	//Create the hexagon out of points and triangles
	private void Create() {
		//Create the 6 corners of the hexagon
		for (int i = 0; i < 6; i++) {
			var degree = 60 * i;
			var radian = Mathf.PI / 180 * degree;
			corners[i] = new Vector3 (center.x + this.width * Mathf.Cos (radian), center.y, center.z + this.width * Mathf.Sin (radian));
		}

		mesh.vertices = corners;

		triangles [0] = 2;
		triangles [1] = 1;
		triangles [2] = 0;

		triangles [3] = 3;
		triangles [4] = 2;
		triangles [5] = 0;

		triangles [6] = 5;
		triangles [7] = 3;
		triangles [8] = 0;

		triangles [9] = 4;
		triangles [10] = 3;
		triangles [11] = 5;
		mesh.triangles = triangles;
	}

}
