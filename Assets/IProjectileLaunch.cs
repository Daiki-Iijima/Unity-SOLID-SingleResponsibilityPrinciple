using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileLaunch
{
    bool IsFire { get; }
    Action OnFire { get; set; }
}
