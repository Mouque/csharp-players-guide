// triangle area formula: area = (base * height) / 2

Console.WriteLine("Vamos calcular o valor da área do triângulo.");
Console.WriteLine("Insira o valor da base: ");

float triangleBase = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Agora, insira o valor da altura: ");

float triangleHeight = Convert.ToInt32(Console.ReadLine());

float triangleArea = triangleBase * triangleHeight / 2;
Console.WriteLine("A área do triângulo é: " + triangleArea);
