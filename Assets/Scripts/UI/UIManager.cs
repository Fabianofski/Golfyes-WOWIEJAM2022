using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace F4B1.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private BoolVariable pauseToggled;
        public BoolVariable PauseToggled
        {
            set => pauseToggled = value;
        }
        
        public void OnPause()
        {
            pauseToggled.Value = !pauseToggled.Value;
        }
        
        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(0);
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}
