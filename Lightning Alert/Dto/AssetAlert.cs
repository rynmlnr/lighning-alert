using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightning_Alert.Dto;

public class AssetAlert : AssetDto
{
    public bool IsAlerted { get; set; } = false;
    public string AlertAsset()
    {
        return $"lightning alert for {AssetOwner}:{AssetName}";
    }
}
