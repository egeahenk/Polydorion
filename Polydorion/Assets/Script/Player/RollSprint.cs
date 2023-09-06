using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollSprint : MonoBehaviour
{
    public PlayerMove pm;

    public float rollSpeed;
    public float rollTime;

    private bool isRolling = false;

    private void Start()
    {
        pm = GetComponent<PlayerMove>();
        cursorlock();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            StartCoroutine(DoRoll());
        }
    }

    public void cursorlock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    IEnumerator DoRoll()
    {
        isRolling = true;
        float startTime = Time.time;

        while (Time.time < startTime + rollTime)
        {
            pm.cch.Move(pm.MoveDir * rollSpeed * Time.deltaTime);
            yield return null;
        }

        isRolling = false;
    }
}
