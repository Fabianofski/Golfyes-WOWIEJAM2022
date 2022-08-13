using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class WallTriggerable : MonoBehaviour, ITriggerable
    {
        private Collider2D _collider2D;

        private void Start()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        public void Trigger(float offset)
        {
            Invoke(nameof(SetWallActive), offset);
        }

        public void Trigger(bool ballIsStill)
        {
            if(ballIsStill) SetWallActive();
        }

        private void SetWallActive()
        {
            _collider2D.enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}