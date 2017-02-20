using System;

namespace tempConverterHW3
{


    public static class Utilities
    {

        public static double FahrenheitToCelsius(double temp)
        {
            return UnitScale<TemperatureBaseKelvin>
                .Convert(temp, TemperatureBaseKelvin.Farenheit, TemperatureBaseKelvin.Celsius);
        }

        public static double CelsiusToFahrenheit(double temp)
        {
            return UnitScale<TemperatureBaseKelvin>
                .Convert(temp, TemperatureBaseKelvin.Celsius, TemperatureBaseKelvin.Farenheit);
        }

        public static double KelvinToCelsius(double temp)
        {
            return UnitScale<TemperatureBaseKelvin>
                .Convert(temp, TemperatureBaseKelvin.Kelvin, TemperatureBaseKelvin.Celsius);

        }

        public static double CelsiusToKelvin(double temp)
        {
            return UnitScale<TemperatureBaseKelvin>
                .Convert(temp, TemperatureBaseKelvin.Celsius, TemperatureBaseKelvin.Kelvin);
        }

        public static double FahrenheitToKelvin(double temp)
        {
            return UnitScale<TemperatureBaseKelvin>
                .Convert(temp, TemperatureBaseKelvin.Farenheit, TemperatureBaseKelvin.Kelvin);
        }

        public static double CmToInches(double cm)
        {
            return UnitScale<DistanceBaseMeters>
                .Convert(cm, DistanceBaseMeters.Cm, DistanceBaseMeters.Inches);
        }

        public static double DelisleToFarenheit(double temp)
        {

            var delisle = new UnitScale<TemperatureBaseKelvin>("Delisle",
                    degreesK => (373.15m - degreesK) * 3 / 2,
                    degreesDelisle => 373.15m - degreesDelisle * 2 / 3);

            return UnitScale<TemperatureBaseKelvin>
                .Convert(temp, delisle, TemperatureBaseKelvin.Farenheit);
        }

    }


    public class UnitScale<TUnitType> where TUnitType:IUnitType

    {
        public readonly Func<decimal, decimal> FromBase;
        public readonly Func<decimal, decimal> ToBase;
        public readonly string NameOfScale;

        public override string ToString()
        {
            return NameOfScale;
        }

        public UnitScale(string nameOfScale, Func<decimal, decimal> fromBase, Func<decimal, decimal> toBase)//mainly replaces old thing
        {
            NameOfScale = nameOfScale;
            FromBase = fromBase;
            ToBase = toBase;
        }

        public static UnitScale<TUnitType> FromNumberOfNewUnitsPerBaseUnit(string nameOfScale, decimal multipleOfBase)//mainly replaces old thing
        {
            return new UnitScale<TUnitType>(
            nameOfScale,
            baseUnits => baseUnits*multipleOfBase,
            newUnits=>newUnits/multipleOfBase);
        }

        public static UnitScale<TUnitType> FromNumberOfNewUnitsPerAnotherUnit(string nameOfScale, decimal multipleOfOther, UnitScale<TUnitType> otherUnit)//mainly replaces old thing
        {
            return new UnitScale<TUnitType>(
                nameOfScale,
                baseUnits => otherUnit.FromBase(baseUnits)*multipleOfOther,
                newUnits=>otherUnit.ToBase(newUnits/multipleOfOther));
        }
        public static UnitScale<TUnitType> FromNumberOfOtherUnitsPerNewUnit(string nameOfScale, decimal multipleOfOther, UnitScale<TUnitType> otherUnit)//mainly replaces old thing
        {
            return new UnitScale<TUnitType>(
                nameOfScale,
                baseUnits => otherUnit.FromBase(baseUnits)/multipleOfOther,
                newUnits=>otherUnit.ToBase(newUnits*multipleOfOther));
        }

        public static UnitScale<TUnitType> FromNumberOfBaseUnitsPerNewUnit(string nameOfScale, decimal multipleOfNew)//mainly replaces old thing
        {
            return new UnitScale<TUnitType>(
                nameOfScale,
                baseUnits => baseUnits/multipleOfNew,
                newUnits=>newUnits*multipleOfNew);
        }

