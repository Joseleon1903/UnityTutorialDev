using UnityEngine;
using System.Collections;

public abstract class Command 
{
    protected IEntity _entity;

    protected Command(IEntity entity)
    {
        this._entity = entity;
    }

    public abstract void Execute();

    public abstract void Undo();
}
