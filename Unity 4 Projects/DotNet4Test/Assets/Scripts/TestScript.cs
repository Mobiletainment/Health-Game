using UnityEngine;
using System.Collections;
using SkillSystem;

public class TestScript : MonoBehaviour {

    private static SkillManager _sm;

    private static BasicSkill _velocity;
    private static BasicSkill _size;
    private static BasicSkill _care;

	// Use this for initialization
	void Start () {
        _sm = new SkillManager();

        _velocity = new BasicSkill("Velocity", "Slow", "Fast");
        _size = new BasicSkill("Size", "Tiny", "Tall");
        _care = new BasicSkill("Care", "Careless", "Careful");

        Debug.Log(_velocity.Name);
        Debug.Log(_size.Name);
        Debug.Log(_care.Name);

        _sm.AddSkill(_velocity);
        _sm.AddSkill(_size);
        _sm.AddSkill(_care);

        _sm.SaveSkillsToFile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
