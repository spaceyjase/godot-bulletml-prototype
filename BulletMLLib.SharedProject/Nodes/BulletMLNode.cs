using System;
using System.Collections.Generic;
using System.Xml;

namespace BulletMLLib
{
  /// <summary>
  /// This is a single node from a BulletML document.
  /// Used as the base node for all teh other node types.
  /// </summary>
  public class BulletMLNode
  {
    #region Members

    /// <summary>
    /// The XML node name of this item
    /// </summary>
    public ENodeName Name { get; }

    /// <summary>
		/// Gets or sets the type of the node.
		/// This is virtual so sub-classes can override it and validate on their own.
		/// </summary>
		/// <value>The type of the node.</value>
		public virtual ENodeType NodeType { get; protected set; } = ENodeType.none;

    /// <summary>
		/// The label of this node
		/// This can be used by other nodes to reference this node
		/// </summary>
		public string Label { get; private set; }

    /// <summary>
    /// An equation used to get a value of this node.
    /// </summary>
    /// <value>The node value.</value>
    protected BulletMLEquation NodeEquation = new BulletMLEquation();

    /// <summary>
    /// A list of all the child nodes for this dude
    /// </summary>
    public List<BulletMLNode> ChildNodes { get; }

    /// <summary>
    /// pointer to the parent node of this dude
    /// </summary>
    protected BulletMLNode Parent { get; private set; }

    #endregion //Members

    #region Methods

    /// <summary>
    /// Initializes a new instance of the <see cref="BulletMLLib.BulletMLNode"/> class.
    /// </summary>
    public BulletMLNode(ENodeName nodeType)
    {
      ChildNodes = new List<BulletMLNode>();
      Name = nodeType;
      //NodeType = ENodeType.none;
    }

    /// <summary>
    /// Convert a string to it's ENodeType enum equivalent
    /// </summary>
    /// <returns>ENodeType: the nuem value of that string</returns>
    /// <param name="str">The string to convert to an enum</param>
    public static ENodeType StringToType(string str)
    {
      //make sure there is something there
      if (string.IsNullOrEmpty(str))
      {
        return ENodeType.none;
      }

      return (ENodeType)Enum.Parse(typeof(ENodeType), str);
    }

    /// <summary>
    /// Convert a string to it's ENodeName enum equivalent
    /// </summary>
    /// <returns>ENodeName: the nuem value of that string</returns>
    /// <param name="str">The string to convert to an enum</param>
    public static ENodeName StringToName(string str)
    {
      return (ENodeName)Enum.Parse(typeof(ENodeName), str);
    }

    /// <summary>
    /// Gets the root node.
    /// </summary>
    /// <returns>The root node.</returns>
    public BulletMLNode GetRootNode()
    {
      //recurse up until we get to the root node
      return null != Parent ? Parent.GetRootNode() : this;
    }

    /// <summary>
    /// Find a node of a specific type and label
    /// Recurse into the xml tree until we find it!
    /// </summary>
    /// <returns>The label node.</returns>
    /// <param name="label">Label of the node we are looking for</param>
    /// <param name="name">name of the node we are looking for</param>
    public BulletMLNode FindLabelNode(string strLabel, ENodeName eName)
    {
      //this uses breadth first search, since labelled nodes are usually top level

      //Check if any of our child nodes match the request
      for (int i = 0; i < ChildNodes.Count; i++)
      {
        if ((eName == ChildNodes[i].Name) && (strLabel == ChildNodes[i].Label))
        {
          return ChildNodes[i];
        }
      }

      //recurse into the child nodes and see if we find any matches
      for (int i = 0; i < ChildNodes.Count; i++)
      {
        BulletMLNode foundNode = ChildNodes[i].FindLabelNode(strLabel, eName);
        if (null != foundNode)
        {
          return foundNode;
        }
      }

      //didnt find a BulletMLNode with that name :(
      return null;
    }

