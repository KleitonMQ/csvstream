using static System.Console;

CriarCsv();

static void CriarCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory, "saida");

    var pessoa = new List<Pessoa>(){
    new Pessoa()
        {
            Nome = "Josenildo",
            Email = "dawsobolado@gmail.com",
            Telefone = 123456,
            Nascimento = new DateOnly(year: 1970, month: 12, day: 26)
        },
    new Pessoa()
        {
            Nome = "Drigosvaldo",
            Email = "digaodelas@gmail.com",
            Telefone = 456789,
            Nascimento = new DateOnly(year: 0980, month: 07, day: 14)
        },
    new Pessoa()
        {
            Nome = "Jusé",
            Email = "j.ze@gmail.com",
            Telefone = 987654,
            Nascimento = new DateOnly(year: 1990, month: 12, day: 15)
        },
    new Pessoa()
        {
            Nome = "Jade Sales",
            Email = "killerbebum@gmail.com",
            Telefone = 654132,
            Nascimento = new DateOnly(year: 1995, month: 12, day: 16)
        },
    new Pessoa()
        {
            Nome = "Joands Sdnaoj",
            Email = "leandsfalsegod@gmail.com",
            Telefone = 321654,
            Nascimento = new DateOnly(year: 2000, month: 04, day: 25)
        }
    };

    var di = new DirectoryInfo(path);
    if (!di.Exists){
        di.Create();
        path = Path.Combine(path, "usuarios.csv");
    }
    using var sw = new StreamWriter(path);
    foreach (var pess in pessoa)
    {
        var linha = $"{pess.Nome},{pess.Email},{pess.Telefone},{pess.Nascimento}";
        sw.WriteLine(linha);
    }

    WriteLine("Arquivo criado");
    ReadLine();
    
}

static void LerCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory, "entrada", "usuarios-exportacao.csv");

    if (File.Exists(path))
    {
        using var sr = new StreamReader(path);

        var cabecalho = sr.ReadLine()?.Split(','); //O ponto de interrogação é para evitar erro caso o split estaja null

        while (true)
        {
            var registro = sr.ReadLine()?.Split(',');
            if (registro == null) break;

            if (cabecalho.Length != registro.Length)
            {
                WriteLine("Arquivo fora do padrão.");
                break;
            }
            for (int i = 0; i < registro.Length; i++)
            {
                WriteLine($"{cabecalho?[i]}:{registro[i]}");
            }
            WriteLine("--------------");
        }

        WriteLine("precione enter para finalizar");
        ReadLine();

    }
    else
    {
        WriteLine("Não encontrado o arquivo para leitura.");
    }

}


class Pessoa
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Telefone { get; set; }
    public DateOnly Nascimento { get; set; }
}