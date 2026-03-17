using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Week05
{
    public class Week05 : MonoBehaviour
    {
        async Task Start()
        {
            //SceneManager.LoadScene(1, LoadSceneMode.Additive);
            //SceneManager.LoadScene(2, LoadSceneMode.Additive);
            //StartCoroutine(LoadingScenes(1));
            //StartCoroutine(LoadingScenes(2));

            await SceneManager.UnloadSceneAsync(1, LoadScewneMode.Additive);
            await SceneManager.UnloadSceneAsync(2, LoadScewneMode.Additive);
            LightProbes.Tetrahedralize();

        }
        IEnumerator LoadingScenes(int sceneNumber)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Additive);

            while (!asyncLoad.isDone)
            {   
                print("is loading: " + asyncLoad.progress + "% complete");
                yield return null;
            }
            LightProbes.Tetrahedralize();
            yield return null;
        }
    }
}
