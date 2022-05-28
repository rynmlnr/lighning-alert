using Lightning_Alert.Dto;
using Lightning_Alert.Helpers;
using Lightning_Alert.Service;
using Newtonsoft.Json;

namespace Lightning_Alert.Presenter;

public class LightningAlert
{
    private readonly IAssetService _assetService;

    public LightningAlert(IAssetService assetService)
    {
        _assetService = assetService;
    }

    /// <summary>
    ///     Alert/Notify Asset Owners for each lightning stiked received
    /// </summary>
    public void Run()
    {
        // Get Assets from JSON File
        var assetList = _assetService.GetAssetsFromJson();
        // Convert Assets Dto to Asset Alert
        var assetsAlert = _assetService.ConvertAssetsDtoToAssetAlert(assetList);

        try
        {
            // Get Lightnings in Json
            string fileUrl = @"Assets/lightning.json";

            using (StreamReader file = new(fileUrl))
            {
                string? line;
                while ((line = file.ReadLine()) != null)
                {
                    // Convert json to Lightning Dto
                    LightningDto? lightning = JsonConvert.DeserializeObject<LightningDto>(line);


                    // Check if lightning has value
                    if (lightning != null)
                    {
                        // Process all lightning if flash type is from "cloud to ground" and "cloud to cloud"
                        if ((lightning.FlashType == 0 || lightning.FlashType == 1))
                        {
                            // Convert Latitude and Longitude to Quad Key
                            string quadKey = GetQuadKey(lightning.Latitude, lightning.Longitude);

                            // Get asset that match the fetch quadkey
                            var assetMatched = _assetService.GetAssetByQuadKey(assetsAlert, quadKey);
                            // Check asset value and asset received an alert
                            if (assetMatched != null && !assetMatched.IsAlerted)
                            {
                                // Update IsAlerted to true;
                                assetMatched.IsAlerted = true;
                                // Alert asset
                                Console.WriteLine(assetMatched.AlertAsset());
                            }
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(ex.Message);
        }


    }

    /// <summary>
    ///     Convert latitude and longitude to quadkey using helper from 
    ///     https://docs.microsoft.com/en-us/bingmaps/articles/bing-maps-tile-system?redirectedfrom=MSDN
    /// </summary>
    /// <param name="latitude"></param>
    /// <param name="longitude"></param>
    /// <param name="zoom"></param>
    /// <returns></returns>
    private string GetQuadKey(double latitude, double longitude, int zoom = 12)
    {
        MapHelper.LatLongToPixelXY(latitude, longitude, 12, out int pixelX, out int pixelY);
        MapHelper.PixelXYToTileXY(pixelX, pixelY, out int tileX, out int tileY);
        return MapHelper.TileXYToQuadKey(tileX, tileY, 12);
    }
}
