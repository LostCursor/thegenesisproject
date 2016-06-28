using UnityEngine;
using System.Collections;
using UnityEditor;

public class Room : MonoBehaviour {
    
    public GameObject[] walls;
    public float[] dimensions = { 5.1f, 3.0f, 6.0f };
    public float wallThickness = 0.34f;
    public Vector3[] wallDirections =
    {
        //list of directions for walls
        Vector3.left,
        Vector3.right,
        Vector3.forward,
        Vector3.back
    };
    public Quaternion[] wallRots =
    {
        //left, right, forward, backward
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f),
    };
    public int[] moveIndex =
    {
        0,
        0,
        2,
        2
    };
    public bool[] expand =
    {
        true,
        true,
        false,
        false
    };
    public int[,] wallDimensions =
    {
        //contains indexes to dimensions array determining which ones to use, ordered: left, right, forward, backward.
        {2, 1},
        {2, 1},
        {1, 0},
        {1, 0}
    };
	private void Start () {
        //initialize the container room object
        GameObject room = new GameObject("Room");
        walls = new GameObject[6];
        //create the floor
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.transform.parent = room.transform;
        floor.name = "floor";
        floor.transform.localScale = new Vector3(dimensions[0] + 2 * wallThickness, wallThickness, dimensions[2] + 2 * wallThickness);
        floor.transform.localPosition = new Vector3(0f, 0f, 0f);
        //floor.transform.localRotation = Quaternion.Euler(-270f, 0f, 0f);
        walls[0] = floor;
        //create the vertical walls
        for (int i = 0; i < 4; i++)
        {
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.parent = room.transform;
            wall.name = "wall" + (i + 1);
            if (expand[i])
            {
                wall.transform.localScale = new Vector3(dimensions[wallDimensions[i, 0]] + (2 * wallThickness), wallThickness, dimensions[wallDimensions[i, 1]]);
            }
            else
            {
                wall.transform.localScale = new Vector3(dimensions[wallDimensions[i, 0]], wallThickness, dimensions[wallDimensions[i, 1]]);
            }
            //determine how much to move the wall by looking at the unused wall dimension value.
            wall.transform.localPosition = wallDirections[i] * ((dimensions[moveIndex[i]] + wallThickness) / 2.0f);
            wall.transform.Translate(new Vector3(0f, (dimensions[1] / 2), 0f));
            wall.transform.localRotation = wallRots[i];
            wall.transform.Rotate(new Vector3(0f, 90f, 0f));
            walls[i] = wall;
        }
        GameObject ceiling = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ceiling.transform.parent = room.transform;
        ceiling.name = "ceiling";
        ceiling.transform.localScale = new Vector3(dimensions[0] + 2 * wallThickness, wallThickness, dimensions[2] + 2 * wallThickness);
        ceiling.transform.localPosition = new Vector3(0f, dimensions[1] + (wallThickness / 2f), 0f);


    }
}
