using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPass : MonoBehaviour
{
    public Animator avatar_anim;
    // Start is called before the first frame update
    void Start()
    {
        avatar_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
