using System.Collections;
using F4B1.UI;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace F4B1.Tests.PlayMode
{
    public class SelectionManagerPlayModeTests
    {
        private EventSystem _eventSystem;
        private GameObject _firstSelected;
        private SelectionManager _selectionManager;
        
        [UnitySetUp]
        public IEnumerator Setup()
        {
            _eventSystem = new GameObject().AddComponent<EventSystem>();
            _firstSelected = new GameObject();
            _selectionManager = new GameObject().AddComponent<SelectionManager>();
            _selectionManager.FirstSelected = _firstSelected;
            yield return null;
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            Object.Destroy(_eventSystem);
            Object.Destroy(_firstSelected);
            Object.Destroy(_selectionManager.gameObject);
            yield return null;
        }
        
        [Test]
        public void Start()
        {
            Assert.AreEqual(_firstSelected,  _selectionManager.LastSelectedGameObject);
        }
        
        [Test]
        public void OnNavigate_NothingSelected_SelectControl()
        {
            _eventSystem.SetSelectedGameObject(null);
            _selectionManager.OnNavigate();
            
            Assert.AreEqual(_firstSelected, _eventSystem.currentSelectedGameObject);
            Assert.AreEqual(_firstSelected, _selectionManager.LastSelectedGameObject);
        }
        
        [Test]
        public void OnNavigate_ControlSelected_DoNothing()
        {
            GameObject selected = new GameObject();
            selected.AddComponent<Button>();
            _eventSystem.SetSelectedGameObject(selected);
            _selectionManager.OnNavigate();
            
            Assert.AreEqual(_firstSelected,  _selectionManager.LastSelectedGameObject);
            Assert.AreEqual(selected, _eventSystem.currentSelectedGameObject);
        }
        
        [Test]
        public void OnMouseMove_ControlSelected_SaveSelectedControl()
        {
            GameObject selected = new GameObject();
            selected.AddComponent<Button>();
            _eventSystem.SetSelectedGameObject(selected);
            _selectionManager.OnMouseMove();
            
            Assert.AreEqual(selected,  _selectionManager.LastSelectedGameObject);
            Assert.AreEqual(selected, _eventSystem.currentSelectedGameObject);
        }
        
        [Test]
        public void OnMouseMove_NothingSelected_DoNothing()
        {
            _eventSystem.SetSelectedGameObject(null);
            _selectionManager.OnMouseMove();
            
            Assert.AreEqual(_firstSelected,  _selectionManager.LastSelectedGameObject);
            Assert.AreEqual(null, _eventSystem.currentSelectedGameObject);
        }
    }
}