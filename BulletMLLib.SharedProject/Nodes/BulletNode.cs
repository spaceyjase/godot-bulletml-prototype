namespace BulletMLLib.SharedProject.Nodes;

public class BulletNode : BulletMLNode
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BulletNode"/> class.
    /// </summary>
    public BulletNode()
        : this(ENodeName.bullet) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BulletNode"/> class.
    /// this is the constructor used by sub classes
    /// </summary>
    /// <param name="eNodeType">the node type.</param>
    public BulletNode(ENodeName eNodeType)
        : base(eNodeType) { }
}