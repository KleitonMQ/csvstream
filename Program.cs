using static System.Console;

var path = Path.Combine(Environment.CurrentDirectory, "entrada", "usuarios-exportacao.csv");
using var sr = new StreamReader(path);

var cabecalho = sr.ReadLine()?.Split(','); //O ponto de interrogação é para evitar erro caso o split estaja null

while(true)
{
    var registro = sr.ReadLine()?.Split(',');
    if(registro == null) break;
    for (int i = 0; i < registro.Length; i++)
    {
        WriteLine($"{cabecalho?[i]}:{registro[i]}");        
    }
    WriteLine("--------------");
}

WriteLine("precione enter para finalizar");
ReadLine();