        public static double Convert(double degrees, UnitScale<TUnitType> from, UnitScale<TUnitType> to)
        {
            return (double) to.FromBase(from.ToBase((decimal) degrees));
        }

/*       public double FromBaseDbl(decimal degreesBase)
        {
//        var validator = (Func<decimal, bool>) typeof(TUnitType).GetMethod("ValidateAsBaseUnit")
//            .Invoke(null, new object[] { });
//        if (!validator(degreesBase))
//        {
//            throw new ArgumentException(
//                "Can't have a temperature less than absolute zero, which is 0K or in your scale " + this._fromBase(0));
//        }
            return (double) FromBase(degreesBase);
        }

        public decimal ToBaseDbl(double degreesOldScale)
        {
            var degreesBase = ToBase((decimal) degreesOldScale);

//        var validator = (Func<decimal, bool>) typeof(TUnitType).GetMethod("ValidateAsBaseUnit")
//            .Invoke(null, new object[] { });
//        if (!validator(degreesBase))
//        {
//            throw new ArgumentException(
//                "Can't have a temperature less than absolute zero, which is 0K or in your scale " + this._fromBase(0));
//        }

            return degreesBase;
        }*/

    }

    public class SelfMultipliedUnitType<T1> : IUnitType//, MultipliedUnitType<T1, T1>
        where T1 : IUnitType


    {
        public static UnitScale<MultipliedUnitType<T1, T1>> GetSquaredScale(UnitScale<T1> s1) =>
            new UnitScale<MultipliedUnitType<T1, T1>>(
                "Squared scale of: " + s1.NameOfScale,
                unitsBase => s1.FromBase(s1.FromBase(unitsBase)),
                unitsThis => s1.ToBase(s1.ToBase(unitsThis)));


//        public static UnitScale<MultipliedUnitType<T1, MultipliedUnitType<T1, T1>>> GetCubedScale(UnitScale<T1> s1) =>
//            new UnitScale<MultipliedUnitType<T1,MultipliedUnitType<T1, T1>>>(
//                "Cubed scale of: " + s1.NameOfScale,
//                unitsThis => s1.ToBase((double) s1.ToBase((double) unitsThis)),
//                unitsBase => (decimal) s1.FromBase((decimal) s1.FromBase(unitsBase)));
    }

    public class MultipliedUnitType<T1, T2> : IUnitType
        where T1 : IUnitType//UnitScale<IUnitType>
        where T2 : IUnitType//UnitScale<IUnitType>
    {
        public static UnitScale<MultipliedUnitType<T1, T2>> GetMultipliedScale(UnitScale<T1> s1, UnitScale<T2> s2) =>
            new UnitScale<MultipliedUnitType<T1, T2>>(
                s1.NameOfScale + " * " + s2.NameOfScale,
                unitsBase => s2.FromBase(s1.FromBase(unitsBase)),
        unitsThis => s2.ToBase(s1.ToBase(unitsThis))

            );

    }
    public class PerUnitType<T1, T2> : IUnitType
        where T1 : IUnitType//UnitScale<IUnitType>
        where T2 : IUnitType//UnitScale<IUnitType>
    {
        public static UnitScale<PerUnitType<T1, T2>> GetPerScale(UnitScale<T1> s1, UnitScale<T2> s2) =>
            new UnitScale<PerUnitType<T1, T2>>(
                s1.NameOfScale + " Per " + s2.NameOfScale,
                unitsBase => s1.FromBase(unitsBase) / s2.FromBase(1),
                unitsThis => s1.ToBase(unitsThis) / s2.ToBase(1));

        //public static UnitScale<PerUnitType<DistanceBaseMeters, TimeBaseSeconds>> Mph => PerUnitType<DistanceBaseMeters, TimeBaseSeconds>.GetPerScale(DistanceBaseMeters.Mile, TimeBaseSeconds.Hour);


    }










//Just a nice immutable temperature class using tempscales. Not neccesary for anything above anymore.
    //should be refactored

 /*   public class Temp
    {
        private readonly decimal _degreesK;

        public Temp (double degrees, TempScale scale)
        {
            _degreesK = scale.ToK(degrees);
        }

        public double InScale(TempScale scale)
        {
            return scale.FromK(_degreesK);
        }

    }*/






}


