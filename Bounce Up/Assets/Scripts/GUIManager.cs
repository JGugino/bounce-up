using UnityEngine;

public class GUIManager : MonoBehaviour {

    public static GUIManager instance;

    [Header("Power Up Object")]
    public GameObject doubleJump, highJump, fastMove;


    [Header("Screen")]
    public GameObject mainMenu, levelSelect;

    [Header("Levels")]
    public GameObject levelOne, levelTwo, levelThree;


    [Header("UI")]
    public GameObject gameUI;

    private void Awake()
    {
        instance = this;
    }

    #region UI Controls
    public void openGameUI()
    {
        if (!gameUI.activeSelf)
        {
            gameUI.SetActive(true);
        }
    }

    public void closeGameUI()
    {
        if (gameUI.activeSelf)
        {
            gameUI.SetActive(false);
        }
    }
    #endregion

    #region Level Controls
    public void openLevelOne()
    {
        levelSelect.SetActive(false);

        openGameUI();

        if (!levelOne.activeSelf)
        {
            levelOne.SetActive(true);
        }
    }

    public void closeLevelOne()
    {
        levelSelect.SetActive(false);

        if (levelOne.activeSelf)
        {
            levelOne.SetActive(false);
        }
    }

    public void openLevelTwo()
    {
        levelSelect.SetActive(false);

        openGameUI();

        if (!levelTwo.activeSelf)
        {
            levelTwo.SetActive(true);
        }
    }

    public void closeLevelTwo()
    {
        levelSelect.SetActive(false);

        openGameUI();

        if (levelTwo.activeSelf)
        {
            levelTwo.SetActive(false);
        }
    }

    public void openLevelThree()
    {
        levelSelect.SetActive(false);

        openGameUI();

        if (!levelThree.activeSelf)
        {
            levelThree.SetActive(true);
        }
    }

    public void closeLevelThree()
    {
        levelSelect.SetActive(false);

        openGameUI();

        if (levelThree.activeSelf)
        {
            levelThree.SetActive(false);
        }
    }
    #endregion

    #region Menu Controls

    public void openMainMenu()
    {
        if (!mainMenu.activeSelf)
        {
            levelSelect.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void closeMainMenu()
    {
        if (mainMenu.activeSelf)
        {
            levelSelect.SetActive(false);
            mainMenu.SetActive(false);
        }
    }

    public void openLevelSelect()
    {
        if (!levelSelect.activeSelf)
        {
            levelSelect.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void closeLevelSelect()
    {
        if (!levelSelect.activeSelf)
        {
            levelSelect.SetActive(false);
            mainMenu.SetActive(false);
        }
    }

    public void closeGame()
    {
        Application.Quit();
    }

    #endregion

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
