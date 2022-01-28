using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected IEntity entity;

    public Command(IEntity entity)
    {
        this.entity = entity;
    }

    public abstract IEnumerator Execute();
    public abstract IEnumerator Undo();
}

