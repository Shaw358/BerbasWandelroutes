using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void LoadNextSceneAsync()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}