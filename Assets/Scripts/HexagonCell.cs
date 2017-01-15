using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexagonCell : MonoBehaviour {

	public bool isTaken;
	public Vector2 OffsetCoords;
	public Vector3 CubeCoords;

	private static readonly Vector3[] _neighbors =  {
		new Vector3(+1, -1, 0), new Vector3(+1, 0, -1), new Vector3(0, +1, -1),
		new Vector3(-1, +1, 0), new Vector3(-1, 0, +1), new Vector3(0, -1, +1)};

	// Use this for initialization
	void Start () {
		//this.transform.position = this.CubeCoords;
		this.OffsetCoords = CubeToOffset();

		this.transform.position = new Vector3 (OffsetCoords.x * 1.5f, 0, Mathf.Sqrt (3) * OffsetCoords.y);

		this.GetComponent<MeshRenderer> ().material.color = Color.white;
	}

	void OnMouseDown(){
		Select();
	}

	public void Select() {
		this.GetComponent<MeshRenderer> ().material.color = Color.blue;
		foreach (var cell in GetNeighbours(this.gameObject.transform.parent.GetComponent<HexGridGenerator>().cells)) {
			cell.GetComponent<HexagonCell> ().Highlight ();
		}
	}

	public void Highlight() {
		this.GetComponent<MeshRenderer> ().material.color = Color.green;
	}

	public Vector2 CubeToOffset()  {
		return new Vector2 (CubeCoords.x, CubeCoords.z + (CubeCoords.x + (CubeCoords.x % 1)) / 2);
	}

	public List<GameObject> GetNeighbours(List<GameObject> cells)
	{
		List<GameObject> neighbors = new List<GameObject> ();
		foreach (var direction in _neighbors) {
			var neighbour = cells.Find (c => c.GetComponent<HexagonCell>().CubeCoords == (CubeCoords + direction));
			if (neighbour == null)
				continue;
			neighbors.Add (neighbour);
		}
		return neighbors;
	}

}
