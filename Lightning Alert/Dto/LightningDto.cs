using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lightning_Alert.Dto;

public class LightningDto
{
    public int FlashType { get; set; }
    public string? StrikeTime { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int PeakAmps { get; set; }
    public string? Reserved { get; set; }
    public int IcHeight { get; set; }
    public string? ReceivedTime { get; set; }
    public int NumberOfSensors { get; set; }
    public int Multiplicity { get; set; }
}
