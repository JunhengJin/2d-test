using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effect/VerticalGradient")]
[RequireComponent(typeof(Text))]
public class VerticalGradient : BaseMeshEffect
{
    public Color32 topColor = new Color32(255, 255, 255, 255);
    public Color32 bottomColor = new Color32(0, 0, 0, 255);
    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount < 4)
        {
            return;
        }
        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);
        float fMaxPosY = vertexList[0].position.y;
        float fMinPosY = vertexList[0].position.y;
        for (int index = 0; index < vertexList.Count; index++)
        {
            if (vertexList[index].position.y < fMinPosY)
            {
                fMinPosY = vertexList[index].position.y;
            }
            else if (vertexList[index].position.y > fMaxPosY)
            {
                fMaxPosY = vertexList[index].position.y;
            }
        }
        float fHeight = fMaxPosY - fMinPosY;
        int nWordCount = vh.currentVertCount / 4;
        UIVertex vertex = new UIVertex();
        for (int index = 0; index < nWordCount; index++)
        {
            for (int pIndex = 0; pIndex < 4; pIndex++)
            {
                int nVerterIndex = index * 4 + pIndex;
                vh.PopulateUIVertex(ref vertex, nVerterIndex);
                vertex.color = Color32.Lerp(bottomColor, topColor, (vertex.position.y - fMinPosY) / fHeight);
                vh.SetUIVertex(vertex, nVerterIndex);
            }
        }
    }
}