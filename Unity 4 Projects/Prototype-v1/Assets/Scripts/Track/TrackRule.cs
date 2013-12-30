using UnityEngine;
using System.Collections;

public class TrackRule : MonoBehaviour 
{
	public RuleConfig _ruleConfig;
	public Rule _leftRule;
	public Rule _rightRule;

	public bool _enableOnAwake = false;
	public TrackRule _nextRule = null;

	public Transform _leftParticlePos;
	public Transform _rightParticlePos;

	private ParticleSystem _leftParticle = null;
	private ParticleSystem _rightParticle = null;

	private bool _ruleTriggered = false;

	void Awake()
	{
		if(_enableOnAwake)
		{
			InitParticles();
		}
	}

	public void InitParticles()
	{
		// Left side:
		InitParticle(_leftRule, ref _leftParticle, _leftParticlePos);

		// Right side:
		InitParticle(_rightRule, ref _rightParticle, _rightParticlePos);
	}

	private void InitParticle(Rule rule, ref ParticleSystem particle, Transform placeholder)
	{
		RuleConfig.ParticleShape particleShape = RuleConfig.ParticleShape.NONE;
		if(rule.HasShape())
		{
			particleShape = (RuleConfig.ParticleShape)rule.Shape;
		}
		
		particle = Instantiate(_ruleConfig.GetRuleParticle(particleShape), placeholder.position, placeholder.rotation) as ParticleSystem;
		particle.transform.parent = transform.parent;
		
		if(rule.HasColor())
		{
			particle.startColor = _ruleConfig.GetPickupColor(rule.Color);
		}
		
		particle.Play();
	}

	public void StopParticles()
	{
		// TODO: Let them fade out before stop!
		if(_leftParticle != null)
			_leftParticle.Stop();
		if(_rightParticle != null)
			_rightParticle.Stop();
	}
	
	public void OnTriggerEnter(Collider other) 
	{
		if(_ruleTriggered == false)
		{
			_ruleTriggered = true;
			StopParticles();

			// Is the HitObject the Avatar (or better asked, one of its arms)?
			ItemHit hitObject = other.gameObject.GetComponent<ItemHit>();
			if(hitObject != null)
			{
				RulesSwitcher ruleSwitcher = GameObject.Find("Rule Switcher").GetComponent<RulesSwitcher>();
				ruleSwitcher.SetLeftRule(_leftRule);
				ruleSwitcher.SetRightRule(_rightRule);

				if(_nextRule != null)
				{
					_nextRule.InitParticles();
				}

				Debug.Log ("RULE SWITCHED!");
			}
		}
	}
}
