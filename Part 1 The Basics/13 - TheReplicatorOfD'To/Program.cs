int[] userArray = new int[5];
int[] newArray = new int[] {1, 2, 3, 4, 5};

Console.WriteLine("Insira 5 números abaixo:");
Console.Write("Primeiro número: ");
int primeiroNumero = Convert.ToInt32(Console.ReadLine());
Console.Write("Segundo número: ");
int segundoNumero = Convert.ToInt32(Console.ReadLine());
Console.Write("Terceiro número: ");
int terceiroNumero = Convert.ToInt32(Console.ReadLine());
Console.Write("Quarto número: ");
int quartoNumero = Convert.ToInt32(Console.ReadLine());
Console.Write("Quinto número: ");
int quintoNumero = Convert.ToInt32(Console.ReadLine());

userArray[0] = primeiroNumero;
userArray[1] = segundoNumero;
userArray[2] = terceiroNumero;
userArray[3] = quartoNumero;
userArray[4] = quintoNumero;

for (int i = 0; i < userArray.Length; i++)
{
    Console.WriteLine($"Antigo número {newArray[i]} mudado para {userArray[i]}, escolhido pelo usuário");
    newArray[i] = userArray[i];
    
}

