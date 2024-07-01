using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex = 1; // Initialisation of the sceneBuildIndex
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Destroy(gameObject);
            // Load random scene from build settings except for current scene
            // TODO : fix the bug where it load the current scene
            sceneBuildIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            while(sceneBuildIndex == SceneManager.GetSceneAt(SceneManager.sceneCount - 1).buildIndex) {
                sceneBuildIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            }
            
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene sc, LoadSceneMode loadSceneMode)
    {
        sc.GetRootGameObjects()[0].transform.position += new Vector3(20, 0, 0); // Move the loaded scene to the right by x units
    }
}