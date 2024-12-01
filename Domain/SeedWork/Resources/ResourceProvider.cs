using System.Globalization;
using System.Resources;

namespace Domain.SeedWork.Resources;

/// <summary>
/// Used to provide required global resources based on the culture.
/// </summary>
public class ResourceProvider
{
    public static ResourceManager ResourceManager => Resource_Fa.ResourceManager;
    
    public static string Persian(string key)
    {
        try
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("fa");
            ResourceSet? resourceSet =
                Resource_Fa.ResourceManager.GetResourceSet
                    (culture, true, true);

            return resourceSet?.GetString(key) ?? key;
        }
        catch (Exception)
        {
            return key;
        }
    }
    
    // Can define multi-language resources as same as Resource_Fa
    // public static string English(string key)
    // {
    //     try
    //     {
    //         CultureInfo culture = new CultureInfo("en");
    //         ResourceSet? resourceSet =
    //             Resource_en.ResourceManager.GetResourceSet
    //                 (culture, true, true);
    //
    //         return resourceSet?.GetString(key) ?? key;
    //     }
    //     catch (Exception)
    //     {
    //         return key;
    //     }
    // }
    // public static ResourceManager ResourceManager => CultureInfo.CurrentCulture.IsFa()
    //     ? Resource_fa.ResourceManager
    //     : Resource_en.ResourceManager;
}