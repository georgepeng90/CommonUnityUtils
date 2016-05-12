using UnityEngine;
using System.Collections;

namespace Battle
{
	public class UnitAnimator : MonoBehaviour 
	{
	    private Vector3 _positionCache;
	    private Animator _animator;
	    private float _toRadian;
	    private SpriteRenderer _render;
	
		// Use this for initialization
		void Start () 
	    {
	        _toRadian = Mathf.PI / 180.0f;
	        _positionCache = transform.position;
	        _animator = GetComponent<Animator>();
	        _render = GetComponent<SpriteRenderer>();
		}
		
		// Update is called once per frame
		void Update () 
	    {
	        Vector3 currentPosition = transform.position;
	        Vector3 delta = currentPosition - _positionCache;
	        if (delta.sqrMagnitude > 0.0f)
	        {
	            float angle = Vector3.Angle(delta, Vector3.right) * _toRadian;
	            if (delta.y < 0)
	            {
	                angle = -angle;
	            }
	            _animator.SetFloat("y", Mathf.Sin(angle));
	            if (delta.x > 0)
	            {
	                _render.flipX = false;
	            }
	            else
	            {
	                _render.flipX = true;
	            }
	
	            _render.sortingOrder = -(int)(transform.position.y * 10.0f);
	        }
	
	        _positionCache = currentPosition;
		}
	}
}
