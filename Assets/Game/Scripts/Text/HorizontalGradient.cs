using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effect/HorizontalGradient")]
[RequireComponent(typeof(UnityEngine.UI.Text))]
public class HorizontalGradient : BaseMeshEffect
{
    public Color32 leftColor = new Color32(255, 255, 255, 255);
    public Color32 rightColor = new Color32(0, 0, 0, 255);
    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount < 4)
        {
            return;
        }
        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);
        float fMaxPosX = vertexList[0].position.x;
        float fMinPosX = vertexList[0].position.x;
        for (int index = 0; index < vertexList.Count; index++)
        {
            if (vertexList[index].position.x < fMinPosX)
            {
                fMinPosX = vertexList[index].position.x;
            }
            else if (vertexList[index].position.x > fMaxPosX)
            {
                fMaxPosX = vertexList[index].position.x;
            }
        }
        float fWidth = fMaxPosX - fMinPosX;
        int nWordCount = vh.currentVertCount / 4;
        UIVertex vertex = new UIVertex();
        for (int index = 0; index < nWordCount; index++)
        {
            for (int pIndex = 0; pIndex < 4; pIndex++)
            {
                int nVerterIndex = index * 4 + pIndex;
                vh.PopulateUIVertex(ref vertex, nVerterIndex);
                vertex.color = Color32.Lerp(leftColor, rightColor, (vertex.position.x - fMinPosX) / fWidth);
                vh.SetUIVertex(vertex, nVerterIndex);
            }
        }
    }
}