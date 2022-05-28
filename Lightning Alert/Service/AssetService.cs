using Lightning_Alert.Dto;
using Newtonsoft.Json;

namespace Lightning_Alert.Service;

public class AssetService : IAssetService
{
    public IReadOnlyList<AssetDto>? GetAssetsFromJson()
    {
        try
        {
            // File Url 
            string fileUrl = @"Assets/assets.json";
            using (StreamReader file = new(fileUrl))
            {
                // Get texts in file
                string jsonFile = file.ReadToEnd();
                // Convert file to List of object (AssetDto)
                IReadOnlyList<AssetDto>? assetList = JsonConvert.DeserializeObject<IReadOnlyList<AssetDto>>(jsonFile);

                return assetList;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public List<AssetAlert> ConvertAssetsDtoToAssetAlert(IReadOnlyList<AssetDto>? assetList)
    {
        List<AssetAlert> assetAlerts = new();
        if (assetList != null)
        {
            assetAlerts = assetList.Select(asset => new AssetAlert { AssetName = asset.AssetName, AssetOwner = asset.AssetOwner, QuadKey = asset.QuadKey}).ToList();
        }

        return assetAlerts;
    }

    public AssetAlert? GetAssetByQuadKey(List<AssetAlert> assetList, string quadkey)
    {
        // Check if list is null
        if (assetList == null)
            return null;

        // Return data based on matched quadKey
        return assetList.FirstOrDefault(a => a.QuadKey == quadkey);
    }
}
