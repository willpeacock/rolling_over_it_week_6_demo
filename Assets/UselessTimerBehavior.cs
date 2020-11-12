using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UselessTimerBehavior : MonoBehaviour
{
	public TMP_Text timerText;

	private float timer = 5.6321f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime * 1.5f;

		timerText.text = $"<color=yellow>Warning:</color> {timer} second(s)";

	}
}
