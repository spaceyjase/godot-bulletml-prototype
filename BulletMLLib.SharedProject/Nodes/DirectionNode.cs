namespace BulletMLLib.SharedProject.Nodes;

public class DirectionNode : BulletMLNode
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DirectionNode"/> class.
    /// </summary>
    public DirectionNode()
        : base(ENodeName.direction)
    {
        //set the default type to "aim"
        NodeType = ENodeType.aim;
    }

    /// <summary>
    /// Gets or sets the type of the node.
    /// This is virtual so sub-classes can override it and validate their own shit.
    /// </summary>
    /// <value>The type of the node.</value>
    public override ENodeType NodeType
    {
        get => base.NodeType;
        protected set
        {
            base.NodeType = value switch
            {
                ENodeType.absolute => value,
                ENodeType.relative => value,
                ENodeType.sequence => value,
                _ => ENodeType.aim
            };
        }
    }
}