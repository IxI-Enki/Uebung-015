/*------------------------------------------------------------------------------
 *                      HTBLA-Leonding / Class: 3ACIF                           
 *------------------------------------------------------------------------------
 *                      Jan Ritt                                                
 *------------------------------------------------------------------------------
 *  Description:  The program reads in the fueltype, the driven km and outputs  
 *                the average fuel amount (calculated to average on 100km)      
 *                And tells you if your car uses too much, average or high      
 *                amounts of fuel.                                              
 *------------------------------------------------------------------------------
*/
using System;
using System.Text;

namespace FuelCalculator
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string fuelType, inputKm, inputGasolineAmount;
      double km = 0, gasolineAmount = 0;
      double averageConsumption;
      string formattedAverageConsumption;
      bool abort = false;

      // Eingabe      (E)  --  Header
      Console.Clear();
      Console.Write("\n Fuel Calculator:\n");
      Console.Write("==================\n");

      // Eingabe      (E)  --  Input Fuel + Check
      Console.Write(" Welchen Kraftstoff tanken Sie (Diesel/Benzin)?  ");
      fuelType = Console.ReadLine();
      if ((fuelType != "Diesel") && (fuelType != "Benzin"))
      {
        abort = true;
      }
      // Eingabe      (E)  --  Input km + Check
      if (abort == false)
      {
        Console.Write(" Wie viele Kilometer sind Sie gefahren?  ");
        inputKm = Console.ReadLine();
        if (double.TryParse(inputKm, out km))
        {
          if (km <= 0)
          {
            abort = true;
          }
        }
        else
        {
          abort = true;
        }
      }
      // Eingabe      (E)  --  Input Gasoline Amount + Check
      if (abort == false)
      {
        Console.Write(" Wie viele Liter Kraftstoff haben Sie getankt?  ");
        inputGasolineAmount = Console.ReadLine();
        if (double.TryParse(inputGasolineAmount, out gasolineAmount))
        {
          if (gasolineAmount <= 0)
          {
            abort = true;
          }
        }
        else
        {
          abort = true;
        }
      }

      // Verarbeitung (V)  --  Calculate
      if (abort == false)
      {
        Console.Write("--------------------------------------------\n");
        averageConsumption = Convert.ToDouble(gasolineAmount / km * 100);
        formattedAverageConsumption = averageConsumption.ToString("0.00");
        Console.Write($" Der errechnete Durchschnittsverbrauch ist {formattedAverageConsumption} pro 100km.\n");
        // Verarbeitung (V)  --  Calculate Diesel
        if ((fuelType == "Diesel") && (averageConsumption < 5))
        {
          Console.Write(" Ihr Auto ist sparsam!\n");
        }
        else if ((fuelType == "Diesel") && (averageConsumption >= 5) && (averageConsumption <= 6))
        {
          Console.Write(" Ihr Auto ist im Normalbereich!\n");
        }
        else if ((fuelType == "Diesel") && (averageConsumption > 6))
        {
          Console.Write(" Ihr Auto braucht zu viel!\n");
        }

        // Verarbeitung (V)  --  Calculate Benzin
        if ((fuelType == "Benzin") && (averageConsumption < 6))
        {
          Console.Write(" Ihr Auto ist sparsam!\n");
        }
        else if ((fuelType == "Benzin") && (averageConsumption >= 6) && (averageConsumption <= 7))
        {
          Console.Write(" Ihr Auto ist im Normalbereich!\n");
        }
        else if ((fuelType == "Benzin") && (averageConsumption > 7))
        {
          Console.Write(" Ihr Auto braucht zu viel!\n");
        }
      }

      // Ausgabe      (A)  --  Output The Fail-message
      if (abort == true)
      {
        Console.Write("--------------------------------------------\n");
        Console.Write(" ! Ungültige Eingabe !\n");
        Console.Write("--------------------------------------------\n");
      }

      // Ausgabe      (A)  --  End
      Console.Write("\n Weiter mit beliebiger Taste ...\n");
      Console.ReadKey();
      Console.Clear();
    }
  }
}

