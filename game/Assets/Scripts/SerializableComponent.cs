using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

class SerializableComponent:MonoBehaviour
{
    public byte componentNum;
    private struct SerializedGameObject
    {
        public byte ObjectNumber;
        public float xPos;
        public float yPos;
    }
    public override string ToString()
    {
        SerializedGameObject sgo = new SerializedGameObject();
        sgo.ObjectNumber = componentNum;
        sgo.xPos = transform.position.x;
        sgo.yPos = transform.position.y;
        return JsonUtility.ToJson(sgo);
    }
}
