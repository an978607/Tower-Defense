﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Lose : MonoBehaviour
{
    private bool mFaded = false;

    public float Duration = 0.4f;

    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvGroup,float start, float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
    }

    public void okButton()
    {
        SceneManager.LoadScene("LevelSelection");
    }

}
