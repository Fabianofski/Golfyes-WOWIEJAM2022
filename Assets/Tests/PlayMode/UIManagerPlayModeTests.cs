using System.Collections;
using F4B1.UI;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace F4B1.Tests.PlayMode
{
    public class UIManagerPlayModeTests
    {
        [UnityTest]
        public IEnumerator LoadNextScene()
        {
            SceneManager.LoadScene(0);
            yield return null;
            UIManager uiManager = new GameObject().AddComponent<UIManager>();
            uiManager.LoadNextScene();
            yield return null;
            Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);
        }
        
        [UnityTest]
        public IEnumerator LoadMenuScene()
        {
            SceneManager.LoadScene(1);
            yield return null;
            UIManager uiManager = new GameObject().AddComponent<UIManager>();
            uiManager.LoadMenuScene();
            yield return null;
            Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);
        }
        
        [UnityTest]
        public IEnumerator ReloadCurrentScene()
        {
            SceneManager.LoadScene(1);
            yield return null;
            UIManager uiManager = new GameObject().AddComponent<UIManager>();
            uiManager.ReloadCurrentScene();
            yield return null;
            Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);
        }
        
        // [UnityTest]
        // public IEnumerator QuitApplication()
        // {
        //     bool wantsToQuit = false;
        //     UIManager uiManager = new GameObject().AddComponent<UIManager>();
        //     Application.quitting += () => wantsToQuit = true;
        //     uiManager.QuitApplication();
        //     yield return null;
        //     Assert.IsTrue(wantsToQuit);
        // }
    }
}
