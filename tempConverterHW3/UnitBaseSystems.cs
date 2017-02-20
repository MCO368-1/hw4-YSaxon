namespace tempConverterHW3
{
    public class IUnitType//just definesunit types
    {

        //Func<decimal, bool> ValidateAsBaseUnit();
        //UnitScale<IUnitType> GetBaseUnit(); // where TUnitType : IUnitType;
    }
    public class TemperatureBaseKelvin : IUnitType//mainly just an imp for the above interface, secondarily contains temp fields
    {

        //public Func<decimal, bool> ValidateAsBaseUnit() => degreesK=>degreesK>0;


        //public static UnitScale<TemperatureBaseKelvin> GetBaseUnit() => Kelvin;

        public static readonly UnitScale<TemperatureBaseKelvin> Kelvin = new UnitScale<TemperatureBaseKelvin>(
            "Kelvin",
            same=>same,same=>same);

        public static readonly UnitScale<TemperatureBaseKelvin> Farenheit = new UnitScale<TemperatureBaseKelvin>(
            "Farenheit",
            degreesK => degreesK / 5 * 9 - 459.67m,
            degreesThisScale => (degreesThisScale + 459.67m) * 5 / 9);

        public static readonly UnitScale<TemperatureBaseKelvin> Celsius = new UnitScale<TemperatureBaseKelvin>(
            "Celsius",
            degreesK =>  degreesK - 273.15m,
            degreesThisScale => degreesThisScale + 273.15m);

    }
    public class DistanceBaseMeters : IUnitType//mainly just an imp for the above interface, secondarily contains temp fields
    {

        //public Func<decimal, bool> ValidateAsBaseUnit() => meters=>true

        //public UnitScale<DistanceBaseMeters> GetBaseUnit() => Meter;

        public static readonly UnitScale<DistanceBaseMeters> Meter = new UnitScale<DistanceBaseMeters>(
            "Meter",
            same=>same,same=>same);

        public static readonly UnitScale<DistanceBaseMeters> Cm = UnitScale<DistanceBaseMeters>.FromNumberOfNewUnitsPerBaseUnit(
            "CM",
            100);

//        public static readonly UnitScale<DistanceBaseMeters> Mile = UnitScale<DistanceBaseMeters>.FromNumberOfBaseUnitsPerNewUnit(
//            "Miles",
//            1609.344000006m);

        public static readonly UnitScale<DistanceBaseMeters> Km = UnitScale<DistanceBaseMeters>.FromNumberOfBaseUnitsPerNewUnit(
            "KM",
            1000);

        public static readonly UnitScale<DistanceBaseMeters> Inches = UnitScale<DistanceBaseMeters>.FromNumberOfNewUnitsPerBaseUnit(
            "Inches",
            39.37007874m);

        public static readonly UnitScale<DistanceBaseMeters> Foot = UnitScale<DistanceBaseMeters>.FromNumberOfOtherUnitsPerNewUnit(
            "Feet",
            12,
        Inches);
        public static readonly UnitScale<DistanceBaseMeters> Mile = UnitScale<DistanceBaseMeters>.FromNumberOfOtherUnitsPerNewUnit(
            "Miles",
            5280,
            Foot);

    }

    public class TimeBaseSeconds : IUnitType//mainly just an imp for the above interface, secondarily contains temp fields
    {

        //public Func<decimal, bool> ValidateAsBaseUnit() => meters=>true

        //public UnitScale<DistanceBaseMeters> GetBaseUnit() => Meter;

        public static readonly UnitScale<TimeBaseSeconds> Second = new UnitScale<TimeBaseSeconds>(
            "Seconds",
            same=>same,same=>same);

        public static readonly UnitScale<TimeBaseSeconds> Minutes = UnitScale<TimeBaseSeconds>.FromNumberOfBaseUnitsPerNewUnit(
            "Minutes",
            (60));

        public static readonly UnitScale<TimeBaseSeconds> Hour = UnitScale<TimeBaseSeconds>.FromNumberOfBaseUnitsPerNewUnit(
            "Hours",
            (3600));

    }

    public class MassBaseGram : IUnitType
    {
        public static readonly UnitScale<MassBaseGram> Gram = new UnitScale<MassBaseGram>(
            "Gram",
            same=>same,same=>same);

        public static readonly UnitScale<MassBaseGram> Kilogram = UnitScale<MassBaseGram>.FromNumberOfBaseUnitsPerNewUnit(
            "Kilograms",
            1000);
    }

    public class ForceTypeNewton : PerUnitType<MultipliedUnitType<MassBaseGram, DistanceBaseMeters>,
        MultipliedUnitType<TimeBaseSeconds, TimeBaseSeconds>>
    {
        public static readonly UnitScale<PerUnitType<MultipliedUnitType<MassBaseGram, DistanceBaseMeters>, MultipliedUnitType<TimeBaseSeconds, TimeBaseSeconds>>>
            Newton =
            ForceTypeNewton.GetPerScale(
                MultipliedUnitType<MassBaseGram, DistanceBaseMeters>.GetMultipliedScale(MassBaseGram.Kilogram, DistanceBaseMeters.Meter),
                SelfMultipliedUnitType<TimeBaseSeconds>.GetSquaredScale(TimeBaseSeconds.Second));
    }
}