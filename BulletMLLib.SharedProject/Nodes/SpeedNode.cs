namespace BulletMLLib.SharedProject.Nodes;

public class SpeedNode : BulletMLNode
{
    public SpeedNode()
        : base(ENodeName.speed)
    {
        NodeType = ENodeType.absolute;
    }
}