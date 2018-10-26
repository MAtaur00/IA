using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// TODO 1: Create a simple class to contain one entry in the blackboard
// should at least contain the gameobject, position, timestamp and a bool
// to know if it is in the past memory

public class Blackboard_Entry : MonoBehaviour
{
    public GameObject body;
    public Vector3 position = Vector3.zero;
    public float time = 0.0f;
    public bool inMemory = false;

    public Blackboard_Entry (GameObject body, Vector3 position, float time, bool inMemory)
    {
        this.body = body;
        this.position = position;
        this.time = time;
        this.inMemory = inMemory;
    }
}

public class AIMemory : MonoBehaviour {

    public GameObject Cube;
	public Text Output;
    private Dictionary<string, Blackboard_Entry> blackboard;
    public PerceptionEvent perception;

    // TODO 2: Declare and allocate a dictionary with a string as a key and
    // your previous class as value

    // TODO 3: Capture perception events and add an entry if the player is detected
    // if the player stop from being seen, the entry should be "in the past memory"

    // Use this for initialization
    void Start ()
    {
        blackboard = new Dictionary<string, Blackboard_Entry>();
        perception = GetComponent<PerceptionEvent>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (perception.type == PerceptionEvent.types.NEW)
        {
            Blackboard_Entry entry = new Blackboard_Entry(perception.go, perception.go.transform.position, Time.time, false);
            blackboard.Add(perception.go.ToString(), entry);
        }
        else if (perception.type == PerceptionEvent.types.LOST)
        {
            foreach (KeyValuePair<string, Blackboard_Entry> entry in blackboard)
            {
                if (entry.Key.Equals(perception.go.ToString()))
                {
                    entry.Value.inMemory = true;
                    Cube.transform.position = entry.Value.body.transform.position;
                    break;
                }
            }
        }
		// TODO 4: Add text output to the bottom-left panel with the information
		// of the elements in the Knowledge base

		Output.text = "test";
	}

}
