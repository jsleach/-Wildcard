using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGridGenerator : MonoBehaviour {

	public HexGridShape gridShape;
	public int radius;
	public List<GameObject> cells;

	// Use this for initialization
	void Start () {
		var hexPrefab = Resources.Load ("HexTile");
		GameObject newHex;
		switch (gridShape) {
		case HexGridShape.Hexagon:
			radius--;
			for (var i = -radius; i <= radius; i++) {
				var j1 = Mathf.Max (-radius, -i - radius);
				var j2 = Mathf.Min (radius, -i + radius);
				for (var j = j1; j <= j2; j++) {
					newHex = (GameObject)Instantiate (hexPrefab, this.transform);
					newHex.GetComponent<HexagonCell> ().CubeCoords = new Vector3 (i, j, (-i - j));
					cells.Add (newHex);
				}
			}
			break;

		case HexGridShape.Parallelogram:
			for (var i = 0; i < radius; i++) {
				for (var j = 0; j < radius; j++) {
					newHex = (GameObject)Instantiate (hexPrefab, this.transform);
					newHex.GetComponent<HexagonCell> ().CubeCoords = new Vector3 (i, j, (-i - j));
					cells.Add (newHex);
				}
			}
			break;

		case HexGridShape.Square:
			for (var i = 0; i < radius; i++) {
				var offset = Mathf.Floor (i / 2);
				for (var j = -offset; j < radius - offset; j++) {
					newHex = (GameObject)Instantiate (hexPrefab, this.transform);
					newHex.GetComponent<HexagonCell> ().CubeCoords = new Vector3 (i, j, (-i - j));
					cells.Add (newHex);
				}
			}
			break;

		case HexGridShape.Triangle:
			for (var i = 0; i < radius; i++) {
				for (var j = 0; j < radius - i; j++) {
					newHex = (GameObject)Instantiate (hexPrefab, this.transform);
					newHex.GetComponent<HexagonCell> ().CubeCoords = new Vector3 (i, j, (-i - j));
					cells.Add (newHex);
				}
			}
			break;
		
		case HexGridShape.Custom:
			// Probably be the most common, used for more detailed generation. likely from a file or somesort

			// NOT YET IMPLEMENTED
			break;
		}
	}
}

public enum HexGridShape
{
	Hexagon, Triangle, Square, Parallelogram, Custom
}
