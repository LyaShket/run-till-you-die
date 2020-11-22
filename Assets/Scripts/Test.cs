﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    void Start()
    {
        transform.localPosition = new Vector2(-10, 6);
    }
	private void Update()
	{
        if (Input.GetMouseButton(0) && !GameManager.IsLosed && Player.Current.isGrounded)
        {
            Vector2 bgDir = Player.Current.playerDir * -1f;

            level1.transform.Translate(bgDir * Time.deltaTime / 3f);
            level2.transform.Translate(bgDir * Time.deltaTime / 6f);
            level3.transform.Translate(bgDir * Time.deltaTime / 10f);
            level4.transform.Translate(bgDir * Time.deltaTime / 15f);
        }
    }
}
