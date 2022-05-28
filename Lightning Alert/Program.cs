using Lightning_Alert.Presenter;
using Lightning_Alert.Service;

AssetService assetService = new();
LightningAlert main = new LightningAlert(assetService);
main.Run();
