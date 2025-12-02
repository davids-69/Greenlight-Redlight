using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
   public void ChangeScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo);
       

    }
}