    /// <summary>
    /// Find a parent node of the specified node type
    /// </summary>
    /// <returns>The first parent node of that type, null if none found</returns>
    /// <param name="nodeType">Node type to find.</param>
    public BulletMLNode FindParentNode(ENodeName nodeType)
    {
      //first check if we have a parent node
      if (null == Parent)
      {
        return null;
      }

      if (nodeType == Parent.Name)
      {
        //Our parent matches the query, return it!
        return Parent;
      }

      //recurse into parent nodes to check grandparents, etc.
      return Parent.FindParentNode(nodeType);
    }

    /// <summary>
    /// Gets the value of a specific type of child node for a task
    /// </summary>
    /// <returns>The child value. return 0.0 if no node found</returns>
    /// <param name="name">type of child node we want.</param>
    /// <param name="task">Task to get a value for</param>
    /// <param name="bullet">The bullet.</param>
    public float GetChildValue(ENodeName name, BulletMLTask task, Bullet bullet)
    {
      foreach (var tree in ChildNodes)
      {
        if (tree.Name == name)
        {
          return tree.GetValue(task, bullet);
        }
      }
      return 0.0f;
    }

    /// <summary>
    /// Get a direct child node of a specific type.  Does not recurse!
    /// </summary>
    /// <returns>The child.</returns>
    /// <param name="name">type of node we want. null if not found</param>
    public BulletMLNode GetChild(ENodeName name)
    {
      foreach (var node in ChildNodes)
      {
        if (node.Name == name)
        {
          return node;
        }
      }
      return null;
    }

    /// <summary>
    /// Gets the value of this node for a specific instance of a task.
    /// </summary>
    /// <returns>The value.</returns>
    /// <param name="task">Task.</param>
    /// <param name="bullet">The bullet to get the value for</param>
    public float GetValue(BulletMLTask task, Bullet bullet)
    {
      //send to the equation for an answer
      return (float)NodeEquation.Solve(task.GetParamValue, bullet.MyBulletManager.Tier);
    }

    #region XML Methods

    /// <summary>
    /// Parse the specified bulletNodeElement.
    /// Read all the data from the xml node into this dude.
    /// </summary>
    /// <param name="bulletNodeElement">Bullet node element.</param>
    public void Parse(XmlNode bulletNodeElement, BulletMLNode parentNode)
    {
      // Handle null argument.
      if (null == bulletNodeElement)
      {
        throw new ArgumentNullException("bulletNodeElement");
      }

      //grab the parent node
      Parent = parentNode;

      //Parse all our attributes
      XmlNamedNodeMap mapAttributes = bulletNodeElement.Attributes;
      for (int i = 0; i < mapAttributes.Count; i++)
      {
        var strName = mapAttributes.Item(i).Name;
        var strValue = mapAttributes.Item(i).Value;

        switch (strName)
        {
          //skip the type attribute in top level nodes
          case "type" when ENodeName.bulletml == Name:
            continue;
          //get the bullet node type
          case "type":
            NodeType = StringToType(strValue);
            break;
          case "label":
            //label is just a text value
            Label = strValue;
            break;
        }
      }

      //parse all the child nodes
      if (!bulletNodeElement.HasChildNodes) return;

      for (var childNode = bulletNodeElement.FirstChild;
        null != childNode;
        childNode = childNode.NextSibling)
      {
        switch (childNode.NodeType)
        {
          //if the child node is a text node, parse it into this dude
          case XmlNodeType.Text:
            //Get the text of the child xml node, but store it in THIS bullet node
            NodeEquation.Parse(childNode.Value);
            continue;
          case XmlNodeType.Comment:
            //skip any comments in the bulletml script
            continue;
          default:
            //create a new node
            var childBulletNode = NodeFactory.CreateNode(StringToName(childNode.Name));

            //read in the node and store it
            childBulletNode.Parse(childNode, this);
            ChildNodes.Add(childBulletNode);
            break;
        }
      }
    }

    /// <summary>
    /// Validates the node.
    /// Overloaded in child classes to validate that each type of node follows the correct business logic.
    /// This checks stuff that isn't validated by the XML validation
    /// </summary>
    public virtual void ValidateNode()
    {
      //validate all the childe nodes
      foreach (var childNode in ChildNodes)
      {
        childNode.ValidateNode();
      }
    }

    #endregion //XML Methods

    #endregion //Methods
  }
}
