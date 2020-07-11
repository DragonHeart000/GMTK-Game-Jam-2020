﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class TreeClickableObject : ClickableObject
{
    public bool Fallen = false;

    bool IsBeingDraged = false;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBeingDraged)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                gameObject.transform.position = hit.point;
            }
        }
    }

    public override void BreakPower()
    {
        base.BreakPower();
        Destroy(gameObject);
    }

    public override void StartTelekinesisPower(Camera camera)
    {
        if (Fallen)
        {
            base.StartTelekinesisPower(camera);
            this.mainCamera = camera;
            IsBeingDraged = true;
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.AngleAxis(90, gameObject.transform.right);
            Fallen = true;
        }
    }

    public override void StopTelekinesisPower()
    {
            base.StopTelekinesisPower();
            IsBeingDraged = false;
            gameObject.GetComponent<Collider>().enabled = true;
    }
}