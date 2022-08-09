using UnityEngine;
using UnityEngine.EventSystems;

namespace F4B1.UI
{
    public class SelectionManager : MonoBehaviour
    {
        private EventSystem _eventSystem;
        [SerializeField] private GameObject firstSelected;
        public GameObject FirstSelected
        {
            set => firstSelected = value;
        }
        public GameObject LastSelectedGameObject { get; private set; }

        private void Start()
        {
            _eventSystem = FindObjectOfType<EventSystem>();
            LastSelectedGameObject = firstSelected;
        }

        public void OnNavigate()
        {
            if (_eventSystem.currentSelectedGameObject != null) return;
            _eventSystem.SetSelectedGameObject(LastSelectedGameObject);
        }
        
        public void OnMouseMove()
        {
            if (_eventSystem.currentSelectedGameObject == null) return;
            LastSelectedGameObject = _eventSystem.currentSelectedGameObject;
        }
    }
}
