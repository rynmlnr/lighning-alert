using Lightning_Alert.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightning_Alert.Service;

public interface IAssetService
{
    List<AssetAlert> ConvertAssetsDtoToAssetAlert(IReadOnlyList<AssetDto>? assetList);
    IReadOnlyList<AssetDto>? GetAssetsFromJson();
    AssetAlert? GetAssetByQuadKey(List<AssetAlert> assetList, string quadkey);
}
