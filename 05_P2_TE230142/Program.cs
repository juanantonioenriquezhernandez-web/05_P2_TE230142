Console.WriteLine("SISTEMA DE CONTROL DE POSICIÓN DE SERVOMOTOR");
Console.WriteLine();

Servomotor servo1 = new Servomotor(); // se crea el objeto servo1

while (true) // bucle de validación de rango
{
    Console.Write("Ingrese la posición actual (0 - 180 °): "); // pide posición actual
    servo1.PosicionActual = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese la posición objetivo (0 - 180 °): "); // pide posición objetivo
    servo1.PosicionObjetivo = Convert.ToDouble(Console.ReadLine());

    if (servo1.PosicionActual >= 0 && servo1.PosicionActual <= 180 &&
        servo1.PosicionObjetivo >= 0 && servo1.PosicionObjetivo <= 180)
    {
        break; // sale del bucle si ambos están en rango
    }
    Console.WriteLine("Error: Los valores deben estar entre 0 y 180 °. Intente nuevamente.\n");
}

Console.WriteLine();
Console.WriteLine($"Desplazamiento absoluto: {servo1.CalcularDesplazamiento():F2} °"); // muestra desplazamiento
Console.WriteLine($"Movimiento: {servo1.ObtenerDireccionMovimiento()}"); // muestra la dirección

class Servomotor // se define la clase
{
    public double PosicionActual { get; set; } // almacena posición actual
    public double PosicionObjetivo { get; set; } // almacena posición objetivo

    public double CalcularDesplazamiento() // calcula la distancia absoluta
    {
        double diferencia = PosicionObjetivo - PosicionActual;
        if (diferencia < 0) return diferencia * -1;
        return diferencia;
    }

    public string ObtenerDireccionMovimiento() // determina la dirección del movimiento
    {
        if (PosicionObjetivo > PosicionActual)
            return "Movimiento hacia una posición mayor";
        else if (PosicionObjetivo < PosicionActual)
            return "Movimiento hacia una posición menor";
        else
            return "No hay movimiento";
    }
}