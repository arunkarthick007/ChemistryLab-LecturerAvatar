using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class VersionManager : MonoBehaviour
{
    public bool guided = false;
    public InputActionReference change_version;
    public GameObject welcome_object;
    public List<GameObject> glassware;
    public GameObject step_1_object;
    public AnimatorPass anim_pass;

    private void Awake()
    {
        GameObject guided_object = GetChildWithName(welcome_object, "GuidedButton");
        Button guided_button = guided_object.GetComponent<Button>();

        guided_button.onClick.AddListener(OnGuidedPressed);

        GameObject free_object = GetChildWithName(welcome_object, "FreeButton");
        Button free_button = free_object.GetComponent<Button>();
    
        free_button.onClick.AddListener(OnFreePressed);

        GameObject menu_object = GetChildWithName(welcome_object, "MainMenu");
        Button menu_button = menu_object.GetComponent<Button>();

        menu_button.onClick.AddListener(OnMenuPressed);
    }

    private void OnDestroy()
    {
        change_version.action.started -= OnPrimaryPress;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeGlasswareVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGuidedPressed() 
    {
        ChangeGlasswareVisibility(true);

        welcome_object.SetActive(false);
        step_1_object.SetActive(true);
        guided = true;
        change_version.action.started += OnPrimaryPress;
        anim_pass.avatar_anim.SetTrigger("Greet");
    }

    void OnFreePressed()
    {
        ChangeGlasswareVisibility(true);

        welcome_object.SetActive(false);
        guided = false;
        change_version.action.started += OnPrimaryPress;
        anim_pass.avatar_anim.SetTrigger("Greet");
    }

     void OnMenuPressed()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    void ChangeGlasswareVisibility(bool visible) 
    {
        foreach (GameObject glass in glassware) 
        {
            glass.SetActive(visible);
        }
    }

    private void OnPrimaryPress(InputAction.CallbackContext context)
    {
        guided = !guided;
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
}
