using UnityEngine;
using System.Collections;

public class TrackRule : MonoBehaviour 
{
	public RuleConfig _ruleConfig;
	public Rule _leftRule;
	public Rule _rightRule;

	public bool _enableOnAwake = false;
	public TrackRule _nextRule = null;

	public Transform _leftParticlePos; // TODO: If you rename this, all connections have to be set again...
	public Transform _rightParticlePos; // Same here!

	private Transform _leftShape = null;
	private Transform _rightShape = null;

	private bool _ruleTriggered = false;

	void Awake()
	{
		if(_enableOnAwake)
		{
			InitShapes();
		}
	}

	public void InitShapes()
	{
		// Left side:
		InitRule(_leftRule, ref _leftShape, _leftParticlePos);

		// Right side:
		InitRule(_rightRule, ref _rightShape, _rightParticlePos);
	}

	private void InitRule(Rule rule, ref Transform shape, Transform placeholder)
	{
		RuleConfig.RuleShape ruleShape = RuleConfig.RuleShape.NONE;
		if(rule.HasShape())
		{
			ruleShape = (RuleConfig.RuleShape)rule.Shape;
		}
		
		shape = Instantiate(_ruleConfig.GetRuleShapeTrans(ruleShape), placeholder.position, placeholder.rotation) as Transform;
		shape.parent = transform.parent;
		
		if(rule.HasColor())
		{
			Color col = _ruleConfig.GetPickupColor(rule.Color);
			col.a = 225.0f / 255.0f; // TODO: HARDCODED
			shape.renderer.material.color = col;
		}
	}

	// Knwon Bug: The Shape gets shortly full opaque, but the values tell me, that it should be transparent... No idea why.
	public IEnumerator RuleFadeOut()
	{
		float curTime = 0.0f;
		float duration = 1.0f;
		AnimationCurve curve = AnimationCurve.Linear(curTime, (225.0f / 255.0f), duration, 0.0f); // TODO: HARDCODED 225
		
		while(curTime < duration)
		{
			curTime += Time.deltaTime;
			
			// HACK: Don't know why there is such a huge problem with floats in C# -.-
			if(curTime >= duration)
			{
				break;
			}
			
			float alpha = curve.Evaluate(curTime);

			Color leftCol = _leftShape.renderer.material.color;
			leftCol.a = alpha;
			_leftShape.renderer.material.color = leftCol;

			Color rightCol = _rightShape.renderer.material.color;
			rightCol.a = alpha;
			_rightShape.renderer.material.color = rightCol;
			
			yield return new WaitForSeconds(Time.deltaTime);
		}
		
		_leftShape.gameObject.SetActive(false);
		_rightShape.gameObject.SetActive(false);
	}
	
	public void OnTriggerEnter(Collider other) 
	{
		if(_ruleTriggered == false)
		{
			_ruleTriggered = true;
			StartCoroutine(RuleFadeOut());

			// Is the HitObject the Avatar (or better asked, one of its arms)?
			ItemHit hitObject = other.gameObject.GetComponent<ItemHit>();
			if(hitObject != null)
			{
				RulesSwitcher ruleSwitcher = GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();
				ruleSwitcher.SetLeftRule(_leftRule);
				ruleSwitcher.SetRightRule(_rightRule);

				if(_nextRule != null)
				{
					_nextRule.InitShapes();
				}

				Debug.Log ("RULE SWITCHED!");
			}
		}
	}
}

public partial class CleanTrackData : MonoBehaviour 
{
	// The first rule for this track. (All other can be get via the linked rule system -> _nextRule)
	public TrackRule firstRule;
}
