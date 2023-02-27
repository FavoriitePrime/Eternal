using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput
{
    Vector3 GetHorizontalInput(Transform transform);

    Vector3 GetVeritcalInput(Transform transform);

    Vector3 GetMouseInput();
}
