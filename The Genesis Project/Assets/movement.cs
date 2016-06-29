using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    
    // Create Variables.
    private Rigidbody John_Rigidbody;
    private float X_Speed;
    private float Z_Speed;

    // Get the rigidbody component from johnsprite and stoe it in John_Rigidbody variable.
    void Start() {
        John_Rigidbody = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void FixedUpdate() {
        // Check for input from left/right and A/D buttons then turn it into speed on the X axis.
        X_Speed = Input.GetAxis("Horizontal") * 5;
        // Check for input from up/down and W/S buttons then turn it into speed on the Y axis.
        Z_Speed = Input.GetAxis("Vertical") * 5;
        // Vector3 changes the movement speed from an object by using 3 variables for each of the axises X(left/right), Y(up/down) and Z(forward/backward).
        // Because the camera is isometric sending just the X_speed or Z_speed variable would move john diagonally, So i send the X_Speed + the Z_Speed to move john left and right properly and the Z_Speed - the X_Speed to move john forwards and backwards properly.
        // The problem with this script is that it relies on the axis placement so when the camera changes position john's movement doesnt change with it. But its late and i can probably fix that tomorrow.
        John_Rigidbody.velocity = new Vector3(X_Speed + Z_Speed, 0, Z_Speed - X_Speed);
    }
}
