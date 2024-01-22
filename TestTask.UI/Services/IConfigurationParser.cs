using TestTask.UI.Models;

namespace TestTask.UI.Services;

public interface IConfigurationParser
{
    List<ConfigurationNode> Parse(string configuration);
}