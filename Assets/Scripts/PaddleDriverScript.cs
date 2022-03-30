using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleDriverScript : MonoBehaviour
{

	private GameState state;
    public float hitPower = 1000f;
    public float paddleDamper = 10f;
    public float upPosition = 45f;
    public float downPosition = 0f;

    public HingeJoint hinge;
    public string inputName;

    void Awake()
    {
	    GameManager.OnGameStateChanged += GMOnGameStateChanged;
    }

	// Use this for initialization
	void Start ()
	{
		
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        JointSpring spring = new JointSpring
        {
            spring = hitPower,
            damper = paddleDamper
        };
        if (state == GameState.Playing)
        {
	        spring.targetPosition = Input.GetKey(KeyCode.Space) ? upPosition : downPosition;
	        hinge.spring = spring;
	        hinge.useLimits = true;
        }
        else
        {
	        //If not in playing don't allow paddle movement. 
	        hinge.spring = spring;
	        hinge.useLimits = false;
        }
	}

	private void GMOnGameStateChanged(GameState obj)
	{
		state = obj;
	}

	private void onDestroy()
	{
		GameManager.OnGameStateChanged -= GMOnGameStateChanged;
	}
}
