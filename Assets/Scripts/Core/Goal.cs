using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class Goal : MonoBehaviour
    {

        [Header("Goal")]
        [SerializeField] private LayerMask ballLayerMask;
        [SerializeField] private float ballSpeedThreshold;
        [SerializeField] private float ballDistanceThreshold;
        [SerializeField] private BoolVariable levelIsCompleted;

        [Header("Animation")] 
        [SerializeField] private LeanTweenType ballScaleTweenType;
        [SerializeField] private float ballScaleTweenDuration;
        
        
        private void OnTriggerStay2D(Collider2D col)
        {
            if (levelIsCompleted.Value) return;
            
            // Is Layer on LayerMask (Bitshift or something idk)
            var onLayerMask = ballLayerMask == (ballLayerMask | 1 << col.gameObject.layer);
            if (!onLayerMask) return;

            var rb2d = col.GetComponent<Rigidbody2D>();
            var ballDistance = Vector3.Distance(transform.position, col.transform.position) ;
            if (rb2d.velocity.magnitude < ballSpeedThreshold && ballDistance < ballDistanceThreshold)
            {
                Debug.Log("Goal");
                levelIsCompleted.Value = true;
                rb2d.velocity = Vector2.zero;
                col.transform.position = transform.position;
                LeanTween.scale(col.gameObject, Vector3.zero, ballScaleTweenDuration).setEase(ballScaleTweenType);
            }
        }
    }
}
