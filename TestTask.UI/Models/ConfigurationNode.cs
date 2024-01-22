namespace TestTask.UI.Models;

public class ConfigurationNode
{
    public string NodeName { get; set; }
    
    public string Value { get; set; }
    
    public List<ConfigurationNode> Children { get; set; }
}