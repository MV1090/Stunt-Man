using UnityEngine;

public class BaseLevel : MonoBehaviour
{
    public LevelController.LevelSelector level;
    protected LevelController context;
    public CameraController cameraRef;
    public Target target;

    public virtual void InitState(LevelController ctx)
    {
        context = ctx;
    }

    public virtual void EnterState()
    {

    }
    public virtual void ExitState()
    {

    }    

    public virtual void SetNextLevel(LevelController.LevelSelector nextLevel)
    {
        context.SetNextLevel(nextLevel);
    }
}
