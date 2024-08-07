using System.Collections;
using System.Collections.Generic;
using TMPro; // Ensure this namespace is included
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectPuzzleButton : MonoBehaviour
{
    public GameData gameData;
    public GameLevelData levelData;
    public TextMeshProUGUI categoryText;
    public Image progressBarFilling;

    private string gameSceneName = "GameScene";
    private bool _levelLocked;


    // Start is called before the first frame update
    void Start()
    {
        _levelLocked = false;
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = true;
        UpdateButtonInformation();

        if (_levelLocked)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateButtonInformation()
    {
        var currentIndex = 1;
        var totalBoards = 0;

        foreach (var data in levelData.data)
        {
            if (data.categoryName == gameObject.name)
            {
                currentIndex = DataSaver.ReadCatologryIndexValue(gameObject.name);
                totalBoards = data.boardData.Count;

                if (levelData.data[0].categoryName == gameObject.name && currentIndex < 0)
                {
                    DataSaver.SaveCatologryData(levelData.data[0].categoryName, 0);
                    currentIndex = DataSaver.ReadCatologryIndexValue(gameObject.name);
                    totalBoards = data.boardData.Count;
                }
            }
        }

        if (currentIndex == -1)
        {
            _levelLocked = true;
        }
        categoryText.text = _levelLocked ? string.Empty : (currentIndex.ToString() + "/" + totalBoards.ToString());
        progressBarFilling.fillAmount = (currentIndex > 0 && totalBoards > 0) ? ((float)currentIndex / (float)totalBoards) : 0f;
    }

    private void OnButtonClick()
    {
        gameData.selectCategoryName = gameObject.name;
        SceneManager.LoadScene(gameSceneName);
    }
}
