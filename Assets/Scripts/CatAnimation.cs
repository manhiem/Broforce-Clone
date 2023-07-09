using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator catAnim;
    [SerializeField]
    private AnimationClip[] animations;

    // Start is called before the first frame update
    void Start()
    {
        int maxAnim = animations.Length;
        catAnim.Play(animations[Random.Range(0, maxAnim)].name);
    }
}
