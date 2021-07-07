using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int BreakableBricks; //Serialized for Debug
    
    //Cached References
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks()
    {
        ++BreakableBricks;
    }
    public void BlockDestroyed()
    {
        --BreakableBricks;
        if(BreakableBricks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
