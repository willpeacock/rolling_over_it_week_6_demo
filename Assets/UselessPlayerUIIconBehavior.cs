using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UselessPlayerUIIconBehavior : MonoBehaviour
{
	public Transform mainPlayerTransform;
	public TMP_Text statsText;

	private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
		playerRB = mainPlayerTransform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		transform.rotation = mainPlayerTransform.rotation;

		statsText.text = $"velocity: {playerRB.velocity}\nangular velocity: {playerRB.angularVelocity}\nrotation: {mainPlayerTransform.eulerAngles.z}°\nposition: {playerRB.position}";

	}
}
