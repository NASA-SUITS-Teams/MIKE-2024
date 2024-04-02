using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;

public enum MenuType
{
    VitalsMenu,
    InputMenu,
    HUDMenu,
    SettingsMenu
}

public class LMCCMenuSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> menuPrefabs;
    [SerializeField] private GameObject sreenContainerPrefab;
    [SerializeField] private Transform spawnLocation;

    private Dictionary<MenuType, GameObject> menuDict;
    public Dictionary<MenuType, LMCCScreenContainerWidget> ActiveScreens { get; private set; }

    private LMCCScreenContainerWidget cachedScreenContainer;
    private LMCCScreenWidget cachedScreen;

    // Start is called before the first frame update
    void Start()
    {
        menuDict = new Dictionary<MenuType, GameObject>();
        ActiveScreens = new Dictionary<MenuType, LMCCScreenContainerWidget>();
        for (int i = 0; i < menuPrefabs.Count; i++)
        {
            menuDict.Add((MenuType)i, menuPrefabs[i]);
        }
    }

    public void SpawnMenu(int i)
    {
        SpawnMenu((MenuType)i);
    }
 
    public void SpawnMenu(MenuType menuType)
    {
        if(ActiveScreens.ContainsKey(menuType))
        {
            // Do Nothing
            Debug.Log("Menu already active");
            return;
        }

        cachedScreenContainer = Instantiate(sreenContainerPrefab, spawnLocation).GetComponent<LMCCScreenContainerWidget>();
        cachedScreen = Instantiate(menuDict[menuType], cachedScreenContainer.transform).GetComponent<LMCCScreenWidget>();//screenContainer.transform.position, screenContainer.transform.rotation, screenContainer.transform);
        ActiveScreens.Add(menuType, cachedScreenContainer);
        Invoke("ActivateScreenContainer", 0.1f);
        //screenContainer.GetComponent<MIKEWidget>().Activate();
    }

    private void ActivateScreenContainer()
    {
        cachedScreenContainer.Activate();
        //activeScreen.Activate();
        cachedScreenContainer = null;
        cachedScreen = null;
    }
}
