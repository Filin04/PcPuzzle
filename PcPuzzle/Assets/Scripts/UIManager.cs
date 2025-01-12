using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI OnHoverName;
    [SerializeField] private TextMeshProUGUI OnHoverDescription;
    [SerializeField] private GameObject windowInfo;
    [SerializeField] private GameObject windowEndGame;
    [SerializeField] private List<GameObject> computerFull;
    /*private List<GameObject> currentComputer;*/


    public void Update()
    {
        if (computerFull != null)
        {
            if(computerFull.FirstOrDefault(n => n.activeSelf == true) == null)
            {
                EndGame();
            }
            /*for (int i = 0; i < computerFull.Count; i++)
            {
                if (!computerFull[i].activeSelf)
                {
                    EndGame();
                }
            }*/
        }
    }
    public void OpenInfo(ComputerComponent component)
    {
        windowInfo.SetActive(true);
        OnHoverName.text = component.ComponentName;
        OnHoverDescription.text = component.Description;
    }
    public void EndGame()
    {
        windowEndGame.SetActive(true);
    }
    public void SetHoverName(string value)
    {
        OnHoverName.text = value;
    }
    public void SetHoverDescription(string value)
    {
        OnHoverDescription.text = value;
    }
    public void ClaerHoverText()
    {
        OnHoverName.text = "";
        OnHoverDescription.text = "";
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
