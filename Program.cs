using System;

class Program
{
    static void Main()
    {
        Console.Write("กรุณากรอกจำนวนช่วงถนน (N): ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("กรุณากรอกระยะทางสูงสุด (K): ");
        int K = int.Parse(Console.ReadLine());

        Console.Write("กรุณากรอกจำนวนประชากรในแต่ละช่วงถนน (เลขคั่นด้วยช่องว่าง): ");
        string input = Console.ReadLine();
        string[] populations = input.Split(' ');

        int[] populationArray = new int[N];
        for (int i = 0; i < N; i++)
        {
            populationArray[i] = int.Parse(populations[i]);
        }

        int maxPopulation = FindMaxCustomers(populationArray, K);
        Console.WriteLine("จำนวนลูกค้าที่มากที่สุด: " + maxPopulation);
    }

    static int FindMaxCustomers(int[] populations, int K)
    {
        int maxPopulation = 0;
        int currentPopulation = 0;

        // คำนวณจำนวนลูกค้าที่มากที่สุดในช่วงถนนแต่ละช่วง
        for (int i = 0; i < populations.Length; i++)
        {
            currentPopulation += populations[i];

            // ลบจำนวนลูกค้าที่ออกนอกช่วงถนนที่ร้านครอบคลุมไม่ได้
            if (i >= K)
            {
                currentPopulation -= populations[i - K];
            }

            // อัปเดตจำนวนลูกค้าที่มากที่สุด
            if (currentPopulation > maxPopulation)
            {
                maxPopulation = currentPopulation;
            }
        }

        return maxPopulation;
    }
}

