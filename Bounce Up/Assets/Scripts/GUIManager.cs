using UnityEngine;

public class GUIManager : MonoBehaviour {

    public static GUIManager instance;

    public GameObject doubleJump, highJump, fastMove;

    private void Awake()
    {
        instance = this;
    }

    #region Show Power Up Icons
    public void showDoubleJump()
    {
        if (!doubleJump.activeSelf)
        {
            doubleJump.SetActive(true);
        }
    }

    public void showHighJump()
    {
        if (!highJump.activeSelf)
        {
            highJump.SetActive(true);
        }
    }

    public void showFastMove()
    {
        if (!fastMove.activeSelf)
        {
            fastMove.SetActive(true);
        }
    }
    #endregion

    #region Hide Power Up Icons
    public void hideDoubleJump()
    {
        if (doubleJump.activeSelf)
        {
            doubleJump.SetActive(false);
        }
    }

    public void hideHighJump()
    {
        if (highJump.activeSelf)
        {
            highJump.SetActive(false);
        }
    }

    public void hideFastMove()
    {
        if (fastMove.activeSelf)
        {
            fastMove.SetActive(false);
        }
    }
    #endregion
}
