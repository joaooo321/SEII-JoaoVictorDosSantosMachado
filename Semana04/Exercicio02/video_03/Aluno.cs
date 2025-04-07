using System;


class Aluno
{
    //Atributos
    public string nome;

    public double nota1, nota2;

    //Media
    public double media()
    {
        return(nota1+nota2)/2;
    }

    //Situação
    public string Situação(double media)
    {
        return media >= 7 ? "aprovado" : "reprovado";
    }

    //Mensagem
    public void Mensagem()
    {
        //Obter a media 
        double obtermedia = media();

        //obeter a situação

        string obeterSituação = Situação(obtermedia);

        //Mensagem
        Console.WriteLine(nome+ " está "+obeterSituação+ " com media "+obtermedia);
    }

}