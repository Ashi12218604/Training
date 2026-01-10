using System;

public class Computer
{
    public string Processor { get; set; }
    public int RamSize { get; set; }
    public int HardDiskSize { get; set; }
    public int GraphicCard { get; set; }
}

public class Desktop : Computer
{
    public int MonitorSize { get; set; }
    public int PowerSupplyVolt { get; set; }

    public double DesktopPriceCalculation()
    {
        double processorCost = 0;

        if (Processor == "i3")
            processorCost = 1500;
        else if (Processor == "i5")
            processorCost = 3000;
        else if (Processor == "i7")
            processorCost = 4500;

        double ramCost = RamSize * 200;
        double hardDiskCost = HardDiskSize * 1500;
        double graphicCost = GraphicCard * 2500;
        double monitorCost = MonitorSize * 250;
        double powerSupplyCost = PowerSupplyVolt * 20;

        double total = processorCost + ramCost + hardDiskCost + graphicCost + monitorCost + powerSupplyCost;

        return total;
    }
}

public class Laptop : Computer
{
    public int DisplaySize { get; set; }
    public int BatteryVolt { get; set; }

    public double LaptopPriceCalculation()
    {
        double processorCost = 0;

        if (Processor == "i3")
            processorCost = 2500;
        else if (Processor == "i5")
            processorCost = 5000;
        else if (Processor == "i7")
            processorCost = 6500;

        double ramCost = RamSize * 200;
        double hardDiskCost = HardDiskSize * 1500;
        double graphicCost = GraphicCard * 2500;
        double displayCost = DisplaySize * 250;
        double batteryCost = BatteryVolt * 20;

        double total = processorCost + ramCost + hardDiskCost + graphicCost + displayCost + batteryCost;

        return total;
    }
}

