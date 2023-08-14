using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VersionManagerV2 : MonoBehaviour
{
    public bool guided = false;
    public InputActionReference change_version;
    public GameObject welcome_object;
    public List<GameObject> glassware;
    public GameObject step_1_object;
    [SerializeField]
    private GameObject greetings_obj;
    [SerializeField]
    private GameObject step1_obj_lec;
    [SerializeField]
    private AnimatorPassing anim_pass;

    private void Awake()
    {
        GameObject guided_object = GetChildWithName(welcome_object, "GuidedButton");
        Button guided_button = guided_object.GetComponent<Button>();

        guided_button.onClick.AddListener(OnGuidedPressed);

        GameObject free_object = GetChildWithName(welcome_object, "FreeButton");
        Button free_button = free_object.GetComponent<Button>();

        free_button.onClick.AddListener(OnFreePressed);

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
        anim_pass.avatar_anim.SetTrigger("Greet");
        greetings_obj.SetActive(true);
        StartCoroutine(StepOne());
        guided = true;
        change_version.action.started += OnPrimaryPress;
    }

    void OnFreePressed()
    {
        ChangeGlasswareVisibility(true);

        welcome_object.SetActive(false);
        guided = false;
        change_version.action.started += OnPrimaryPress;
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

    private IEnumerator StepOne()
    {
        yield return new WaitForSeconds(10);
        step_1_object.SetActive(true);
        step1_obj_lec.SetActive(true);
        anim_pass.avatar_anim.SetTrigger("Step1");
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