using System;

namespace BulletMLLib.SharedProject.Nodes;

/// <summary>
/// This is a simple class used to create different types of nodes.
/// </summary>
public static class NodeFactory
{
    /// <summary>
    /// Given a node type, create the correct node.
    /// </summary>
    /// <returns>An instance of the correct node type</returns>
    /// <param name="nodeType">Node type that we want.</param>
    public static BulletMLNode CreateNode(ENodeName nodeType)
    {
        return nodeType switch
        {
            ENodeName.bullet => new BulletNode(),
            ENodeName.action => new ActionNode(),
            ENodeName.fire => new FireNode(),
            ENodeName.changeDirection => new ChangeDirectionNode(),
            ENodeName.changeSpeed => new ChangeSpeedNode(),
            ENodeName.accel => new AccelNode(),
            ENodeName.wait => new WaitNode(),
            ENodeName.repeat => new RepeatNode(),
            ENodeName.bulletRef => new BulletRefNode(),
            ENodeName.actionRef => new ActionRefNode(),
            ENodeName.fireRef => new FireRefNode(),
            ENodeName.vanish => new VanishNode(),
            ENodeName.horizontal => new HorizontalNode(),
            ENodeName.vertical => new VerticalNode(),
            ENodeName.term => new TermNode(),
            ENodeName.times => new TimesNode(),
            ENodeName.direction => new DirectionNode(),
            ENodeName.speed => new SpeedNode(),
            ENodeName.param => new ParamNode(),
            ENodeName.bulletml => new(ENodeName.bulletml),
            _ => throw new($"Unhandled type of ENodeName: {nodeType}")
        };
    }
}