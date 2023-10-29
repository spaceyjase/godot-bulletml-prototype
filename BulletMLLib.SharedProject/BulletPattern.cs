using System;
using System.Xml;
using System.Xml.Schema;
using BulletMLLib.SharedProject.Nodes;

namespace BulletMLLib.SharedProject;

/// <summary>
/// This is a complete document that describes a bullet pattern.
/// </summary>
public class BulletPattern
{
    #region Members

    /// <summary>
    /// The root node of a tree structure that describes the bullet pattern
    /// </summary>
    public BulletMLNode RootNode { get; private set; }

    /// <summary>
    /// Gets the filename.
    /// This property is only set by calling the parse method
    /// </summary>
    /// <value>The filename.</value>
    public string Filename { get; private set; }

    /// <summary>
    /// the orientation of this bullet pattern: horizontal or vertical
    /// this is read in from the xml
    /// </summary>
    /// <value>The orientation.</value>
    public EPatternType Orientation { get; private set; } = EPatternType.none;

    #endregion //Members

    #region Methods

    /// <summary>
    /// Initializes a new instance of the <see cref="BulletPattern"/> class.
    /// </summary>
    public BulletPattern()
    {
        RootNode = null;
    }

    /// <summary>
    /// convert a string to a pattern type enum
    /// </summary>
    /// <returns>The type to name.</returns>
    /// <param name="str">String.</param>
    private static EPatternType StringToPatternType(string str)
    {
        return (EPatternType)Enum.Parse(typeof(EPatternType), str);
    }

    /// <summary>
    /// Parses a bulletml document into this bullet pattern
    /// </summary>
    /// <param name="xmlFileName">Xml file name.</param>
    public void ParseXML(string xmlFileName)
    {
        //grab that filename
        Filename = xmlFileName;

        try
        {
#if NETFX_CORE
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Ignore;
#else
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.None,
                DtdProcessing = DtdProcessing.Parse
            };
            settings.ValidationEventHandler += MyValidationEventHandler;
#endif

            //using (var reader = XmlReader.Create(new StringReader(xmlFileName), settings))
            using (var reader = XmlReader.Create(xmlFileName, settings))
            {
                //Open the file.
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);
                ReadXmlDocument(xmlDoc);
            }
        }
        catch (Exception ex)
        {
            //an error occurred reading in the tree
            throw new("Error reading \"" + xmlFileName + "\"", ex);
        }

        //validate that the bullet nodes are all valid
        try
        {
            RootNode.ValidateNode();
        }
        catch (Exception ex)
        {
            //an error occurred reading in the tree
            throw new("Error reading \"" + xmlFileName + "\"", ex);
        }
    }

    private void ReadXmlDocument(XmlDocument xmlDoc)
    {
        XmlNode rootXmlNode = xmlDoc.DocumentElement;

        //make sure it is actually an xml node
        if (rootXmlNode == null || rootXmlNode.NodeType != XmlNodeType.Element)
            return;

        //eat up the name of that xml node
        var strElementName = rootXmlNode.Name;
        if ("bulletml" != strElementName)
        {
            //The first node HAS to be bulletml
            throw new(
                "Error reading \""
                + Filename
                + "\": XML root node needs to be \"bulletml\", found \""
                + strElementName
                + "\" instead"
            );
        }

        //Create the root node of the bulletml tree
        RootNode = new(ENodeName.bulletml);

        //Read in the whole bulletml tree
        RootNode.Parse(rootXmlNode, null);

        //Find what kind of pattern this is: horizontal or vertical
        XmlNamedNodeMap mapAttributes = rootXmlNode.Attributes;
        if (mapAttributes == null)
            return;

        for (var i = 0; i < mapAttributes.Count; i++)
        {
            //will only have the name attribute
            var strName = mapAttributes.Item(i).Name;
            var strValue = mapAttributes.Item(i).Value;
            if ("type" == strName)
            {
                //if this is a top level node, "type" will be vertical or horizontal
                Orientation = StringToPatternType(strValue);
            }
        }
    }

#if !NETFX_CORE
    /// <summary>
    /// delegate method that gets called when a validation error occurs
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="args">Arguments.</param>
    private static void MyValidationEventHandler(object sender, ValidationEventArgs args)
    {
        throw new XmlSchemaException(
            "Error validating bulletml document: " + args.Message,
            args.Exception,
            args.Exception.LineNumber,
            args.Exception.LinePosition
        );
    }
#endif

    #endregion //Methods
}
